# Evidencia de `Examples/13-Prueba-De-Arquitectura` (2026-10-28)

Salidas crudas de la corrida en `mcr.microsoft.com/dotnet/sdk:10.0` (digest en `00-entorno.txt`), con el recurso `build`, sobre una copia del ejemplo fuera del workspace. Sin modelo: no hay corridas R-LLM.

| Archivo | Qué es |
|---|---|
| `00-entorno.txt` | digest de la imagen, fecha, versión del SDK |
| `01-build.txt` | `dotnet build` de la solución: 0 advertencias, 0 errores |
| `02-cableado.txt` | `dotnet test` con verbosidad detallada: 13/13, con los hallazgos que imprime cada caso rojo |
| `03-mutacion-<nombre>.txt` | la regla (`Category=Regla`, 7 pruebas) sobre la aplicación compilada con `-p:Mutacion=<nombre>` |
| `04-soloUsing-entra-al-compilador.txt` | prueba de que `Mutaciones/SoloUsing/GlobalUsingSinUso.cs` entra al compilador (verbosidad detallada) |
| `05-busqueda-de-texto-sobre-R4.txt` | la búsqueda de `using Microsoft.Extensions.AI` sobre el núcleo con R4 puesta: 0 coincidencias |
| `06-rpriv-ejemplo.txt` | compuerta R-PRIV v2 sobre el ejemplo y sobre esta carpeta |
| `07-barridos.txt` | barrido ampliado de la tarea, literales de RV-12, `bin/`/`obj/` y `diff -r` de la copia |
