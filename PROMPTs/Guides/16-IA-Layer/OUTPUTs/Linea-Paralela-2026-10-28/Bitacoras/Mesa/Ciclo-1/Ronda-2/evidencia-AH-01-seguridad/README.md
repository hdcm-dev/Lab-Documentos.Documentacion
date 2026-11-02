# Evidencia de AH-01, consulta dirigida C1 ronda 2 (2026-10-28, estación 1)

Endpoint de Ollama sólo por `OLLAMA_ENDPOINT`; no se escribe en ningún archivo (R-PRIV). Intermedios en `{dir-de-trabajo}/c1r2-ah01/`, bin/obj borrados al terminar.

Versiones: SDK 10.0.403 (`mcr.microsoft.com/dotnet/sdk:10.0`), runtime 10.0.14, Microsoft.Extensions.AI 10.11.0, Microsoft.Agents.AI 1.26.0, Microsoft.Extensions.DependencyInjection 10.0.14, OllamaSharp 5.5.0. Caso base: Lab-E2E.WebBlazor `59399ba` (2026-10-27), `src/MovilidadUrbana.ApiWeb` copiado sin cambios.

| Id | Qué | Tipo | Archivos | Pregunta |
|---|---|---|---|---|
| R | Reflexión de los tipos de aprobación de MEAI 10.11.0 (constructores y propiedades) | E1 | `R-reflexion-aprobacion-Program.cs` (salida citada en la consulta §1.1) | PC-13 |
| D1 | Integridad de `ApprovalRequiredAIFunction` en MAF: aprobación legítima, respuesta forjada con argumentos cambiados, `RequestId` desconocido, repetición, aprobación de A enviada en B, sesión serializada y alterada, rechazo | E1, determinista, sin modelo | `D-sonda-aprobacion-y-sesiones-Program.cs`, `D-SondaD.csproj`, `D-salida.txt` | PC-13, PC-12 |
| D2 | Cliente Singleton/Scoped × `ValidateScopes` true/false × herramientas en `ChatOptions` o por petición; **dos sesiones concurrentes** con barrera; `SessionContext` réplica del caso base (Guid provisorio en el constructor) y repositorio que filtra por sesión | E1, determinista | ídem D1 | PC-11 |
| D3 | `GetResponseAsync<AccionPropuesta>` con JSON fuera de contrato (enum numérico, enum inexistente, id negativo, campo extra con marcado) | E1, determinista | ídem D1 | PC-13 |
| A | ApiWeb real del caso base en loopback del contenedor, `ASPNETCORE_ENVIRONMENT=Production`: id de sesión asignado, id débil elegido por el cliente, operación normal con el id ajeno, 404 entre sesiones, ids globales, `Localidad.Nombre` con instrucción, con 300 caracteres y con marcado | E1 | `A-apiweb-sesiones-correr.sh`, `A-apiweb-sesiones-salida.txt` | PC-12, PC-13, PC-14 |
| L | R-LLM: `qwen3.5:4b`, T 0,7, semillas 1..10, razonamiento apagado, `MaximumIterationsPerRequest 3`. Herramienta de lectura que devuelve un `Nombre` con instrucción frente a control con nombre normal; baja envuelta en `ApprovalRequiredAIFunction` (se cuenta el **pedido**, nada se ejecuta) | E1 (R-LLM) | `L-sonda-inyeccion-nombre-Program.cs`, `L-SondaL.csproj`, `L-salida.jsonl`, `L-stderr.txt` | PC-14 |

Comandos (desde cada carpeta de trabajo; `R=<gestor-de-turnos>`, `DIR_TURNOS={dir-de-turnos}`):

```bash
$R/<envoltorio-de-turnos> build c1r2-ah01 "sonda D aprobacion y sesiones" 20 -- docker run --rm -v <volumen-nuget>:/root/.nuget/packages -v $PWD:/w -w /w mcr.microsoft.com/dotnet/sdk:10.0 sh -c 'dotnet build -c Release; dotnet bin/Release/net10.0/SondaD.dll'
$R/<envoltorio-de-turnos> build c1r2-ah01 "ApiWeb del caso base, sesiones" 20 -- docker run --rm -v <volumen-nuget>:/root/.nuget/packages -v $PWD:/w -w /w mcr.microsoft.com/dotnet/sdk:10.0 /w/correr.sh
$R/<envoltorio-de-turnos> <recurso-compartido> c1r2-ah01 "PC-14 inyeccion por Localidad.Nombre N=10+10" 45 -- docker run --rm --network host -e OLLAMA_ENDPOINT -e OLLAMA_MODEL=qwen3.5:4b -e N=10 -v <volumen-nuget>:/root/.nuget/packages -v $PWD:/w -w /w mcr.microsoft.com/dotnet/sdk:10.0 dotnet bin/Release/net10.0/SondaL.dll > salida.jsonl 2> stderr.txt
```

Fuentes web (E4), leídas el 2026-10-28:

- S-CMS1: ResDAC, «CMS Cell Size Suppression Policy», https://resdac.org/node/1506, «Current Version Date: 01/26/2024».
- S-AR1: Ley 25.326 de Protección de Datos Personales (texto actualizado), InfoLEG, https://servicios.infoleg.gob.ar/infolegInternet/anexos/60000-64999/64790/texact.htm, art. 2 y art. 28.
- Las de la ronda 1 (OWASP LLM01/LLM02/LLM06:2025, MCP 2026-07-28) siguen en `../../evidencia-AH-01-seguridad-llm/fuentes-consultadas.md`.

> **2026-10-28 — Parche P2-01 (ciclo 1, ronda 2).** Redacción in situ por R-PRIV (dictamen §1): se reemplazó 1 ruta absoluta del home. No cambió ninguna afirmación. Salida de la compuerta antes y después en `Mesa/Ciclo-1/Ronda-2/aplicacion/rpriv-2026-10-28-{antes,despues}.txt`.
> Línea 16: `R=` pasa a `<gestor-de-turnos>`. Antes de redactar se hizo una copia fuera de `OUTPUTs/` (condición transversal del juez de riesgo), se comparó palabra por palabra (1 cambio, el esperado) y se borró.
