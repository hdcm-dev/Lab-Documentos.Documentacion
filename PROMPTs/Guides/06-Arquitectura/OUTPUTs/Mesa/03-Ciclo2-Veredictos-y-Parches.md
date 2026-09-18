# Mesa evaluadora — Ciclo 2 — Veredictos y parches

**Fecha:** 2026-09-18
**Objeto:** `LAB/Lab-Documentos/Guides/Arquitectura/Dot-NET-Arquitectura-Guide.md` v2.0.0 (1308 líneas) y `Dot-NET-Arquitectura-Lab/` (lab.sh, capturas/, aserciones.log, MyProject/).
**Marco:** `IA.Prompts/Base/Mesa-Evaluadora.md` §3 (evidencia y severidad), §4.2 (relator), §4.3 (jurado), §4.4 (cuerpo auditor), §5.3–§5.6, §6 (escaladas), §7 (parada).
**Vara:** R-01..R-17 (Bitácora 02), DR-01..DR-30 e índice aprobado (Veredictos §5 y §7), DC-1..DC-4 (Bitácora 01), DA-1..DA-4 (Veredictos §4).
**Insumos:** ocho informes en `Mesa/Ciclo-2/` (01-Didáctica, 02-Edición, 03-Arquitecto-NET, 04-Requisitos, 05-Verificación-QA, 06-Lector-Novato, 07-Abogado-Diablo, 08-Seguridad): 52 hallazgos, 24 ítems «revisado y correcto», 13 solicitudes de convocatoria.
**Roles de este documento:** relator (§1), jurado de cinco jueces (§2), cuerpo auditor (§3–§4), cierre (§5–§7). La separación de funciones se conserva en la forma: el relator consolida sin juzgar; el jurado vota por hallazgo consolidado; el auditor redacta parches solo para los `PROCEDE` y no los aprueba: los aplica y verifica el editor.

---

## 1. Relatoría

### 1.1 Verificaciones propias del juez de evidencia (2026-09-18)

Antes de votar, el jurado reprodujo las anclas que deciden los ítems de mayor peso. Todo lo que sigue se contrastó sobre el material publicado, sin modificarlo.

| Id | Qué | Resultado |
|---|---|---|
| V1 | `capturas/L11-tests.txt` l.26, 28; `L12-regresion.txt` l.23, 32, 34, 42 | `Duration: 111 ms`, `94 ms`; `[9 ms]`, `Duration: 301 ms`, `[46 ms]`, `Duration: 206 ms`. La guía muestra 71/44, 11/19 y omite las duraciones de `Failed!`. Confirma C-01 |
| V2 | `MyProject/src/Backend/MyProject.WebAPI/ExceptionHandlers/DomainExceptionHandler.cs` l.24–29 | `Status = StatusCodes.Status400BadRequest` en inicializador de varias líneas; la guía muestra `Status = 400` en una. Confirma C-02 |
| V3 | `grep -rn Application MyProject/src/Backend/MyProject.Infrastructure --include=*.cs`; `grep -rn "IEmailService\|ICurrentUserService" MyProject/src` | 0 y 0 líneas. Confirma C-03 |
| V4 | `MyProject/global.json` | `"rollForward": "latestFeature"`, `"version": "10.0.400"`. Confirma C-23 |
| V5 | `capturas/L16-compilar-con-efcore.txt` l.7 y l.13–15, 35–36 | El comando de la cabecera es `dotnet build -v n 2>&1 \| grep -E … ; echo "sha256 …"`; la línea `Skipping target "CoreCompile"` de `Domain` está seguida por `6>Done Building Project ".../MyProject.Domain.csproj" (default targets).`. Confirma C-12 |
| V6 | `capturas/L24-evaluar-dependencia.txt` l.26–33; `lab.sh` l.825–827 | Las cuatro líneas `<license …>` son `MIT`, `LICENSE.md`, `Apache-2.0`, `LICENSE.md`; el patrón `automapper/15\.0\.0` de la aserción coincide con el encabezado `== automapper/15.0.0` que el bucle imprime siempre. Confirma C-16 y la aserción vacía de QA-02 |
| V7 | `https://api.github.com/advisories/GHSA-rvv3-g6hj-g44x` | CVE-2026-32933, High (CVSS 7.5), DoS por recursión sin límite; rangos `< 15.1.1` → 15.1.1 y `>= 16.0.0, < 16.1.1` → 16.1.1. Confirma Diablo H-06 y H-SEG-03 |
| V8 | PDF de `https://luckypennysoftware.com/license` («License document version 2.0», 18 páginas; texto extraído con `pdftotext`) | §4.2.g.1 «not available to any government agency or any quasi-government agency»; §4.2.g.3.1 ingresos brutos < USD 5 M; §4.2.g.3.2 nunca más de USD 10 M de capital externo; §4.2.g.3.3 universidades no elegibles para software institucional u operativo, con excepción para estudiantes y docentes con fines educativos. Confirma Diablo H-06 |
| V9 | `https://api.github.com/advisories/GHSA-3hxg-fxwm-8gf7` | Refit, CVE-2024-51501, Critical (CVSS 9.8), inyección CRLF en `[Header]`, `[HeaderCollection]`, `[Authorize]`; `< 7.2.22` → 7.2.22. Habilita la fila de Refit que pedía DR-29 |
| V10 | `https://learn.microsoft.com/en-us/dotnet/standard/data/sqlite/types` | Fila «Decimal \| TEXT \| `0.0###########################` format. REAL would be lossy»; «SQLite allows you to specify type facets like length, precision, and scale, but they are not enforced by the database engine». Confirma Arq H-01 y la verificación E1 de QA; asciende la explicación del `4500.0` a E1 con fuente |
| V11 | `lab.sh` l.58 (`start_api`), l.92–116 (L03), l.120–133 (L05), l.245–261 (L10), l.349–350 y 432 (L11), l.576–578 y 668–696 (L16), l.788–812 (L22); `Program.cs` final; `IProductoRepository.cs`; `ProductosController.cs` l.22–28 | Confirman C-15 (comandos y archivos que la guía no muestra), C-24 (tercer handler y `NotFound()`), la forma del rótulo de L03/L10 (C-14) y el `EnsureDatabaseCreated()` de L16 (C-12) |
| V12 | Simulación de los parches sobre una copia de la guía | 1425 líneas; 72 enlaces internos, 0 rotos; 0 referencias huérfanas; 0 `csharp` sin rótulo previo; R-03 y DR-18 en 0; chequeo V-LIT (§4.2) en 0 líneas sin respaldo para los 15 bloques de salida; extensión por `##`: §0 74, §1 121, §2 144, §3 113, §4 113, **§5 196**, §6 122, §7 143, §8 93, §9 75 |

### 1.2 Hallazgos consolidados por raíz común

52 hallazgos de ocho informes se agrupan en 26 raíces. La columna «Fuentes» nombra el hallazgo de cada informe; «Ev.» es el nivel más alto verificado por el jurado; «Sev.» es la severidad que fija el jurado (entre paréntesis, la declarada por los especialistas cuando difiere).

| Id | Raíz común | Fuentes | Ev. | Sev. |
|---|---|---|---|---|
| C-01 | Los extractos de L11/L12 no son literales de sus capturas (duraciones de otra corrida; recorte sin `...`) | Req H-01, QA-01, Nov H-NOV-07 | E2 (V1) | S2 |
| C-02 | Bloque **[Compilado]** de `DomainExceptionHandler` reescrito; comentario agregado en el bloque de L11 | Arq H-04, QA-04 | E2 (V2) | S3 |
| C-03 | La referencia `Infrastructure → Application` se justifica con interfaces que el laboratorio no contiene y ningún archivo usa | Arq H-02, Diablo H-02, solicitud QA | E1 (V3) | S3 (Diablo: S2) |
| C-04 | Explicación del `4500.0` imprecisa y sin fuente; `HasPrecision(18, 2)` mostrado sin decir que no rige en SQLite; dos causas para `12000.0` | Arq H-01, QA revisado 2, Diablo H-05, solicitud Ed (L16 vs L17) | E1 (V10 + ejecución de Arq y QA) | S3 |
| C-05 | El rótulo E-A nombra dos estructuras (un proyecto sin handlers en §9.1/§4.6/§2.7; Blazor Server que inyecta handlers en §6.4/§5.7/§6.6/§8.3) | Diablo H-01 | E2 + E3 | S2 |
| C-06 | §9.1 no tiene fila para una API cuyos clientes no son .NET; E-B induce a crear `Contracts` sin consumidor | Diablo H-03 | E3 + E2 | S3 (Diablo: S2) |
| C-07 | La señal «probar la regla sin base» manda al escalón 2 en §9.2/§9.5 y al 3 en §9.3/Anexo B; §9.3 l.1115 no da criterio entre 2 y 3 | DID2-01, Diablo H-04 | E2 | S2 |
| C-08 | HC-25: el lector del recorrido no sabe qué escalón construye ni por qué; la escalera aparece en l.1091 | DID2-02 (asciende HC-25 de C a E2) | E2 | S3 |
| C-09 | §7.2 c y e sin remisión Lnn; l.855 falsa para e y f; `@bind-Value` sin definir | DID2-03, Req H-05 | E2 | S3 |
| C-10 | `curl` y sus opciones no se definen | DID2-04, Nov H-NOV-06 | E2 | S3 |
| C-11 | DR-16: EF Core, ASP.NET Core, controller, caso de uso… usados en §2 antes de definirse; CRUD, doble de prueba, `Guid`, `CancellationToken`, `[FromServices]`, `IActionResult` sin definir | DID2-05, Nov H-NOV-05 | E2 | S3 |
| C-12 | L16: el comando mostrado no produce la salida mostrada; huella sin «qué puede cambiar»; `Skipping target` sin proyecto; «`Program.cs` cambia una línea» omite `EnsureDatabaseCreated()`; `10.0.12` sin marca | DID2-06, QA-06, Arq H-03, Req H-07, solicitud Req | E1 (V5, V11) | S3 |
| C-13 | Anexo D: 17 términos definidos sin fila, sin columna de equivalente (índice aprobado, fila D), dos § erróneas; índice sin glosa de anexos; frontmatter con `prerequisites` partido | ED2-02, ED2-04 | E2 + E1 | S2 (rows) / S3 |
| C-14 | Rótulos: L03 y L10 rotulados «no compilado» aunque compilan; rótulo después del código (DR-09); marcas sin SDK; formas no declaradas en l.597 y l.1038 | ED2-03, solicitud Req | E2 + E4 | S3 |
| C-15 | Reproducibilidad del recorrido: 16 tipos nombrados sin código ni ubicación; pasos sin comando (L05, L06, L11, L16, L22); arranque de la API sin carpeta ni `&`; carpeta de trabajo nunca creada; Anexo A sin comando ni captura | Nov H-NOV-01/02/03/04, Req H-02 | E2 + E1 (V11) | S2 |
| C-16 | §9.4/Anexo C: «versión anterior de esta guía» (R-03 = 1); L24 no muestra «RPL» sino `LICENSE.md`; los dos comandos de L24 no se muestran; «corregida en versiones de esa rama» impreciso (15.0.0–15.1.0 siguen vulnerables); «con otras condiciones» oculta las exclusiones de gobierno y universidades; falta la fila de Refit (DR-29) | ED2-01, Req H-03, Req H-06, Diablo H-06, H-SEG-03, solicitudes Arq y Diablo | E1 + E2 (V6–V9) | S2 |
| C-17 | DR-15/R-09: §0.3 promete ✅/❌ en toda decisión y 12 no lo tienen; §3.5 sin E-x; §8 sin cierre; §7 y §9 fallan el grep de R-09 | DID2-07, Req H-04, solicitudes Req y Ed | E2 + E4 | S3 |
| C-18 | Voz y terminología: única regla con voseo (l.212); variante «Qué puede cambiar:»; «interfaz» usada para la interfaz de usuario (DR-12) | ED2-05, ED2-06 | E2 + E4 | S3 |
| C-19 | Referencias: letras 2026a–h sin criterio; «Círculo (Martin, 2012)» sin enlace | ED2-07 | E1 + E4 | S4 |
| C-20 | Política de recorte de extractos no declarada; «falla en silencio» (Anexo A) y «deja solo `Add`» (§5.5) contradicen en detalle a sus capturas; L03 partido en dos líneas; leyenda del diagrama 4; decorador sin interfaz; MSB4006 en fase de restauración | QA-07, solicitudes Did/QA/Arq/Req/Ed, observación S4 de Arq | E2 | S4 |
| C-21 | Seguridad: «esa página» de §5.6 sin nombrar ni explicar; el `DelegatingHandler` ilustrativo envía el token a cualquier destino y su nombre colisiona con la clase del framework | H-SEG-01, H-SEG-02 | E2 + E3 | S3 |
| C-22 | «Blazor WebAssembly no tiene el ensamblado del dominio» presenta como imposibilidad una decisión; §6.4 da otra razón | Arq H-05 | E3 | S3 |
| C-23 | «Cualquier SDK 10.0.* reproduce el laboratorio» choca con `global.json` (`latestFeature`, 10.0.400) | Arq H-06 | E4 (V4) | S3 |
| C-24 | `ObtenerProductoPorIdHandler` no se presenta; §5.2 dice «los tres handlers» | Arq H-07 | E2 (V11) | S3 |
| C-25 | Dos «Criterio de esta guía» con apoyo ausente: 422 sin cita (DR-28); «en ese orden» sin fundamento | Diablo H-07 | E4 + E2 | S3 |
| C-26 | Aserciones de `lab.sh` que no prueban lo que la guía afirma: L24 pasa por construcción; L12 pasa con cualquier fallo; 404 de §5.1 sin captura | QA-02, QA-03, QA-05 | E2 (V6) | S2 / S3 / S3 |

Fuera de las raíces: la solicitud de Seguridad sobre HTTPS y la cadena de conexión (§2.6, `Program.cs`) y la observación de Arq sobre la numeración de diagramas se resuelven en §2.3 sin parche.

### 1.3 Contradicciones entre especialistas

| Id | Contradicción | Resolución del jurado |
|---|---|---|
| CT-A | **Causa del `4500.0`.** Diablo H-05 la califica de «interpretación sin verificar» y pide rotularla como probable; Arq H-01 y QA (revisado 2) la verificaron por ejecución con `Microsoft.EntityFrameworkCore.Sqlite 10.0.12` (columna `TEXT`, valor `'4500.0'`) | Gana la evidencia E1, confirmada además por la fuente de Microsoft (V10). No se rotula como interpretación: se reescribe con la causa exacta y la cita. La observación de Diablo sobre las dos causas de `12000.0` (escala y cultura) se atiende separando «dígito decimal» (SQLite) de «separador» (cultura) en §6.3 |
| CT-B | **HC-25.** Diablo lo archiva («no ascendió de C en dos ciclos»); Didáctica (DID2-02) lo asciende a E2 con las ubicaciones que el ciclo 1 pidió | Ascendió: la regla del marco archiva lo que *no* asciende. Se corrige (C-08). Ninguna corrección reabre CT-01 del ciclo 1: el laboratorio sigue bajando desde la solución completa; solo se anuncia por qué |
| CT-C | **Escalón 2 y pruebas.** Didáctica pidió al Arquitecto confirmar que en el escalón 2 la regla se prueba sin base | El jurado lo resuelve como perito con el laboratorio: `Producto.Create` es un método estático que lanza `DomainException`; las pruebas de L11 que lo ejercitan (`ProductoTests`) no tocan base ni EF Core aunque el proyecto que las contiene los referencie. El escalón 3 se justifica cuando hace falta que el compilador impida la dependencia (§2.2), no para poder probar. Se aplica C-07 |
| CT-D | **Rótulo doble de E-A.** Diablo propone cuatro reemplazos que reasignan el caso a E-D; su propia solicitud a Didáctica ofrece la alternativa de una nota en §0.4 | Se elige la nota (P-06) más tres ajustes de precisión (P-46, P-53, P-58, P-69): DR-17 y DR-23 siguen nombrando E-A para el «único cliente en el mismo proceso», así que reasignarlo a E-D contradiría una directiva vigente; la nota resuelve la ambigüedad sin tocarla |
| CT-E | **Alcance de R-09.** Requisitos y Edición piden decidir si el «¿cuándo no…?» alcanza a §7–§9 | Alcanza a §8 (que no tenía ninguna pregunta de aplicabilidad) y se registra en la Bitácora 02 que §7.5 y §9.3 cumplen el criterio con otra forma (P-B1). No se renombra §7.5: su título está en el índice aprobado |
| CT-F | **Recorte de L03.** QA-07.3 pide reescribir en una línea; Edición y Didáctica piden declarar la política | Se declara la política en §0.5 (P-07), que admite partir una línea larga con sangría; L03 queda como está y el chequeo V-LIT lo contempla |
| CT-G | **404 (QA-05): opción mínima o relanzar.** Riesgo prefiere la mínima; los demás, la completa | Se relanza el laboratorio de todos modos por C-26, así que la opción completa no agrega riesgo propio (véase §2.2, C-26) |

### 1.4 Solicitudes de convocatoria consolidadas

| Solicitud | Especialidad | Resolución |
|---|---|---|
| Did → Arq: escalón 2 y pruebas | Arquitectura | Resuelta como perito por el jurado (CT-C) |
| Did → QA: recorte de L14 sin `...` | Verificación | Cubierta por la política de recorte (C-20, P-07) |
| Ed → Arq: §7.2 g atribuye a L16 el guardado | Arquitectura | Corrección textual S4 (P-64) |
| Ed → Arq: decorador «misma interfaz» sin interfaz | Arquitectura | Corrección textual S4 (P-28) |
| Ed/Req → Did: alcance de R-09 | Didáctica/Requisitos | CT-E |
| Arq → Seguridad: rango corregido de GHSA-rvv3-g6hj-g44x | Seguridad | Verificado por el jurado (V7); C-16 |
| Arq → Ed: numeración de diagramas; norma de «extracto» | Edición | Numeración: NO_PROCEDE (§2.3). Norma: P-07 |
| Req → Did: 14 decisiones sin ✅/❌ | Didáctica | C-17 |
| Req → Ed: rótulos después del bloque; diagrama 4 sin convención | Edición | C-14 (P-10, P-21) y P-36 |
| Req → QA: chequeo literal por línea; `Done Building` en L16 | Verificación | V-LIT (§4.2) y P-38 |
| QA → Arq: `Infrastructure → Application` sin uso | Arquitectura | C-03 |
| QA → Ed: política de recorte | Edición | P-07 |
| Nov → QA: otras salidas de una corrida anterior | Verificación | V12: con los parches, V-LIT da 0 líneas sin respaldo |
| Diablo → Arq: causa del `4500.0` | Arquitectura | CT-A |
| Diablo → AH-001: licencia v2.0 y 15.1.1; FluentValidation y Refit en el Anexo C | Ecosistema | Verificado por el jurado (V7–V9). Refit entra al Anexo C (P-81). FluentValidation no se agrega: la guía no la menciona en ningún lugar, así que no hay dato volátil que respaldar |
| Diablo → Did: nota en §0.4 en lugar de cuatro reemplazos | Didáctica | CT-D |
| Seg → Operación: HTTPS y cadena de conexión | Operación y entrega | NO_PROCEDE (§2.3): despliegue fuera de alcance por §0.1 y contrato |

No hubo ronda de convocatoria en caliente: cada solicitud quedó resuelta con evidencia disponible en la mesa o por el jurado con verificación propia, y el presupuesto (`ciclos_max: 2`) no admite un ciclo siguiente que reciba un especialista nuevo.

---

## 2. Veredictos

Jueces: **Ev** evidencia, **Im** impacto, **CB** costo/beneficio, **CH** coherencia histórica (DC, DA, DR, veredictos previos), **Ri** riesgo e irreversibilidad. Votos: **P** procede, **NP** no procede, **I** insuficiente. Quórum 5 en todos los ítems; ningún veto de Ri (ninguna corrección es irreversible: todo es texto y guion versionados).

### 2.1 Hallazgos que proceden

| Id | Sev. | Ev | Im | CB | CH | Ri | Resultado |
|---|---|---|---|---|---|---|---|
| C-01 | S2 | P — V1: los números no están en la captura citada | P — rompe la promesa de §0.5 en el único lugar donde el lector puede comprobarla | P — copiar seis valores | P — R-13 y DR-05 exigen literalidad | P — reversible; exige resincronizar si se relanza (P-SYNC) | **PROCEDE 5-0** |
| C-02 | S3 | P — V2 | P — la marca [Compilado] es el mecanismo de confianza del documento | P — 6 líneas | P — DR-09 «extraído del código que compiló» | P | **PROCEDE 5-0** |
| C-03 | S3 | P — V3: 0 usos, 0 interfaces | P — el lector busca `IEmailService` y no lo encuentra; copia una flecha que no puede explicar | P — un párrafo | P — no reabre DC-3 (las interfaces técnicas siguen en Application); la referencia se declara en el esqueleto del veredicto §6 (L08 «referencias según la regla»), así que se conserva y se explica, no se quita | P — severidad S3: la referencia es coherente con DC-3 y la corrección es textual | **PROCEDE 5-0** (S3) |
| C-04 | S3 | P — V10 y ejecuciones E1 de Arq y QA | P — el lector ve `HasPrecision(18, 2)` y dos párrafos después un solo decimal | P — dos oraciones y una cita | P — CT-A | P | **PROCEDE 5-0** |
| C-05 | S2 | P — §9.1 l.1093 «un proyecto» contra §8.3 l.1052 «referencia Application», mismo rótulo | P — quien consulta sale con estructuras distintas | P — la nota de §0.4 cuesta un párrafo | P — CT-D: la nota no toca DR-17 ni DR-23 | P | **PROCEDE 5-0** |
| C-06 | S3 | P — contraejemplo válido; §8.5 ya tiene la respuesta | P — el mapa es la puerta declarada en §0.3 | P — una fila | P — la fila no crea un rótulo E-x (DR-17) | P — S3: la respuesta existe en §8.5 y Anexo B #4, el defecto es de acceso | **PROCEDE 5-0** (S3) |
| C-07 | S2 | P — l.1102 contra l.1116 | P — quien lee §9.3 aislada crea un proyecto que el diagrama no pide | P — tres celdas | P — CT-C; no reabre CT-01 | P | **PROCEDE 5-0** |
| C-08 | S3 | P — «escalón» aparece por primera vez en l.1091; la razón de construir el escalón 4 está en l.1151 | P — el lector del recorrido construye todo sin saber por qué | P — un párrafo en §0.4 y tres oraciones | P — CT-B: asciende, no se archiva; no reabre CT-01 | P | **PROCEDE 5-0** |
| C-09 | S3 | P — conteo `L[0-9][0-9]` por `####`: c = 0, e = 0 | P — R-02 y DR-19 exigen la remisión | P — cuatro oraciones | P — DR-19 | P | **PROCEDE 5-0** |
| C-10 | S3 | P — grep: solo usos | P — sin `-i` explicado, el lector no sabe de dónde salen la línea de estado y `Location` | P — una definición | P — DR-16 pide definir en el primer uso; se ubica en §5.1 con las demás definiciones | P | **PROCEDE 5-0** |
| C-11 | S3 | P — primeras apariciones citadas | P — el lector novato no sabe si debería conocer esos términos | P — un párrafo de adelanto y cuatro definiciones | P — DR-16 | P | **PROCEDE 5-0** |
| C-12 | S3 | P — V5, V11 | P — quien ejecuta `dotnet build -v n` no ve huellas y quien sigue «cambia una línea» arranca sin tabla | P — un párrafo, una línea de captura, una oración | P — DR-06 y DR-11 | P | **PROCEDE 5-0** |
| C-13 filas, §, glosa e índice, frontmatter | S2 | P — comparación grep contra el Anexo D; PyYAML | P — §0.2 promete lo que el anexo no tiene; el YAML queda con ítems sin sentido | P | P — índice aprobado, DR-13, DR-14 | P | **PROCEDE 5-0** |
| C-13 columna «equivalente» | S3 | P — el índice aprobado (fila D) la exige | P — el lector novato busca el término en inglés | NP — 62 celdas nuevas por una columna que el cuerpo ya da en cursiva la primera vez | P — E4: índice aprobado por el jurado del ciclo 1 | P — se aplica junto con las filas, en un solo reemplazo de la tabla | **PROCEDE 4-1** |
| C-14 | S3 | P — `lab.sh` l.113 y l.259 compilan los bloques; la definición de §0.5 dice «no se compiló» | P — el rótulo contradice su propia definición | P | P — DR-05, DR-09 | P | **PROCEDE 5-0** |
| C-15 | S2 | P — V11; `grep 'dotnet test\|dotnet remove\|dotnet new xunit'` en la guía = 0 | P — el pedido del PO es que el lector pruebe comandos; sin ellos, doce pasos solo se leen | P — 40 líneas repartidas; §1 121/130, §3 113/120, §4 113/140 (V12) | P — R-06, DR-20 (`&`), índice aprobado (Anexo A con comando y captura) | P | **PROCEDE 5-0** |
| C-16 | S2 | P — V6–V9 | P — R-03 = 1 (restricción dura «autocontenida»); quien elija 15.0.0 por la tabla adopta una versión vulnerable; la exclusión de gobierno y universidades decide para la audiencia declarada | P | P — DA-4 no se reabre: la guía sigue sin adoptar los paquetes; solo precisa los datos | P — §5 del marco, disparador 5 («dominio con consecuencia externa»): no se dispara, porque la guía informa con fuente y no adopta; se registra en §6 | **PROCEDE 5-0** |
| C-17 §0.3, §2.3, §6.2, §3.5, §8.6, Bitácora 02 | S3 | P — l.60 contra 12 decisiones; grep R-09 | P — la promesa de §0.3 es falsa tal como está; §8 no tiene pregunta de aplicabilidad | P — reescribir la promesa cuesta una línea; dos tablas y un cierre | P — CT-E; DR-15 | P | **PROCEDE 5-0** |
| C-17 tablas ✅/❌ en las otras diez decisiones | S3 | NP — el contraste lo da la salida del laboratorio en §1.4, §1.5, §5.3, §5.4, §6.3, §7.4, §8.2, §8.5 | P — habría más contraste | NP — 30 filas nuevas para decisiones que ya contrastan con evidencia | NP — DR-15 admite «o una tabla de escenarios»; el laboratorio es la tabla | NP | **NO_PROCEDE 4-1**; cubierto por la reescritura de §0.3 (P-04); deuda declarada |
| C-18 l.212 e «interfaz» | S3 | P — DR-18 «igual en todo el documento»; DR-12 | P — ambigüedad en §6, donde `IProductoApiService` es una interfaz de C# | P | P — HC-18 (4-1) permitió el voseo, no lo exigió; el infinitivo es la forma dominante en las reglas; no se reabre | P | **PROCEDE 5-0** |
| C-18 rótulo «Qué puede cambiar en tu equipo» → «en otro equipo» | S4 | NP — DR-11 prescribe el rótulo con «tu» | NP — un rótulo fijo no es exposición coloquial | NP | NP — DR-11 es la directiva específica; el mapa del veredicto §6 no es norma de redacción | P — Ri sostiene su objeción de HC-18 | **NO_PROCEDE 4-1**; se unifica la variante «Qué puede cambiar:» al rótulo de DR-11 (P-35, P-52) |
| C-19 «Círculo (Martin, 2012)» sin enlace | S4 | lote | | | | | **APLICAR en lote** (P-14) |
| C-19 renumerar 2026a–h | S4 | NP — es cierto que no hay criterio | NP — ninguna cita queda ambigua: cada letra resuelve a una entrada | NP — 17 anclas y citas a renombrar por un beneficio de forma | NP — DR-10 no fija criterio de letras | NP — riesgo de anclas rotas | **NO_APLICAR 5-0**; deuda declarada; las entradas nuevas siguen la secuencia (i, j, k) |
| C-20 lote S4 (política de recorte, «falla en silencio», «deja solo», diagrama 4, decorador, MSB4006, L16→L17) | S4 | lote | | | | | **APLICAR en lote** (P-07, P-11, P-28, P-36, P-41, P-64, P-79) |
| C-21 | S3 | P — fuente citada por la guía dice que la página se habilita por defecto en Development con `CreateBuilder`; `Program.cs` no la nombra; contraejemplo del token válido | P — el lector no puede saber qué desactivar; el fragmento es un modelo a copiar | P — un párrafo, un fragmento, una entrada | P — DR-21 (fragmento ilustrativo con token en el mismo fragmento) se conserva; el nombre `ApiTokenHandler` sigue DC-2 (término técnico en inglés) | P | **PROCEDE 5-0** |
| C-22 | S3 | P — `Domain` es `classlib net10.0` sin dependencias; el ❌ de §6.4 da la razón correcta | P — dos razones distintas para el mismo caso | P | P — F-09 de la Bitácora 00 se ajusta y se declara (P-B2), como se hizo con F-03..F-05 en el ciclo 1 | P | **PROCEDE 5-0** |
| C-23 | S3 | P — V4 y regla documentada de `rollForward` | P — quien abra `MyProject/` con 10.0.1xx recibe «A compatible .NET SDK was not found» sin aviso | P | P — DA-3 fija `global.json` con el SDK usado; se conserva y se explica | P | **PROCEDE 5-0** |
| C-24 | S3 | P — V11 | P — quien construye desde §4.2 escribe dos handlers y §5.2 exige tres | P | P — DR-26 (`CreatedAtAction` apunta a `GetById`) | P | **PROCEDE 5-0** |
| C-25 cita del 422 | S3 | P — DR-28 «con su cita» | P | P | P | P | **PROCEDE 5-0** |
| C-25 «en ese orden» | S3 | P — nada en §9.4 justifica un orden | NP — impacto bajo | P — cuatro palabras | P — sin conflicto | NP — inocuo | **PROCEDE 3-2** |
| C-26 L24 y L12 (`lab.sh`) | S2 / S3 | P — V6; la aserción de L12 acepta cualquier fallo | P — un PASS vacío contradice el propósito de `aserciones.log` y DR-06 | P — seis líneas de guion | P — DR-06 | P — exige relanzar; véase §2.2 | **PROCEDE 5-0** |
| C-26 404 de §5.1 (opción completa) | S3 | P — DR-07: código sin captura | P | P — dos líneas de guion | P — DR-07 | NP — Ri prefiere la opción mínima para no tocar el guion en el último ciclo | **PROCEDE 4-1** (CT-G) |

### 2.2 Decisión sobre el relanzamiento del laboratorio

C-26 cambia `lab.sh` (aserciones de L12 y L24, paso L15). Una aserción que no se corrió no es una aserción, y `aserciones.log` es un producto de la corrida: editarlo a mano sería fabricar evidencia. Por eso el laboratorio se relanza. Consecuencia: una corrida nueva cambia todo valor variable de las capturas (Guid, fechas, duraciones, huella SHA-256), y los extractos de la guía deben resincronizarse (P-SYNC) con el chequeo V-LIT de §4.2. El jurado registra la objeción de Ri (último ciclo, sin ciclo de revisión posterior) y la responde con dos salvaguardas: el chequeo V-LIT es mecánico y el conteo esperado de aserciones queda fijado (`PASS: 74  FAIL: 1`).

### 2.3 Hallazgos y solicitudes que no proceden

| Ítem | Resultado | Motivo |
|---|---|---|
| Numeración de diagramas por aparición (solicitud de Arq y Req) | NO_PROCEDE 5-0 | DR-22 numera por su lista; renumerar contradiría la directiva y las remisiones «diagrama n» del cuerpo |
| HTTPS y cadena de conexión (solicitud de Seguridad) | NO_PROCEDE 5-0 | Despliegue fuera de alcance (§0.1 de la guía; `fuera_de_alcance` del contrato); §2.6 ya declara por qué `--no-https` |
| Renombrar §7.5 para pasar el grep de R-09 (Req H-04, opción b) | NO_PROCEDE 5-0 | El título está en el índice aprobado; se ajusta el chequeo (P-B1) |
| Reescribir L03 en una sola línea (QA-07.3) | NO_PROCEDE 4-1 | CT-F |
| Reasignar el «único cliente en el mismo proceso» a E-D (Diablo H-01, reemplazos originales) | NO_PROCEDE 5-0 | CT-D; el hallazgo procede con la nota de §0.4 |
| FluentValidation en el Anexo C (DR-29) | NO_PROCEDE 5-0 | La guía v2.0.0 no menciona FluentValidation; DR-29 la listaba porque la guía anterior la usaba |

### 2.4 Controles del jurado

- **Homogeneidad (§9 del marco):** 33 ítems votados; 27 unánimes (82 %). Supera el 80 %: el ciclo queda marcado como sospechoso de homogeneidad. Lectura del jurado: 24 de los 27 unánimes tienen evidencia E1 o E2 reproducida por el juez de evidencia (V1–V12) antes de votar; los disensos reales están donde la decisión es de costo o de riesgo (columna del glosario, relanzamiento, «en ese orden», rótulo de DR-11). Salvaguarda: como no hay ciclo 3, la revisión de los `NO_PROCEDE` por el abogado del diablo se sustituye por la lista de §2.3 con motivo verificable, y los dos NO_PROCEDE con voto dividido quedan en `deuda_declarada`.
- **Nivel C:** ningún hallazgo del ciclo 2 se presentó en nivel C. HC-25 ascendió a E2 (CT-B). HC-26 y HC-27 quedan cerrados como correctos, con la verificación del abogado del diablo (L00 `curl 8.5.0`; L13 `Hosting environment: Development`).
- **Decisiones cerradas:** ninguna se reabre. C-03 roza DC-3 y la conserva; C-16 precisa DA-4 sin cambiar la decisión; C-05 se resuelve sin tocar DR-17 ni DR-23; C-23 conserva DA-3.

---

## 3. Parches (cuerpo auditor)

Reglas de redacción de los parches: cada uno reemplaza un fragmento que existe **exactamente una vez** en el archivo indicado (verificado por script sobre los archivos vigentes, 90/90) y ningún fragmento está contenido en otro, así que el orden de aplicación es indistinto dentro de cada archivo. Los parches que tocaban un mismo fragmento están fusionados (P-06, P-07, P-13, P-24, P-32, P-37, P-39, P-46, P-52, P-77, P-79, P-81, P-82). Costo de todos: bajo (texto). Reversibles: sí (git). Capa de origen: la guía y el guion son el artefacto mismo; las dos bitácoras son derivados que registran la decisión.

### 3.1 Índice de parches

| Parche | Archivo | Ubicación | Cubre |
|---|---|---|---|
| P-01, P-02 | guía | frontmatter | C-13 |
| P-03 | guía | índice | C-13 |
| P-04 | guía | §0.3 | C-17 |
| P-05, P-06 | guía | §0.4 | C-06, C-05, C-08 |
| P-07 | guía | §0.5 | C-14, C-15, C-20 |
| P-08 | guía | §0.6 | C-23 |
| P-09 | guía | §1.2 | C-15 |
| P-10 | guía | §1.4 | C-14, C-15 |
| P-11, P-12, P-13 | guía | §1.5 | C-20, C-15, C-18 |
| P-14, P-15 | guía | §2.1 | C-19, C-11 |
| P-16 | guía | §2.3 | C-17 |
| P-17 | guía | §2.6 | C-03 |
| P-18 | guía | §2.7 | C-08 |
| P-19 | guía | §3.1 | C-11 |
| P-20 | guía | §3.2 | C-15, C-14 |
| P-21 | guía | §3.3 | C-14, C-15 |
| P-22 | guía | §3.5 | C-17 |
| P-23 | guía | §4.2 | C-24 |
| P-24 … P-27 | guía | §4.3 | C-15, C-02, C-01 |
| P-28 | guía | §4.5 | C-20 |
| P-29, P-30, P-31 | guía | §5.1 | C-26, C-10, C-18 |
| P-32 … P-36 | guía | §5.2 | C-24, C-11, C-14, C-15, C-26, C-18, C-20 |
| P-37, P-38, P-39 | guía | §5.3 | C-12, C-04 |
| P-40 | guía | §5.4 | C-04 |
| P-41, P-42 | guía | §5.5 | C-20, C-14 |
| P-43, P-44, P-45 | guía | §5.6 | C-21, C-02, C-25 |
| P-46 | guía | §5.7 | C-05, C-08 |
| P-47 … P-49 | guía | §6.1, §6.2 | C-18, C-11, C-17 |
| P-50, P-51, P-52 | guía | §6.3 | C-14, C-15, C-18, C-04 |
| P-53 | guía | §6.4 | C-05 |
| P-54 … P-57 | guía | §6.5 | C-18, C-16, C-21 |
| P-58 | guía | §6.6 | C-05 |
| P-59 … P-64 | guía | §7 | C-09, C-18, C-20 |
| P-65, P-66 | guía | §7.4, §7.5 | C-22, C-08 |
| P-67 … P-70 | guía | §8 | C-14, C-05, C-17 |
| P-71 … P-78 | guía | §9 | C-11, C-06, C-07, C-25, C-16 |
| P-79 | guía | Anexo A | C-15, C-12, C-20 |
| P-80 | guía | Anexo B | C-07 |
| P-81 | guía | Anexo C | C-16 |
| P-82 | guía | Anexo D | C-13, C-10, C-11 |
| P-83, P-84 | guía | Anexo E | C-16, C-25, C-10, C-21, C-04, C-23 |
| P-85, P-86 | guía | §2.2 | C-14 |
| P-L1 … P-L4 | lab.sh | L12, L15, L24 | C-26 |
| P-B1 | Bitácora 02 | R-09 | C-17 |
| P-B2 | Bitácora 00 | F-09 | C-22 |
| P-SYNC | guía | extractos con valores variables | C-01 (tras el relanzamiento) |

### 3.2 Texto exacto de cada parche

Copia mecánica de esta lista, generada desde la misma fuente: `Mesa/03-Ciclo2-Parches.json` (93 objetos con `id`, `archivo`, `hallazgos`, `reemplazar`, `por`, `verificacion`). El editor aplica desde el JSON y contrasta contra este documento.

Convención: «Reemplazar» es el fragmento tal como está hoy en el archivo; «Por» es el texto nuevo; «Verificación» es el chequeo que el editor corre después de aplicar.


#### P-01 — `Dot-NET-Arquitectura-Guide.md` — C-13 (ED2-04)

**Reemplazar:**

```text
prerequisites: [C# básico (clases, métodos, propiedades), uso de una terminal]
```

**Por:**

```text
prerequisites: ["C# básico (clases, métodos, propiedades)", "uso de una terminal"]
```

**Verificación:** PyYAML: `prerequisites` tiene exactamente 2 ítems.

#### P-02 — `Dot-NET-Arquitectura-Guide.md` — C-13 (ED2-04)

**Reemplazar:**

```text
traces: [NC-01, NC-02, NC-03, NC-04, NC-05, NC-06, NC-07, NC-08, NC-09, NC-10, R-01..R-17]
```

**Por:**

```text
traces: [NC-01, NC-02, NC-03, NC-04, NC-05, NC-06, NC-07, NC-08, NC-09, NC-10, R-01, R-02, R-03, R-04, R-05, R-06, R-07, R-08, R-09, R-10, R-11, R-12, R-13, R-14, R-15, R-16, R-17]
```

**Verificación:** PyYAML: `traces` tiene 27 ítems y ninguno contiene `..`.

#### P-03 — `Dot-NET-Arquitectura-Guide.md` — C-13 (ED2-02, DR-13)

**Reemplazar:**

```text
- **[Anexo A. Hoja de ruta del laboratorio](#anexo-a-hoja-de-ruta-del-laboratorio)** · **[Anexo B. Lista de verificación](#anexo-b-lista-de-verificación-para-diseñar-una-solución-nueva)** · **[Anexo C. Versiones, soporte y licencias](#anexo-c-versiones-soporte-y-licencias-verificadas)** · **[Anexo D. Glosario](#anexo-d-glosario)** · **[Anexo E. Referencias](#anexo-e-referencias)**
```

**Por:**

```text
- **[Anexo A. Hoja de ruta del laboratorio](#anexo-a-hoja-de-ruta-del-laboratorio)**: los 25 pasos con su sección, su comando, lo que confirman y su captura.
- **[Anexo B. Lista de verificación](#anexo-b-lista-de-verificación-para-diseñar-una-solución-nueva)**: las preguntas de §9 como plantilla para una solución nueva.
- **[Anexo C. Versiones, soporte y licencias](#anexo-c-versiones-soporte-y-licencias-verificadas)**: datos volátiles con fuente y fecha de consulta.
- **[Anexo D. Glosario](#anexo-d-glosario)**: cada término con su equivalente y la sección donde se define.
- **[Anexo E. Referencias](#anexo-e-referencias)**: fuentes citadas, en formato autor-fecha.
```

**Verificación:** El índice tiene una viñeta con glosa por cada anexo; el script de anclas sigue dando 0 enlaces rotos.

#### P-04 — `Dot-NET-Arquitectura-Guide.md` — C-17 (DID2-07)

**Reemplazar:**

```text
su porqué y ejemplos que cumplen (✅) y que no cumplen (❌)—, práctica
```

**Por:**

```text
su porqué y, cuando la pregunta admite más de una manera de resolverla, ejemplos que cumplen (✅) y que no cumplen (❌); cuando se responde con un experimento, el contraste lo da la salida registrada—, práctica
```

**Verificación:** §0.3 ya no promete ✅/❌ en toda decisión; la frase nueva aparece una vez.

#### P-05 — `Dot-NET-Arquitectura-Guide.md` — C-06 (Diablo H-03)

**Reemplazar:**

```text
| **E-B** | Una API HTTP con uno o más clientes .NET remotos (web, móvil, consola) | ¿Dónde vive lo que comparten la API y sus clientes? |
```

**Por:**

```text
| **E-B** | Una API HTTP con uno o más clientes .NET remotos (web, móvil, consola); si los clientes no son .NET, la estructura es la misma sin `Contracts` (§8.5, §9.1) | ¿Dónde vive lo que comparten la API y sus clientes? |
```

**Verificación:** grep de «E-B» en §0.4 muestra la remisión a §8.5 y §9.1; DR-17: siguen existiendo solo cuatro rótulos E-x.

#### P-06 — `Dot-NET-Arquitectura-Guide.md` — C-05 (Diablo H-01) + C-08 (DID2-02, HC-25)

**Reemplazar:**

```text
El problema se resuelve en [§9.5](#95-el-problema-conductor-resuelto).
```

**Por:**

```text
Los escenarios describen situaciones, no estructuras: la estructura de partida de cada uno está en el [§9.1](#91-mapa-de-entrada-dónde-está-el-problema) y puede crecer sin que cambie el rótulo; en particular, E-A empieza con un solo proyecto y suma `Domain` y `Application` cuando aparecen reglas que proteger (§6.4 y §8.3 tratan ese caso). La guía construye la versión más completa de la solución —cuatro proyectos de backend, un contrato compartido y un cliente remoto— porque el enunciado incluye «otras aplicaciones que consumen el catálogo», que es la señal del escenario E-B. No es la estructura que conviene siempre: cada capítulo cierra con la pregunta de cuándo lo construido no hace falta, y el [§9.2](#92-la-escalera-de-opciones) ordena esas respuestas en una escalera de cuatro escalones, desde un solo proyecto hasta la API con clientes remotos. El problema se resuelve en [§9.5](#95-el-problema-conductor-resuelto).
```

**Verificación:** §0.4 nombra la escalera y la razón de construir el escalón 4 antes de §1; las tres anclas (#91-…, #92-…, #95-…) resuelven.

#### P-07 — `Dot-NET-Arquitectura-Guide.md` — C-14 (ED2-03) + C-15 (H-NOV-01, H-NOV-04) + C-20 (QA-07, solicitudes de Did/QA/Arq)

**Reemplazar:**

```text
| Marca | Significado |
| --- | --- |
| *Salida registrada: `capturas/Lnn-….txt`* | La salida mostrada es un extracto literal de una ejecución real, guardada en [`Dot-NET-Arquitectura-Lab/`](Dot-NET-Arquitectura-Lab/) junto a esta guía |
| **[Compilado: `src/…`]** | El bloque de código es un extracto del laboratorio y compiló con cero advertencias |
| **[Fragmento ilustrativo: motivo]** | El bloque no se compiló en el laboratorio; el motivo se declara |
| **Criterio de esta guía** | Recomendación propia, no una norma ni un dato externo |
| [Autor, año](#anexo-e-referencias) | Afirmación respaldada por la fuente citada en el Anexo E |
```

**Por:**

```text
| Marca | Significado |
| --- | --- |
| *Salida registrada: `capturas/Lnn-….txt`, SDK 10.0.400* | La salida mostrada es un extracto literal de una ejecución real, guardada en [`Dot-NET-Arquitectura-Lab/`](Dot-NET-Arquitectura-Lab/) junto a esta guía |
| **[Compilado: `MyProject/src/…`]** | El bloque de código es un extracto textual del archivo indicado, que compiló en el laboratorio con cero advertencias. La ruta `MyProject/…` es la del código publicado en `Dot-NET-Arquitectura-Lab/` y coincide con la carpeta que se crea en L01 |
| **[Fragmento ilustrativo: motivo]** | El bloque no forma parte del código final del laboratorio: o no se compiló, o se compiló solo para provocar un error y se eliminó; el motivo se declara |
| **Criterio de esta guía** | Recomendación propia, no una norma ni un dato externo |
| [Autor, año](#anexo-e-referencias) | Afirmación respaldada por la fuente citada en el Anexo E |
| Tipo nombrado sin código | Cuando la guía nombra un tipo (`IProductoRepository`, `ProductoDto`, `FakeProductoRepository`, `Program.cs`…) sin mostrar su código, el archivo completo está en [`Dot-NET-Arquitectura-Lab/MyProject/`](Dot-NET-Arquitectura-Lab/MyProject/), en la carpeta que indica su espacio de nombres (`MyProject.Domain.Productos` → `src/Backend/MyProject.Domain/Productos/`); se copia desde ahí antes de compilar el paso |

Qué recorta un extracto: los bloques de salida omiten líneas que no hacen al punto (encabezados HTTP, avisos de restauración) y acortan las rutas absolutas con `...`; una línea larga puede partirse en dos con sangría; una línea `...` sola marca líneas quitadas dentro de un bloque. Nunca se altera el texto de una línea mostrada. Los bloques **[Compilado]** omiten la declaración de la clase, los `using` y los miembros que no hacen al punto, y no reescriben ninguna expresión.
```

**Verificación:** La tabla tiene 6 filas; la política de recorte aparece una vez; todo rótulo [Fragmento ilustrativo] del documento cumple la definición nueva (L03 y L10 incluidos).

#### P-08 — `Dot-NET-Arquitectura-Guide.md` — C-23 (Arq H-06)

**Reemplazar:**

```text
Cualquier SDK `10.0.*` reproduce el laboratorio.
```

**Por:**

```text
Cualquier SDK `10.0.*` reproduce el laboratorio ejecutando `lab.sh` o los comandos de cada paso, porque L01 genera `global.json` con la versión instalada. El `MyProject/` publicado junto a esta guía fija `10.0.400` con `rollForward: latestFeature`, que acepta esa banda de características o una superior ([Microsoft, 2026k](#ref-microsoft-2026k)); con un SDK `10.0.1xx`–`10.0.3xx` hay que editar `version` en `global.json` antes de compilarlo.
```

**Verificación:** La frase coincide con `MyProject/global.json` (version 10.0.400, rollForward latestFeature); el ancla ref-microsoft-2026k resuelve.

#### P-09 — `Dot-NET-Arquitectura-Guide.md` — C-15 (H-NOV-04)

**Reemplazar:**

````text
```bash
dotnet new sln -n MyProject

````

**Por:**

````text
```bash
mkdir MyProject && cd MyProject      # todo el laboratorio se ejecuta desde esta carpeta
dotnet new sln -n MyProject

````

**Verificación:** El primer bloque bash de §1.2 empieza con `mkdir MyProject && cd MyProject`; coincide con `lab.sh` (mkdir -p "$SLN"; cd "$SLN").

#### P-10 — `Dot-NET-Arquitectura-Guide.md` — C-14 (ED2-03, DR-09) + C-15 (H-NOV-05)

**Reemplazar:**

````text
El paso escribe en `Domain` una clase que usa un tipo de `Infrastructure`, sin referencia en esa dirección:

```csharp
using MyProject.Infrastructure.Persistence;

namespace MyProject.Domain;

public class Producto
{
    public string Nombre { get; set; } = "";

    public void Guardar(ConexionSql conexion) =>
        conexion.Ejecutar($"INSERT INTO Productos VALUES ('{Nombre}')");
}
```

**[Fragmento ilustrativo: código escrito para fallar a propósito; se elimina en L05.]**
````

**Por:**

````text
El paso crea primero, en `src/Backend/MyProject.Infrastructure/Persistence/ConexionSql.cs`, una clase vacía que simula el acceso a datos (`public class ConexionSql { public void Ejecutar(string sql) { } }`, en el espacio de nombres `MyProject.Infrastructure.Persistence`), y después escribe en `src/Backend/MyProject.Domain/Producto.cs` una clase que la usa, sin referencia en esa dirección:

**[Fragmento ilustrativo: compilado en L03 para provocar el error; los dos archivos se eliminan en L05.]**

```csharp
using MyProject.Infrastructure.Persistence;

namespace MyProject.Domain;

public class Producto
{
    public string Nombre { get; set; } = "";

    public void Guardar(ConexionSql conexion) =>
        conexion.Ejecutar($"INSERT INTO Productos VALUES ('{Nombre}')");
}
```
````

**Verificación:** El rótulo precede al bloque (script DR-09: la línea anterior a cada ```csharp es un rótulo); el contenido de ConexionSql coincide con lab.sh l.92–99.

#### P-11 — `Dot-NET-Arquitectura-Guide.md` — C-20 lote S4 (Arq observación MSB4006)

**Reemplazar:**

```text
El error no lo emite el compilador de C# (sus códigos empiezan con `CS`) sino MSBuild (`MSB`), el motor que ordena la compilación: no puede decidir qué proyecto compilar primero si cada uno necesita al otro.
```

**Por:**

```text
El error no lo emite el compilador de C# (sus códigos empiezan con `CS`) sino MSBuild (`MSB`), el motor que ordena la compilación, y aparece en la fase de restauración que corre antes de compilar (la captura lo ubica en `NuGet.targets`): al recorrer el grafo de proyectos encuentra que cada uno necesita al otro y no puede decidir cuál va primero.
```

**Verificación:** `grep NuGet.targets capturas/L04-ciclo-compilar.txt` devuelve la línea del MSB4006.

#### P-12 — `Dot-NET-Arquitectura-Guide.md` — C-15 (H-NOV-02)

**Reemplazar:**

```text
Deshacer el ciclo (L05) deja una segunda lección sobre leer salidas. Con la ruta de la carpeta, el comando **no encuentra** la referencia y aun así termina con código 0:
```

**Por:**

````text
Deshacer el ciclo (L05) deja una segunda lección sobre leer salidas. El comando inverso de `add … reference` es `dotnet remove <proyecto> reference <referencia>`. Con la ruta de la carpeta, **no encuentra** la referencia y aun así termina con código 0:

```bash
dotnet remove src/Backend/MyProject.Domain reference src/Backend/MyProject.Infrastructure
```
````

**Verificación:** El comando coincide con la cabecera `# comando:` de capturas/L05-quitar-con-carpeta.txt.

#### P-13 — `Dot-NET-Arquitectura-Guide.md` — C-15 (H-NOV-02) + C-18 (ED2-05, voz)

**Reemplazar:**

```text
Con la ruta al archivo `.csproj`, la quita (`Project reference … removed.`) y la solución vuelve a compilar. *Salida registrada: `capturas/L05-quitar-con-carpeta.txt` y `capturas/L05-quitar-con-csproj.txt`, SDK 10.0.400.* Regla práctica: **leé el mensaje, no solo el código de salida**, y para quitar referencias pasá la ruta al `.csproj`.
```

**Por:**

````text
Con la ruta al archivo `.csproj` la quita (`Project reference … removed.`); después se borran los dos archivos de L03 y la solución vuelve a compilar:

```bash
dotnet remove src/Backend/MyProject.Domain reference src/Backend/MyProject.Infrastructure/MyProject.Infrastructure.csproj
rm src/Backend/MyProject.Domain/Producto.cs src/Backend/MyProject.Infrastructure/Persistence/ConexionSql.cs
dotnet build
```

*Salida registrada: `capturas/L05-quitar-con-carpeta.txt` y `capturas/L05-quitar-con-csproj.txt`, SDK 10.0.400.* Regla práctica: **leer el mensaje, no solo el código de salida**, y pasar la ruta al `.csproj` para quitar una referencia.
````

**Verificación:** Los tres comandos coinciden con la cabecera de capturas/L05-quitar-con-csproj.txt; `grep -c 'leé\|pasá' guía` = 0.

#### P-14 — `Dot-NET-Arquitectura-Guide.md` — C-19 lote S4 (ED2-07)

**Reemplazar:**

```text
| Círculo (Martin, 2012) | Proyecto | Contiene |
```

**Por:**

```text
| Círculo ([Martin, 2012](#ref-martin-2012)) | Proyecto | Contiene |
```

**Verificación:** grep de «(Martin, 2012)» sin enlace = 0.

#### P-15 — `Dot-NET-Arquitectura-Guide.md` — C-11 (DID2-05, DR-16)

**Reemplazar:**

```text
| Frameworks & Drivers | Bibliotecas externas: ASP.NET Core, EF Core, SQLite | Lo que se usa, no se escribe |
```

**Por:**

```text
| Frameworks & Drivers | Bibliotecas externas: ASP.NET Core, EF Core, SQLite | Lo que se usa, no se escribe |

Los términos de la columna «Contiene» se definen en el capítulo de su proyecto: entidad y value object en §3.1; caso de uso, mensaje, modelo de lectura y repositorio en §4.1; controller y EF Core en §5.1. Por ahora alcanza con saber que **EF Core** es la biblioteca de Microsoft que guarda objetos de C# en una base de datos, y que **ASP.NET Core** es el marco de Microsoft para construir aplicaciones web y API HTTP en .NET.
```

**Verificación:** El párrafo sigue a la tabla de §2.1 y antecede al diagrama 1; ASP.NET Core y EF Core quedan definidos antes de §2.2.

#### P-16 — `Dot-NET-Arquitectura-Guide.md` — C-17 (DID2-07, DR-15)

**Reemplazar:**

```text
`Domain` declara `IProductoRepository` («necesito guardar y recuperar productos») sin saber cómo se hace. `Infrastructure` referencia a `Domain` e implementa esa interfaz con EF Core. En ejecución la llamada va de adentro hacia afuera; en el código fuente la flecha va de afuera hacia adentro. Esa es la inversión de dependencias, y es la razón por la cual en el §5.3 se reemplaza el almacenamiento sin recompilar `Domain`.
```

**Por:**

```text
`Domain` declara `IProductoRepository` («necesito guardar y recuperar productos») sin saber cómo se hace. `Infrastructure` referencia a `Domain` e implementa esa interfaz con EF Core. En ejecución la llamada va de adentro hacia afuera; en el código fuente la flecha va de afuera hacia adentro. Esa es la inversión de dependencias, y es la razón por la cual en el §5.3 se reemplaza el almacenamiento sin recompilar `Domain`.

| | |
| --- | --- |
| ✅ | `IProductoRepository` en `Domain`, `ProductoRepository` en `Infrastructure` |
| ❌ | `IProductoRepository` en `Infrastructure`: `Domain` tendría que referenciarlo para usarla y se forma el ciclo de L04 |
| ❌ | `Producto.Guardar(ConexionSql)`, como en L03: la entidad conoce la base |
```

**Verificación:** §2.3 tiene una tabla ✅/❌ con 1 ✅ y 2 ❌; §2 sigue en ≤ 150 líneas (DR-08).

#### P-17 — `Dot-NET-Arquitectura-Guide.md` — C-03 (Arq H-02, Diablo H-02, solicitud QA)

**Reemplazar:**

```text
`Infrastructure` referencia también a `Application` porque ahí se declaran las interfaces de servicios técnicos (correo, usuario actual) que Infrastructure implementa.
```

**Por:**

```text
`Infrastructure` referencia también a `Application` para poder implementar las interfaces de servicios técnicos (correo, usuario actual; §4.1) que una solución real declara en esa capa. En el laboratorio esa referencia queda declarada pero sin uso: ningún archivo de `Infrastructure` nombra un tipo de `Application` (se comprueba con `grep -rn Application src/Backend/MyProject.Infrastructure --include=*.cs`, que no devuelve nada), porque el ejemplo no llega a necesitar un servicio técnico. Con el criterio del §9.6, en una solución real esa flecha se agrega cuando aparece la primera interfaz que la necesita.
```

**Verificación:** `grep -rn Application Dot-NET-Arquitectura-Lab/MyProject/src/Backend/MyProject.Infrastructure --include=*.cs` = 0 líneas; la frase «ahí se declaran» ya no aparece.

#### P-18 — `Dot-NET-Arquitectura-Guide.md` — C-08 (DID2-02)

**Reemplazar:**

```text
La regla empieza a pagar cuando aparecen reglas que proteger (E-D) o una segunda forma de acceder a los mismos datos (E-B).
```

**Por:**

```text
La regla empieza a pagar cuando aparecen reglas que proteger (E-D) o una segunda forma de acceder a los mismos datos (E-B). En la escalera del §9.2, adoptar la regla completa es subir del escalón 1 al 3.
```

**Verificación:** §2.7 nombra la escalera del §9.2.

#### P-19 — `Dot-NET-Arquitectura-Guide.md` — C-11 (H-NOV-05, DR-16)

**Reemplazar:**

```text
- **Setter privado.** `{ get; private set; }`: la propiedad se lee desde cualquier lugar y se modifica solo desde dentro de la clase.
```

**Por:**

```text
- **Setter privado.** `{ get; private set; }`: la propiedad se lee desde cualquier lugar y se modifica solo desde dentro de la clase.
- **`Guid`.** Identificador único global: un número de 128 bits que .NET genera con `Guid.NewGuid()` y que sirve como `Id` sin necesidad de que una base de datos lo asigne.
- **`CancellationToken`.** Parámetro que reciben las operaciones que esperan (base de datos, red) para poder interrumpirse si quien las pidió ya no espera el resultado, por ejemplo porque el cliente cerró la conexión. En esta guía se llama `ct` y `= default` permite omitirlo.
```

**Verificación:** `Guid` y `CancellationToken` quedan definidos en §3.1, antes de su primer uso en §3.2.

#### P-20 — `Dot-NET-Arquitectura-Guide.md` — C-15 (H-NOV-01) + C-14 (ED2-03, marca SDK)

**Reemplazar:**

```text
`Domain` contiene además `DomainException` y la interfaz `IProductoRepository` (§4.1), y compila sin ninguna referencia (*salida registrada: `capturas/L09-domain.txt`*).
```

**Por:**

````text
`Domain` contiene además `DomainException` (una clase que hereda de `Exception` y recibe el mensaje de la regla incumplida) y la interfaz que declara lo que el dominio necesita del almacenamiento (§4.1); sus métodos devuelven `Task` porque esperan a la base o a la red (§4.1):

**[Compilado: `MyProject/src/Backend/MyProject.Domain/Productos/IProductoRepository.cs`]**

```csharp
public interface IProductoRepository
{
    Task<Producto?> GetByIdAsync(Guid id, CancellationToken ct = default);
    Task<IReadOnlyList<Producto>> GetAllAsync(CancellationToken ct = default);
    Task AddAsync(Producto producto, CancellationToken ct = default);
}
```

`Domain` compila sin ninguna referencia (*salida registrada: `capturas/L09-domain.txt`, SDK 10.0.400*).
````

**Verificación:** El bloque coincide línea a línea con MyProject/src/Backend/MyProject.Domain/Productos/IProductoRepository.cs (sin el namespace ni el comentario XML); §3 ≤ 120 líneas.

#### P-21 — `Dot-NET-Arquitectura-Guide.md` — C-14 (ED2-03, DR-09) + C-15 (H-NOV-05)

**Reemplazar:**

````text
El paso intenta, desde `Application`, bajar el precio de un producto ya creado:

```csharp
var producto = Producto.Create("Mate", 3500m);
producto.Precio = -1m;
```

**[Fragmento ilustrativo: código escrito para fallar a propósito; se elimina después de L10.]**
````

**Por:**

````text
El paso crea `src/Backend/MyProject.Application/Productos/Intento.cs` con un método estático cualquiera (`public static class Intento { public static void BajarPrecio() { … } }`) que intenta bajar el precio de un producto ya creado:

**[Fragmento ilustrativo: compilado en L10 para provocar el error; el archivo se elimina a continuación.]**

```csharp
var producto = Producto.Create("Mate", 3500m);
producto.Precio = -1m;
```
````

**Verificación:** El rótulo precede al bloque; archivo y clase coinciden con lab.sh l.245–257 y con `Intento.cs(10,9)` de la captura L10.

#### P-22 — `Dot-NET-Arquitectura-Guide.md` — C-17 (DID2-07, R-09)

**Reemplazar:**

```text
un `Nombre` que solo es texto no necesita un tipo propio.
```

**Por:**

```text
un `Nombre` que solo es texto no necesita un tipo propio. En el escenario E-A, con pocas reglas, un value object rara vez tiene comportamiento que proteger; en E-D es el lugar donde una regla sobre un valor se escribe una sola vez. **Criterio de esta guía.**
```

**Verificación:** §3.5 responde en términos de E-A y E-D.

#### P-23 — `Dot-NET-Arquitectura-Guide.md` — C-24 (Arq H-07)

**Reemplazar:**

```text
La Query equivalente, `ObtenerProductosHandler`, llama a `GetAllAsync` y convierte cada entidad en `ProductoDto` con `ProductoDto.From(producto)`.
```

**Por:**

```text
Las dos Queries siguen el mismo patrón: `ObtenerProductosHandler` llama a `GetAllAsync` y convierte cada entidad en `ProductoDto` con `ProductoDto.From(producto)`; `ObtenerProductoPorIdHandler` recibe `ObtenerProductoPorIdQuery(Id)`, llama a `GetByIdAsync` y devuelve `ProductoDto?` (nulo si no existe). La segunda es la que usa la API para responder la consulta de un producto por su `Id` (§5.2).
```

**Verificación:** grep de `ObtenerProductoPorIdHandler` en la guía ≥ 2 (§4.2 y §5.2); coincide con MyProject.Application/Productos/Queries/ObtenerProductoPorId/.

#### P-24 — `Dot-NET-Arquitectura-Guide.md` — C-15 (H-NOV-02) + C-02 (Arq H-04, comentario de l.504)

**Reemplazar:**

```text
Aquí nacen los proyectos de pruebas, uno por proyecto probado, en `tests/Backend/`. Una **prueba unitaria** es un método marcado con `[Fact]` (en la biblioteca xUnit) que ejecuta una porción de código y verifica el resultado con `Assert`.
```

**Por:**

````text
Aquí nacen los proyectos de pruebas, uno por proyecto probado, en `tests/Backend/`. Se crean con la plantilla `xunit`, referencian al proyecto que prueban y se ejecutan con `dotnet test`, que compila y corre todas las pruebas de la solución:

```bash
dotnet new xunit -n MyProject.Domain.Tests -o tests/Backend/MyProject.Domain.Tests
dotnet new xunit -n MyProject.Application.Tests -o tests/Backend/MyProject.Application.Tests
dotnet sln add tests/Backend/MyProject.Domain.Tests tests/Backend/MyProject.Application.Tests
dotnet add tests/Backend/MyProject.Domain.Tests reference src/Backend/MyProject.Domain
dotnet add tests/Backend/MyProject.Application.Tests reference src/Backend/MyProject.Application
dotnet test
```

Una **prueba unitaria** es un método marcado con `[Fact]` (en la biblioteca xUnit, que la plantilla ya incluye) que ejecuta una porción de código y verifica el resultado con `Assert`. El repositorio falso, `FakeProductoRepository`, está escrito en el proyecto de pruebas de `Application` y guarda los productos en una lista, `Guardados`, que la prueba inspecciona.
````

**Verificación:** Los comandos coinciden con lab.sh l.349–350 y con la cabecera de capturas/L11-tests.txt; §4 ≤ 140 líneas.

#### P-25 — `Dot-NET-Arquitectura-Guide.md` — C-02 (Arq H-04)

**Reemplazar:**

```text
    var repository = new FakeProductoRepository();   // guarda en una List<Producto>
```

**Por:**

```text
    var repository = new FakeProductoRepository();
```

**Verificación:** El bloque [Compilado] de §4.3 coincide línea a línea con CrearProductoHandlerTests.cs l.19–27.

#### P-26 — `Dot-NET-Arquitectura-Guide.md` — C-01 (Req H-01, QA-01, H-NOV-07)

**Reemplazar:**

```text
Passed!  - Failed:     0, Passed:     3, Skipped:     0, Total:     3, Duration: 71 ms - MyProject.Domain.Tests.dll (net10.0)
Passed!  - Failed:     0, Passed:     2, Skipped:     0, Total:     2, Duration: 44 ms - MyProject.Application.Tests.dll (net10.0)
```

**Por:**

```text
Passed!  - Failed:     0, Passed:     3, Skipped:     0, Total:     3, Duration: 111 ms - MyProject.Domain.Tests.dll (net10.0)
Passed!  - Failed:     0, Passed:     2, Skipped:     0, Total:     2, Duration: 94 ms - MyProject.Application.Tests.dll (net10.0)
```

**Verificación:** Cada línea del bloque aparece literalmente en capturas/L11-tests.txt (`grep -F`). Si el laboratorio se relanza, las duraciones se copian de la captura nueva y se vuelve a correr el chequeo.

#### P-27 — `Dot-NET-Arquitectura-Guide.md` — C-01 (Req H-01, QA-01, H-NOV-07)

**Reemplazar:**

```text
  Failed MyProject.Domain.Tests.ProductoTests.Create_con_precio_negativo_lanza_DomainException [11 ms]
  Error Message:
   Assert.Throws() Failure: No exception was thrown
Failed!  - Failed:     1, Passed:     2, Skipped:     0, Total:     3 - MyProject.Domain.Tests.dll (net10.0)
  Failed MyProject.Application.Tests.CrearProductoHandlerTests.Handle_con_precio_negativo_no_guarda_nada [19 ms]
Failed!  - Failed:     1, Passed:     1, Skipped:     0, Total:     2 - MyProject.Application.Tests.dll (net10.0)
```

**Por:**

```text
  Failed MyProject.Domain.Tests.ProductoTests.Create_con_precio_negativo_lanza_DomainException [9 ms]
  Error Message:
   Assert.Throws() Failure: No exception was thrown
...
Failed!  - Failed:     1, Passed:     2, Skipped:     0, Total:     3, Duration: 301 ms - MyProject.Domain.Tests.dll (net10.0)
  Failed MyProject.Application.Tests.CrearProductoHandlerTests.Handle_con_precio_negativo_no_guarda_nada [46 ms]
...
Failed!  - Failed:     1, Passed:     1, Skipped:     0, Total:     2, Duration: 206 ms - MyProject.Application.Tests.dll (net10.0)
```

**Verificación:** Cada línea del bloque distinta de `...` aparece literalmente en capturas/L12-regresion.txt. Si el laboratorio se relanza, se copian los valores nuevos.

#### P-28 — `Dot-NET-Arquitectura-Guide.md` — C-20 lote S4 (solicitud de Edición: decorador)

**Reemplazar:**

```text
Ese mismo efecto se obtiene con un **decorador**: una clase que implementa la misma interfaz que el handler, hace su trabajo adicional y delega en el handler original.
```

**Por:**

```text
Ese mismo efecto se obtiene con un **decorador**: una clase que implementa la misma interfaz que el handler (para eso el handler tiene que declarar una, cosa que este ejemplo no necesita), hace su trabajo adicional y delega en el handler original.
```

**Verificación:** La frase ya no supone una interfaz que §4.2 no muestra.

#### P-29 — `Dot-NET-Arquitectura-Guide.md` — C-QA-05 (404 sin captura) — exige el parche P-L2 de lab.sh

**Reemplazar:**

```text
`4xx` el cliente pidió algo inválido (`400 Bad Request`, `404 Not Found`), `5xx` falló el servidor (`500 Internal Server Error`).
```

**Por:**

```text
`4xx` el cliente pidió algo inválido (`400 Bad Request`; `404 Not Found` cuando el recurso no existe, L15), `5xx` falló el servidor (`500 Internal Server Error`).
```

**Verificación:** Tras relanzar el laboratorio, capturas/L15-get.txt contiene `HTTP/1.1 404 Not Found` y aserciones.log tiene `PASS L15 404 para un id inexistente`.

#### P-30 — `Dot-NET-Arquitectura-Guide.md` — C-10 (DID2-04, H-NOV-06)

**Reemplazar:**

```text
- **JSON.** Formato de texto para datos estructurados: `{"nombre":"Yerba 1 kg","precio":4500}`.
```

**Por:**

```text
- **JSON.** Formato de texto para datos estructurados: `{"nombre":"Yerba 1 kg","precio":4500}`.
- **`curl`.** Programa de línea de comandos que envía una petición HTTP y muestra la respuesta; viene instalado en la imagen del SDK (L00). Opciones usadas en la guía: `-X` fija el verbo (`POST`; sin `-X`, `curl` envía `GET`), `-H` agrega un encabezado (`Content-Type: application/json` avisa que el cuerpo es JSON), `-d` envía el cuerpo, `-i` muestra también la línea de estado (`HTTP/1.1 201 Created`) y los encabezados de la respuesta, `-s` silencia la barra de progreso ([curl, 2026](#ref-curl-2026)).
```

**Verificación:** `curl` queda definido en §5.1 antes de su primer uso en §5.2; el ancla ref-curl-2026 resuelve; capturas/L00-entorno.txt contiene `curl 8.5.0`.

#### P-31 — `Dot-NET-Arquitectura-Guide.md` — C-18 (ED2-06, DR-12)

**Reemplazar:**

```text
no incluye una interfaz visual interactiva
```

**Por:**

```text
no incluye una página web interactiva para explorarla
```

**Verificación:** grep de «interfaz visual» = 0.

#### P-32 — `Dot-NET-Arquitectura-Guide.md` — C-24 (Arq H-07) + C-11 (H-NOV-05) + C-14 (ED2-03, rótulo no declarado) + C-QA-05

**Reemplazar:**

```text
Las acciones `GetAll` y `GetById` siguen el mismo patrón con sus handlers; `CreatedAtAction(nameof(GetById), …)` arma la URL del recurso creado a partir de esa acción. En esta etapa `CrearProductoRequest` y `ProductoResponse` viven dentro de la WebAPI, en la carpeta `Contracts/`; en §6.3 se mudan a su propio proyecto. `Program.cs` es el composition root: registra `InMemoryProductoRepository` (un diccionario en memoria, en Infrastructure) como implementación de `IProductoRepository`, y los tres handlers. **[Compilado en L13; `Program.cs` se reemplaza en L16 y la versión de esta etapa queda en `lab.sh`.]**
```

**Por:**

```text
Las acciones `GetAll` y `GetById` siguen el mismo patrón con sus handlers (`ObtenerProductosHandler` y `ObtenerProductoPorIdHandler`; `GetById` responde `404 Not Found` cuando el handler devuelve nulo); `CreatedAtAction(nameof(GetById), …)` arma la URL del recurso creado a partir de esa acción. `[FromServices]` le indica al controller que ese parámetro no viene de la petición sino del contenedor de dependencias (§2.1), e `IActionResult` es el tipo que representa cualquier respuesta HTTP. En esta etapa `CrearProductoRequest` y `ProductoResponse` viven dentro de la WebAPI, en la carpeta `Contracts/`; en §6.3 se mudan a su propio proyecto. `Program.cs` es el composition root: registra `InMemoryProductoRepository` (un diccionario en memoria, en Infrastructure) como implementación de `IProductoRepository`, y los tres handlers (`CrearProductoHandler`, `ObtenerProductosHandler`, `ObtenerProductoPorIdHandler`) con `AddScoped`. La versión de `Program.cs` de esta etapa compiló en L13, se reemplaza en L16 y se conserva en `lab.sh`.
```

**Verificación:** Los tres handlers nombrados coinciden con los `AddScoped` de Program.cs; grep de «[Compilado en L13» = 0.

#### P-33 — `Dot-NET-Arquitectura-Guide.md` — C-15 (H-NOV-03, DR-20)

**Reemplazar:**

````text
La API se arranca con una receta fija, para que el puerto no dependa de la configuración del equipo:

```bash
ASPNETCORE_ENVIRONMENT=Development dotnet run --no-launch-profile --urls http://127.0.0.1:5180
```
````

**Por:**

````text
La API se arranca con una receta fija, para que el puerto no dependa de la configuración del equipo. Se ejecuta desde la carpeta del proyecto WebAPI, y el `&` final la deja corriendo en segundo plano para seguir usando la misma terminal (para detenerla: `kill %1`):

```bash
cd src/Backend/MyProject.WebAPI
ASPNETCORE_ENVIRONMENT=Development dotnet run --no-launch-profile --urls http://127.0.0.1:5180 &
cd ../../..
```
````

**Verificación:** El bloque coincide con la receta DR-20 (`&`) y con start_api de lab.sh (cd a la carpeta de WebAPI).

#### P-34 — `Dot-NET-Arquitectura-Guide.md` — C-15 (H-NOV-03)

**Reemplazar:**

```text
Con la API escuchando, desde otra terminal:
```

**Por:**

```text
Con la API escuchando (la línea `Now listening on`), en la misma terminal:
```

**Verificación:** grep de «otra terminal» = 0.

#### P-35 — `Dot-NET-Arquitectura-Guide.md` — C-QA-05 + C-18 (ED2-05, variante del rótulo)

**Reemplazar:**

```text
`GET /openapi/v1.json` devuelve el documento OpenAPI (`"openapi": "3.1.1"`). **Qué puede cambiar:** el `Guid` y las fechas.
```

**Por:**

```text
`GET /openapi/v1.json` devuelve el documento OpenAPI (`"openapi": "3.1.1"`), y un `GET` a `/api/productos/` con un `Guid` que no existe responde `404 Not Found` (misma captura). **Qué puede cambiar en tu equipo:** el `Guid` y las fechas.
```

**Verificación:** Tras relanzar, capturas/L15-get.txt contiene `HTTP/1.1 404 Not Found`; grep de «**Qué puede cambiar:**» = 0.

#### P-36 — `Dot-NET-Arquitectura-Guide.md` — C-20 lote S4 (solicitud de Requisitos: leyenda del diagrama 4)

**Reemplazar:**

```text
*Diagrama 4. Secuencia de una petición en tiempo de ejecución.*
```

**Por:**

```text
*Diagrama 4. Secuencia de una petición en tiempo de ejecución. Todas las flechas son llamadas en ejecución (equivalen a la línea punteada de los otros diagramas); ninguna es una referencia entre proyectos.*
```

**Verificación:** Los seis diagramas declaran su convención de línea.

#### P-37 — `Dot-NET-Arquitectura-Guide.md` — C-12 (DID2-06, Arq H-03, Req H-07, H-NOV-02)

**Reemplazar:**

```text
L16 agrega el paquete `Microsoft.EntityFrameworkCore.Sqlite` (se resolvió la versión `10.0.12`), crea `AppDbContext`, `ProductoConfiguration` y `ProductoRepository`, y agrupa el registro en el método de extensión `AddInfrastructure` (`MyProject/src/Backend/MyProject.Infrastructure/DependencyInjection.cs`), que llama a `AddDbContext<AppDbContext>(o => o.UseSqlite(...))` y registra `ProductoRepository` como `IProductoRepository`. `Program.cs` cambia una línea: `builder.Services.AddInfrastructure(...)` en lugar del registro en memoria. Al compilar con detalle (`dotnet build -v n`):
```

**Por:**

```text
L16 agrega el paquete `Microsoft.EntityFrameworkCore.Sqlite` con `dotnet add src/Backend/MyProject.Infrastructure package Microsoft.EntityFrameworkCore.Sqlite` (se resolvió la versión `10.0.12`; *salida registrada: `capturas/L16-paquete-agregar-efcore.txt`, SDK 10.0.400*), crea `AppDbContext`, `ProductoConfiguration` y `ProductoRepository`, y agrupa el registro en el método de extensión `AddInfrastructure` (`MyProject/src/Backend/MyProject.Infrastructure/DependencyInjection.cs`), que llama a `AddDbContext<AppDbContext>(o => o.UseSqlite(...))` y registra `ProductoRepository` como `IProductoRepository`. En `Program.cs` el registro en memoria se reemplaza por `builder.Services.AddInfrastructure(...)`, se ajustan los `using` y se agrega, después de `builder.Build()`, `app.Services.EnsureDatabaseCreated();`: otro método de extensión de `Infrastructure` que llama a `Database.EnsureCreated()` para crear el archivo y la tabla si no existen (en un proyecto real se usan migraciones). Sin esa línea la tabla no existe y el primer `POST` falla; la versión completa está en `MyProject/src/Backend/MyProject.WebAPI/Program.cs`. Antes de agregar el paquete, el paso guarda la huella SHA-256 de `MyProject.Domain.dll` con `sha256sum src/Backend/MyProject.Domain/bin/Debug/net10.0/MyProject.Domain.dll`; después compila con detalle (`dotnet build -v n`) y vuelve a calcularla. La compilación con detalle imprime cientos de líneas; el extracto conserva las que corresponden a `Domain` y las dos huellas (el comando completo figura en la cabecera de la captura):
```

**Verificación:** Coincide con lab.sh l.576–578 (sha256sum, dotnet add package) y l.668–696 (Program.cs con EnsureDatabaseCreated); capturas/L16-paquete-agregar-efcore.txt contiene `10.0.12`.

#### P-38 — `Dot-NET-Arquitectura-Guide.md` — C-12 (DID2-06, solicitud de Requisitos)

**Reemplazar:**

```text
       Skipping target "CoreCompile" because all output files are up-to-date with respect to the input files.
Build succeeded.
sha256 Domain.dll antes : 7ce966b2e3debc58e5a961670e453d181bab076856f5610bf8a6c0317150987a
```

**Por:**

```text
       Skipping target "CoreCompile" because all output files are up-to-date with respect to the input files.
     6>Done Building Project ".../src/Backend/MyProject.Domain/MyProject.Domain.csproj" (default targets).
Build succeeded.
sha256 Domain.dll antes : 7ce966b2e3debc58e5a961670e453d181bab076856f5610bf8a6c0317150987a
```

**Verificación:** La línea `Done Building Project …MyProject.Domain.csproj" (default targets).` sigue a la de `Skipping target` en capturas/L16-compilar-con-efcore.txt (l.14–15); si se relanza, la huella se copia de la captura nueva.

#### P-39 — `Dot-NET-Arquitectura-Guide.md` — C-12 (QA-06, DID2-06) + C-04 (Arq H-01, QA revisado 2, Diablo H-05)

**Reemplazar:**

```text
*Salida registrada: `capturas/L16-compilar-con-efcore.txt`, SDK 10.0.400.* `Domain.dll` es el mismo archivo, byte por byte, antes y después de cambiar la base de datos. L17 repite el `POST` y el `GET` contra SQLite y obtiene `[{"id":"592827de-…","nombre":"Yerba 1 kg","precio":4500.0}]` (*salida registrada: `capturas/L17-mismo-contrato.txt`, SDK 10.0.400*). Los campos del contrato son los mismos. El precio llega como `4500.0` en lugar de `4500`: el valor numérico es igual, pero el tipo `decimal` conserva la escala con la que el proveedor de SQLite lo devuelve. Un cliente que compare textos en lugar de números notaría la diferencia, y por eso la prueba de un contrato compara valores. La búsqueda de `Infrastructure` en el código de la WebAPI (`grep -rn Infrastructure --include=*.cs`) encuentra solo dos líneas, ambas en `Program.cs`: el composition root es el único que la conoce (§2.4).
```

**Por:**

```text
*Salida registrada: `capturas/L16-compilar-con-efcore.txt`, SDK 10.0.400.* Cómo leerla: `Skipping target "CoreCompile"` dice que MSBuild no volvió a compilar un proyecto porque ninguno de sus archivos cambió, y la línea `Done Building Project` que sigue identifica ese proyecto: `Domain`. La huella SHA-256 es un número calculado a partir del contenido del archivo; si coincide, el archivo es el mismo. `Domain.dll` es el mismo archivo, byte por byte, antes y después de cambiar la base de datos. **Qué puede cambiar en tu equipo:** el valor de la huella, que depende del directorio de compilación y del parche exacto del compilador; lo que no cambia es que las dos líneas sean iguales entre sí. L17 repite el `POST` y el `GET` contra SQLite y obtiene `[{"id":"592827de-…","nombre":"Yerba 1 kg","precio":4500.0}]` (*salida registrada: `capturas/L17-mismo-contrato.txt`, SDK 10.0.400*). Los campos del contrato son los mismos. El precio llega como `4500.0` en lugar de `4500`: el valor numérico es igual. SQLite no tiene un tipo decimal, así que el proveedor guarda el `decimal` como texto con el formato `0.0###…`, siempre con al menos un dígito decimal ([Microsoft, 2026j](#ref-microsoft-2026j)); al releerlo, el `decimal` conserva esa escala y el JSON la reproduce. Un cliente que compare textos en lugar de números notaría la diferencia, y por eso la prueba de un contrato compara valores. La búsqueda de `Infrastructure` en el código de la WebAPI (`grep -rn Infrastructure --include=*.cs`) encuentra solo dos líneas, ambas en `Program.cs`: el composition root es el único que la conoce (§2.4).
```

**Verificación:** §5.3 tiene «Qué puede cambiar en tu equipo»; el ancla ref-microsoft-2026j resuelve; la fila Decimal → TEXT `0.0###` está en la fuente citada.

#### P-40 — `Dot-NET-Arquitectura-Guide.md` — C-04 (Arq H-01)

**Reemplazar:**

```text
Un modelo de persistencia separado solo hace falta cuando el esquema no se puede adaptar (escenario E-C, §7.2 g).
```

**Por:**

```text
Un modelo de persistencia separado solo hace falta cuando el esquema no se puede adaptar (escenario E-C, §7.2 g). `HasPrecision(18, 2)` documenta la intención y rige en proveedores con tipo decimal nativo (SQL Server, PostgreSQL); en SQLite la columna se crea como `TEXT` y la base no aplica precisión ni escala ([Microsoft, 2026j](#ref-microsoft-2026j)), por eso en L17 el precio vuelve con un solo decimal y no con dos.
```

**Verificación:** §5.4 explica por qué L17 muestra `4500.0` y no `4500.00`; la fuente dice que SQLite no hace cumplir precisión ni escala.

#### P-41 — `Dot-NET-Arquitectura-Guide.md` — C-20 lote S4 (QA-07.2) + C-14 (ED2-03, marca SDK)

**Reemplazar:**

```text
L18 quita del repositorio la llamada a `SaveChangesAsync` y deja solo `_db.Productos.Add(producto)`:
```

**Por:**

```text
L18 reemplaza en el repositorio la llamada a `SaveChangesAsync` por un `await Task.CompletedTask` que no confirma nada, y deja `_db.Productos.Add(producto)` como única operación sobre la base:
```

**Verificación:** Coincide con capturas/L18-sin-savechanges.txt l.20–21.

#### P-42 — `Dot-NET-Arquitectura-Guide.md` — C-14 (ED2-03, DR-05)

**Reemplazar:**

```text
Con la línea restituida el producto aparece (*`capturas/L18-corregido-con-savechanges.txt`*).
```

**Por:**

```text
Con la línea restituida el producto aparece (*salida registrada: `capturas/L18-corregido-con-savechanges.txt`, SDK 10.0.400*).
```

**Verificación:** Toda marca de captura del documento lleva «SDK 10.0.400».

#### P-43 — `Dot-NET-Arquitectura-Guide.md` — C-21 (H-SEG-01)

**Reemplazar:**

```text
El 500 de L20 muestra la traza completa porque la API corre en el entorno `Development`; en producción esa página no debe habilitarse ([Microsoft, 2026e](#ref-microsoft-2026e)).
```

**Por:**

```text
El 500 de L20 trae la traza completa porque la produce la *página de excepciones del desarrollador* (`DeveloperExceptionPageMiddleware`), que `WebApplication.CreateBuilder` activa por sí sola cuando la variable de entorno `ASPNETCORE_ENVIRONMENT` vale `Development`; el `Program.cs` del laboratorio no la nombra, y la receta de §5.2 arranca la API con ese valor (L13: `Hosting environment: Development`). Esa traza expone rutas del sistema de archivos, nombres de clases internas y, según el caso, encabezados y cookies de la petición, por lo que no debe estar activa fuera de `Development`: alcanza con no fijar ese valor en producción, y Microsoft indica no compartir públicamente el detalle de las excepciones ([Microsoft, 2026e](#ref-microsoft-2026e)). Con el manejador de L21 la excepción del dominio ya no llega a esa página.
```

**Verificación:** capturas/L13-arranque.txt contiene `Hosting environment: Development`; Program.cs no contiene `UseDeveloperExceptionPage`; la fuente [Microsoft, 2026e] dice que la página se habilita por defecto en Development con WebApplication.CreateBuilder.

#### P-44 — `Dot-NET-Arquitectura-Guide.md` — C-02 (Arq H-04, QA-04)

**Reemplazar:**

```text
        ProblemDetails = { Status = 400, Title = "Regla de negocio incumplida", Detail = exception.Message },
```

**Por:**

```text
        ProblemDetails =
        {
            Status = StatusCodes.Status400BadRequest,
            Title = "Regla de negocio incumplida",
            Detail = exception.Message,
        },
```

**Verificación:** `diff <(sed -n 13,30p MyProject/src/Backend/MyProject.WebAPI/ExceptionHandlers/DomainExceptionHandler.cs) <(bloque de la guía)` vacío.

#### P-45 — `Dot-NET-Arquitectura-Guide.md` — C-25 (Diablo H-07, DR-28)

**Reemplazar:**

```text
responder `422 Unprocessable Content` a las reglas de negocio es otra convención posible.
```

**Por:**

```text
responder `422 Unprocessable Content` (definido en RFC 9110, §15.5.21, [IETF, 2022](#ref-ietf-2022)) a las reglas de negocio es otra convención posible.
```

**Verificación:** El ancla ref-ietf-2022 resuelve; la URL apunta a la sección 15.5.21 de RFC 9110.

#### P-46 — `Dot-NET-Arquitectura-Guide.md` — C-05 (Diablo H-01) + C-08 (DID2-02)

**Reemplazar:**

```text
**¿Cuándo no hace falta una API?** Cuando no hay un segundo proceso que consuma los datos: en el escenario E-A la aplicación Blazor en el servidor llama a los casos de uso dentro del mismo proceso, sin HTTP ni contrato (§8.3).
```

**Por:**

```text
**¿Cuándo no hace falta una API?** Cuando no hay un segundo proceso que consuma los datos: en el escenario E-A la aplicación Blazor en el servidor llama a su servicio o, si ya tiene `Application`, a los casos de uso dentro del mismo proceso, sin HTTP ni contrato (§8.3). En la escalera del §9.2 es la diferencia entre los escalones 1 a 3 y el escalón 4.
```

**Verificación:** §5.7 distingue servicio (escalón 1) de casos de uso (escalón 3) y nombra la escalera.

#### P-47 — `Dot-NET-Arquitectura-Guide.md` — C-18 (ED2-06, DR-12)

**Reemplazar:**

```text
Tecnología de Microsoft para construir interfaces web con componentes C#
```

**Por:**

```text
Tecnología de Microsoft para construir páginas web con componentes C#
```

**Verificación:** grep de «interfaces web» = 0.

#### P-48 — `Dot-NET-Arquitectura-Guide.md` — C-11 (DID2-05)

**Reemplazar:**

```text
recibe una implementación real o un doble de prueba.
```

**Por:**

```text
recibe una implementación real o un **doble de prueba**: una implementación falsa, escrita para las pruebas, como el repositorio falso de §4.3.
```

**Verificación:** «doble de prueba» queda definido en su primer uso.

#### P-49 — `Dot-NET-Arquitectura-Guide.md` — C-17 (DID2-07, DR-15)

**Reemplazar:**

```text
*Diagrama 5. Línea continua = dependencia de código; punteada = llamada en ejecución.*
```

**Por:**

```text
*Diagrama 5. Línea continua = dependencia de código; punteada = llamada en ejecución.*

| | |
| --- | --- |
| ✅ | La página pide `IProductoApiService`; en las pruebas recibe un doble que devuelve una lista fija |
| ❌ | La página crea un `HttpClient` y arma la URL `api/productos` en su propio código |
| ❌ | Cada página repite la lectura del JSON y el manejo del código de estado |
```

**Verificación:** §6.2 tiene una tabla ✅/❌ con 1 ✅ y 2 ❌; §6 ≤ 150 líneas.

#### P-50 — `Dot-NET-Arquitectura-Guide.md` — C-14 (ED2-03, DR-05)

**Reemplazar:**

```text
La WebAPI compiló sin cambiar una línea de código (*`capturas/L22-build-compilar-solucion.txt`*, 0 advertencias)
```

**Por:**

```text
La WebAPI compiló sin cambiar una línea de código (*salida registrada: `capturas/L22-build-compilar-solucion.txt`, SDK 10.0.400*, 0 advertencias)
```

**Verificación:** Toda marca de captura lleva «Salida registrada» y «SDK 10.0.400».

#### P-51 — `Dot-NET-Arquitectura-Guide.md` — C-15 (H-NOV-02)

**Reemplazar:**

````text
```text
POST api/productos -> 201
````

**Por:**

````text
Con la API de L21 escuchando, `dotnet run --project src/Clients/MyProject.ConsoleClient -- http://127.0.0.1:5180` compila el cliente y lo ejecuta:

```text
POST api/productos -> 201
````

**Verificación:** El comando coincide con la cabecera de capturas/L22-cliente-consola.txt.

#### P-52 — `Dot-NET-Arquitectura-Guide.md` — C-18 (ED2-05) + C-04 (Diablo H-05, dos causas para 12000.0)

**Reemplazar:**

```text
**Qué puede cambiar:** el `Guid`, y el formato del número según la cultura regional del equipo.
```

**Por:**

```text
**Qué puede cambiar en tu equipo:** el `Guid`, y el separador decimal del número (`12000.0` o `12000,0`) según la cultura regional del equipo; el dígito decimal viene de SQLite (§5.3).
```

**Verificación:** grep de «**Qué puede cambiar:**» = 0; §6.3 remite a §5.3 para la escala.

#### P-53 — `Dot-NET-Arquitectura-Guide.md` — C-05 (Diablo H-01)

**Reemplazar:**

```text
**Respuesta: en ese caso se puede, y es el escenario E-A; la condición deja de cumplirse cuando aparece un cliente remoto.**
```

**Por:**

```text
**Respuesta: en ese caso se puede; es el escenario E-A cuando ya tiene `Application` (escalón 3 del §9.2), y la condición deja de cumplirse cuando aparece un cliente remoto.**
```

**Verificación:** §6.4 y §9.1 dejan de asignar estructuras incompatibles al mismo rótulo E-A.

#### P-54 — `Dot-NET-Arquitectura-Guide.md` — C-18 (ED2-06, DR-12)

**Reemplazar:**

```text
La interfaz se carga sin red porque los componentes viajan dentro de la aplicación
```

**Por:**

```text
Las pantallas se cargan sin red porque los componentes viajan dentro de la aplicación
```

**Verificación:** grep de «La interfaz se carga» = 0.

#### P-55 — `Dot-NET-Arquitectura-Guide.md` — C-16 (DR-29: aviso de versión de Refit)

**Reemplazar:**

```text
la implementación de una interfaz decorada con atributos HTTP (`[Get("/api/productos")]`), en lugar de escribir el servicio con `HttpClient` a mano.
```

**Por:**

```text
la implementación de una interfaz decorada con atributos HTTP (`[Get("/api/productos")]`), en lugar de escribir el servicio con `HttpClient` a mano. Las versiones anteriores a 7.2.22 tienen una vulnerabilidad crítica (Anexo C).
```

**Verificación:** §6.5 remite al Anexo C, que tiene la fila de Refit.

#### P-56 — `Dot-NET-Arquitectura-Guide.md` — C-21 (H-SEG-02)

**Reemplazar:**

```text
- **Autenticación.** Un `DelegatingHandler` es un eslabón de la cadena de `HttpClient` que agrega el encabezado `Authorization` a cada petición. Qué emite el token y cómo se valida es tema de seguridad y queda fuera de esta guía.
```

**Por:**

```text
- **Autenticación.** Un `DelegatingHandler` es un eslabón de la cadena por la que pasa cada petición de `HttpClient` antes de salir; el de este ejemplo agrega el encabezado `Authorization` con un token portador (*bearer*). Un token portador sirve a quien lo tenga, así que el handler debe agregarlo solo a las peticiones dirigidas a la API propia y nunca a otros orígenes; en Blazor WebAssembly el framework ya provee `AuthorizationMessageHandler` y `BaseAddressAuthorizationMessageHandler`, que lo agregan únicamente cuando la URL de la petición está bajo una lista de URLs autorizadas ([Microsoft, 2026i](#ref-microsoft-2026i)). Qué emite el token y cómo se valida es tema de seguridad y queda fuera de esta guía.
```

**Verificación:** El ancla ref-microsoft-2026i resuelve; la fuente dice «The access token is only attached if at least one of the authorized URLs is a base of the request URI».

#### P-57 — `Dot-NET-Arquitectura-Guide.md` — C-21 (H-SEG-02)

**Reemplazar:**

```text
public class AuthorizationMessageHandler : DelegatingHandler
{
    private readonly Func<Task<string?>> _obtenerToken;

    public AuthorizationMessageHandler(Func<Task<string?>> obtenerToken) => _obtenerToken = obtenerToken;

    protected override async Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken ct)
    {
        var token = await _obtenerToken();
        if (!string.IsNullOrEmpty(token))
            request.Headers.Authorization = new AuthenticationHeaderValue("Bearer", token);
        return await base.SendAsync(request, ct);
    }
}
```

**Por:**

```text
public class ApiTokenHandler : DelegatingHandler
{
    private readonly Func<Task<string?>> _obtenerToken;
    private readonly Uri _baseDeLaApi; // solo a esta URL se le envía el token

    public ApiTokenHandler(Func<Task<string?>> obtenerToken, Uri baseDeLaApi)
        => (_obtenerToken, _baseDeLaApi) = (obtenerToken, baseDeLaApi);

    protected override async Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken ct)
    {
        var token = await _obtenerToken();
        if (!string.IsNullOrEmpty(token) && _baseDeLaApi.IsBaseOf(request.RequestUri!))
            request.Headers.Authorization = new AuthenticationHeaderValue("Bearer", token);
        return await base.SendAsync(request, ct);
    }
}
```

**Verificación:** El fragmento conserva el rótulo [Fragmento ilustrativo: no compilado]; el nombre ya no colisiona con la clase del framework; `Uri.IsBaseOf` es API pública de System.

#### P-58 — `Dot-NET-Arquitectura-Guide.md` — C-05 (Diablo H-01)

**Reemplazar:**

```text
en el escenario E-A la página inyecta los casos de uso directamente (§6.4), y un servicio intermedio que solo reenvía sería una capa sin trabajo.
```

**Por:**

```text
en el escenario E-A la página inyecta el servicio o los casos de uso directamente (§6.4), y un servicio de API intermedio que solo reenvía sería una capa sin trabajo.
```

**Verificación:** §6.6 coherente con §5.7 y §6.4.

#### P-59 — `Dot-NET-Arquitectura-Guide.md` — C-09 (DID2-03, Req H-05)

**Reemplazar:**

```text
*Prerrequisitos para el recorrido: §3–§6. Para la consulta, cada respuesta remite al paso de laboratorio donde el objeto se vio funcionando.*
```

**Por:**

```text
*Prerrequisitos para el recorrido: §3–§6. Para la consulta, cada respuesta remite al paso de laboratorio donde el objeto se vio funcionando; el ViewModel y el form model no se construyeron en el laboratorio (§6.5) y sus respuestas remiten al paso que muestra la necesidad que resuelven.*
```

**Verificación:** La afirmación de §7 es verdadera para las siete respuestas.

#### P-60 — `Dot-NET-Arquitectura-Guide.md` — C-09 (DID2-03, Req H-05)

**Reemplazar:**

```text
el controller lo construye a partir de `CrearProductoRequest` (§5.2).
```

**Por:**

```text
el controller lo construye a partir de `CrearProductoRequest` (§5.2, L14), y el handler lo recibe sin saber que existe HTTP (L11, donde la prueba lo construye a mano).
```

**Verificación:** §7.2 c remite a L14 y L11 (conteo de `L[0-9][0-9]` en c ≥ 1).

#### P-61 — `Dot-NET-Arquitectura-Guide.md` — C-09 (DID2-03, Req H-05)

**Reemplazar:**

```text
El ViewModel cambia cuando cambia el diseño.
```

**Por:**

```text
El ViewModel cambia cuando cambia el diseño. Es el único objeto de la tabla que el laboratorio no construye: el cliente de consola de L22 imprime `ProductoResponse` directamente porque no tiene pantalla, y muestra la necesidad: el precio sale como `12000.0`, y presentarlo como «$ 12.000,00» es trabajo de la pantalla, no del contrato. El ViewModel aparece con el cliente Blazor de §6.5, que es ilustrativo.
```

**Verificación:** §7.2 e remite a L22; capturas/L22-cliente-consola.txt contiene `12000.0`.

#### P-62 — `Dot-NET-Arquitectura-Guide.md` — C-09 (DID2-03, DR-16)

**Reemplazar:**

```text
El enlace de datos de Blazor (`@bind-Value`) necesita
```

**Por:**

```text
El enlace de datos de Blazor —la sintaxis `@bind-Value`, que copia lo que el usuario escribe en un campo a una propiedad del objeto— necesita
```

**Verificación:** `@bind-Value` queda definido en su primer uso.

#### P-63 — `Dot-NET-Arquitectura-Guide.md` — C-18 (ED2-06, DR-12)

**Reemplazar:**

```text
| ✅ | `ProductoFormModel` con `{ get; set; }` y atributos de validación de interfaz |
```

**Por:**

```text
| ✅ | `ProductoFormModel` con `{ get; set; }` y atributos de validación del formulario |
```

**Verificación:** grep de «validación de interfaz» = 0.

#### P-64 — `Dot-NET-Arquitectura-Guide.md` — C-20 lote S4 (solicitud de Edición: L16 vs L17)

**Reemplazar:**

```text
En L16 `Producto` se guarda en SQLite sin cambiar una línea del dominio
```

**Por:**

```text
En L16–L17 `Producto` se guarda en SQLite sin cambiar una línea del dominio
```

**Verificación:** §7.2 g remite al paso que ejercita el guardado (L17).

#### P-65 — `Dot-NET-Arquitectura-Guide.md` — C-22 (Arq H-05)

**Reemplazar:**

```text
En un cliente Blazor WebAssembly, además, el código corre en el navegador y no tiene el ensamblado del dominio.
```

**Por:**

```text
En un cliente Blazor WebAssembly, además, el código corre en el navegador: para que la página recibiera la entidad habría que descargar el ensamblado de `Domain` al cliente, y aun así no habría base ni repositorio que la respalden (§6.4).
```

**Verificación:** §7.4 y el ❌ de §6.4 dan la misma razón para el mismo caso.

#### P-66 — `Dot-NET-Arquitectura-Guide.md` — C-08 (DID2-02)

**Reemplazar:**

```text
sin montar las cuatro capas. **Criterio de esta guía.**
```

**Por:**

```text
sin montar las cuatro capas. Es el escalón 2 de la escalera del [§9.2](#92-la-escalera-de-opciones). **Criterio de esta guía.**
```

**Verificación:** §7.5 nombra el escalón 2; el ancla resuelve.

#### P-67 — `Dot-NET-Arquitectura-Guide.md` — C-14 (ED2-03, DR-05)

**Reemplazar:**

```text
contiene los ocho proyectos compilados (*salida registrada: `capturas/L23-estructura.txt`*).
```

**Por:**

```text
contiene los ocho proyectos compilados (*salida registrada: `capturas/L23-estructura.txt`, SDK 10.0.400*).
```

**Verificación:** Toda marca de captura lleva «SDK 10.0.400».

#### P-68 — `Dot-NET-Arquitectura-Guide.md` — C-14 (ED2-03, rótulo aplicado a prosa)

**Reemplazar:**

```text
MSBuild permite desactivar la transitividad con la propiedad `DisableTransitiveProjectReferences`. **[Fragmento ilustrativo: no se ejercitó en el laboratorio.]**
```

**Por:**

```text
MSBuild permite desactivar la transitividad con la propiedad `DisableTransitiveProjectReferences`. Esta propiedad no se ejercitó en el laboratorio.
```

**Verificación:** Los rótulos [Fragmento ilustrativo] solo preceden bloques ```csharp.

#### P-69 — `Dot-NET-Arquitectura-Guide.md` — C-05 (Diablo H-01)

**Reemplazar:**

```text
| Cliente en el mismo proceso, único (E-A) | `Application`² | `Infrastructure`, `Domain` por fuera de `Application` |
```

**Por:**

```text
| Cliente en el mismo proceso, único (E-A con `Application`, §6.4) | `Application`² | `Infrastructure`, `Domain` por fuera de `Application` |
```

**Verificación:** La fila de §8.3 remite a §6.4 y no contradice a §9.1.

#### P-70 — `Dot-NET-Arquitectura-Guide.md` — C-17 (Req H-04, DID2-07, R-09)

**Reemplazar:**

```text
En el laboratorio, `Contracts` nace en L22 y la API no necesita cambiar una línea de código para usarlo (§6.3).
```

**Por:**

```text
En el laboratorio, `Contracts` nace en L22 y la API no necesita cambiar una línea de código para usarlo (§6.3).

### 8.6 Pregunta de cierre

**¿Cuándo no hace falta el árbol completo de §8.1?** Cuando la solución tiene un solo proyecto (escenario E-A en el escalón 1 de §9.2): no hay `src/Backend/`, `src/Clients/` ni `src/Contracts/` porque no hay nada que se despliegue por separado ni ningún contrato compartido. El árbol crece con la solución: `tests/` aparece en L11, y `src/Contracts/` y `src/Clients/` en L22, con el primer cliente remoto (E-B). La tabla de §8.3 sigue siendo la referencia para cualquier proyecto que se agregue.
```

**Verificación:** grep «¿Cuándo no» en §8 ≥ 1; §8 ≤ 110 líneas.

#### P-71 — `Dot-NET-Arquitectura-Guide.md` — C-11 (DID2-05, CRUD)

**Reemplazar:**

```text
| **E-A** una app Blazor en el servidor, CRUD con pocas reglas |
```

**Por:**

```text
| **E-A** una app Blazor en el servidor, alta, baja, modificación y consulta (CRUD) con pocas reglas |
```

**Verificación:** La sigla CRUD queda desplegada en su primer uso (§9.1 se lee aislada).

#### P-72 — `Dot-NET-Arquitectura-Guide.md` — C-06 (Diablo H-03)

**Reemplazar:**

```text
| **E-B** una API con clientes .NET remotos | Cuatro proyectos de backend + `Contracts` + clientes | Entidad, mensaje, modelo de lectura, contrato; modelos de pantalla en cada cliente | §2, §5, §6, §8 | — |
```

**Por:**

```text
| **E-B** una API con clientes .NET remotos | Cuatro proyectos de backend + `Contracts` + clientes | Entidad, mensaje, modelo de lectura, contrato; modelos de pantalla en cada cliente | §2, §5, §6, §8 | — |
| Una API cuyos clientes no son .NET (navegador con JavaScript, móvil nativo, otro equipo) | La de E-B sin `Contracts`: el contrato es el documento OpenAPI que publica la API | Entidad, mensaje, modelo de lectura, DTOs de la WebAPI | §5, §8.5 | Aparece el primer cliente .NET: nace `Contracts` (§6.3) |
```

**Verificación:** §9.1 tiene cinco filas; la nueva no introduce un rótulo E-x (DR-17).

#### P-73 — `Dot-NET-Arquitectura-Guide.md` — C-07 (DID2-01, Diablo H-04)

**Reemplazar:**

```text
| La misma validación aparece en dos pantallas | Falta una entidad con comportamiento (escalón 2 o 3) |
```

**Por:**

```text
| La misma validación aparece en dos pantallas | Falta una entidad con comportamiento (escalón 2); si las reglas son muchas y se repiten en varios casos de uso (E-D), escalón 3 |
```

**Verificación:** La fila da un criterio para elegir entre 2 y 3.

#### P-74 — `Dot-NET-Arquitectura-Guide.md` — C-07 (DID2-01, Diablo H-04)

**Reemplazar:**

```text
| Se quiere probar una regla y hace falta levantar la base | Falta separar Domain (escalón 3) |
```

**Por:**

```text
| Se quiere probar una regla y hace falta levantar la base | Falta una entidad que contenga la regla y se pruebe sola (escalón 2: `Producto.Create` se prueba sin base, como en L11); si además hace falta que el compilador impida que la regla dependa de EF Core (§2.2), falta separar `Domain` (escalón 3) |
```

**Verificación:** §9.2, §9.3 y §9.5 mandan la señal «probar la regla» al mismo escalón (2).

#### P-75 — `Dot-NET-Arquitectura-Guide.md` — C-25 (Diablo H-07)

**Reemplazar:**

```text
**Respuesta: soporte, licencia, vulnerabilidades conocidas, alternativa nativa y costo de salida, en ese orden.**
```

**Por:**

```text
**Respuesta: soporte, licencia, vulnerabilidades conocidas, alternativa nativa y costo de salida; las cinco antes de agregar la primera línea que dependa del paquete.**
```

**Verificación:** grep de «en ese orden» = 0.

#### P-76 — `Dot-NET-Arquitectura-Guide.md` — C-16 (ED2-01, Req H-03, Req H-06, R-03)

**Reemplazar:**

```text
**Paquetes.** Dos comprobaciones se pueden hacer desde la terminal. El paso L24 las aplica a AutoMapper, la biblioteca de mapeo que la versión anterior de esta guía recomendaba:
```

**Por:**

```text
**Paquetes.** Dos comprobaciones se pueden hacer desde la terminal, en un proyecto descartable: `dotnet list package --vulnerable` consulta la base de avisos de seguridad de nuget.org, y `curl -s https://api.nuget.org/v3-flatcontainer/automapper/14.0.0/automapper.nuspec` descarga el archivo de metadatos del paquete, donde el elemento `<license>` declara la licencia. El paso L24 las aplica a AutoMapper, una biblioteca que copia automáticamente los datos entre objetos de clases distintas:
```

**Verificación:** `grep -i -c 'versión anterior\|guía vigente' guía` = 0 (chequeo R-03); los dos comandos coinciden con la cabecera de capturas/L24-evaluar-dependencia.txt.

#### P-77 — `Dot-NET-Arquitectura-Guide.md` — C-16 (Req H-03, Diablo H-06, H-SEG-03, solicitud de Arq)

**Reemplazar:**

```text
*Salida registrada: `capturas/L24-evaluar-dependencia.txt`, SDK 10.0.400.* La versión 14.0.0 es la última con licencia MIT; desde la 15.0.0 la licencia es dual, RPL-1.5 o comercial ([Bogard, 2025](#ref-bogard-2025)), y la vulnerabilidad está corregida en versiones de esa rama. La misma captura muestra el campo de licencia de cada versión leído de nuget.org.
```

**Por:**

```text
*Salida registrada: `capturas/L24-evaluar-dependencia.txt`, SDK 10.0.400.* La versión 14.0.0 es la última con licencia MIT; desde la 15.0.0 la licencia es dual, RPL-1.5 o comercial ([Bogard, 2025](#ref-bogard-2025)). La vulnerabilidad informada (GHSA-rvv3-g6hj-g44x, CVE-2026-32933, severidad alta) es una denegación de servicio: el mapeo recurre sin límite de profundidad y un objeto anidado unas 25 000 veces desborda la pila y termina el proceso. Afecta a toda versión menor que 15.1.1 y a las 16.0.0–16.1.0; está corregida en 15.1.1 y 16.1.1 ([GitHub, 2026](#ref-github-2026)), es decir, solo en versiones con licencia dual. La misma captura muestra el elemento `<license>` de cada versión leído de nuget.org: en 14.0.0 es la expresión `MIT`; en 15.0.0 pasa a ser un archivo, `LICENSE.md`, cuyo contenido es la licencia dual que describe Bogard. Lo mismo ocurre con MediatR entre 12.5.0 (`Apache-2.0`) y 13.0.0 (`LICENSE.md`).
```

**Verificación:** Los rangos coinciden con api.github.com/advisories/GHSA-rvv3-g6hj-g44x (< 15.1.1 → 15.1.1; >= 16.0.0, < 16.1.1 → 16.1.1); las cuatro líneas <license> coinciden con capturas/L24-evaluar-dependencia.txt l.26–33.

#### P-78 — `Dot-NET-Arquitectura-Guide.md` — C-16 (H-SEG-03)

**Reemplazar:**

```text
| ¿Vulnerabilidades conocidas? | Alta en 14.0.0 (L24) | Ninguna agregada |
```

**Por:**

```text
| ¿Vulnerabilidades conocidas? | Alta (DoS) en toda versión < 15.1.1 y en 16.0.0–16.1.0; corregida en 15.1.1 y 16.1.1 (L24; [GitHub, 2026](#ref-github-2026)) | Ninguna agregada |
```

**Verificación:** La tabla ya no sugiere que la falla sea propia de 14.0.0.

#### P-79 — `Dot-NET-Arquitectura-Guide.md` — C-15 (Req H-02, H-NOV-02) + C-12 (QA-06) + C-20 lote S4 (QA-07.1)

**Reemplazar:**

```text
El guion `Dot-NET-Arquitectura-Lab/lab.sh` ejecuta todos los pasos dentro del contenedor del SDK, guarda cada salida en `capturas/` y verifica lo que no cambia entre equipos en `aserciones.log`. El código final está en `Dot-NET-Arquitectura-Lab/MyProject/`.

| Paso | § | Qué se hace | Qué confirma |
| --- | --- | --- | --- |
| L00 | 0.6 | `dotnet --info` | El SDK disponible |
| L01 | 1.2 | `dotnet new sln`, `global.json` | La solución se crea como `.slnx` |
| L02 | 1.2 | Dos bibliotecas, una referencia, `build` | La referencia es una flecha |
| L03 ⚠ | 1.4 | `using` sin referencia | CS0234 y CS0246: el espacio de nombres no crea dependencias |
| L04 ⚠ | 1.5 | Referencia inversa | Se agrega con código 0; MSB4006 al compilar |
| L05 | 1.5 | Quitar la referencia | Con la carpeta falla en silencio; con el `.csproj` funciona |
| L06 | 2.2 | Entidad y SQL en un proyecto | Nada impide mezclar |
| L07 ⚠ | 2.2 | El mismo código separado | La separación hace cumplir la regla |
| L08 | 2.6 | Esqueleto de cuatro proyectos | `Domain` sin referencias |
| L09 | 3.2 | `Producto`, `Dinero`, `DomainException` | `Domain` compila solo |
| L10 ⚠ | 3.3 | Asignar `Precio` desde afuera | CS0200: el setter privado protege la invariante |
| L11 | 4.3 | Pruebas con repositorio falso | La regla se prueba sin base ni HTTP |
| L12 ⚠ | 4.3 | Quitar la regla | Las pruebas la detectan |
| L13 | 5.2 | Arrancar la API | Composition root en marcha |
| L14 | 5.2 | `POST` | 201 con `Location` |
| L15 | 5.2 | `GET` y OpenAPI | El contrato filtra `Activo` |
| L16 | 5.3 | Cambiar a EF Core con SQLite | `Domain.dll` idéntico |
| L17 | 5.3 | Repetir el `GET` | Mismo contrato; `Infrastructure` solo en `Program.cs` |
| L18 ⚠ | 5.5 | Sin `SaveChangesAsync` | 201 y lista vacía |
| L19 ⚠ | 5.6 | JSON mal formado | 400 automático |
| L20 ⚠ | 5.6 | Precio negativo sin traductor | 500 |
| L21 | 5.6 | Manejador de excepciones | 400 con ProblemDetails |
| L22 | 6.3 | Nace `Contracts`; cliente de consola | Un cliente remoto vive con el contrato |
| L23 | 8.1 | `dotnet sln list` | La estructura física |
| L24 | 9.4 | `dotnet list package --vulnerable` | Evaluar una dependencia antes de adoptarla |

**Qué puede cambiar en tu equipo en todos los pasos:** rutas absolutas, identificadores `Guid`, fechas, duraciones y el número de parche del SDK. Lo que no cambia —códigos de error, códigos de estado HTTP, códigos de salida— es lo que verifica `aserciones.log`. El registro incluye una aserción que falla a propósito, para demostrar que el mecanismo detecta.
```

**Por:**

```text
El guion `Dot-NET-Arquitectura-Lab/lab.sh` ejecuta todos los pasos dentro del contenedor del SDK, guarda cada salida en `capturas/` y verifica lo que no cambia entre equipos en `aserciones.log`. El código final está en `Dot-NET-Arquitectura-Lab/MyProject/`. La columna «Comando» resume el que produjo la captura; el comando completo, con sus rutas, está en la primera línea `# comando:` de cada archivo de `capturas/`. Todos los comandos se ejecutan desde la carpeta `MyProject/` creada en L01, salvo L00, L06 y L24. La columna «Captura» da el nombre del archivo sin la extensión `.txt`.

| Paso | § | Comando | Qué confirma | Captura |
| --- | --- | --- | --- | --- |
| L00 | 0.6 | `dotnet --info`; `curl --version` | El SDK disponible | `L00-entorno` |
| L01 | 1.2 | `dotnet new sln -n MyProject`; `dotnet new globaljson …` | La solución se crea como `.slnx` | `L01-nueva-solucion` |
| L02 | 1.2 | `dotnet new classlib …` ×2; `dotnet sln add …`; `dotnet add … reference …`; `dotnet list … reference`; `dotnet build` | La referencia es una flecha | `L02-dos-proyectos` |
| L03 ⚠ | 1.4 | `dotnet build src/Backend/MyProject.Domain` con un `using` sin referencia | CS0234 y CS0246: el espacio de nombres no crea dependencias | `L03-using-sin-referencia` |
| L04 ⚠ | 1.5 | `dotnet add src/Backend/MyProject.Domain reference src/Backend/MyProject.Infrastructure`; `dotnet build` | Se agrega con código 0; MSB4006 al compilar | `L04-ciclo-agregar`, `L04-ciclo-compilar` |
| L05 | 1.5 | `dotnet remove … reference <carpeta>`; después `… reference <ruta>.csproj`; `dotnet build` | Con la carpeta avisa que no la encuentra pero devuelve 0; con el `.csproj` la quita | `L05-quitar-con-carpeta`, `L05-quitar-con-csproj` |
| L06 | 2.2 | `dotnet build` en el proyecto `TodoJunto` | Nada impide mezclar | `L06-todo-junto` |
| L07 ⚠ | 2.2 | `dotnet build src/Backend/MyProject.Domain` con el mismo código separado | La separación hace cumplir la regla | `L07-separado` |
| L08 | 2.6 | `dotnet new classlib …`; `dotnet new webapi --use-controllers --no-https …`; referencias; `dotnet list … reference`; `dotnet build` | `Domain` sin referencias | `L08-esqueleto` |
| L09 | 3.2 | `dotnet build src/Backend/MyProject.Domain` | `Domain` compila solo | `L09-domain` |
| L10 ⚠ | 3.3 | `dotnet build src/Backend/MyProject.Application` con `producto.Precio = -1m` | CS0200: el setter privado protege la invariante | `L10-setter-privado` |
| L11 | 4.3 | `dotnet new xunit …` ×2; `dotnet sln add …`; `dotnet add … reference …`; `dotnet test` | La regla se prueba sin base ni HTTP | `L11-tests` |
| L12 ⚠ | 4.3 | Quitar las dos líneas que validan el precio; `dotnet test` | Las pruebas la detectan | `L12-regresion` |
| L13 | 5.2 | `dotnet build`; `ASPNETCORE_ENVIRONMENT=Development dotnet run --no-launch-profile --urls http://127.0.0.1:5180 &` | Composition root en marcha | `L13-build-compilar-api`, `L13-arranque` |
| L14 | 5.2 | `curl -s -i -X POST …/api/productos -H 'Content-Type: application/json' -d '{"nombre":"Yerba 1 kg","precio":4500}'` | 201 con `Location` | `L14-post` |
| L15 | 5.2 | `curl -s -i …/api/productos`; `curl -s -i <Location>`; `curl -s …/openapi/v1.json`; `curl -s -i …/api/productos/<Guid inexistente>` | El contrato filtra `Activo`; 404 si el recurso no existe | `L15-get` |
| L16 | 5.3 | `sha256sum …/MyProject.Domain.dll`; `dotnet add src/Backend/MyProject.Infrastructure package Microsoft.EntityFrameworkCore.Sqlite`; `dotnet build -v n`; `sha256sum` otra vez | `Domain.dll` idéntico | `L16-paquete-agregar-efcore`, `L16-compilar-con-efcore` |
| L17 | 5.3 | Repetir L14 y L15; `grep -rn Infrastructure src/Backend/MyProject.WebAPI --include=*.cs` | Mismo contrato; `Infrastructure` solo en `Program.cs` | `L17-mismo-contrato` |
| L18 ⚠ | 5.5 | Reemplazar `SaveChangesAsync` por `Task.CompletedTask`; repetir L14 y L15; restituir; repetir | 201 y lista vacía; después, el producto presente | `L18-sin-savechanges`, `L18-corregido-con-savechanges` |
| L19 ⚠ | 5.6 | `curl … -d '{"nombre":"Mate","precio":}'` | 400 automático | `L19-json-mal-formado` |
| L20 ⚠ | 5.6 | `curl … -d '{"nombre":"Mate","precio":-5}'` | 500 | `L20-regla-sin-traducir` |
| L21 | 5.6 | Registrar `DomainExceptionHandler`; `dotnet build src/Backend/MyProject.WebAPI`; repetir L20 | 400 con ProblemDetails | `L21-build-compilar-manejador`, `L21-regla-traducida` |
| L22 | 6.3 | `dotnet new classlib -n MyProject.Contracts …`; mover los DTO; `dotnet new console -n MyProject.ConsoleClient …`; `dotnet list … reference`; `dotnet build`; `dotnet run --project src/Clients/MyProject.ConsoleClient -- http://127.0.0.1:5180` | Un cliente remoto vive con el contrato | `L22-contracts-nace-contracts`, `L22-build-compilar-solucion`, `L22-cliente-consola` |
| L23 | 8.1 | `dotnet sln list` | La estructura física | `L23-estructura` |
| L24 | 9.4 | En un proyecto descartable: `dotnet add package AutoMapper --version 14.0.0`; `dotnet list package --vulnerable`; `curl -s https://api.nuget.org/v3-flatcontainer/<paquete>/<versión>/<paquete>.nuspec` | Evaluar una dependencia antes de adoptarla | `L24-evaluar-dependencia` |

**Qué puede cambiar en tu equipo en todos los pasos:** rutas absolutas, identificadores `Guid`, fechas, duraciones, el valor de la huella SHA-256 de L16 y el número de parche del SDK. Lo que no cambia —códigos de error, códigos de estado HTTP, códigos de salida— es lo que verifica `aserciones.log`. El registro incluye una aserción que falla a propósito, para demostrar que el mecanismo detecta.
```

**Verificación:** Las 25 filas tienen Comando y Captura; cada nombre de la columna Captura existe como `capturas/<nombre>.txt` (33 archivos); cada comando resumido es prefijo o resumen fiel de la línea `# comando:` de su captura; la fila L15 se verifica tras relanzar el laboratorio.

#### P-80 — `Dot-NET-Arquitectura-Guide.md` — C-07 (DID2-01)

**Reemplazar:**

```text
| 2 | ¿Hay reglas de negocio que se repiten o que conviene probar sin base de datos? | `Domain` y `Application` separados (E-D) | §3, §4 |
```

**Por:**

```text
| 2 | ¿Hay reglas de negocio ricas que se repiten en varios casos de uso? (Si es una regla que solo se quiere probar sin base, alcanza el término medio del §7.5.) | `Domain` y `Application` separados (E-D) | §3, §4, §7.5 |
```

**Verificación:** El Anexo B #2 coincide con §9.2 y §9.3 corregidos.

#### P-81 — `Dot-NET-Arquitectura-Guide.md` — C-16 (Req H-03, Diablo H-06, H-SEG-03, DR-29)

**Reemplazar:**

```text
| MediatR | 12.5.0 Apache-2.0; desde 13.0.0 RPL-1.5 o comercial | [Bogard, 2025](#ref-bogard-2025); L24 |
| AutoMapper | 14.0.0 MIT con vulnerabilidad alta GHSA-rvv3-g6hj-g44x; desde 15.0.0 RPL-1.5 o comercial | [Bogard, 2025](#ref-bogard-2025); [GitHub, 2026](#ref-github-2026); L24 |
| Licencia comunitaria de Lucky Penny Software | Gratuita para organizaciones con ingresos brutos anuales menores a USD 5 millones, con otras condiciones | [Lucky Penny Software, 2025](#ref-luckypenny-2025) |
```

**Por:**

```text
| MediatR | 12.5.0 Apache-2.0; desde 13.0.0 RPL-1.5 o comercial | [Bogard, 2025](#ref-bogard-2025); L24 (la licencia pasa de expresión `Apache-2.0` a archivo `LICENSE.md`) |
| AutoMapper | 14.0.0 es la última MIT; GHSA-rvv3-g6hj-g44x (CVE-2026-32933, alta, denegación de servicio) afecta a < 15.1.1 y a 16.0.0–16.1.0, corregida en 15.1.1 y 16.1.1; desde 15.0.0 RPL-1.5 o comercial | [Bogard, 2025](#ref-bogard-2025); [GitHub, 2026](#ref-github-2026); L24 (la licencia pasa de expresión `MIT` a archivo `LICENSE.md`) |
| Licencia comunitaria de Lucky Penny Software (documento v2.0) | Gratuita para personas y para organizaciones con ingresos brutos anuales menores a USD 5 millones (§4.2.g.3.1) que nunca recibieron más de USD 10 millones de capital externo (§4.2.g.3.2). No disponible para agencias de gobierno ni cuasi gubernamentales (§4.2.g.1) ni para universidades en software institucional u operativo; estudiantes y docentes pueden usarla con fines educativos (§4.2.g.3.3) | [Lucky Penny Software, 2025](#ref-luckypenny-2025) |
| Refit | MIT; genera la implementación con generadores de código; versiones < 7.2.22 con vulnerabilidad crítica GHSA-3hxg-fxwm-8gf7 (CVE-2024-51501, inyección CRLF en encabezados), corregida en 7.2.22 | [ReactiveUI, 2026](#ref-reactiveui-2026); [GitHub, 2024](#ref-github-2024) |
```

**Verificación:** Las cláusulas §4.2.g.1, §4.2.g.3.1–3.3 están en el PDF de https://luckypennysoftware.com/license (v2.0); los rangos de los dos avisos coinciden con api.github.com/advisories; el ancla ref-github-2024 resuelve.

#### P-82 — `Dot-NET-Arquitectura-Guide.md` — C-13 (ED2-02) + C-10 + C-11

**Reemplazar:**

```text
| Término | Definición | § |
| --- | --- | --- |
| `async` / `await` | Forma de escribir operaciones que esperan sin bloquear el hilo | 4.1 |
| Caso de uso | Intención del usuario implementada como una unidad de código que orquesta el dominio | 4.1 |
| Cliente | Aplicación que consume la API por HTTP | 6.1 |
| Código de estado HTTP | Número de tres cifras que resume el resultado de una petición (201, 400, 500) | 5.1 |
| Command | Mensaje que pide cambiar algo | 4.1 |
| Composition root | Único lugar que registra qué implementación corresponde a cada interfaz | 2.1 |
| Contrato | Tipos de petición y respuesta de la API HTTP, en el proyecto `Contracts` | 5.1, 8.5 |
| CQRS | Separar el modelo de escritura del de lectura; no es lo que hace este ejemplo | 4.4 |
| DbContext | Clase de EF Core que representa una sesión con la base y confirma los cambios con `SaveChanges` | 5.1 |
| Dependencia | Relación en la que un código no compila o no funciona sin otro | 2.1 |
| DTO | Objeto sin comportamiento que transporta datos entre procesos o capas | 5.1 |
| Ensamblado | Archivo `.dll` que produce la compilación de un proyecto | 1.1 |
| Entidad | Objeto del negocio con identidad y comportamiento | 3.1 |
| Espacio de nombres | Nombre lógico de un grupo de tipos; no crea dependencias | 1.1 |
| Form model | Objeto mutable que enlaza un formulario | 7.2 f |
| Handler | Clase que ejecuta el caso de uso de un mensaje | 4.1 |
| Interfaz | Tipo que declara métodos sin implementarlos | 2.1 |
| Invariante | Condición que un objeto debe cumplir siempre | 3.1 |
| Inversión de dependencias | Declarar la interfaz adentro e implementarla afuera | 2.1 |
| Inyección de dependencias | Mecanismo que entrega implementaciones a quien pide interfaces | 2.1 |
| JSON | Formato de texto para datos estructurados que usan las API HTTP | 5.1 |
| Middleware | Componente que procesa cada petición HTTP en cadena | 5.1 |
| Modelo de lectura | Objeto plano que devuelve una Query (`ProductoDto`) | 4.1 |
| OpenAPI | Documento que describe los recursos y operaciones de una API HTTP | 5.1 |
| Paquete NuGet | Código de terceros distribuido desde nuget.org | 1.1 |
| Persistence model | Clase con la forma de una tabla, separada de la entidad | 7.2 g |
| ProblemDetails | Formato estándar de cuerpo de error en APIs HTTP (RFC 9457) | 5.6 |
| Proyecto | Unidad de compilación: un `.csproj` y sus archivos | 1.1 |
| Query | Mensaje que pide datos sin cambiar nada | 4.1 |
| `record` | Tipo de C# cuya igualdad compara los datos | 3.1 |
| Referencia de proyecto | Declaración de que un proyecto puede usar los tipos públicos de otro | 1.1 |
| Regla de dependencia | Las dependencias del código apuntan solo hacia adentro | 2.1 |
| Repositorio | Objeto que media entre el dominio y el almacenamiento como si fuera una colección | 4.1 |
| SDK | Herramientas para crear, compilar, probar y ejecutar código .NET | 1.1 |
| Solución | Archivo (`.slnx` o `.sln`) que agrupa proyectos | 1.1 |
| Transaction Script | Organización de la lógica en procedimientos, uno por petición | 3.4 |
| Unidad de trabajo | Grupo de cambios que se confirman juntos; en EF Core, `SaveChanges` | 5.5 |
| Value object | Objeto sin identidad que se compara por su contenido | 3.1 |
| ViewModel | Datos preparados para una pantalla | 7.2 e |
```

**Por:**

```text
| Término | Equivalente en inglés o alias | Definición | § |
| --- | --- | --- | --- |
| ASP.NET Core | — | Marco de Microsoft para construir aplicaciones web y API HTTP en .NET | 2.1 |
| `async` / `await` | `Task` | Forma de escribir operaciones que esperan sin bloquear el hilo | 4.1 |
| Blazor | — | Tecnología de Microsoft para construir páginas web con componentes C# (`.razor`) | 6.1 |
| `CancellationToken` | — | Parámetro con el que una operación que espera puede interrumpirse si quien la pidió ya no espera el resultado | 3.1 |
| Caso de uso | *use case* | Intención del usuario implementada como una unidad de código que orquesta el dominio | 4.1 |
| CLI `dotnet` | *command-line interface* | Interfaz de línea de comandos del SDK: el comando `dotnet` | 1.1 |
| Cliente | *client* | Aplicación que consume la API por HTTP | 6.1 |
| Código de estado HTTP | *status code* | Número de tres cifras que resume el resultado de una petición (201, 400, 404, 500) | 5.1 |
| Command | comando (un tipo de mensaje) | Mensaje que pide cambiar algo | 4.1 |
| Composition root | raíz de composición | Único lugar que registra qué implementación corresponde a cada interfaz | 2.1 |
| Configuración Fluent API | *Fluent API configuration* | Clase que indica a EF Core cómo mapear una entidad sin modificarla | 5.1 |
| Contrato | *contract* | Tipos de petición y respuesta de la API HTTP, en el proyecto `Contracts` | 5.1, 8.5 |
| Controller | controlador | Clase que recibe peticiones HTTP de una ruta y devuelve respuestas | 5.1 |
| CQRS | *Command Query Responsibility Segregation* | Separar el modelo de escritura del de lectura; no es lo que hace este ejemplo | 4.4 |
| CRUD | alta, baja, modificación y consulta | Las cuatro operaciones básicas sobre datos (*create, read, update, delete*) | 0.4, 9.1 |
| `curl` | — | Programa de línea de comandos que envía peticiones HTTP y muestra la respuesta | 5.1 |
| DbContext | — | Clase de EF Core que representa una sesión con la base y confirma los cambios con `SaveChanges` | 5.1 |
| Decorador | *decorator* | Clase que implementa la misma interfaz que otra, agrega un trabajo y delega en la original | 4.5 |
| Dependencia | *dependency* | Relación en la que un código no compila o no funciona sin otro | 2.1 |
| Doble de prueba | *test double*, *fake* | Implementación falsa escrita para las pruebas, como `FakeProductoRepository` | 4.3, 6.2 |
| DTO | *Data Transfer Object* | Objeto sin comportamiento que transporta datos entre procesos o capas | 5.1 |
| EF Core | Entity Framework Core | Biblioteca de Microsoft que traduce objetos a filas de una base relacional | 2.1, 5.1 |
| Ensamblado | *assembly* | Archivo `.dll` que produce la compilación de un proyecto | 1.1 |
| Entidad | *Entity* | Objeto del negocio con identidad y comportamiento | 3.1 |
| Espacio de nombres | *namespace* | Nombre lógico de un grupo de tipos; no crea dependencias | 1.1 |
| Excepción de dominio | *domain exception* | Excepción propia (`DomainException`) que señala una regla de negocio incumplida | 3.1 |
| Form model | modelo de formulario | Objeto mutable que enlaza un formulario | 6.1, 7.2 f |
| `Guid` | *globally unique identifier* | Identificador único de 128 bits que .NET genera con `Guid.NewGuid()` | 3.1 |
| Handler | manejador | Clase que ejecuta el caso de uso de un mensaje | 4.1 |
| Interfaz | *interface* | Tipo de C# que declara métodos sin implementarlos | 2.1 |
| Interfaz de servicio técnico | — | Declaración, en `Application`, de una capacidad técnica (correo, usuario actual) que `Infrastructure` implementa | 4.1 |
| Invariante | *invariant* | Condición que un objeto debe cumplir siempre | 3.1 |
| Inversión de dependencias | *dependency inversion* | Declarar la interfaz adentro e implementarla afuera | 2.1 |
| Inyección de dependencias | DI, *dependency injection* | Mecanismo que entrega implementaciones a quien pide interfaces | 2.1 |
| JSON | *JavaScript Object Notation* | Formato de texto para datos estructurados que usan las API HTTP | 5.1 |
| MAUI Blazor Hybrid | — | Aplicación nativa .NET MAUI cuyos componentes Razor corren en el dispositivo y se dibujan en un *Web View* incrustado | 6.1 |
| Mensaje | *message* | Objeto que transporta los datos de una intención: un Command o una Query | 4.1 |
| Método de fábrica | *factory method* | Método `static` que es el único camino para crear instancias y verifica las invariantes | 3.1 |
| Middleware | — | Componente que procesa cada petición HTTP en cadena | 5.1 |
| Modelo de lectura | *read model* | Objeto plano que devuelve una Query (`ProductoDto`) | 4.1 |
| OpenAPI | — | Documento que describe los recursos y operaciones de una API HTTP | 5.1 |
| Paquete NuGet | *NuGet package* | Código de terceros distribuido desde nuget.org | 1.1 |
| Persistence model | modelo de persistencia | Clase con la forma de una tabla, separada de la entidad | 7.2 g |
| Petición HTTP | *HTTP request* | Mensaje de un cliente a un servidor con verbo, ruta, encabezados y, a veces, cuerpo | 5.1 |
| Plantilla | *template* | Punto de partida de `dotnet new` (`classlib`, `webapi`, `console`, `xunit`) | 1.1 |
| ProblemDetails | — | Formato estándar de cuerpo de error en APIs HTTP (RFC 9457) | 5.1, 5.6 |
| Proyecto | *project* | Unidad de compilación: un `.csproj` y sus archivos | 1.1 |
| Prueba unitaria | *unit test* | Método `[Fact]` que ejecuta una porción de código y verifica el resultado con `Assert` | 4.3 |
| Query | consulta (un tipo de mensaje) | Mensaje que pide datos sin cambiar nada | 4.1 |
| Razor Class Library | RCL | Proyecto que empaqueta componentes `.razor`, estilos y recursos para reutilizarlos en varias aplicaciones | 6.1 |
| `record` | — | Tipo de C# cuya igualdad compara los datos | 3.1 |
| Referencia de proyecto | `ProjectReference` | Declaración de que un proyecto puede usar los tipos públicos de otro | 1.1 |
| Regla de dependencia | *Dependency Rule* | Las dependencias del código apuntan solo hacia adentro | 2.1 |
| Repositorio | *Repository* | Objeto que media entre el dominio y el almacenamiento como si fuera una colección | 4.1 |
| SDK | *software development kit* | Herramientas para crear, compilar, probar y ejecutar código .NET | 1.1 |
| Servicio de API del cliente | — | Clase del cliente que encapsula las llamadas HTTP a la API detrás de una interfaz | 6.1 |
| Setter privado | `private set` | Propiedad que se lee desde cualquier lugar y se modifica solo dentro de la clase | 3.1 |
| Solución | *solution* | Archivo (`.slnx` o `.sln`) que agrupa proyectos | 1.1 |
| Transaction Script | — | Organización de la lógica en procedimientos, uno por petición | 3.4 |
| Unidad de trabajo | *Unit of Work* | Grupo de cambios que se confirman juntos; en EF Core, `SaveChanges` | 5.1, 5.5 |
| Value object | objeto de valor | Objeto sin identidad que se compara por su contenido | 3.1 |
| ViewModel | modelo de vista | Datos preparados para una pantalla | 6.1, 7.2 e |
```

**Verificación:** Cada término definido en negrita en §1.1–§6.1 (`grep -o -E '^- \*\*[^*]+\*\*'`) tiene fila; la tabla tiene 4 columnas; las § de ProblemDetails y Unidad de trabajo incluyen 5.1.

#### P-83 — `Dot-NET-Arquitectura-Guide.md` — C-16 (Refit) + C-25 (422)

**Reemplazar:**

```text
<a id="ref-github-2026"></a>GitHub Advisory Database. (2026). *GHSA-rvv3-g6hj-g44x: AutoMapper*. https://github.com/advisories/GHSA-rvv3-g6hj-g44x (consultado el 2026-09-18).
```

**Por:**

```text
<a id="ref-github-2024"></a>GitHub Advisory Database. (2024). *GHSA-3hxg-fxwm-8gf7: CRLF injection in Refit's [Header], [HeaderCollection] and [Authorize] attributes*. https://github.com/advisories/GHSA-3hxg-fxwm-8gf7 (consultado el 2026-09-18).

<a id="ref-github-2026"></a>GitHub Advisory Database. (2026). *GHSA-rvv3-g6hj-g44x: AutoMapper*. https://github.com/advisories/GHSA-rvv3-g6hj-g44x (consultado el 2026-09-18).

<a id="ref-ietf-2022"></a>IETF. (2022). *RFC 9110: HTTP Semantics*, §15.5.21 «422 Unprocessable Content». https://www.rfc-editor.org/rfc/rfc9110.html#section-15.5.21 (consultado el 2026-09-18).
```

**Verificación:** Las anclas ref-github-2024 y ref-ietf-2022 resuelven y cada una tiene al menos una cita en el cuerpo.

#### P-84 — `Dot-NET-Arquitectura-Guide.md` — C-10 (curl) + C-21 (H-SEG-02) + C-04 (SQLite) + C-23 (global.json)

**Reemplazar:**

```text
<a id="ref-reactiveui-2026"></a>ReactiveUI. (2026). *Refit* (README del repositorio). https://github.com/reactiveui/refit (consultado el 2026-09-18).
```

**Por:**

```text
<a id="ref-microsoft-2026i"></a>Microsoft. (2026i). *ASP.NET Core Blazor WebAssembly additional security scenarios*. https://learn.microsoft.com/en-us/aspnet/core/blazor/security/webassembly/additional-scenarios?view=aspnetcore-10.0 (consultado el 2026-09-18).

<a id="ref-microsoft-2026j"></a>Microsoft. (2026j). *Data types — Microsoft.Data.Sqlite*. https://learn.microsoft.com/en-us/dotnet/standard/data/sqlite/types (consultado el 2026-09-18).

<a id="ref-microsoft-2026k"></a>Microsoft. (2026k). *global.json overview* (sección «rollForward»). https://learn.microsoft.com/en-us/dotnet/core/tools/global-json#rollforward (consultado el 2026-09-18).

<a id="ref-curl-2026"></a>curl project. (2026). *curl.1 the man page*. https://curl.se/docs/manpage.html (consultado el 2026-09-18).

<a id="ref-reactiveui-2026"></a>ReactiveUI. (2026). *Refit* (README del repositorio). https://github.com/reactiveui/refit (consultado el 2026-09-18).
```

**Verificación:** Las cuatro anclas nuevas resuelven; cada una tiene al menos una cita en el cuerpo; el script de anclas da 0 rotos y 0 entradas huérfanas.

#### P-L1 — `Dot-NET-Arquitectura-Lab/lab.sh` — C-QA-03 (aserción de L12 débil)

**Reemplazar:**

```text
ok L12 "las pruebas detectan la regla faltante" '(Failed!|failed)'
```

**Por:**

```text
ok L12 "falla la prueba de Domain que depende de la regla" 'Failed MyProject\.Domain\.Tests\.ProductoTests\.Create_con_precio_negativo_lanza_DomainException'
ok L12 "falla la prueba de Application que depende de la regla" 'Failed MyProject\.Application\.Tests\.CrearProductoHandlerTests\.Handle_con_precio_negativo_no_guarda_nada'
ok L12 "en Domain falla exactamente una de tres" 'Failed! +- Failed: +1, Passed: +2, Skipped: +0, Total: +3'
ok L12 "en Application falla exactamente una de dos" 'Failed! +- Failed: +1, Passed: +1, Skipped: +0, Total: +2'
```

**Verificación:** Tras relanzar: aserciones.log tiene cuatro líneas `PASS L12 …`; prueba negativa: cambiar `+1, Passed: +2` por `+2, Passed: +1` y ver FAIL.

#### P-L2 — `Dot-NET-Arquitectura-Lab/lab.sh` — C-QA-05 (404 sin captura, opción completa)

**Reemplazar:**

```text
cap L15 get "curl -s -i $API/api/productos; echo; echo; curl -s -i $LOC; echo; echo; curl -s $API/openapi/v1.json | head -c 400"
```

**Por:**

```text
cap L15 get "curl -s -i $API/api/productos; echo; echo; curl -s -i $LOC; echo; echo; curl -s $API/openapi/v1.json | head -c 400; echo; echo; curl -s -i $API/api/productos/00000000-0000-0000-0000-000000000000 | head -1"
```

**Verificación:** Tras relanzar: capturas/L15-get.txt termina con `HTTP/1.1 404 Not Found`.

#### P-L3 — `Dot-NET-Arquitectura-Lab/lab.sh` — C-QA-05

**Reemplazar:**

```text
ok L15 "documento OpenAPI" '\"openapi\"'
```

**Por:**

```text
ok L15 "documento OpenAPI" '\"openapi\"'
ok L15 "404 para un id inexistente" 'HTTP/1.1 404'
```

**Verificación:** Tras relanzar: aserciones.log contiene `PASS L15 404 para un id inexistente`.

#### P-L4 — `Dot-NET-Arquitectura-Lab/lab.sh` — C-QA-02 (aserción de L24 vacía)

**Reemplazar:**

```text
ok L24 "licencia de AutoMapper 15 no es MIT" 'automapper/15\.0\.0'
```

**Por:**

```text
lic() { body "$LAST" | grep -A1 -F "== $1" | tail -1; }   # línea <license …> que sigue al encabezado
if lic automapper/14.0.0 | grep -q 'expression">MIT<';        then echo "PASS L24 AutoMapper 14.0.0 es MIT" >> "$LAB/aserciones.log"; else echo "FAIL L24 AutoMapper 14.0.0 no muestra MIT" >> "$LAB/aserciones.log"; fi
if lic automapper/15.0.0 | grep -q 'type="file"';              then echo "PASS L24 AutoMapper 15.0.0 declara licencia por archivo (no MIT)" >> "$LAB/aserciones.log"; else echo "FAIL L24 AutoMapper 15.0.0 no muestra licencia por archivo" >> "$LAB/aserciones.log"; fi
if lic mediatr/12.5.0    | grep -q 'expression">Apache-2.0<'; then echo "PASS L24 MediatR 12.5.0 es Apache-2.0" >> "$LAB/aserciones.log"; else echo "FAIL L24 MediatR 12.5.0 no muestra Apache-2.0" >> "$LAB/aserciones.log"; fi
```

**Verificación:** Tras relanzar: tres líneas `PASS L24 …` nuevas y ninguna `licencia de AutoMapper 15 no es MIT`; prueba negativa: cambiar `MIT<` por `MIX<` y ver FAIL. Conteo final esperado: `PASS: 74  FAIL: 1`.

#### P-B1 — `OUTPUTs/Bitacora/02-Requisitos.md` — C-17 (Req H-04, solicitud de Edición: alcance de R-09)

**Reemplazar:**

```text
| R-09 | Preguntas guía formadoras de criterio con «cuándo sí/no» | Cada capítulo cierra con una pregunta de aplicabilidad en términos E-A..E-D | grep de «¿Cuándo no» por capítulo ≥ 1 | DR-15 |
```

**Por:**

```text
| R-09 | Preguntas guía formadoras de criterio con «cuándo sí/no» | Cada capítulo cierra con una pregunta de aplicabilidad en términos E-A..E-D | grep de «¿Cuándo no» por capítulo ≥ 1 en §1–§6 y §8; en §7 y §9 la pregunta de aplicabilidad es §7.5 y §9.3 (decisión del ciclo 2, C-17) | DR-15 |
```

**Verificación:** La fila R-09 registra la decisión; el chequeo pasa con la guía parcheada (§8.6).

#### P-B2 — `OUTPUTs/Bitacora/00-Fuente-Conversacion.md` — C-22 (Arq H-05)

**Reemplazar:**

```text
| F-09 | El contrato filtra campos; WASM no tiene el ensamblado de dominio | §5.2 (L15), §7.4 | — |
```

**Por:**

```text
| F-09 | El contrato filtra campos; WASM no tiene el ensamblado de dominio | §5.2 (L15), §7.4 | Ajuste del ciclo 2 (C-22): §7.4 dice que el ensamblado de `Domain` podría descargarse al navegador pero que no habría base ni repositorio que respalden a la entidad; el punto de la fuente (la página no trabaja con la entidad) se conserva |
```

**Verificación:** La fila F-09 declara el ajuste; R-01 sigue trazado.

#### P-85 — `Dot-NET-Arquitectura-Guide.md` — C-14 (ED2-03, DR-05)

**Reemplazar:**

```text
*salida registrada: `capturas/L06-todo-junto.txt`*
```

**Por:**

```text
*salida registrada: `capturas/L06-todo-junto.txt`, SDK 10.0.400*
```

**Verificación:** Toda marca de captura lleva «SDK 10.0.400».

#### P-86 — `Dot-NET-Arquitectura-Guide.md` — C-14 (ED2-03, DR-05)

**Reemplazar:**

```text
*salida registrada: `capturas/L07-separado.txt`*
```

**Por:**

```text
*salida registrada: `capturas/L07-separado.txt`, SDK 10.0.400*
```

**Verificación:** Toda marca de captura lleva «SDK 10.0.400».

#### P-SYNC — `Dot-NET-Arquitectura-Guide.md` — C-01 (relanzamiento) — se aplica después de correr lab.sh

**Reemplazar:**

```text
(valores variables de los extractos: Guid de L14/L15/L17/L22, huella SHA-256 de L16, duraciones de L11/L12, fechas; tal como queden en la guía tras los parches P-26, P-27, P-38, P-39)
```

**Por:**

```text
(los mismos valores copiados de las capturas de la corrida vigente, sin alterar ninguna otra palabra de los bloques)
```

**Verificación:** Chequeo V-LIT: para cada bloque ```text con marca «Salida registrada: capturas/X», cada línea (sin la sangría inicial, uniendo la continuación sangrada a su línea anterior, saltando `...` y tratando `...` dentro de una línea como comodín) es subcadena de alguna línea de capturas/X. Debe dar 0 líneas sin respaldo.


---

## 4. Orden de aplicación y verificación

### 4.1 Orden

1. **Guion:** aplicar P-L1..P-L4 a `lab.sh`. Prueba negativa antes de correr: cambiar temporalmente `MIT<` por `MIX<` en P-L4 y `+1, Passed: +2` por `+2, Passed: +1` en P-L1, correr solo esas líneas contra las capturas actuales con `body()` y ver los `FAIL`; restaurar.
2. **Relanzar el laboratorio** con la misma imagen y digest del frontmatter (`docker run --rm --user "$(id -u):$(id -g)" -e IMAGEN=mcr.microsoft.com/dotnet/sdk:10.0 -e DIGEST=sha256:e1ffd2a9… -v "$PWD":/lab -w /lab mcr.microsoft.com/dotnet/sdk:10.0 bash lab.sh` desde `Dot-NET-Arquitectura-Lab/`). Esperado: `aserciones.log` termina en `PASS: 74  FAIL: 1`; `capturas/L15-get.txt` contiene `HTTP/1.1 404 Not Found`; cuatro `PASS L12`, tres `PASS L24` nuevos, `PASS L15 404 para un id inexistente`. Si el conteo no coincide, no se sigue: el hallazgo vuelve a auditoría como `regresión`.
3. **Guía:** aplicar P-01..P-86 (orden indistinto; ningún fragmento se solapa con otro).
4. **P-SYNC:** copiar de las capturas nuevas los valores variables de los extractos (Guid de L14/L15/L17/L22, huella de L16, duraciones de L11/L12) sin tocar ninguna otra palabra.
5. **Bitácoras:** P-B1, P-B2. Registrar además en la Bitácora 04 la quinta corrida (fecha, PASS/FAIL) y este ciclo.
6. **Chequeos mecánicos de cierre** (§4.2). Si alguno falla, se revierte el parche responsable y su hallazgo vuelve a auditoría.
7. Versión de la guía: `2.0.1`, `last_review` sin cambio (misma fecha). Changelog en la Bitácora 04: hallazgo → veredicto → parche → verificación.

### 4.2 Chequeos mecánicos de cierre (todos deben pasar)

| Chequeo | Esperado | Estado en la simulación (V12) |
|---|---|---|
| Anclas internas (script de Edición/Requisitos) | 0 rotas; 0 referencias `ref-` huérfanas o sin entrada | 72 enlaces, 0 rotos, 0 huérfanas |
| R-03: `grep -i -c 'versión anterior\|guía vigente'` | 0 | 0 |
| DR-18: lista de palabras prohibidas fuera de URL; `leé\|pasá` | 0 | 0 |
| DR-12: `interfaz visual\|interfaces web\|validación de interfaz\|La interfaz se carga`; alias prohibidos | 0 | 0 |
| DR-09: línea previa a cada ```csharp es un rótulo | 11 de 11 (más el bloque nuevo de §3.2: 12) | 0 sin rótulo |
| DR-05: toda marca «alida registrada» lleva `SDK 10.0.400` | 0 sin SDK | 0 sin SDK |
| R-09: «¿Cuándo no» por capítulo | ≥ 1 en §1–§6 y §8; §7.5 y §9.3 por P-B1 | §1–§6 y §8 = 1 |
| DR-14: PyYAML (`python:3-slim`) | `prerequisites` con 2 ítems; `traces` con 27 | pendiente (sin PyYAML en el host) |
| DR-08: `wc -l` por `##` | §0 ≤ 90, §1 ≤ 130, §2 ≤ 150, §3 ≤ 120, §4 ≤ 140, §5 ≤ 190, §6 ≤ 150, §7 ≤ 170, §8 ≤ 110, §9 ≤ 150; total ≤ 1600 | Todos dentro salvo **§5 = 196** (véase deuda D-03); total 1425 |
| Mermaid | 6/6 renderizan | sin cambios en los bloques |
| **V-LIT** (nuevo, cubre el hueco por el que pasó C-01): para cada bloque ```text con marca «Salida registrada: capturas/X» en las 12 líneas anteriores o posteriores, cada línea del bloque (sin sangría inicial; uniendo a la anterior una línea de continuación sangrada; saltando las líneas `...`; tratando `...` dentro de una línea como comodín) es subcadena de alguna línea de `capturas/X`. El árbol de §8.1 no es un extracto y queda fuera | 0 líneas sin respaldo | 0 en 15 bloques (con las capturas actuales; se repite tras P-SYNC) |
| `aserciones.log` | `PASS: 74  FAIL: 1`; una línea `FAIL L02-provocada` | pendiente del relanzamiento |
| Bloques [Compilado] contra `MyProject/` (diff línea a línea, admitiendo omisión de `using`, namespace, clase, campos y constructor) | 10 de 10 iguales | P-20, P-25 y P-44 los dejan iguales |

---

## 5. Escaladas al humano

Ninguna. Chequeo de los siete disparadores del §6 del marco:

| # | Disparador | ¿Se dispara? | Por qué |
|---|---|---|---|
| 1 | Ambigüedad de intención irresoluble | No | Las dos lecturas de E-A (C-05) y de la señal «probar la regla» (C-07) se resolvieron con evidencia interna (§9.1, §9.2, L11) |
| 2 | Conflicto entre restricciones duras | No | «No inventar» y «comandos probables» empujan en la misma dirección que R-06 y R-13 |
| 3 | Cambio de alcance | No | Ningún parche agrega ni quita lo que la guía promete; el 404 de L15 ejercita código que ya existía |
| 4 | Irreversibilidad con impacto real | No | Texto y guion versionados; el relanzamiento regenera capturas que git conserva |
| 5 | Dominio con consecuencia externa | No | C-16 informa licencias y vulnerabilidades con fuente primaria verificada (V7, V8, V9) y la guía sigue sin adoptar los paquetes (DA-4) |
| 6 | Empate persistente | No | Un 3-2 (C-25 «en ese orden») resuelto en primera ronda por mayoría simple |
| 7 | Reapertura de decisión cerrada | No | §2.4 |

---

## 6. Bloque de cierre (§7 del marco)

Criterio de parada que se cumple: **se agotó `ciclos_max` (2)**. Además, tras aplicar y verificar los parches no queda ningún hallazgo abierto por encima del umbral (S1/S2): todos los S2 (C-01, C-05, C-07, C-13, C-15, C-16, C-26) tienen parche con verificación. No hay rendimientos decrecientes (el ciclo 2 produjo 24 raíces `PROCEDE` de severidad ≥ S3 frente a 24 del ciclo 1), pero el marco cierra por cualquiera de los criterios.

Condición del cierre: el cierre queda **condicionado** a que los pasos 1–6 de §4.1 pasen. Si un parche S2 falla su verificación, el ciclo no cierra: el hallazgo vuelve a auditoría como `regresión` y se resuelve antes del changelog.

```yaml
cierre:
  version_final: Dot-NET-Arquitectura-Guide.md 2.0.1 (tras aplicar P-01..P-86, P-L1..P-L4, P-SYNC, P-B1, P-B2)
  ciclos_ejecutados: 2
  panel:
    convocados:
      - Requisitos: 6 procedentes de 7 (H-01..H-05, H-07; H-06 absorbido en C-16)
      - Verificación/QA: 7 de 7 (QA-01..QA-06; QA-07 en lote S4)
      - Lector novato: 7 de 7 (H-NOV-01..07; 04 y 05 fusionados en C-14/C-15)
      - Abogado del diablo: 7 de 7 (H-01 con forma distinta a la propuesta; H-05 resuelto por E1 de otros; H-07 parcial 3-2)
      - E-Didáctica: 7 de 7 (DID2-07 parcial: NO_PROCEDE las diez tablas restantes)
      - E-Edición: 6 de 7 (ED2-01..ED2-06; ED2-07 en lote S4, renumeración NO_APLICAR; ED2-05 parcial: rótulo de DR-11 se conserva)
      - E-Arquitecto .NET: 7 de 7 (H-01..H-07)
      - Seguridad (mandato acotado): 3 de 3 (H-SEG-01..03)
    descartados: []
    ad_hoc:
      - AH-001: disuelto en el ciclo 1; su reconvocatoria acotada (pedida por Diablo) la absorbió el juez de evidencia con V7–V9; aportó la fila de Refit y la precisión de la licencia v2.0
    postergados_por_cupo: []
    aporte_nulo: []
  hallazgos: { detectados: 52, consolidados: 26, procedentes: 24 raíces (33 ítems votados; 27 PROCEDE, 5 NO_PROCEDE/NO_APLICAR, 1 lote), aplicados: 0 (pendiente del editor), revertidos: 0 }
  coherencia: { contradicciones: 0 (C-05 y C-07 resueltas por P-06/P-46/P-53/P-58/P-69 y P-73/P-74/P-80), requisitos_sin_criterio: 0, requisitos_sin_prueba: 0 (R-15 se cumple con este documento y el changelog), tareas_huérfanas: 0 }
  deuda_declarada:
    - D-01 Tablas ✅/❌ en las diez decisiones restantes (§1.3, §1.4, §1.5, §2.4, §5.3, §5.4, §6.3, §7.4, §8.2, §8.5): NO_PROCEDE 4-1; §0.3 reescrito para que la promesa sea verdadera (P-04)
    - D-02 Letras 2026a–h del Anexo E sin criterio declarado: NO_APLICAR 5-0 (17 anclas por un beneficio de forma); las entradas nuevas siguen la secuencia
    - D-03 DR-08: §5 queda en 196 líneas (≤ 190). Las seis de exceso vienen de literalidad (P-44) y de reproducibilidad (P-33, P-30), restricciones duras del PO que el jurado antepone al presupuesto de extensión; se declara y no se recorta
    - D-04 Rótulo «Qué puede cambiar en tu equipo» (segunda persona) se conserva por DR-11; objeción de Ri registrada (NO_PROCEDE 4-1)
    - D-05 Extracto de L03 partido en dos líneas con sangría: admitido por la política de recorte de §0.5 (P-07), no por literalidad
    - D-06 Escalón 2 (término medio) sin práctica de laboratorio: rotulado «Criterio de esta guía» conforme a CT-01 del ciclo 1; se nombra ahora en §0.4, §7.5 y §9.3
  escaladas_pendientes: []
  capas_a_revalidar:
    - Dot-NET-Arquitectura-Lab/capturas/* y aserciones.log (corrida 5; conteo esperado PASS 74 / FAIL 1)
    - Extractos de la guía con valores variables (P-SYNC; chequeo V-LIT)
    - Bitacora/00-Fuente-Conversacion.md fila F-09 (P-B2); Bitacora/02-Requisitos.md fila R-09 (P-B1); Bitacora/04-Laboratorio-y-Redaccion.md (corrida 5 y changelog; extensión por sección actualizada)
    - Mesa/03-Ciclo2-* (este documento) como evidencia de R-15
```

---

## 7. Registro de convocatoria contrastado con los hallazgos (§5.1 del marco)

Los ocho roles aportaron hallazgos con veredicto `PROCEDE`; ninguno queda en «señal presente, aporte nulo». Seguridad, convocada 4-1 con mandato acotado, produjo tres procedentes dentro del mandato y una solicitud fuera de él que se resolvió sin convocar a Operación. El voto en contra de CB en el ciclo 1 («alcanza con retirar la afirmación») no se sostuvo: la afirmación de §6.5 era verdadera pero inaccionable, y el fragmento era un modelo inseguro a copiar.
