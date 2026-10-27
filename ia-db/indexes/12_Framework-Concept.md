# 12 · Framework Concept: apps .NET MAUI con pantallas Blazor actualizables sin tienda

> **Propósito**: qué hay en `Concepts/Framework-Concept/` —una guía de estudio y una demo ejecutable para construir
> apps .NET MAUI cuyo contenido Blazor WebAssembly se actualiza desde un canal firmado propio, sin pasar por la
> tienda—, en qué orden se lee y cómo se compila y se prueba la demo.
> **Fuentes primarias**: `Concepts/Framework-Concept/Developer-Guide.md` (`GUIA-INDICE`, v1.0.0, único índice de la
> carpeta), `Concepts/Framework-Concept/README.md` (`GUIA-PORTADA`) y `Concepts/Framework-Concept/Demo/README.md`.
> **Vigencia**: verificado contra `Lab-Documentos` en `main` `fe10086` (2026-10-27). La carpeta entró el 2026-10-26
> (`CHANGELOG.md`, «guía nueva», v1.0.0 borrador) y recibió el folio 042 (medición del TPR) el 2026-10-27.

## Índice

1. [Definiciones](#1-definiciones)
2. [En una pantalla](#2-en-una-pantalla)
3. [Inventario de la guía](#3-inventario-de-la-guía)
4. [La demo (`Demo/`)](#4-la-demo-demo)
5. [Procedencia](#5-procedencia)
6. [Hallazgos](#6-hallazgos)
7. [Para preguntas X → leé Y](#7-para-preguntas-x--leé-y)

## 1. Definiciones

| Término | Significado |
| --- | --- |
| Cascarón | La app MAUI que se instala una vez por tienda y aloja el contenido |
| Contenido | Páginas Razor compiladas a Blazor WebAssembly que se descargan y activan sin tienda |
| Definiciones | Encuestas como datos JSON, que se corrigen sin subir la versión del cascarón |
| Canal firmado | Origen de paquetes con índice firmado (`semilla/indice.json` + `.sig`); una firma rota rechaza la actualización |
| `fw-ok` | Único check requerido de `main`: job agregador del workflow `framework-concept-demo` (`TEM-06`); verde habilita el merge |
| N1…N5 | Núcleos temáticos de la guía (actualización, cascarón, integración, pruebas, demo) |

## 2. En una pantalla

- **Guía**: `Developer-Guide.md` es el **único índice** (decisión P10 del expediente 0001); `README.md` es sólo una
  portada que remite a él. Marco + temas `TEM-01`…`TEM-08` + `ANEXO-99`, todos en `borrador`.
- **Demo**: solución .NET 10 (`FrameworkConcept.Demo.sln`, filtro `FrameworkConcept.Demo.SinMaui.slnf`) con tres
  proyectos (`FrameworkConcept.Shell`, `.Core`, `.Content`) y tres de pruebas (`.Core.Tests`, `.Gate.Tests`,
  `.Update.Tests`); compila dentro de un contenedor (`contenedor/Dockerfile`, SDK 10.0.400 + `maui-android`), sin .NET
  instalado en el host.
- **CI**: `.github/workflows/framework-concept-demo.yml`, un solo workflow de PR sin `paths` (un job `alcance` decide
  si corre la `compuerta`), en `[self-hosted, i7infra-dev]` con guarda de mismo repositorio.
- `Framework-APP.md` es un borrador del PO **fuera del conjunto**: no se edita ni forma parte de la guía
  (`ANEXO-99` §8).

## 3. Inventario de la guía

Rutas bajo `Concepts/Framework-Concept/` (245 archivos versionados en la carpeta; 232 en `Demo/`).

| Ruta | `doc_id` | Líneas | Qué contiene |
| --- | --- | ---: | --- |
| `README.md` | `GUIA-PORTADA` | 43 | Portada; remite al índice único |
| `Developer-Guide.md` | `GUIA-INDICE` | 498 | Resumen, lector, cómo usar la guía (§3, tabla de documentos), la idea en una página, recorrido con la demo, diez ejercicios guiados, rojos provocados, limitaciones |
| `00-Marco.md` | `MARCO-REFERENCIA` | 254 | Siete escenarios, contextos, actores y mapa conceptual |
| `01-Actualizacion-Sin-Tienda.md` | `TEM-01` | 259 | N1: contenido descargable, canal firmado, activación, rollback, semilla |
| `02-Cascaron-Puente-Y-Capacidades.md` | `TEM-02` | 281 | N2: puente, catálogo de capacidades, predicado de compatibilidad, base local, outbox, encuestas como datos |
| `03-Integracion-Y-Versionado.md` | `TEM-03` | 234 | N3: alternativas de ramas, protección y líneas de versión |
| `04-Estrategia-De-Pruebas.md` | `TEM-04` | 188 | N4: capas, compuerta mínima, rojos provocados |
| `05-La-Demo-Como-Caso-De-Estudio.md` | `TEM-05` | 200 | N5: cómo está armada la demo, el caso base, el contenedor y el guion |
| `06-Procedimientos-PR-Integracion-Versionado.md` | `TEM-06` | 334 | `fw-ok`, ramas, protección de `main`, las cuatro líneas de versión, fusionar y publicar |
| `07-Red-Y-Autenticacion.md` | `TEM-07` | 263 | Estado de red, política de acciones, OIDC + PKCE, desbloqueo con la seguridad del teléfono |
| `08-Cohesion-Global.md` | `TEM-08` | 126 | Relaciones entre núcleos, contratos en cada borde, contradicciones resueltas |
| `99-Anexos.md` | `ANEXO-99` | 240 | Glosario, fuentes, trazabilidad a folios, mapa guía ↔ demo, pendientes, apartamientos |
| `Framework-APP.md` | — (sin frontmatter) | 382 | Insumo del PO fuera del conjunto |

Ruta de lectura (`Developer-Guide.md` §3): la guía de corrido → `00-Marco` → `TEM-01`…`TEM-07` → `TEM-08` → `ANEXO-99`;
para «hacerlo ahora», §6 Ejercicios; para evaluar un PR, las preguntas guía de cada tema y `TEM-06`.

## 4. La demo (`Demo/`)

| Pieza | Qué es |
| --- | --- |
| `README.md` (407 líneas) | Qué hace falta, cómo se compila y se prueba, estado y recorrido en dispositivo |
| `MAPA-CASO-BASE.md`, `DISENO-RED-Y-AUTENTICACION.md` | Mapa del caso base del que parte la demo; diseño de red y autenticación (661 líneas) |
| `src/FrameworkConcept.{Shell,Core,Content}/` | Cascarón MAUI, núcleo compartido y contenido Blazor WebAssembly |
| `tests/FrameworkConcept.{Core,Gate,Update}.Tests/` | Pruebas del núcleo, de la compuerta y de la actualización |
| `semilla/`, `definiciones/`, `claves/publica-demo.pem` | Índice firmado, paquetes y encuestas de ejemplo; clave **pública** de la demo |
| `etapas/*.patch` | Cambios que provocan rojos a propósito (error en el cascarón, aviso promovido a error, regla `M-13`) |
| `scripts/{contenedor,imagen,guion,ci-local}.sh` | Imagen de compilación por huella de la receta, guion del recorrido, compuerta local |
| `infra/keycloak/` | Proveedor de identidad para el recorrido de red y cuenta |
| `global.json`, `Directory.Build.props` | SDK fijado y propiedades comunes |

Para ver el contenido hace falta un Android con WebView 94 o mayor; el README declara qué caminos de red se midieron
y cuáles siguen sin verificar.

## 5. Procedencia

La guía y la demo salen del **expediente 0001** de Framework Concept, en este repositorio:
`PROMPTs/Concepts/01-Framework-Concept/OUTPUTs/Expedientes/0001-Framework-Concept-Maui-Autoactualizable/`
(folio 037: plan de aplicación y cierre de la mesa, con la decisión P10; folio 042: medición del TPR). La delegación
del merge de ese expediente está en `CHANGELOG.md` de este repositorio (entrada del 2026-10-26).

## 6. Hallazgos

| Tipo | Ruta | Detalle |
| --- | --- | --- |
| Enlaces absolutos del workspace | todo `Concepts/Framework-Concept/` | 202 enlaces empiezan con `/LAB/Lab-Documentos/…` o `/LAB/Lab-Documentos.Documentacion/…`: resuelven en el workspace local, **no en GitHub** |
| Enlace roto | `Framework-APP.md` | `Cascaron-Aplicacion-Maui.md` no existe; es el insumo fuera del conjunto |
| `doc_id` que colisiona | `Developer-Guide.md` | `GUIA-INDICE` es también el README de DT, IS y OEP (4 en total; ver [10](10_Convenciones-y-Glosario.md) §2.1). `TEM-01`…`TEM-08` y `MARCO-REFERENCIA` no chocan hoy, pero no llevan sufijo de guía: citar siempre con la ruta |
| Action sin fijar por SHA | `.github/workflows/framework-concept-demo.yml` l. 48, 93, 154 | `actions/checkout@v4` por etiqueta; los otros tres workflows del repo la fijan por SHA |
| Fuera de la compuerta | toda la carpeta | No está bajo un `corpus_id`: `docs-guard` la trata como heredada (sólo avisos) |

## 7. Para preguntas X → leé Y

| Necesitás saber… | Leé (bajo `Concepts/Framework-Concept/`) |
| --- | --- |
| La idea completa en una página | `Developer-Guide.md` §4 |
| Cómo se actualiza el contenido sin tienda y cómo se vuelve atrás | `01-Actualizacion-Sin-Tienda.md` |
| Qué expone el cascarón al contenido y cómo se decide la compatibilidad | `02-Cascaron-Puente-Y-Capacidades.md` |
| Ramas, protección de `main` y versiones del producto | `03-Integracion-Y-Versionado.md`, `06-Procedimientos-PR-Integracion-Versionado.md` |
| Qué se prueba y qué es compuerta | `04-Estrategia-De-Pruebas.md`; `Developer-Guide.md` §7 |
| Compilar y correr la demo | `Demo/README.md`; `Developer-Guide.md` §6 ejercicios 1–2 |
| Sesión, OIDC y comportamiento sin red | `07-Red-Y-Autenticacion.md`; `Demo/DISENO-RED-Y-AUTENTICACION.md` |
| Qué quedó pendiente | `99-Anexos.md`; `Developer-Guide.md` §8 |
