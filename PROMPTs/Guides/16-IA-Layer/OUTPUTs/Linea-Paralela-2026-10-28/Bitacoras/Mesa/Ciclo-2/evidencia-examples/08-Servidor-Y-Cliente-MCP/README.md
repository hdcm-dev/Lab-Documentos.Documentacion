# Evidencia de Examples/08-Servidor-Y-Cliente-MCP (2026-10-28)

Imagen: mcr.microsoft.com/dotnet/sdk:10.0@sha256:de4fe90a98845d75910b9769662465c84de1a934665c431279d1382b2bddc02b (SDK 10.0.403).
Compilado y probado en una copia fuera del workspace (sin bin/obj en el ejemplo), con el recurso build.

| Archivo | Qué es |
|---|---|
| 00-criterio-previo.md | criterio R-LLM escrito antes de la primera corrida contra el modelo |
| 01-build-cableado-consola-y-sin-endpoint.txt | build (0 warnings, 0 errors), Cableado 44/44, consola sin modelo (rc 0), consola sin DOTNET_ENVIRONMENT (rc 3), ConModelo sin OLLAMA_ENDPOINT (Skipped/Inconclusive) |
| 02-consola-sin-modelo.txt | corrida anterior de la consola sin modelo (antes de fijar ServerInfo) |
| con-modelo-estacion-2/ | ConModelo (20 pedidos) y consola con modelo en la estación de 15 vCPU (recurso <recurso-propio>): verde, 0 violaciones |
| con-modelo-estacion-1/ | ConModelo (20 pedidos) en la estación de 4 núcleos (recurso <recurso-compartido>): ROJO, 1 violación (timeout de 300 s en s=1, Chaco) |
| 03-rpriv-ejemplo.txt | rpriv v2 sobre la carpeta del ejemplo: 0/0/0 |

Orden de las corridas: la estación 2 se usó primero porque, al planificar, la cola de <recurso-compartido> superaba 20 min (criterio previo);
la estación 1 se corrió después, cuando se liberó, con las mismas semillas (reproducción en otra estación, no comparación).
En la estación 1 no se controló la carga de llamadas sueltas de otros agentes durante el turno.
