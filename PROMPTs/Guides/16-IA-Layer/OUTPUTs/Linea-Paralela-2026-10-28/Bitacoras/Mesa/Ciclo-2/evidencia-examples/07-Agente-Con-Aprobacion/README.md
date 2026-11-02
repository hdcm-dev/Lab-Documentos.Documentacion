# Evidencia de Examples/07-Agente-Con-Aprobacion (2026-10-28, fase de redacción)

Salida cruda, sin endpoint (reemplazado por `$OLLAMA_ENDPOINT` / `<servidor>` antes de guardar). Compilado y corrido en
una copia limpia fuera del workspace, con `mcr.microsoft.com/dotnet/sdk:10.0`
(`sha256:de4fe90a98845d75910b9769662465c84de1a934665c431279d1382b2bddc02b`, SDK 10.0.403) y la caché NuGet en un volumen.
Turnos por `<envoltorio-de-turnos>` (`build`; modelo en la estación 2).

| Archivo | Qué |
|---|---|
| `00-criterio-previo.md` | criterios R-LLM escritos antes de pedir el turno de modelo |
| `cableado/01-build.txt` | build desde cero: 0 advertencias, 0 errores |
| `cableado/02-test-cableado.txt` | `Cableado`: 25/25 |
| `cableado/03-test-conmodelo-sin-endpoint.txt` | `ConModelo` sin `OLLAMA_ENDPOINT`: 2 Skipped «no medido» |
| `cableado/04-paquetes.txt` | `dotnet list package` (directos, transitivos, `--vulnerable`: ninguno, `--deprecated`: ninguno) |
| `cableado/05-consola-sin-modelo.txt` | consola `--sin-modelo` con `--aprobar s`, `--aprobar n`, sin respuesta, y sin Development (código 3) |
| `cableado/06-literales.txt` | RV-12 (sólo el nombre de la clave `num_ctx`, ningún valor) y ningún `bin/`/`obj/` en el workspace |
| `cableado/07-procedencia-casobase.txt` | los 9 archivos de `CasoBase/` iguales al origen `59399ba` |
| `con-modelo/estacion-4-nucleos-intento/` | turno de la estación 1 15:46–15:52 -03: la consola cortó por `TimeoutSegundos` (300 s) en el primer pedido, con el anfitrión a carga ~42 (8 hilos) por otras compilaciones; la primera prueba se detuvo a mano. **No medido** en esa estación |
| `con-modelo/estacion-15-vcpu/` | turno de la estación 2 15:52–15:56 -03 (rótulo «estación de laboratorio de 15 vCPU»): consola 38 s, `DelChatAlAgenteConModeloTests` (5 semillas) y `BajaConAprobacionConModeloTests` (10 semillas), las dos en verde |
| `con-modelo/estacion-15-vcpu/rllm/*.txt` | registros R-LLM que escribió cada prueba |
| `rpriv-ejemplo-2026-10-28.txt` | compuerta R-PRIV v2 sobre la carpeta del ejemplo y sobre esta evidencia |
| `scripts/` | scripts de turno, parametrizados después de correr (`EJEMPLO`, `TRABAJO`, `VOLUMEN_NUGET`) para no dejar rutas del laboratorio; los comandos son los mismos |

Los `ConModelo` de la estación 2 corrieron sobre la compilación previa a renombrar cuatro pruebas de `Cableado/`
(cambio de nombres, sin cambio de código); el build final desde cero y su `Cableado` 25/25 son los de `cableado/`.
