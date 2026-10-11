# Anexo A — Plantillas comentadas, verificadas en conjunto

[`repo/`](repo/) es un repositorio mínimo que contiene **todas** las plantillas del Anexo A de la guía (`Metodologia-Entorno-Desarrollo-Guide.md`), en las rutas donde las buscan sus herramientas. [`verificar.sh`](verificar.sh) (experimento **EA-1**) comprueba que funcionan juntas: copia `repo/` a un directorio temporal y corre siete pasos (con dos subpasos), cada uno en el contenedor de su ecosistema.

| Paso | Qué comprueba | Contenedor |
|---|---|---|
| 1 | Qué resuelve `.editorconfig` y qué aplica `.gitattributes` para nueve rutas de ejemplo; la compuerta de texto de N2 sobre las propias plantillas | `lab-n2-texto:local` (ver `../N2-politica-de-texto-y-remediacion/tools/Dockerfile`) |
| 1b | Un `dotnet new console` dentro del repo: con la variante A, dos violaciones (`Program.cs` y el `.csproj` con BOM); ninguna después de normalizarlos | `lab-n2-texto:local` |
| 2 | La condición de CI de `Directory.Build.props` (sin variable, `CI=true`, `TF_BUILD=True`) | `mcr.microsoft.com/dotnet/sdk:8.0` |
| 2b | `Directory.Build.targets`: lock en el ejecutable y no en una biblioteca; lock sin salto final; modo estricto en CI y su falla `NU1004` | `mcr.microsoft.com/dotnet/sdk:8.0` |
| 3 | `devEngines` + `engine-strict` en Node 24 (pasa) y Node 22 (falla) | `node:24-bookworm-slim`, `lab-n8-poliglota:local` |
| 4 | `pyproject.toml` + `.python-version` + `required-version` con uv | `lab-n8-poliglota:local` |
| 5 | Sintaxis de `devcontainer.json` (JSONC; `build.dockerfile` y `PYTHON_VERSION` coherentes con el repo), JSON, `ci.yml` y esquema de `dependabot.yml` (con el ecosistema `docker`) | `python:3.12-slim` |
| 6 | La imagen de A.10 (`imagen/Dockerfile`, Node 24) se construye y corre la plantilla `web/` adentro | `docker build` local |
| 7 | El hook de A.11 con el esqueleto de compuerta rechaza un commit con un `.cs` en cp1252 (el esqueleto falla a propósito hasta reemplazarlo) | `lab-n2-texto:local` |

```bash
bash verificar.sh | tee salidas/EA-1-plantillas.txt
```

Salida registrada el 2026-10-09 (revisión de la mesa, ciclo 1; la primera, del 2026-10-07): [`salidas/EA-1-plantillas.txt`](salidas/EA-1-plantillas.txt). Lo que **no** verifica: el workflow de CI y `dependabot.yml` sólo se validan por sintaxis y esquema (no se ejecutaron en GitHub); `tools/ci/compuerta.sh` es un esqueleto que **falla a propósito** (la compuerta completa es la de `../N7-compuertas-y-gobierno/compuerta/`, o `verificar.sh` de N8 si los proyectos viven en subcarpetas).
