# E09 — Anclas de versión, concurrencia y costo de la suite documental
Método: comandos git locales, WebFetch y medición de tiempo · Fecha-hora: 2026-10-26 (tarde, -03:00) · Quién: comisión C-VERIFICACION

## Anclas verificables (Lab-Geometria 4b114d7)
```text
git rev-parse --verify -q 'v1.2.0^{commit}' → 4b114d7, exit=0
git rev-parse --verify -q 'v9.9.9^{commit}' → exit=1
git merge-base --is-ancestor HEAD~3 HEAD → exit=0 ; con SHA inexistente → exit=128
git tag | wc -l → Lab-Documentos 0 · Lab-Documentos.Documentacion 0 · Lab-E2E.WebBlazor 0 · Lab-Geometria: v1.1.1 v1.1.2 v1.2.0 (últimos)
ls Lab-Documentos.Documentacion/.github → No existe
```
## Concurrencia
```text
Lab-Geometria .github/workflows/e2e.yml:59-61 → concurrency: group: e2e-laboratorio, cancel-in-progress: false
GitHub Docs, «Control the concurrency of workflows and jobs», https://docs.github.com/en/actions/how-tos/write-workflows/choose-when-workflows-run/control-workflow-concurrency (consultado el 2026-10-26):
  un job espera cuando «another job or workflow using the same concurrency group in the repository is in progress» (alcance: repositorio)
```
## Costo de la suite (corpus/base, 15 .md)
```text
lychee --offline: 0,78 s · lychee con externos: 1,9 s · suite completa (lychee offline + markdownlint + esquema + ocultos + cita-linea + url-fecha + mermaid), dos contenedores: 5,25 s
build -warnaserror con OpenAPI en build (ApiWeb, caché NuGet fría): 15,8 s
```
