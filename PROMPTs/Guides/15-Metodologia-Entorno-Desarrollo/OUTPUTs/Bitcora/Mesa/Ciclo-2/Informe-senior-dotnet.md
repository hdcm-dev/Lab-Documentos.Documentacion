# Informe de la mesa: Senior .NET, ciclo 2

- **Especialista:** Senior .NET. Cubre Roslyn y codificación, MSBuild, `global.json`/`rollForward`, lock de NuGet y CPM, `Deterministic`/`ContinuousIntegrationBuild`, Source Link, Visual Studio frente a la CLI, imágenes oficiales del SDK.
- **Objeto:** `LAB/Lab-Documentos/Guides/Metodologia-Entorno-Desarrollo/Metodologia-Entorno-Desarrollo-Guide.md` (3391 líneas, `1.0.0-rc.1`), leída como obra terminada, con el laboratorio `Examples/` como respaldo.
- **Fecha:** 2026-10-09. Revisión a ciegas: no leí informes de otros especialistas del ciclo 2. Del ciclo 1 leí sólo mi informe, el consolidado y la deuda de `05-Aplicacion.md` §8, para no volver a discutir lo que ya se cerró.
- **Experimentos propios:** corridos en el scratchpad de la sesión con `mcr.microsoft.com/dotnet/sdk:8.0` (8.0.425). Las salidas quedaron copiadas en `Ciclo-2/evidencia-senior-dotnet/`.
- **Verificación de lo aplicado en el ciclo 1:** C1-01, C1-02, C1-04, C1-26, C1-52 y C1-53 están en el texto y son correctos (ver «Revisado y bien»). Dos deudas que el ciclo 1 dejó para este ciclo siguen abiertas en la guía: D-1 (hallazgo 01) y D-2 (hallazgo 02).

---

## Hallazgos

### senior-dotnet-01: la regla «lock sólo en los ejecutables» (A.4b) deja fuera, sin aviso, a WinForms/WPF y a los proyectos de prueba, y la CI sigue en verde (D-1 sin aplicar)

- **Ubicación:** Anexo A.4b, L2552–L2558 (`<PropertyGroup Condition="'$(OutputType)' == 'Exe'">`). Depende de esa regla lo que dicen §6.4 L1044 («`packages.lock.json` en los ejecutables»), §7.4 L1222 y §7.6 L1267.
- **Nivel:** E1. **Severidad:** S2.
- **Ancla** (`evidencia-senior-dotnet/lock-outputtype.txt` y `lock-winexe-ci.txt`; `Directory.Build.props` y `.targets` copiados de `Examples/A-plantillas/repo/`):

```text
SDK 8.0.425
== winexe (UseWPF, OutputType=WinExe)   OutputType=WinExe   RestorePackagesWithLockFile=""
== web (Sdk.Web)                        OutputType=Exe      RestorePackagesWithLockFile=true
== test (Microsoft.NET.Test.Sdk)        OutputType=Library  RestorePackagesWithLockFile=""
   tras el restore:                     OutputType=Exe      RestorePackagesWithLockFile=true   ← evaluación de build
   restore 2:                           sin packages.lock.json                                  ← evaluación de restore
== WinExe con CI=true (A.4 + A.4b)      RestoreLockedMode=true
   Restored /w/winexe/winexe.csproj     rc=0   ls: cannot access 'winexe/packages.lock.json'
```

- **Qué está mal:**
  1. `WinExe` es el `OutputType` que escriben las plantillas de WinForms y WPF. Además, desde el SDK 5.0.100 el propio SDK cambia `Exe` por `WinExe` en esas aplicaciones («*when `OutputType` is set to `Exe`, it is automatically changed to `WinExe` for WPF and Windows Forms apps*», learn.microsoft.com/dotnet/core/compatibility/sdk/5.0/automatically-infer-winexe-output-type, consultado el 2026-10-09). En las dos situaciones la regla no se cumple, el proyecto queda sin lock y `RestoreLockedMode` no tiene nada que verificar, así que el restore termina con 0. ESC-01 (Windows con Visual Studio) es justamente donde viven esas aplicaciones de escritorio.
  2. En un proyecto de pruebas, `Microsoft.NET.Test.Sdk` pone `OutputType=Exe` desde un `.props` del paquete. El restore se evalúa sin las importaciones de paquetes, así que ese proyecto **nunca** recibe lock. La evaluación de build, en cambio, dice `RestorePackagesWithLockFile=true`. Quien inspeccione con `-getProperty` concluye lo contrario de lo que hace el restore.
  3. La guía no dice nada de esto: `grep -c WinExe` → 0.
- **Dirección:**
  1. Aplicar la condición medida en D-1: `'$(OutputType)' == 'Exe' Or '$(OutputType)' == 'WinExe'`.
  2. Agregar en A.4b una línea: «los proyectos de prueba no reciben lock por esta regla; si se los quiere congelar, `RestorePackagesWithLockFile` explícito en su `.csproj`».
  3. Que la compuerta haga visible el hueco: avisar si un proyecto ejecutable no tiene `packages.lock.json`.
  4. Si se aplica en `Examples/A-plantillas`, sumar a EA-1 un proyecto `WinExe` con `EnableWindowsTargeting=true`.
  5. **[no verificado]** (requiere Windows): si la inferencia `Exe` → `WinExe` ocurre antes de que se importe `Directory.Build.targets`. La condición con `Or` cubre los dos casos.

### senior-dotnet-02: la defensa de la política por defecto contra `NU1603` existe sólo como frase (D-2); se implementa en diez líneas y el laboratorio no la tiene

- **Ubicación:** §7.2.1 L1179 («**[criterio]** Con lock, la compuerta compara `requested` con `resolved`…»); §7.9 L1304, práctica 1, que da ese control como *respuesta esperada*; A.11 y `Examples/N7-compuertas-y-gobierno/compuerta/compuerta.sh`, que no lo tienen (`grep -rn requested Examples/**/*.sh` sólo encuentra diagnósticos de experimentos).
- **Nivel:** E1. **Severidad:** S2.
- **Ancla** (`evidencia-senior-dotnet/requested-vs-resolved.py` y `.txt`, sobre los locks de E4-2 regenerados con SDK 8.0.425):

```text
== base (Logging 8.0.0, Options 8.0.2 con pinning)
requested=resolved: OK                                                      rc=0
== Primitives 8.0.2 (inexistente), con lock: el restore no emite NU1603
lock: Microsoft.Extensions.Primitives pide [8.0.2, ) y resolvió 9.0.0 (net8.0)
requested≠resolved: REVISAR                                                 rc=1
```

- **Qué está mal:**
  - La política que la guía adopta por defecto en .NET (con lock) es la que, según la propia guía, «desarma» `NU1603` (E4-2).
  - El control que lo compensa no está en la compuerta copiable (A.11/N7). Tampoco tiene experimento.
  - La práctica 7.9.1 pide al lector una respuesta que el laboratorio no puede mostrarle.
  - El resultado es que quien copia las plantillas tal como están se queda sin la defensa.
- **Dirección:**
  1. Llevar el chequeo (recorrer `dependencies`, y en las entradas `Direct` y `CentralTransitive` comparar la cota inferior de `requested` con `resolved`) a `compuerta.sh` como paso del grafo. Anclarlo con la salida de arriba como E4-2 paso 6 o como parte de E7.
  2. Declarar su límite como **[criterio]**: también marca una subida legítima, la de una transitiva que exige más de lo que se fijó centralmente. En CPM esa subida es la señal de que la versión central quedó vieja, así que el aviso pide revisar, no rechazar.
  3. Si no se implementa, bajar el tono de §7.2.1 y §7.9.1 para que no se presente como una defensa existente.

### senior-dotnet-03: las plantillas fijan el SDK 8.0.425 sin decir que sale de soporte el 2026-11-10, y el costo del SDK independiente omite que deja de actualizarse

- **Ubicación:** A.3 L2496–L2510 (preguntas y JSON con `8.0.425`); §6.5 L1056; §6.4 L1044 (columna «Qué cuesta» de la política con lock). El dato sí está en §10.2.6 L1890 y en el Anexo F L3380, lejos de la plantilla que se copia.
- **Nivel:** E2. **Severidad:** S3.
- **Ancla:**
  - `releases.json` de 8.0 (B62), consultado el 2026-10-09: `latest-sdk 8.0.425`, `eol-date 2026-11-10`, `support-phase maintenance`. Para 10.0: `latest-sdk 10.0.401`, `eol-date 2028-11-14`.
  - [B59], tabla de ciclo de vida: «8.0.4xx | 17.11 | Aug '24 | Nov '26».
  - [B56], *Troubleshoot build warnings*: «*if you do* [install the stand-alone SDK], *you won't get automatic updates to that version of the .NET SDK anymore through Visual Studio and might be at risk for security issues*».
- **Qué está mal:**
  - A.3 es la plantilla copiable y la lista B.1 la toma. Un equipo que la copie después del 2026-11-10 fija un SDK sin soporte, y `CheckSdkVulnerabilities`, que §6.3 recomienda, se lo va a señalar.
  - Que la versión venga del caso (un heredado en .NET 8) es razonable, pero A.3 no lo dice.
  - El costo de `disable` en ESC-01 omite el que Microsoft destaca: el SDK independiente que la guía manda instalar no recibe parches por Visual Studio, así que su actualización pasa a ser trabajo del equipo.
- **Dirección:**
  1. En A.3 agregar una línea: «8.0.425 es el SDK del caso; .NET 8 sale de soporte el 2026-11-10 [B61][B62]; un repo nuevo parte de la última 10.0.4xx».
  2. En la celda «Qué cuesta» de §6.4, sumar: «el SDK independiente no se actualiza con Visual Studio: su parche mensual es un PR del equipo [B56]».
  3. Agregar `8.0.425` y su fecha de fin de soporte a los datos volátiles del Anexo F.

### senior-dotnet-04: §6.2.2 repite dentro de un párrafo el mismo error y el mismo costo, que además se reiteran en cinco lugares más

- **Ubicación:** §6.2.2 L990 (`A compatible .NET SDK was not found` dos veces en el mismo párrafo, con E3-1 citado dos veces); el costo de `disable` («SDK exacto en toda máquina») vuelve en §3.3 L318, §6.4 L1044 y L1047, §6.6 L1095 y L1112–L1113, y A.3 L2510.
- **Nivel:** E1 (`grep -n -o "A compatible .NET SDK was not found\|SDK exacto"` → 18 apariciones; 7 de ellas en §6.2.2–§6.6). **Severidad:** S4.
- **Ancla:** L990: «…`dotnet` falla **antes de compilar** con `A compatible .NET SDK was not found` (E3-1)… con `disable`, **toda** máquina… necesita exactamente ese SDK, y `dotnet` falla con `A compatible .NET SDK was not found` en la que tenga otro parche (E3-1). §6.4 pone las dos políticas lado a lado.»
- **Qué está mal:** es un problema de compresión, no de exactitud. El párrafo más denso del capítulo cita dos veces el mismo error. La tabla de §6.4 ya es el lugar canónico del costo, y las otras apariciones lo reescriben en lugar de remitir a ella.
- **Dirección:**
  1. En L990, cerrar con «Esa recomendación tiene un costo, que §6.4 pone al lado de la alternativa». Quitar la segunda cita del error.
  2. En §6.6 (L1095) dejar sólo «*Criterio*: §6.4».
  3. Mantener la pregunta-caso de L1112, que sí aporta la situación concreta.

### senior-dotnet-05: §4.2.3 anuncia la condición del `CS2016` («según el estado del servidor de compilación») y en la oración siguiente la vuelve a explicar

- **Ubicación:** §4.2.3 L492.
- **Nivel:** E1 (lectura del texto). **Severidad:** S4.
- **Ancla:** «…con SDK 8.0.425 la build con `CodePage=1252` falla con `CS2016: …` según el estado del servidor de compilación, y con SDK 10.0.400 compila (E1-03). En E1-03 la falla aparece con el servidor de compilación (`VBCSCompiler`) recién arrancado, desaparece si…».
- **Qué está mal:** la corrección C1-52 se agregó detrás de la frase vieja en lugar de reemplazarla. Quedan dos oraciones seguidas que citan E1-03 y nombran el servidor.
- **Dirección:** fundir las dos oraciones en una: «con SDK 8.0.425, `CodePage=1252` falla con `CS2016` cuando el servidor `VBCSCompiler` recién arrancó, no falla si ya compiló un archivo con *fallback* ni con `-p:UseSharedCompilation=false`; con SDK 10.0.400 compila (E1-03)». Después sigue [B16] sin cambios.

---

## Revisado y bien

1. **§6.2.2, el compilador en la CLI frente a Visual Studio (C1-04 aplicado), y §9.6, el registro de la versión del compilador.** El párrafo coincide con los *targets* de 8.0.425 y 10.0.400 y con [B59], consultado hoy:
   - 10.0.400 se distribuye con Visual Studio 18.9 y exige como mínimo 18.0, y el umbral `_IsDisjointMSBuildVersion < 18.9` cae justo entre los dos.
   - Las bandas mínimas citadas (10.0.100 → 17.14; 10.0.2xx–4xx → 18.0) están en la tabla.
   - `#error version` produce efectivamente `error CS8304: Compiler version: '4.11.0-3.25569.22 (3fb752d4)'. Language version: 12.0.` con SDK 8.0.425 (`evidencia-senior-dotnet/cs8304.txt`), lo que coincide con el 4.11.0 de E3-2.
2. **§6.4 y A.3/A.4, las dos políticas de `rollForward` (C1-01, C1-02 y C1-03 aplicados).** Separan bien el modo estricto del lock (sólo en CI) de la selección del SDK (en toda máquina). La nota † de [B56] («*set `rollForward` to `disable` so the SDK version and dependency graph stay in lockstep*») está citada fielmente, y `paths`/`errorMessage` «desde el SDK 10» coinciden con la página. La condición de CI de A.4 y `NU1603` comentado como opción de la política sin lock son coherentes con E4-2.
3. **§8.2.2, etiquetas e imágenes oficiales del SDK.** La etiqueta fija `mcr.microsoft.com/dotnet/sdk:8.0.425-bookworm-slim` existe en el registro (`/v2/dotnet/sdk/tags/list`, consultado el 2026-10-09), lo que cierra la mitad .NET de D-7. La distinción entre etiqueta fija y flotante, y la observación de que ambas se reconstruyen con la base del SO, coinciden con [B115]. La lista de tags confirma esas reconstrucciones con sufijos del tipo `8.0.401-1-bookworm-slim`.

## Solicitudes de convocatoria

Ninguna. No vi nada fuera de mi mandato que requiera a otro especialista.
