# E07 — OpenAPI emitido en build en MovilidadUrbana.ApiWeb (copia de Lab-E2E.WebBlazor 8fb4c3a) y compuerta de contrato
Método: comando local o en contenedor efímero (--rm) · Fecha-hora: 2026-10-26 (tarde, -03:00) · Quién: comisión C-VERIFICACION

Cambio en la copia (una variable): se agregan al .csproj `Microsoft.Extensions.ApiDescription.Server` 10.0.11 (PrivateAssets=all) y `OpenApiDocumentsDirectory=$(MSBuildProjectDirectory)/openapi`.
Comando: docker run --rm -v <copia>:/w -w /w/MovilidadUrbana.ApiWeb mcr.microsoft.com/dotnet/sdk:10.0 dotnet build -c Release -warnaserror -nologo -v q
```text
Build succeeded. 0 Warning(s) 0 Error(s). Time Elapsed 00:00:14.13
openapi/MovilidadUrbana.ApiWeb.json  16883 bytes
openapi 3.1.1 info {'title': 'MovilidadUrbana.ApiWeb | v1', 'version': '1.0.0'}
operaciones 8
X-Sesion-Id presente: False

Prueba negativa: [HttpPost] → [HttpPost("alta")] en el controlador de localidades, rebuild:
git diff --stat: .../openapi/MovilidadUrbana.ApiWeb.json | 98 +++++-----
git diff --exit-code -- '*/openapi/*.json' → exit=1
Revertido el controlador y rebuild: git diff --exit-code → exit=0 (salida determinista)
```
