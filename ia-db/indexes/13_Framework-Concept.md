# 13 · Framework Concept: apps .NET MAUI híbridas con contenido OTA firmado y trabajo sin red

> **Propósito**: qué hay en `Concepts/Framework-Concept/`. Es una guía de estudio con una demo ejecutable para construir
> apps .NET MAUI cuyas pantallas Blazor WebAssembly se bajan firmadas de un canal propio y se activan sin pasar por la
> tienda. Este índice dice en qué orden se lee, qué decide cada pieza, cómo se compila y se prueba la demo y qué
> inconsistencias tiene hoy el corpus.
> **Fuentes primarias**: `Concepts/Framework-Concept/Developer-Guide.md` (`FC-GUIA-INDICE`, v1.0.0, índice único de la
> guía en capítulos), `Concepts/Framework-Concept/MAUI-Framework-Developer-Guide.md` (`FC-GUIA-LIBRO`, el libro que
> reúne todo), `Concepts/Framework-Concept/README.md` (`GUIA-PORTADA`) y `Concepts/Framework-Concept/Demo/README.md`.
> **Vigencia**: 2026-11-16, verificado contra `Lab-Documentos` `main` `34929f2`. Reemplaza al índice `12_Framework-Concept.md`
> de la ia-db v1.x (2026-10-29, `66d3b5a`).

## Índice

1. [Definiciones](#1-definiciones)
2. [En una pantalla](#2-en-una-pantalla)
3. [Inventario de la guía](#3-inventario-de-la-guía)
4. [Rutas de lectura](#4-rutas-de-lectura)
5. [Conceptos y decisiones clave](#5-conceptos-y-decisiones-clave)
6. [La demo (`Demo/`)](#6-la-demo-demo)
7. [CI: los dos workflows](#7-ci-los-dos-workflows)
8. [Procedencia y relaciones](#8-procedencia-y-relaciones)
9. [Estado y vigencia](#9-estado-y-vigencia)
10. [Hallazgos](#10-hallazgos)
11. [Para preguntas X → leé Y](#11-para-preguntas-x--leé-y)
12. [Fuentes](#12-fuentes)

## 1. Definiciones

| Término | Significado | Fuente |
| --- | --- | --- |
| Contenedor nativo (*native shell*, sin. *native wrapper*) | La app MAUI que se instala desde la tienda. Aloja el WebView, el puente nativo y el verificador de firma, y no trae las pantallas de negocio | `Decisiones/ADR-0001-Contenedor-Nativo.md` §2 |
| Cascarón (coloq.) | Nombre original del contenedor nativo. En la prosa nueva sólo aparece como remisión, pero sigue en nombres de archivo, en el código y en los capítulos 00–08 | ADR-0001 §2–§3 |
| App híbrida con contenido OTA | El modelo completo. **No** es Blazor Hybrid, que compila las pantallas dentro del binario | ADR-0001 §2 |
| Contenido web / paquete de actualización OTA | Las pantallas Razor compiladas a Blazor WASM. Se descargan como zip firmado, se verifican y se sirven desde el disco | ADR-0001 §2; `01-Actualizacion-Sin-Tienda.md` |
| Definiciones | Las encuestas son datos JSON y se corrigen sin subir la versión del contenedor | `02-Cascaron-Puente-Y-Capacidades.md`; `Demo/definiciones/` |
| Canal firmado | Índice firmado (`semilla/indice.json` + `.sig`, `keyId`, `expires`). Si la firma está rota, la actualización se rechaza | `01-…`; `Demo/semilla/indice.json` |
| Puente | El contrato contenedor ↔ contenido: tabla de métodos, catálogo de capacidades y transporte. Su versión mayor es la identidad del contrato | `Demo/versionado/puente.json`; `Demo/src/FrameworkConcept.Core/Contracts/contrato.json` |
| Outbox | Cola local de envíos pendientes. La base local SQLite es la fuente de verdad (*offline-first*) | Libro cap. 5; `Conocimientos/…` §6 |
| TPR | Tiempo hasta el primer render del contenido en un arranque en frío. Lo marca `FC-MARCA primer-render`. Umbral: ≤ 5 000 ms en el teléfono de medida | Libro Anexo H.3; `Demo/README.md` §«Medición del TPR» |
| `fw-ok` | Job agregador estricto de `framework-concept-demo.yml` y único check requerido de `main`. Si un job queda omitido o cancelado, el check da rojo | `06-Procedimientos-…` (`FC-TEM-06`); workflow, cabecera P6.3 |
| Rojo provocado | Un parche de `Demo/etapas/` que pone una suite en rojo a propósito, para demostrar que la suite mira lo que dice mirar | `Demo/etapas/README.md`; `04-Estrategia-De-Pruebas.md` |
| N1…N5 | Núcleos temáticos de la guía en capítulos (actualización, contenedor, integración, pruebas, demo) | `08-Cohesion-Global.md` §2 |
| P1…P11 | Decisiones numeradas del expediente 0001 que el código y los YAML citan (p. ej. P6.2 sin `paths`, P7 versionado, P8 rojos, P10 índice único) | Cabeceras de `framework-concept-demo.yml` y de `Demo/versionado/*` |

## 2. En una pantalla

- **Dos formas de la misma guía**:
  - la **guía en capítulos** (`Developer-Guide.md`, `00-Marco`, `01`–`08`, `99-Anexos`; edición 2026-10-26, todos en `borrador`);
  - el **libro** `MAUI-Framework-Developer-Guide.md` (`FC-GUIA-LIBRO`, 2 865 líneas, «1.0.0-borrador», reedición 04 del
    2026-11-01), que reúne todo en un texto autocontenido de 12 capítulos y anexos A–H.
- **Capa nueva desde la ia-db anterior**:
  - `Decisiones/` (ADR-0001, *contenedor nativo* en lugar de «cascarón», vigente desde el 2026-11-02);
  - `Conocimientos/` (un conocimiento reutilizable para arrancar proyectos con estos principios);
  - el contenedor nativo en iOS (simulador) con su workflow de entrega `framework-concept-ios.yml`.
- **Demo**: una solución .NET 10 con tres proyectos de producto (`Shell`, `Core`, `Content`), tres de pruebas y tres
  herramientas. Compila dentro de un contenedor (`Demo/contenedor/Dockerfile`), sin .NET en el host. iOS compila sólo en una
  Mac con la receta fija `Demo/ci/receta/ios/versiones.env`.
- **CI**:
  - `framework-concept-demo.yml` es la compuerta de PR (`fw-ok`) y corre en un runner propio con la etiqueta `ci-hdcm`;
  - `framework-concept-ios.yml` es la entrega iOS en `main` o a mano. **No** es compuerta.
- **Fuera del conjunto**: `Framework-APP.md` es el borrador original del PO. Se conserva como documento de origen y no
  se edita (`99-Anexos.md` §8; ADR-0001 §3).

## 3. Inventario de la guía

Rutas bajo `Concepts/Framework-Concept/`. La carpeta tiene 284 archivos versionados: 22 fuera de `Demo/` y 262 dentro
(`git ls-files` en `34929f2`). Las líneas son `wc -l`.

| Ruta | `doc_id` · `doc_type` | Líneas | Qué contiene |
| --- | --- | ---: | --- |
| `README.md` | `GUIA-PORTADA` · portada | 55 | §0 «Empezá acá» (4 pasos), vocabulario del ADR, mermaid portada → índice. Aclara que **no es índice** (P10) |
| `Developer-Guide.md` | `FC-GUIA-INDICE` · indice, v1.0.0 | 543 | §1 resumen, §2 lector, §3 tabla de documentos y ruta, §4 la idea en una página, §5 recorrido con la demo, §6 diez ejercicios, §7 rojos provocados, §8 limitaciones, **§9 plataformas verificadas y plan** (nuevo) |
| `00-Marco.md` | `FC-MARCO-REFERENCIA` · marco-de-referencia | 257 | Vocabulario mínimo, escenarios, contextos, actores, mapa «estoy acá → qué aplico» (§6) |
| `01-Actualizacion-Sin-Tienda.md` | `FC-TEM-01` · tema | 262 | N1: contenido descargable, canal firmado, activación, rollback, semilla |
| `02-Cascaron-Puente-Y-Capacidades.md` | `FC-TEM-02` · tema | 284 | N2: puente, catálogo de capacidades, predicado de compatibilidad, base local, outbox, encuestas como datos |
| `03-Integracion-Y-Versionado.md` | `FC-TEM-03` · tema | 236 | N3: alternativas de ramas, protección, líneas de versión (conceptos) |
| `04-Estrategia-De-Pruebas.md` | `FC-TEM-04` · tema | 188 | N4: capas, compuerta mínima, rojos provocados |
| `05-La-Demo-Como-Caso-De-Estudio.md` | `FC-TEM-05` · tema | 204 | N5: del caso base a la app autoactualizable, contenedor de build, guion |
| `06-Procedimientos-PR-Integracion-Versionado.md` | `FC-TEM-06` · tema | 339 | `fw-ok`, ramas, protección de `main`, las cuatro líneas de versión, fusionar y publicar, §8 procedimientos |
| `07-Red-Y-Autenticacion.md` | `FC-TEM-07` · tema | 325 | Estado de red, política de acciones, OIDC + PKCE, desbloqueo con la seguridad del teléfono |
| `08-Cohesion-Global.md` | `FC-TEM-08` · tema | 127 | Grafo de núcleos, contratos en cada borde, contradicciones resueltas |
| `99-Anexos.md` | `FC-ANEXO-99` · anexo | 257 | Glosario, equivalencias de nombres, fuentes, trazabilidad a folios, mapa guía ↔ demo, pendientes y NO VERIFICADO, §8 insumos fuera del conjunto |
| `MAUI-Framework-Developer-Guide.md` | `FC-GUIA-LIBRO` · libro | 2 865 | Libro en 5 partes, 12 capítulos y anexos A–H (ver §4) |
| `Decisiones/README.md` | `FC-DECISIONES` · indice | 24 | Índice de ADR |
| `Decisiones/ADR-0001-Contenedor-Nativo.md` | `FC-ADR-0001` · proceso, **vigente** | 94 | Término y regla de uso. Alcance del renombre y lo que no se toca. Riesgo con `Microsoft.Maui.Controls.Shell` |
| `Conocimientos/README.md` | — (sin frontmatter) | 14 | Tabla de conocimientos y convenciones de cita (`[ruta:líneas]`, `[Libro §x]`, `[Rn]`) |
| `Conocimientos/Knowledge-App-Hibrida-OTA-Offline-First.md` | — (encabezado de conocimiento: alias, naturaleza «propio», v1.0, Vigente, 2026-11-01) | 386 | Qué decidir y en qué orden: cuándo sí y cuándo no, arquitectura, contrato del puente, OTA, outbox, sesión y equipos compartidos, métricas de arranque, pruebas, checklist de arranque, límites |
| `Framework-APP.md` | — (sin frontmatter) | 382 | Borrador del PO: qué se quiere, punto crítico, login, cámara, red, SQLite, puente, estructura tentativa, PoC, decisiones abiertas, riesgos |
| `Demo/**` | — | 262 archivos | Ver §6 |

Todos los capítulos llevan el mismo esqueleto: resumen ejecutivo, definición, aplicación por escenario, ejemplos,
preguntas guía, criterios de calidad, anexo con plantilla comentada, observaciones y referencias. Cada uno declara
`traces` hacia los demás `FC-*`.

## 4. Rutas de lectura

**Guía en capítulos** (`Developer-Guide.md` §3; portada, mermaid):

```text
README (portada) → Developer-Guide (índice único)
   → 00-Marco → 01 … 07 (temas) → 08-Cohesión → 99-Anexos
   «hacerlo ahora»: Developer-Guide §6 ejercicios · «evaluar un PR»: preguntas guía + FC-TEM-06
```

**Libro** (`MAUI-Framework-Developer-Guide.md`, Prólogo, tabla 0.1):

| Parte | Capítulos |
| --- | --- |
| I. Fundamentos | 1 Fundamentos · 2 Marco de referencia |
| II. Mecanismo | 3 OTA firmada con rollback · 4 Contenedor nativo y contrato del puente · 5 Base local y outbox · 6 Red y sesión del dispositivo |
| III. Ingeniería | 7 Integración y versionado · 8 Estrategia de pruebas · 9 Seguridad del entorno y cuentas en la industria |
| IV. Práctica | 10 La demo como caso de estudio y ejercicios · 11 Cohesión y mantenimiento de la guía |
| V. Industria | 12 El framework en la industria |
| Anexos | A Glosario · B Referencias `[Rn]` · C Folios y ensayos · D Mapa libro ↔ demo · E Marcas de estado · F Plantillas · G Diferencias con `Framework-APP.md` · H Historia de tramos y corrida fechada |

| Perfil (tabla 0.1) | Ruta |
| --- | --- |
| Quien llega sin contexto | 1 → 2 → 10 |
| Desarrollador del contenido | 1 → 4 → 5 → 8 |
| Desarrollador del contenedor nativo | 1 → 3 → 4 → 6 → 9 |
| Quien integra y publica | 1 → 7 → 8 → 3.10 |
| Quien evalúa la arquitectura | 1 → 2 → 12 → 9 |

**Marcas de estado del libro** (Prólogo, tabla 0.2; Anexo E): **NO VERIFICADO**, **NO EJECUTADO**, **ESPECULACIÓN**,
**HISTÓRICO (fecha)** y **VARIANTE NO FUSIONADA**. Las citas van al final de la oración: `[archivo:líneas]`,
`[folio NNN]` (expediente privado, sin enlace), `[E0x]` (ensayos) y `[Rn]` (web, Anexo B). Los conteos de pruebas
viven sólo en la corrida fechada del Anexo H.

**Arranque rápido** (`README.md` §0):
1. `Developer-Guide` §1 y §4.
2. El ejercicio 1, compilar sin instalar nada.
3. `Demo/README` para el teléfono.
4. El libro para leer todo de corrido, o el Conocimiento para empezar un proyecto.

## 5. Conceptos y decisiones clave

| Concepto / decisión | Qué fija | Dónde |
| --- | --- | --- |
| Dos capas | El contenedor nativo cambia poco y va por tienda. El contenido web va OTA | `Developer-Guide.md` §4; Libro cap. 1 |
| Activación con staging y rollback | La versión nueva baja a staging y se activa en el próximo arranque en frío. Si nunca confirma «Listo», se vuelve atrás | Libro cap. 3 (pasos 3–7 del recorrido); `01-…` |
| Firma del canal | Índice con `keyId`, `emitido` y `expires`. Cada paquete lleva `sha256`. La clave pública de la demo está en `Demo/claves/publica-demo.pem` | `Demo/semilla/indice.json`; `01-…` |
| Contenido sin pre-release | SemVer 2.0.0 sin sufijo; el empaquetador agrega `+<commit>`. La madurez la da el canal, no un sufijo (P7) | `Demo/versionado/contenido.json` |
| Cuatro líneas de versión | Contenido, puente, contenedor (`ApplicationDisplayVersion` + `ApplicationVersion` monótono) y fase | `Demo/versionado/{contenido,puente,fase}.json`, `version-cascaron.props`; `06-…` |
| Compatibilidad por puente | `puenteMayor` del índice contra el mayor del contrato. La instantánea de la compuerta exige que coincidan `puente.json`, `ContratoDelPuente.Version` y `contrato.json` (P3) | `Demo/versionado/puente.json`; `02-…` |
| Offline-first | La base local es la fuente de verdad y los envíos salen por outbox. La política de acciones depende del estado de red | Libro caps. 5–6; `07-…` |
| Sesión del dispositivo | OIDC + PKCE contra un emisor (Keycloak de ensayo). Sellado en Keystore o Keychain, desbloqueo con la seguridad del teléfono, equipos compartidos | `07-…`; `Demo/DISENO-RED-Y-AUTENTICACION.md`; Conocimiento §7 |
| Base sin código dinámico | Modelo compilado y consultas precompiladas de EF Core (`--precompile-queries --nativeaot`), versionados. Se regeneran con cualquier cambio en `Data/` | `Demo/scripts/modelo-compilado.sh`; `Demo/README.md` §«La base del contenedor nativo sin código dinámico» |
| Reglas de tienda | Rigen Apple 2.5.2, 4.7 y 4.7.2 y la regla de Google sobre código interpretado. La 4.7.2 afecta al puente | ADR-0001 §4; Libro y Conocimiento |
| Índice único (P10) | `Developer-Guide.md` es el único índice de la guía en capítulos. La portada sólo remite | `README.md` §2 |
| Término (ADR-0001) | En la prosa se dice «contenedor nativo», nunca «contenedor» solo. Se descartan «App Shell model», «contenido web remoto» y «sitio empaquetado» | ADR-0001 §2 |
| Cifras de la demo | Son parámetros de la demo, no norma | Conocimiento §0 (`[Libro §1.4.2]`) |

## 6. La demo (`Demo/`)

Inventario por carpeta (262 archivos):

| Carpeta / archivo | Arch. | Qué es |
| --- | ---: | --- |
| `README.md` (541 l.) | 1 | Qué hace falta, cómo se compila, prueba y corre, el contenedor en iOS, qué hay en cada carpeta, dónde está cada decisión en el código, estado por tramos A1–A4 y medición del TPR |
| `MAPA-CASO-BASE.md` (74 l.) | 1 | Mapa del caso base del que parte la demo |
| `DISENO-RED-Y-AUTENTICACION.md` (726 l.) | 1 | Diseño de red y autenticación (incremento del folio 038) |
| `src/FrameworkConcept.Shell/` | 81 | Contenedor nativo MAUI: `Actualizacion`, `Auth`, `Bridge`, `Catalogo`, `Data` (21, con `Compilado/`), `Hosting`, `Pages`, `Platforms`, `Red`, `Sync` |
| `src/FrameworkConcept.Core/` | 55 | Núcleo compartido: `Application`, `Auth`, `Contracts` (con `contrato.json`), `Domain`, `Red`, `Update` |
| `src/FrameworkConcept.Content/` | 32 | Contenido Blazor WASM: `Auth`, `Bridge`, `Pages`, `Red`, `Survey`, `Testing`, `declaracion-del-contenido.json` |
| `tests/FrameworkConcept.{Core,Gate,Update}.Tests/` | 14 + 14 + 9 | Núcleo y dominio, compuerta (instantánea del contrato, definiciones, catálogo) y actualizador |
| `tools/FrameworkConcept.Tools/` | 11 | Claves, empaquetar, indexar, firmar, verificar, retirar, publicar definiciones, leer TPR |
| `tools/FrameworkConcept.Receptor/` | 8 | Doble del servidor: canal estático, recepción y validación de respuestas, autenticación |
| `tools/FrameworkConcept.Shell.Diseno/` | 2 | Proyecto de diseño para `dotnet ef` (el contenedor es MAUI) |
| `semilla/` | 4 | `indice.json` + `.sig` (canal `dev`, contenido `1.0.0+dc96101`, emitido 2026-11-02, vence 2026-12-02), `paquetes/contenido-1.0.0.zip`, definición v1 |
| `definiciones/encuesta-movilidad/` | 3 | `esquema.json`, `v1.json`, `v2.json` |
| `claves/publica-demo.pem` | 1 | Clave **pública** de la demo |
| `etapas/` | 4 | `README.md` y tres parches de rojo: `M-13-codigo-postal-cinco-digitos` (`Core.Tests`), `aviso-promovido-a-error` (CS0219 con `CI=true`), `error-de-compilacion-en-el-cascaron` (CS0029 en el APK) |
| `scripts/` | 6 | `contenedor.sh`, `imagen.sh` (imagen por huella de la receta), `guion.sh` (recorrido / `humo`), `ci-local.sh` (compuerta local), `modelo-compilado.sh`, `humo-ios.sh` (humo en el simulador) |
| `ci/receta/ios/` | 2 | `versiones.env` (Xcode, runtime, SDK y workloads fijos), `verificar.sh` |
| `infra/keycloak/` | 2 | `keycloak.sh`, `realm-fc-demo.json`: emisor OIDC de ensayo |
| `contenedor/Dockerfile` | 1 | Imagen de compilación |
| `versionado/` | 4 | `contenido.json` 1.0.0, `puente.json` 1.3.0, `fase.json` «diseño», `version-cascaron.props` 1.0.0 / 1 |
| Raíz | 6 | `FrameworkConcept.Demo.sln`, `FrameworkConcept.Demo.SinMaui.slnf`, `global.json` (SDK 10.0.400, `latestPatch`), `Directory.Build.props`, `.config/dotnet-tools.json` (`dotnet-ef` local), `.gitignore` |

**Estado por plataforma** (`Developer-Guide.md` §9 y `Demo/README.md`):

| Plataforma | Estado |
| --- | --- |
| Emulador Android 13 x86_64, WebView 155 | Recorridos completos de E02 y E03 |
| Teléfono de medida (moto g42) | Sólo E01, un intento de E02 y el TPR con APK Release (folio 049). Sin recorrido completo |
| Android con WebView 83 | El runtime de Blazor .NET 10 no arranca (E01) |
| Simulador iOS 26 (Face ID simulado) | **Verificado** según `Demo/README.md` §«El contenedor nativo en iOS»: arranque, puente, login por formulario y por navegador (`ASWebAuthenticationSession`), Keychain, bloqueo y desbloqueo, con red y sin red. Queda **NO VERIFICADO** lo que corre en un teléfono: Secure Enclave, biometría real, firma con perfil |

**TPR** (Libro, Anexo H.3):

| Variante | TPR en régimen | Estado |
| --- | --- | --- |
| Original, con la semilla en el camino crítico | ~8,2 s | Histórico |
| `main` desde 2026-10-29 | 6,9–7,3 s (9,2 s en la primera corrida) | Fusionada |
| E04 V1 | 4,8–5,2 s | Variante no fusionada (folio 052) |
| E04 V1S | 4,9–5,6 s | Variante no fusionada (folio 053) |

El umbral de ≤ 5 s en el teléfono **no está alcanzado en `main`**.

## 7. CI: los dos workflows

| Workflow | Disparo | Runner | Jobs | Rol |
| --- | --- | --- | --- | --- |
| `.github/workflows/framework-concept-demo.yml` | `pull_request` y `workflow_dispatch`, **sin `paths`** (P6.2) | `[self-hosted, ci-hdcm]` con guarda de mismo repositorio (P6.4) | `alcance` (¿el PR toca la demo?) → `compuerta` (0 base del PR, 1 build sin MAUI con avisos como error, 2 `Core.Tests`, 3 `Update.Tests`, 4 `Gate.Tests`, 5 publish y empaquetado) + `apk` (6 APK android-arm64) → `fw-ok` | **Compuerta**: `fw-ok` es el único check requerido. Si `alcance` dice que el PR no toca la demo, da verde por omisión declarada |
| `.github/workflows/framework-concept-ios.yml` | `push` a `main` con `paths` en `Demo/**` y el propio YAML, excepto `**.md`; `workflow_dispatch` con input `runner` (`m4dev` por defecto, o `github`) | El job `elegir` (`ubuntu-latest`) calcula `runs-on`. En `push` usa `vars.FC_IOS_RUNNER` y, si falta, `github` (macos-15) | `elegir` → `ios-simulador`: build Release `iossimulator-arm64` con firma ad hoc, instalación, apertura, espera de la marca `FC-MARCA primer-render` y artefactos (.app, bitácora, captura, video, TPR, manifiesto de herramientas) | **Entrega**, no compuerta. Nunca se dispara con `pull_request`, porque el runner propio es una VM efímera JIT. La cadena de herramientas es fija según `ci/receta/ios/versiones.env`, y el Xcode lleva SHA-256 fijado y caché |

La etiqueta `ci-hdcm` reemplazó a `i7infra-dev` (commit `9865b23`, «ci: etiqueta genérica del runner propio»).

## 8. Procedencia y relaciones

- **Expediente**: la guía y la demo salen del expediente 0001 de Framework Concept, en el repositorio de documentación
  hermano: `Lab-Documentos.Documentacion/PROMPTs/Concepts/01-Framework-Concept/OUTPUTs/Expedientes/0001-Framework-Concept-Maui-Autoactualizable/`.
  - Folios citados desde la guía: 001, 004–007, 021, 023, 035–038, 042, 047, 049, 050 y 052–054. El 054 es un
    dictamen de UX sobre arranque, actualización y sin conexión.
  - Ensayos citados: `OUTPUTs/Ensayos/E01`–`E03` (E04 lo citan el libro y el Anexo H).
  - El libro aclara que el expediente es **privado** y lo cita sin enlace (Prólogo).
- **Terminología**: la mesa del 2026-11-01 que originó ADR-0001 está en
  `Lab-Documentos.Documentacion/PROMPTs/Guides/16-IA-Layer/OUTPUTs/Bitacoras/Prompt-02/Terminologia/` (ADR-0001 §1), y se
  aprobó 5/5. Es la relación con la guía de IA Layer (ver el índice de `Guides/IA` de esta ia-db).
- **DocsAsCode**: el expediente 0003 de DocsAsCode tiene dos evidencias selladas que copian «cascarón» de
  `01-Actualizacion-Sin-Tienda.md:235` (ADR-0001 §3). Por eso esa línea no se toca.
- **Otras referencias del repo**: `.github/pull_request_template.md` (1 mención en texto a `Concepts/Framework-Concept/Demo/**`)
  y `framework-concept-demo.yml` (3 menciones a rutas de la carpeta). El libro cita el YAML por líneas 7 veces
  (p. ej. `framework-concept-demo.yml:166-170`, `:41-205`).
- **Workflow de referencia**: el de iOS se basa en el CD de iOS de `Ejemplo_Maui_Hibrida`, según su cabecera
  (repo externo, sin verificar).

## 9. Estado y vigencia

| Pieza | Estado | Nota |
| --- | --- | --- |
| Capítulos 00–08, 99, `Developer-Guide.md` | `borrador`, `last_review` 2026-10-26 | **Congelados por diseño**: el libro los cita por número de línea (ADR-0001 §3). Siguen diciendo «cascarón» |
| Libro | `borrador`, 2026-11-01, reedición 04 | Es el texto más completo y actual. Recoge folios hasta el 054 y E04 |
| Conocimiento | v1.0 Vigente, 2026-11-01 | `Compatible-con` el libro, edición 2026-11-01 |
| ADR-0001 | vigente, 2026-11-02 | El renombre de la prosa ya está aplicado: «cascarón» queda en 1–3 apariciones por archivo en `Demo/README.md`, `DISENO-…`, el libro y el Conocimiento (primera mención o cita). «App Shell model» ya no figura fuera del ADR |
| `Framework-APP.md` | Documento de origen | Fuera del conjunto. El Anexo G del libro lista las diferencias |
| Semilla | `1.0.0+dc96101` | Regenerada en `820541c`. El índice vence el 2026-12-02: después, la verificación de `expires` rechazaría la semilla (sin verificar el comportamiento exacto) |
| Duplicación | — | Capítulos ↔ libro es una duplicación **deliberada**: el libro es la consolidación y los capítulos quedan como fuente citada |

## 10. Hallazgos

| Tipo | Ruta | Evidencia |
| --- | --- | --- |
| Enlaces absolutos del workspace | 12 `.md` de la carpeta | 179 enlaces con la forma `](/LAB/Lab-Documentos/…)`. Resuelven en el workspace local, **no en GitHub**. Los que apuntan a `Lab-Documentos.Documentacion/…` llevan además a otro repositorio (privado según el libro) |
| Doble segmento en la ruta | `README.md` y otros | Los enlaces usan `/LAB/Lab-Documentos/Lab-Documentos/Concepts/…`, con la carpeta del workspace más la del repo |
| Estado de iOS contradictorio | `Developer-Guide.md` §9 vs `Demo/README.md` §«El contenedor nativo en iOS» | El índice dice «iOS: diseño sin ensayo, NO VERIFICADO — sin Mac ni cuenta de Apple Developer». La demo y `framework-concept-ios.yml` lo dan por verificado en el simulador. Es efecto del congelamiento del ADR: manda el libro o la demo |
| Plan A5 desactualizado | `Developer-Guide.md` §9; `06-…` l. 42 | Dicen «A5 entrega por PR y protección de `main`, pendiente» al 2026-10-26. Hoy `fw-ok` corre en el runner propio (sin verificar el estado de la protección de rama) |
| Versión del puente | Libro, Anexo H.2 vs `Demo/versionado/puente.json` | El Anexo H.2 dice 1.2.0 (corrida del 2026-11-01, marcada como fechada). Hoy `puente.json` y `contrato.json` dicen **1.3.0** |
| Enlace roto | `Framework-APP.md` l. 4 | `Cascaron-Aplicacion-Maui.md` no existe. Es el insumo fuera del conjunto y no se corrige |
| Sin frontmatter | `Conocimientos/*.md`, `Framework-APP.md` | El Conocimiento usa el encabezado propio de los conocimientos, no `doc_id`. `Conocimientos/README.md` no tiene ninguno de los dos |
| `doc_type` raro | `Decisiones/ADR-0001-…` | `doc_type: proceso` para un ADR, mientras su README es `indice` |
| Nombres heredados | `02-Cascaron-…`, `PuenteDelCascaron`, `ContextoDelCascaron.cs`, `version-cascaron.props`, `FrameworkConcept.Shell` | Se conservan a propósito (ADR-0001 §3). Existe el riesgo de confundir `FrameworkConcept.Shell` con `Microsoft.Maui.Controls.Shell` (§5 del ADR) |
| Nombre de etiqueta | `framework-concept-demo.yml` | `ci-hdcm` reemplazó a `i7infra-dev`. La ia-db v1.x lo registraba con la etiqueta vieja |
| Hostnames en prosa | `Demo/README.md` (emulador `fc-android-emu-hpdev`, «por Tailscale»), cabecera del YAML iOS (`m4dev`) | El corpus nombra las máquinas del entorno. No es una fuga de credenciales, pero sí un detalle local en un repo público |
| Fuera de la compuerta documental | Toda la carpeta | No está bajo un `corpus_id`, así que `docs-guard` la trata como heredada (sin verificar en `34929f2`) |

## 11. Para preguntas X → leé Y

| Necesitás saber… | Leé (bajo `Concepts/Framework-Concept/`) |
| --- | --- |
| La idea completa en una página | `Developer-Guide.md` §4; Libro cap. 1 |
| Todo de corrido y actualizado | `MAUI-Framework-Developer-Guide.md` (ruta por perfil en la tabla 0.1) |
| Cómo se actualiza sin tienda y cómo se vuelve atrás | Libro cap. 3; `01-Actualizacion-Sin-Tienda.md` |
| Qué expone el contenedor nativo y cómo se decide la compatibilidad | Libro cap. 4; `02-Cascaron-Puente-Y-Capacidades.md` |
| Trabajo sin red, base local y outbox | Libro cap. 5; Conocimiento §6 |
| Sesión, OIDC y desbloqueo | Libro cap. 6; `07-Red-Y-Autenticacion.md`; `Demo/DISENO-RED-Y-AUTENTICACION.md` |
| Ramas, `fw-ok` y versiones | `06-Procedimientos-PR-Integracion-Versionado.md`; Libro cap. 7; `Demo/versionado/` |
| Qué se prueba y los rojos provocados | Libro cap. 8; `Demo/etapas/README.md`; `Developer-Guide.md` §7 |
| Compilar y correr la demo (Android o iOS) | `Demo/README.md`; `Developer-Guide.md` §6 ejercicios 1–2; `Demo/ci/receta/ios/versiones.env` |
| Arrancar un proyecto nuevo con estos principios | `Conocimientos/Knowledge-App-Hibrida-OTA-Offline-First.md` §11 (checklist) |
| Por qué «contenedor nativo» y no «cascarón» | `Decisiones/ADR-0001-Contenedor-Nativo.md` |
| Comparación con Capacitor, Expo y la industria | Libro caps. 9 y 12 |
| TPR y cifras medidas | Libro Anexo H; `Demo/README.md` §«Medición del TPR» |
| Qué quedó pendiente | `99-Anexos.md` §6; `Developer-Guide.md` §8; Libro Anexo E |

## 12. Fuentes

Todas las rutas son relativas a `Lab-Documentos/`:

- `Concepts/Framework-Concept/README.md`, `Developer-Guide.md`, `00-Marco.md` … `08-Cohesion-Global.md`, `99-Anexos.md`
- `Concepts/Framework-Concept/MAUI-Framework-Developer-Guide.md` (Prólogo, tablas 0.1 y 0.2; Anexo H)
- `Concepts/Framework-Concept/Decisiones/README.md`, `Decisiones/ADR-0001-Contenedor-Nativo.md`
- `Concepts/Framework-Concept/Conocimientos/README.md`, `Conocimientos/Knowledge-App-Hibrida-OTA-Offline-First.md`
- `Concepts/Framework-Concept/Framework-APP.md`
- `Concepts/Framework-Concept/Demo/README.md`, `Demo/etapas/README.md`, `Demo/semilla/indice.json`, `Demo/versionado/*`,
  `Demo/scripts/humo-ios.sh`, `Demo/scripts/modelo-compilado.sh`, `Demo/src/FrameworkConcept.Core/Contracts/contrato.json`
- `.github/workflows/framework-concept-demo.yml`, `.github/workflows/framework-concept-ios.yml`
- Historia: `git log` de la carpeta (`9865b23`, `a9c1db6`, `820541c`, `dc96101`, `3727717`)

Vigente al **2026-11-16**, fuente `main` `34929f2`.
