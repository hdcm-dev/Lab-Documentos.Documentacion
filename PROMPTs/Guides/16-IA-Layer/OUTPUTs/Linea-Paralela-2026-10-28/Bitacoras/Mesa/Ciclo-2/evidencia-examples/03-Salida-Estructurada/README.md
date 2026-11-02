# Evidencia — Examples/03-Salida-Estructurada (2026-10-28)

Imagen: `mcr.microsoft.com/dotnet/sdk:10.0` @ `sha256:de4fe90a98845d75910b9769662465c84de1a934665c431279d1382b2bddc02b` (SDK 10.0.403). Compilado y probado sobre una copia fuera del workspace, por el recurso `build`; el modelo, por el turno del segundo servidor (la cola de la estación 1 estaba tomada hasta 43 min por otro ejemplo).

| Archivo | Qué es |
|---|---|
| `00-criterio-previo.md` | criterio de las tasas, escrito antes de la primera llamada, con el sha256 del archivo de pruebas |
| `01-build-y-cableado.txt` | build 0/0 y `dotnet test` sin endpoint: 15 en verde, `ConModelo` Inconclusive (Skipped) |
| `02-conmodelo-corrida-1/` | antecedente: reveló un defecto del ejemplo en las modificaciones (ver `NOTA.md`) |
| `03-conmodelo-corrida-2/` | corrida vigente del README (mismas semillas; crudo idéntico a la corrida 1 en 40/40 → reproducción, no evidencia nueva) |
| `04-dotnet-run-D1.txt` | el programa con «Agregá Goya, Corrientes, CP 34, 89959 habitantes» (endpoint reemplazado por `<OLLAMA_ENDPOINT>`) |
| `05-procedencia-casobase.txt` | los 8 archivos de `CasoBase/` iguales al origen `59399ba` |
| `06-rpriv-evidencia.txt` | R-PRIV v2 sobre esta carpeta |
| `07-clon-limpio-comandos-del-readme.txt` | los comandos del README tal cual, en una copia nueva y sin caché NuGet |
