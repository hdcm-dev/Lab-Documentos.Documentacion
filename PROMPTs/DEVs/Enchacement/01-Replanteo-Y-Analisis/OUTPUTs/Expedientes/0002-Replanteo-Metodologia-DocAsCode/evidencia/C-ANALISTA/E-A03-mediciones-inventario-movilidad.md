# E-A03 — Mediciones para el inventario por pieza de MovilidadUrbana (MAUI, ApiWeb, Web)

Fecha-hora: 2026-10-26T15:08-03:00 · Quién: comisión C-ANALISTA · Raíz: /LAB/Lab-E2E.WebBlazor/
```
$ git -C Lab-E2E.WebBlazor log --oneline -1; git tag | wc -l
8fb4c3a README y CHANGELOG enlazan la guía de nomenclatura de la documentación
0
$ git log --oneline 8fb4c3a..HEAD | wc -l   # deriva de la ia-db respecto del código
0
$ git -C Lab-E2E.WebBlazor.Documentacion log --oneline -1; git tag | wc -l; git status --short
c63b571 Merge pull request #2 from hdcm-dev/docs/ia-db-3.1
0
 M PROMPTs/Indexado/Crear-Indexado.md
$ comparación de reglas entre las tres apps (namespace normalizado)
Domain/Rules/LocalidadRules.cs MAUI=b83d11e594 ApiWeb=b83d11e594 Web=b83d11e594
Domain/Rules/EncuestaRules.cs MAUI=1a867021b9 ApiWeb=1a867021b9 Web=1a867021b9
Domain/Catalogos.cs MAUI=97cc15b8f9 ApiWeb=97cc15b8f9 Web=97cc15b8f9
Application/Localidades/LocalidadPolicy.cs MAUI=ceca1d1755 ApiWeb=ceca1d1755 Web=ceca1d1755
Application/Encuestas/EncuestaPolicy.cs MAUI=0ff6244068 ApiWeb=0ff6244068 Web=0ff6244068
Application/Localidades/LocalidadService.cs MAUI=1ecba02f3a ApiWeb=1ecba02f3a Web=1ecba02f3a
Application/Encuestas/EncuestaService.cs MAUI=e086c6a64e ApiWeb=e086c6a64e Web=e086c6a64e
$ grep -l GenerateDocumentationFile src/*/*.csproj
src/MovilidadUrbana.ApiWeb/MovilidadUrbana.ApiWeb.csproj
$ ls docs
ls: no se puede acceder a 'docs': No existe el fichero o el directorio
$ grep -c '\[Test' tests/MovilidadUrbana.E2ETests/*.cs
tests/MovilidadUrbana.E2ETests/NavigationTests.cs:5
tests/MovilidadUrbana.E2ETests/LocalidadesTests.cs:10
tests/MovilidadUrbana.E2ETests/EncuestaTests.cs:10
$ grep -n 'runs-on' .github/workflows/*.yml (no comentadas)
.github/workflows/ci.yml:41:    runs-on: ubuntu-latest
.github/workflows/ci.yml:120:    runs-on: ubuntu-latest
.github/workflows/ci.yml:168:    runs-on: ubuntu-latest
.github/workflows/e2e.yml:89:    runs-on: [self-hosted, i7infra-dev]
.github/workflows/e2e.yml:137:    runs-on: ubuntu-latest
.github/workflows/e2e.yml:160:    runs-on: ubuntu-latest
.github/workflows/e2e.yml:257:    runs-on: ubuntu-latest
.github/workflows/e2e-login.yml:56:    runs-on: ubuntu-latest
.github/workflows/e2e-login.yml:96:    runs-on: ubuntu-latest
.github/workflows/android.yml:37:    runs-on: ubuntu-latest
.github/workflows/e2e-holamundo.yml:37:    runs-on: ubuntu-latest
$ grep -rEc 'CU-|RN-' ../Lab-E2E.WebBlazor.Documentacion (archivos con coincidencia)
0
```
