---
doc_id: BIT-16-C2-INF-implementador-desarrollador
doc_type: informe-de-mesa
title: Relectura integral, ciclo 2 — implementador ingenuo / desarrollador de código
status: vigente
origin: agent
owner: implementador ingenuo (relectura integral, ciclo 2)
last_review: 2026-10-28
audience: [presidencia, redacción]
traces: [Crear-IA-Layer-Guide-Reedicion.md (REED-16) §10; Mesa/Ciclo-1/06-Plan-De-Redaccion.md §10.3; Mesa/Ciclo-2/00-Compuertas-Redaccion.md; evidencia-implementador-desarrollador/]
---

# Informe del implementador ingenuo (relectura integral, ciclo 2)

## 1. Qué hice

Mi mandato: Linux con Docker, sin SDK ni experiencia en IA, siguiendo la guía y los README al pie de la letra. Leí la guía completa por partes (§0 a Anexo F, 4116 líneas). Después reproduje tres ejemplos y la demo en una copia limpia de la carpeta: sin `bin/`, `obj/` ni `*.db`, en el área de trabajo de la corrida. La carpeta de la guía no está versionada (la excluye `.git/info/exclude`), así que el «clon» es una copia con rsync. Tomé los comandos exactos de cada README. Agregué una sola cosa, el volumen de caché NuGet de la corrida, y corrí todo con turno de `build`.

Elección: **básico** `06-Tool-Calling` (el primer ejercicio, según §0.4 y §7.3), **intermedio** `07-Agente-Con-Aprobacion` y **avanzado** `10-Workflow`, más la **demo**.

| Paso | Resultado | Lo que dice el README |
|---|---|---|
| 06 build / `Cableado` / consola `--sin-modelo` / consola sin `DOTNET_ENVIRONMENT` / suite completa | 0 adv. 0 err.; 23/23; rc 0; rc 3; 23 verdes + 2 `Skipped` | coincide |
| 07 build Release / `Cableado` / consola `--aprobar s` y `n` | 0/0; 25/25; queda Corrientes / quedan las dos | coincide |
| 10 build / `Cableado` / `encuesta` / `alta --sin-modelo [--confirmar nadie]` / `secuencial --sin-modelo` | 0/0; 27/27; 4 filas iguales; rechaza CP 34 y registra 3450 (o `PendingRequests`, 0 escrituras) | coincide (el comando de `secuencial` lo tuve que adivinar: IMPLEM-06) |
| Demo `Cableado` | 69/69 | coincide |
| **06 `ConModelo`** (turno <recurso-propio>, estación con más núcleos) | 2/2 verdes. Por vía: Chaco 10/10 [0,72; 1] y nombra 1 10/10. Misiones: sin herramienta 0/10; «fuera del catálogo» 9/10 (`/api/chat`) y 10/10 (`/v1`); conteo 0/10. 0 invariantes violadas. Pared mediana 9,9 s y 9,3 s | **reproduce exactamente** las tasas del README (este pedido; la pared, 8,6 s allá, no se compara) |
| **Demo `ConModelo` D1** (el comando del README) | 1/1 verde. CP «34» tal cual 10/10 [0,72; 1]; inventado 0/10 | reproduce |
| **10 `ConModelo`** | **Test Run Failed**: 2 violaciones, ambas en s = 10 (timeout de 300 s y «Connection timed out»). La estación 2 se cayó durante la corrida y sigue sin responder. Secuencial 10/10, 0 violaciones | no comparable: s = 10 queda «no medido» por infraestructura (avisé a la presidencia) |

Registros crudos y logs, con el endpoint y las rutas redactados, en `evidencia-implementador-desarrollador/`: `00-corrida-*.txt`, `*.log`, `crudo-*.txt|jsonl`, `sin-modelo.sh` y `con-modelo.sh`. La copia de trabajo se borró al final con un contenedor, porque quedaba con archivos de root.

## 2. Hallazgos

### IMPLEM-01 · Los comandos de los README dejan `bin/`, `obj/` y salidas con dueño root en la carpeta del lector — S2 · reproducibilidad

- **Ubicación:** cabecera de la guía («Cómo correr los ejemplos»), §8.12.2, §9.8; sección «Comandos» de los README de `Examples/01`…`13` y de `Demos/MovilidadUrbana.Asistente/README.md`.
- **Evidencia:** después del `dotnet build` del README de 06, `bin/` quedó con uid 0 (`propietarios.log`). `rm -rf bin` como usuario da «Permiso denegado» en cada archivo. `resultados-conmodelo/` de la demo también es de root. En una máquina sin sudo, el lector no puede limpiar ni volver a copiar su carpeta. Sólo la limpié con `docker run --rm -v …:/w alpine rm -rf`. Con `-u "$(id -u):$(id -g)" -e HOME=/tmp`, el mismo comando dio 23/23 en verde, 0 archivos de root, y la carpeta se borró sin privilegios (`06-cableado-con-u.log`).
- **Propuesta:** en la cabecera de la guía, en §9.8 y en todos los README, agregar `-u "$(id -u):$(id -g)" -e HOME=/tmp` a cada `docker run` del SDK, y sumar esta nota en la cabecera de la guía: «Sin `-u`, el contenedor corre como root y deja `bin/`, `obj/` y las salidas con dueño root en tu carpeta; si ya pasó, se borran con `docker run --rm -v "$PWD":/w alpine rm -rf /w/<carpeta>`.» Con `-u`, el volumen opcional de caché NuGet necesita `-e NUGET_PACKAGES=/nuget -v nuget:/nuget`.

### IMPLEM-02 · La guía cita un `00-criterio-previo.md` que no existe en ningún ejemplo — S2 · evidencia

- **Ubicación:** guía §7.4 (l. 2064), §7.6.2 (l. 2271) y §7.8.4 (l. 2471).
- **Evidencia:** `find` sobre la guía, `Examples/` y `Demos/` no encuentra ningún `00-criterio-previo.md`. El único archivo de criterio es el `CRITERIO.md` de la demo. En 07, 08 y 10, el criterio está en el comentario de cabecera de cada clase de `ConModelo/`, como dicen sus README. El lector que quiere verificar «criterio escrito antes» busca un archivo que no está.
- **Propuesta:** en l. 2064, reemplazar «(criterio previo en `00-criterio-previo.md` del ejemplo y en cada clase de `ConModelo/`)» por «(criterio previo en el comentario de cabecera de cada clase de `ConModelo/`)». En l. 2271, «criterio previo en `00-criterio-previo.md`» por «criterio previo en el comentario de `ConModelo/WorkflowConModeloTests.cs`». En l. 2471, el mismo cambio, apuntando a `ConModelo/AgentePorMcpConModeloTests.cs`.

### IMPLEM-03 · El registro R-LLM y el mensaje de la prueba copian la excepción tal cual, con host y puerto del servidor — S2 · seguridad

- **Ubicación:** `Examples/10-Workflow/tests/…/ConModelo/WorkflowConModeloTests.cs` (las líneas «violación: …»), y por construcción análoga los `ConModelo/` de 06, 07 y 08, que también registran la excepción. Choca con §5.10 criterio 7, §8.5.4 y B.3 ACT-OPS («ninguna captura publicada muestra la URL del servidor»).
- **Evidencia:** con el servidor caído, `salidas-con-modelo/workflow-de-alta.txt` y el `Error Message` de NUnit dicen «InvalidOperationException: Connection timed out (<host>:<puerto>)», con la dirección real (redactada en `crudo-workflow-de-alta.txt` y `10-conmodelo.log`). Bajar `HttpClient` a `Warning` no lo evita. El crudo es justamente lo que la guía invita a guardar y citar.
- **Propuesta:** en el helper que arma la línea de violación, escribir `$"{ex.GetType().Name}: {ex.Message.Replace(new Uri(Endpoint).Authority, "<OLLAMA_ENDPOINT>")}"`, o sólo `ex.GetType().Name`. En §8.5.4, después de «ninguna captura publicada filtra el endpoint», agregar: «Tampoco los mensajes de excepción del `HttpClient`, que nombran host y puerto: los registros R-LLM los redactan antes de escribirlos.»

### IMPLEM-04 · Una caída del servidor se cuenta como violación de invariante y deja la suite en rojo, y el README no le dice al lector cómo distinguirlo — S3 · reproducibilidad

- **Ubicación:** `Examples/10-Workflow/README.md`, «Resultado esperado» (`ConModelo/`: «falla ante una sola violación … sin excepción»), y lo mismo en 06, 07 y 08. La guía §8.1.3 define los tres tipos de aserción.
- **Evidencia:** mi corrida de 10 terminó en «Test Run Failed». Las dos «violaciones» fueron de la red (timeout de 300 s y «Connection timed out» en s = 10), no del workflow: las otras 18 corridas del alta y las 10 de la secuencial cumplieron. Un lector ingenuo lee «el workflow viola una invariante». La guía (§7.8.4) cuenta así el timeout de 08, pero no da la regla de lectura.
- **Propuesta:** en el «Resultado esperado» de 06, 07, 08 y 10, agregar: «Si la única violación es una excepción de conexión o de `TimeoutSegundos` (`HttpRequestException`, `TaskCanceledException`, «Connection timed out»), la corrida no mide el código: esas semillas quedan "no medido" y se repiten con el servidor sano. Una violación de escritura, de lista cerrada o de camino es un defecto.» Una línea igual en §8.1.3, después de la definición de invariante.

### IMPLEM-05 · Seis nombres distintos de variable para lo mismo, y el Anexo E.5 da una regla que no se cumple — S3 · reproducibilidad

- **Ubicación:** Anexo E.5, última línea (l. 4079): «`salidas-con-modelo/` o la variable `CONMODELO_SALIDA`». Código de `ConModelo/` de cada ejemplo.
- **Evidencia (grep en el código):** la carpeta de salida es `RLLM_SALIDA` (01, 04–10), `R_LLM_SALIDA` (02), `SALIDA_DIR` (03) y `CONMODELO_SALIDA` (demo). El rótulo de estación es `ESTACION` (03, 06–10), `RLLM_ESTACION` (05) y `ESTACION_ROTULO` (demo), y 01 no tiene variable de rótulo. La carpeta por defecto es `salidas-con-modelo/` en unos, `salida-r-llm/` en 02, el `WorkDirectory` en 03 y `resultados-conmodelo/` en la demo. Quien arma un script para varios ejemplos (lo hice) tiene que leer cada README y equivocarse por lo menos una vez.
- **Propuesta:** unificar en el código a `RLLM_SALIDA` y `ESTACION`, con `salidas-con-modelo/` por defecto (la demo puede aceptar las dos durante esta versión). Si no se unifica, reemplazar la l. 4079 por: «Cada README dice su variable de salida y de rótulo; no son las mismas en todos los ejemplos (`RLLM_SALIDA`, `R_LLM_SALIDA` en 02, `SALIDA_DIR` en 03, `CONMODELO_SALIDA` en la demo; rótulo `ESTACION`, `RLLM_ESTACION` en 05, `ESTACION_ROTULO` en la demo).»

### IMPLEM-06 · 10-Workflow: el comando de `secuencial` sin modelo falta, y la consola de `alta` imprime la confirmación debajo del pedido equivocado — S3 · técnico

- **Ubicación:** `Examples/10-Workflow/README.md`, «La consola sin modelo» (l. 109–119) y «Resultado medido» («los cinco comandos»); `src/MovilidadUrbana.Ejemplos.Orquestacion/Program.cs`, l. 64–70.
- **Evidencia:** el README nombra `secuencial` y «cinco comandos», pero muestra dos. El `-- secuencial --sin-modelo` lo adiviné (rc 0). En `10-alta-si.log`, la línea «[confirmar-alta] ¿Agregar … CodigoPostal = 3450 …? → si» sale **debajo** del bloque «> Agregá Goya, Corrientes, CP 34…», porque `Console.WriteLine($"> {texto}")` corre después de `EjecutarAsync`. Leído así, parece que el CP 34 llegó a la persona, que es justo lo que el ejemplo dice que no pasa.
- **Propuesta:** en `Program.cs`, mover `Console.WriteLine($"> {texto}");` a antes de `var traza = await WorkflowDeAlta.EjecutarAsync(…)`. En el README, completar el bloque con los otros tres comandos: `-- alta --sin-modelo`, `-- alta --sin-modelo --confirmar no` y `-- secuencial --sin-modelo`.

### IMPLEM-07 · README 01: «Resultado esperado» dice 17 pruebas y el resto dice 18 — S3 · coherencia

- **Ubicación:** `Examples/01-Chat-Basico/README.md`, «Resultado esperado» («`Cableado`: 17 de 17 en verde»).
- **Evidencia:** el mismo README, en «Resultado medido», dice «18 de 18». El Anexo E.1 dice «18 pruebas». En `Cableado/` hay 13 `[Test]` y 5 `[TestCase]`, o sea 18 (conteo estático).
- **Propuesta:** «`Cableado`: 18 de 18 en verde.»

### IMPLEM-08 · README 10: un rótulo de estación que no existe en la guía — S4 · coherencia

- **Ubicación:** `Examples/10-Workflow/README.md`, l. 188: «Medido en la estación de laboratorio de 15 vCPU».
- **Evidencia:** §0.5 y E.3 definen sólo dos rótulos, y RV-01 (plan §10.3) fija el texto. Es la única aparición de «vCPU» en la guía, `Examples/` y `Demos/`. Un lector no sabe si es una tercera estación.
- **Propuesta:** «Medido en una estación de laboratorio con más núcleos (CPU sin GPU; contenedor limitado a 14 CPU / 34 GiB; Ollama 0.40.11), 2026-10-28.»

## 3. Revisado y bien

1. **Los README de 06, 07 y 10 y el de la demo se pueden seguir tal cual sin modelo.** Cada comando dio exactamente lo que promete: builds 0/0 con `TreatWarningsAsErrors`, `Cableado` 23/25/27/69, y salida con código 3 y mensaje claro («'TimeoutSegundos' … must be between 1 and 3600») sin `DOTNET_ENVIRONMENT`. Las líneas de snippet que cité de §7.3–§7.7 (15 rangos) coinciden con el código.
2. **Las tasas de 06 contra el modelo se reprodujeron una por una** en otra copia, en otro momento: Chaco 10/10, Misiones sin herramienta 0/10, «fuera del catálogo» 9/10 y 10/10, conteo 0/10. La demo D1 también: «34» 10/10 e inventado 0/10. La cabecera R-LLM sale escrita sola, con estimando, digest, parámetros, rótulo y criterio, y sin el endpoint (salvo en las excepciones: IMPLEM-03).
3. **«`ConModelo/` sin servidor no es verde» se ve de verdad:** las líneas `Skipped … PrimerEjercicio_PorLaVia` dentro de un resumen «Passed! … Skipped: 0». Es lo que avisan §8.4.2 y el README de la demo, y sin ese aviso el lector ingenuo se equivoca.
