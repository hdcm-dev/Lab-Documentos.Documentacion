# Evidencia de Examples/04-Embeddings-Y-Busqueda (2026-10-28)

- Imagen: `mcr.microsoft.com/dotnet/sdk@sha256:de4fe90a98845d75910b9769662465c84de1a934665c431279d1382b2bddc02b` (SDK 10.0.403), volumen de paquetes `<volumen-nuget>`, recurso `build`. Compilado sobre una copia fuera del workspace (sin bin/obj en el destino).
- Modelo: `qwen3-embedding:0.6b@ac6da0dfba84`, Ollama 0.40.11, estación de laboratorio de 4 núcleos, recurso `<recurso-compartido>` (turno 15:18–15:21 aprox.). Endpoint sólo por variable; los registros del HttpClient se apagaron (Logging Warning) porque escribían la URL.
- Oro: `oro/oro-requisitos.json` sha256 aaf3d78775c200896049dcc12775f94c1d02c0c1c2c79f6d55418330b2c17149.

| Archivo | Qué es |
|---|---|
| `00-criterio-previo.md` | criterio escrito antes de la primera llamada al modelo |
| `01-cableado.txt` | build + Cableado 13/13 + ConModelo sin endpoint (3 Inconclusive) + `dotnet list package` |
| `01-dimension.txt`, `02-oro-con-y-sin-instruccion.txt`, `03-similitud-entre-medios.txt` | registros R-LLM de las tres pruebas ConModelo |
| `02-conmodelo-dotnet-test.txt` | salida de `dotnet test --filter TestCategory=ConModelo` (3/3) |
| `03-consola.txt` | consola: buscar, no respondible, similitud, dimensión 512 (exit 4), sin Development (exit 3), sin modelo (buscar y evaluar) |
| `04-rpriv-ejemplo.txt` | compuerta R-PRIV v2 sobre la carpeta del ejemplo: 0/0/0 |
