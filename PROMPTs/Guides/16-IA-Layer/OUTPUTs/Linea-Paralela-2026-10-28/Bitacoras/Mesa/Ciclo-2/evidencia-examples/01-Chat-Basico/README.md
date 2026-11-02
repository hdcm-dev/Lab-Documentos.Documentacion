# Evidencia de Examples/01-Chat-Basico (2026-10-28, fase de redacción)

Salida cruda, sin endpoint (reemplazado por `$OLLAMA_ENDPOINT` / `<servidor>` antes de guardar). Compilado y corrido en una
copia fuera del workspace (`{dir-de-trabajo}/ej01/copia`), con `mcr.microsoft.com/dotnet/sdk:10.0`
(`sha256:de4fe90a98845d75910b9769662465c84de1a934665c431279d1382b2bddc02b`, SDK 10.0.403) y la caché NuGet en el volumen
`<volumen-nuget>`. Turnos por `<envoltorio-de-turnos>` (`build`; `<recurso-compartido>` = estación 1, rótulo «estación de laboratorio de 4 núcleos»).

| Archivo | Qué |
|---|---|
| `00-criterio-previo.md` | criterios R-LLM escritos antes de pedir el turno de modelo |
| `cableado/01-build.txt` | build: 0 advertencias, 0 errores |
| `cableado/02-test-cableado.txt` | `Cableado`: 18/18 |
| `cableado/03-test-conmodelo-sin-endpoint.txt` | `ConModelo` sin `OLLAMA_ENDPOINT`: 3 Skipped «no medido» |
| `cableado/04-paquetes.txt` | `dotnet list package --include-transitive`, `--vulnerable` (ninguno) y `--deprecated` (ninguno) |
| `cableado/05-consola-sin-modelo.txt` | consola sin Development → código 3; 2001 caracteres → código 2 sin llamar al servidor |
| `con-modelo/turno-1/*.txt` | turno <recurso-compartido> 14:54:58–15:02:45 -03: consola (ver nota), ChatConModelo 10/10, MaxOutputTokens 3/3 + 3/3, NumCtx 3/3 ×3 |
| `con-modelo/rllm/*.txt` | registros R-LLM que escribió cada prueba |
| `con-modelo/programa/*.txt` | consola por las dos vías, turno aparte (ver nota) |
| `rpriv-ejemplo-2026-10-28.txt` | compuerta R-PRIV v2 sobre la carpeta del ejemplo: 0/0/0 |
| `scripts/` | scripts de turno (contienen rutas del laboratorio: sólo bitácora) |

**Nota sobre `con-modelo/turno-1/programa.txt`:** esa corrida de la consola arrancó un segundo antes de que otro paso
recompilara la copia (mismo código fuente); salió con código 0, pero se repitió en un turno aparte para no depender
de esa coincidencia: `con-modelo/programa/`.
