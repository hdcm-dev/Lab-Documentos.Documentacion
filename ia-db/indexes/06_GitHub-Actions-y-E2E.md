# 06 — GitHub Actions y pruebas E2E con Playwright en .NET

> **Propósito**: la herramienta con la que se implementan los workflows que el procedimiento de
> ramas exige (GitHub Actions) y la familia de pruebas que esos workflows corren (E2E con
> Playwright para .NET). Cubre `Guides/GitHub-Action-Guide/` (1 documento, 2 974 líneas) y
> `Guides/E2E-Guide/` (2 documentos, 2 137 líneas).
> **Fuente primaria**: `GitHub-Action-Guide/GitHub-Action-Guide.md` (`GHA-00`, `last_review`
> 2026-08-31), `E2E-Guide/Beginner-Guide.md` (`E2E-00`, 2026-08-23), `E2E-Guide/Quick-Guide-ABM.md`
> (`E2E-01`, 2026-08-24).

## En una pantalla

- **Actions**: «primero el vocabulario, después la sintaxis sección por sección, recién entonces
  los escenarios». **Todos los ejemplos salen de workflows que existen y corren en el
  workspace** (Anexo F); lo no implementado se dice y se marca como ilustrativo.
- **E2E**: escrita para quien nunca hizo una; se apoya en `Lab-E2E.WebBlazor` (Blazor
  *interactive server*, SQLite, Clean Architecture, 22 pruebas con las vinculaciones oficiales de
  Playwright para .NET, tres workflows). Cada afirmación técnica remite a un archivo de ese repo.
- Ambas usan marcas **[F] / [C] / [E]** (la E2E agrega **[V]** = solo validación de sintaxis).
- Dueños distintos: Actions es de `Lab-GitFlow`; E2E es de `Lab-E2E.WebBlazor.Documentacion`.

## GitHub Actions — guía de estudio (`GitHub-Action-Guide.md`)

### Contenido

| § | Tema |
|---|---|
| 1 | Automatización de la construcción: CI, CD (entrega vs despliegue), pipeline, stage, **puerta**; qué nivel de prueba corre dónde |
| 2 | Qué es GitHub Actions y su modelo de ejecución; dónde vive un workflow; qué se ve en la interfaz |
| 3 | Marco de referencia (abajo) y **la regla de reparto** que evita la mitad de las discusiones |
| 4 | Mapa conceptual: entrada por escenario, por **síntoma**, por artefacto que quiero producir |
| 5 | Anatomía sección por sección: `name`, `on`, `permissions`, `concurrency`, `jobs`/`runs-on`/`needs`, `steps`/`run`/`uses`, `if`, artefactos y caché, `GITHUB_ENV`/`GITHUB_OUTPUT`/`GITHUB_STEP_SUMMARY`, contextos y expresiones, `env` |
| 6 | Composición: workflows reutilizables (`workflow_call`), acciones propias, matrices |
| 7 | Diez escenarios `E-01..E-10` (abajo) |
| 8 | Cadena de suministro: SCA (`dotnet list package --vulnerable`), SBOM (CycloneDX), **lo que el workspace no hace** (ningún workflow firma artefactos ni publica atestaciones; SLSA se cita, no se desarrolla) |
| 9 | Operación: runners alojados vs propios, costo, secretos/permisos/acciones de terceros, protección de rama, diagnóstico |
| A–F | Glosario · Plantillas (B.1 CI mínima, B.2 reutilizable + invocación, B.3 publicación por tag, B.4 job resumen) · Listas (C.1 antes de mergear un workflow, C.2 «verifica de verdad», C.3 antes de publicar, C.4 revisión de seguridad) · Preguntas · Fuentes (GitHub docs, prácticas de ingeniería) · **Catálogo de evidencia** |

### Marco (§3)

| Eje | Valores |
|---|---|
| Escenarios | `E-01` verificación de un PR · `E-02` de la línea principal · `E-03` puertas de calidad · `E-04` publicar NuGet · `E-05` publicar por FTP · `E-06` imagen de contenedor · `E-07` app móvil · `E-08` corte de versión y release · `E-09` verificar un entorno desplegado · `E-10` regresión programada |
| Contextos | `C-1` runner alojado por GitHub (limpio, se paga por minuto en privados) · `C-2` autoalojado (conserva estado; hay que mantenerlo) · `C-3` repo público (minutos gratis, todo visible) · `C-4` repo privado (cuota, multiplicadores por SO) · `C-5` plataforma destino ≠ runner (p. ej. workload `ios` no existe en Linux) |
| Actores | `A-DEV` · `A-QA` (qué nivel corre en cada disparador) · `A-DEVOPS` (runners, secretos, permisos, caché, publicación) · `A-PO` (si una versión sale) · `A-SEC` (permisos del token, procedencia de acciones, secretos) |

### Entrada por artefacto (§4.3)

| Quiero producir | Comando/acción central | § |
|---|---|---|
| Resultados de prueba consultables | `dotnet test --logger trx` + `actions/upload-artifact` | 7.1 |
| Paquete en nuget.org | `dotnet pack` + `dotnet nuget push` | 7.4 |
| Sitio en un hosting | `dotnet publish` + acción FTP | 7.5 |
| Imagen en un registro | `docker/build-push-action` | 7.6 |
| APK descargable | `dotnet publish -f net10.0-android` + artefacto | 7.7 |
| Release de GitHub con adjuntos | `gh release create` | 7.8 |
| SBOM | generador CycloneDX + artefacto | 8.2 |

### Catálogo de evidencia (Anexo F): los workflows reales que la guía disecciona

| ID | Ruta en el workspace | Aporta |
|---|---|---|
| `W-E2E-CI`, `W-E2E-E2E`, `W-E2E-ENT` | `LAB/Lab-E2E.WebBlazor/.github/workflows/{ci,e2e,verificacion-entorno}.yml` | Disparadores, concurrencia condicional, permisos por job, comentario idempotente en el PR, job resumen; reutilizable con inputs/outputs, matriz dinámica, caché de navegadores; prueba de humo contra entorno |
| `W-PT-CI`, `W-PT-NUGET`, `W-PT-ANDROID` | `Libs/NugetOrg/PrintThermal_Motor_Maui/.github/workflows/` | Runner autoalojado, versión única por outputs, dos runners por restricción de plataforma, matriz literal, `NETSDK1178`/`NU1102` |
| `W-GEO-FTP` | `PROG2/Geometria/Lab-Geometria/.github/workflows/deploy-front-ftp.yml` | Filtro de rutas, puertas antes de publicar, configuración por secret |
| `W-DEV-QR`, `W-HIB-INT` | `APLICADA/Ejemplos_Maui_Devices/…`, `APLICADA/Ejemplo_Maui_Hibrida/…` | Pipelines de iOS (33 pasos), versionado desde `Info.plist`, `push` filtrado por ruta |
| `W-BOT-CI`, `W-BOT-DOCKER`, `W-BOT-PUB` | `DEV/Discord.Bot.Moderador.Core/.github/workflows/` | Cinco puertas con trazabilidad a stages, SCA y SBOM, Buildx con caché, release con checksum |
| `IDX-DEV-09`, `IDX-HIB-08`, `IDX-PT-08`, `IDX-GEO-08` | ia-db de esos proyectos | Índices de CI/CD consultados como fuente |

Esas rutas son **externas a `Lab-Documentos`**; la guía las cita con la fecha de lectura.

## Pruebas E2E — guía de estudio (`Beginner-Guide.md`, `E2E-00`)

### Contenido

| § | Tema | Qué deja |
|---|---|---|
| 1 | Qué es una prueba E2E | Definición, qué no es, dónde se ubica, qué hace Playwright |
| 2 | Marco de referencia | Escenarios, contextos, actores (abajo) |
| 3 | Mapa conceptual | Por escenario, por artefacto, por síntoma |
| 4 | Anatomía del proyecto | Dónde vive, paquetes, carpetas, **el detalle de namespace que cuesta una tarde**, `.runsettings`, cómo se ve una corrida |
| 5 | Qué testear y qué no | Tres filtros en orden **[C]**: valor para el negocio, riesgo de integración, costo de detectarlo de otro modo; contrato de selección; antipatrones |
| 6 | Cómo se escribe un caso | Forma, **localizadores como contrato con la interfaz** (`data-testid`), aserciones que esperan, datos: sembrar, no depender |
| 7 | Cuando la app tiene servidor | Circuito de Blazor; esperar interactividad; **aislar el estado en el servidor** (middleware de cookie de sesión + repositorios que filtran por ella: `src/MovilidadUrbana.Web/Infraestructura/Sesiones/MiddlewareDeSesion.cs`); compilar antes de probar; eventos de enlace de datos; catálogo de intermitencias; paralelismo; «menos JavaScript, menos intermitencia»; cómo se corren en los cuatro contextos |
| 8 | Workflows | Vocabulario, principio de diseño, los tres workflows del laboratorio, atar las pruebas al merge, `workflow_dispatch`, prácticas y motivo |
| 9 | Evidencias | Qué se verificó y qué no (abajo) |
| A–F | Plantilla de clase base · plantilla de caso · listas · glosario · fuentes · ruta por perfil |

### Marco (§2)

| Eje | Valores |
|---|---|
| Escenarios | `ESC-01` pantalla nueva · `ESC-02` cambio en un PR (CI bloquea el merge) · `ESC-03` prueba intermitente · `ESC-04` despliegue en un ambiente (humo contra la URL) · `ESC-05` regresión de fondo (todos los navegadores, fuera del camino crítico) |
| Contextos | `CTX-01` máquina de desarrollo · `CTX-02` runner de CI (headless) · `CTX-03` entorno desplegado (no se levanta nada; el estado no se destruye) · `CTX-04` emulación móvil |
| Actores | `ACT-01` quien desarrolla (recorridos, casos, `data-testid`) · `ACT-02` QA (qué es crítico, qué se automatiza) · `ACT-03` DevOps (runners, disparadores, artefactos, caché) · `ACT-04` PO/autoridad de cambio (qué no puede romperse; acepta o rechaza liberar en rojo) |

### Evidencias (§9)

Verificado con `scripts/dotnet.sh` y `scripts/pruebas.sh` del laboratorio: build `-warnaserror`
en verde; **22 pruebas en verde** en chromium (7 s), firefox (13 s), webkit (15 s) y con
`EMULAR_MOVIL=true` (6 s); 49 unitarias. **No verificado**: Explorador de pruebas de Visual Studio
(no hay Windows), `playwright show-trace`, **comportamiento real de los tres workflows en Actions**
(solo YAML **[V]**), `NumberOfTestWorkers` sin `.runsettings`, invocación de `e2e.yml` desde otro
repo, referencias externas del Anexo E (sin red en esa ejecución).

## Guía rápida: montar un E2E de un ABM (`Quick-Guide-ABM.md`, `E2E-01`)

Receta para quien ya escribió E2E; base: el ABM de localidades del laboratorio (nueve casos en
verde). Pasos: 2.1 poner el contrato en la pantalla (`data-testid`) → 2.2 crear el proyecto →
2.3 copiar la infraestructura → 2.4 aislar los datos de cada prueba → 2.5 escribir la matriz de
casos → 2.6 configurar la corrida → 2.7 atarlo a la integración continua. Enlaza a la guía de
estudio para los fundamentos; no los repite.

## Relación con las otras guías

- Los workflows del anexo de ramas (`ci.yml`, `release.yml`, `auditoria-convergencia.yml`)
  consumen el `e2e.yml` reutilizable que la guía E2E §8.3 describe → [05](05_Modelo-de-Ramas-y-Practicas.md).
- `DevOps-Guide/marco-teorico.md` §7–§8 (pipeline de 15 stages, SLSA, SBOM, Sigstore) es el
  marco teórico de supply chain que la guía de Actions §8 deliberadamente **no** desarrolla por
  falta de implementación propia → [07](07_DevOps-Agiles-SDD-UX.md).
- `DOC-TESTPLAN`/`DOC-TESTCASES` de Documentación técnica son los artefactos donde se documenta
  la estrategia que estas guías implementan → [01](01_Documentacion-Tecnica.md).
