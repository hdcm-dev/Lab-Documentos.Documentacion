---
doc_id: BIT-15-03
doc_type: marco-de-referencia
title: Marco de referencia — escenarios, contextos y actores
status: vigente
origin: agent
confidence: 0.8
owner: analista de descomposición (sin voto en la mesa)
last_review: 2026-10-07
audience: [mesa-evaluadora, redactores]
traces: [PROFILE-STUDY-GUIDE §Enfoque, BIT-15-01, BIT-15-02]
---

# Bitácora 03 — Marco de referencia

El Profile pide fijar, antes de escribir los temas, el vocabulario común que reaparece en toda la guía: **escenarios** (dónde ocurre el trabajo), **contextos** (qué variante cambia las respuestas dentro de un escenario) y **actores** (quién decide qué). Se definen una sola vez acá y en la §2 de la guía; los núcleos los referencian por ID. Un núcleo que no se cruza con ningún escenario ni contexto está mal delimitado: la matriz del §4 lo comprueba.

## Índice

- [1. Escenarios](#1-escenarios)
- [2. Contextos](#2-contextos)
- [3. Actores](#3-actores)
- [4. Matrices de cruce](#4-matrices-de-cruce)
- [5. Uso en la guía](#5-uso-en-la-guía)

## 1. Escenarios

Un escenario es el **lugar físico y lógico donde se edita, restaura o construye** el código. Lo que cambia entre escenarios es quién aporta cada capa del modelo N0 (el sistema operativo del host, el usuario, la imagen).

| ID | Escenario | Qué lo caracteriza | Riesgo típico para esta guía |
|---|---|---|---|
| ESC-01 | Estación Windows con Visual Studio | Edición, restauración y build nativas en Windows; el IDE trae su propio SDK/MSBuild; la configuración de git y de página de códigos es la del usuario. | Es el escenario donde el problema del caso **no se ve**: el código en cp1252 compila igual. Las configuraciones locales (`core.autocrlf`, codificación al guardar) suplen lo que el repo no declara. |
| ESC-02 | Estación Linux (o macOS) nativa | Editor de texto o IDE en Linux; SDK, Node y Python instalados en el host o con gestores de versión. | Donde el problema del caso **aparece**; versiones de toolchain instaladas a mano que divergen del resto. |
| ESC-03 | Windows con WSL 2 | Herramientas Linux sobre una máquina Windows; el repo puede vivir en el sistema de archivos de Windows o en el de Linux. | Mezcla de configuraciones de git (host y WSL), finales de línea según dónde se clonó, rendimiento de E/S entre sistemas de archivos. **[C: a verificar en learn.microsoft.com]** |
| ESC-04 | Devcontainer | El editor (VS Code u otro compatible) corre contra un contenedor definido en `devcontainer.json`; el repo se monta o se clona dentro. | Creer que el contenedor fija todo; bind mount de archivos escritos desde Windows; imagen por etiqueta que cambia bajo los pies. |
| ESC-05 | Integración continua (CI) | Build en una máquina efímera, sin estado previo, disparada por un push o PR; produce el artefacto que se publica. | Que la CI resuelva distinto que los desarrolladores; que sea la única que hace cumplir la política y nadie la reproduzca en local; que no deje registro de procedencia. |

**Criterio de delimitación.** WSL se separa de ESC-01 y ESC-02 porque combina configuraciones de ambos y tiene fallas propias; macOS no se separa de ESC-02 porque, para los temas de la guía (LF, UTF-8 por defecto, herramientas Unix), se comporta igual **[C: a verificar en N1 para el compilador de C#]**. La build de release fuera de CI no es un escenario aparte: si existe, la guía la trata como un ESC-05 sin garantías.

## 2. Contextos

Un contexto es la **composición tecnológica de la solución**. Dentro de un mismo escenario, el contexto cambia qué archivos de fijación existen y qué lectores de texto intervienen.

| ID | Contexto | Mecanismos que entran en juego (a verificar en cada núcleo) |
|---|---|---|
| CTX-NET | Solución .NET sola | Roslyn/MSBuild/Razor, `global.json`, NuGet (CPM, `packages.lock.json`, `nuget.config`), propiedades de build determinista, SourceLink. |
| CTX-NODE | Proyecto Node.js solo | Node y su lectura de archivos, `.nvmrc`/`.node-version`, `engines`, `packageManager`/Corepack, `package-lock.json`/`npm ci` (o pnpm/Yarn), procedencia de npm. |
| CTX-PY | Proyecto Python solo | PEP 263/PEP 686, `requires-python`, `.python-version`, entornos virtuales, uv/Poetry/pip-tools y sus lock files, PEP 751. |
| CTX-POLI | Solución políglota (.NET + Node.js + Python en un repo) | Todo lo anterior conviviendo: una política de texto raíz por extensión, un punto de verdad para las versiones, un lock file por ecosistema, orquestación de builds, imagen(es) multi-runtime, SBOM unificado. |

Una variante transversal que la guía nombra sin convertirla en contexto: **código heredado** (repositorio con historia previa a la política, como el del caso) frente a **repositorio nuevo**. Afecta sobre todo a N2 (migración) y N4 (adopción tardía de lock files), y se trata dentro de esos núcleos.

## 3. Actores

Un actor es un **rol con decisiones propias**. Una misma persona puede ocupar varios roles; la guía le dice a cada uno qué le toca decidir y qué no.

| ID | Actor | Decide | No decide | Necesita de la guía |
|---|---|---|---|---|
| ACT-DEV | Desarrollador | Su escenario de trabajo (ESC-01…04); configurar su editor y su git para respetar la política; regenerar el lock file cuando agrega una dependencia. | La política de texto, las versiones fijadas, la imagen base. | Saber qué archivos del repo mandan, cómo verificar en local antes del push, cómo diagnosticar un archivo con codificación incorrecta. |
| ACT-ARQ | Líder técnico / arquitecto | La política de texto (N2), las versiones de toolchain (N3), la estrategia de dependencias (N4), si se ofrece devcontainer (N5), la estructura del repo políglota (N8). | Cómo se implementa la compuerta en la herramienta de CI concreta. | Criterios para elegir entre alternativas y sus consecuencias por escenario y contexto. |
| ACT-OPS | DevOps / ingeniería de plataforma | La imagen de CI y del devcontainer, su fijación y actualización (N5, N7), la generación de SBOM y procedencia (N6), las compuertas (N7). | Las versiones de lenguaje o de dependencias de negocio. | Qué registrar para la procedencia, cómo hacer que la compuerta sea la misma en local y en CI. |
| ACT-REV | Revisor de PR | Aprobar o rechazar cambios; en particular los que tocan lock files, archivos de fijación, imagen base y `.gitattributes`/`.editorconfig`. | La política en sí (la aplica, no la define). | Una lista de verificación de qué mirar en un diff de entorno y cómo reconocer un cambio de BOM/EOL que no debería estar. |

**Actor que se descartó como separado:** *consumidor del artefacto* (quien despliega o audita la pieza construida). Se cubre dentro de N6 como destinatario de la procedencia, sin decisiones sobre el entorno de desarrollo. Si la mesa entiende que la auditoría externa es un actor con decisiones propias, se agrega.

## 4. Matrices de cruce

### 4.1 Núcleo × escenario (dónde pesa cada núcleo)

`●` el núcleo es central en ese escenario; `○` aplica con matices; `—` no aplica.

| Núcleo | ESC-01 Windows+VS | ESC-02 Linux | ESC-03 WSL | ESC-04 Devcontainer | ESC-05 CI |
|---|---|---|---|---|---|
| N0 Modelo de capas | ● | ● | ● | ● | ● |
| N1 Codificación (fenómeno) | ● (lo oculta) | ● (lo revela) | ● | ● | ● |
| N2 Política de texto | ● | ● | ● | ○ | ● (la hace cumplir) |
| N3 Toolchain | ● | ● | ● | ○ (la imagen lo trae) | ● |
| N4 Dependencias | ● | ● | ● | ● | ● (modo estricto) |
| N5 Contenedores | ○ (convivencia) | ○ | ● | ● | ● |
| N6 Procedencia | — | — | — | ○ | ● |
| N7 Compuertas | ○ (hooks locales) | ○ | ○ | ○ | ● |
| N8 Políglota | ● | ● | ● | ● | ● |

N6 sólo pesa en CI por una decisión de criterio propio (a someter a la mesa): la procedencia que vale es la del artefacto que se publica, y ese sale de la CI. Las builds locales se tratan como no trazables salvo que reproduzcan el entorno de CI.

### 4.2 Núcleo × contexto

| Núcleo | CTX-NET | CTX-NODE | CTX-PY | CTX-POLI |
|---|---|---|---|---|
| N1 | Roslyn/MSBuild/Razor | lectura de módulos y `fs` | PEP 263 / 540 / 686 | choque de convenciones |
| N2 | BOM para `.cs`/`.razor` | sin BOM (a verificar) | sin BOM (a verificar) | política por extensión |
| N3 | `global.json` | `.nvmrc`, `engines`, `packageManager` | `requires-python`, `.python-version` | un punto de verdad (gestor multi-runtime o devcontainer) |
| N4 | CPM + `packages.lock.json` | `package-lock.json` + `npm ci` | `uv.lock` / `poetry.lock` / `pylock.toml` | un lock por ecosistema |
| N5 | imagen `dotnet/sdk` | imagen `node` | imagen `python` | imagen multi-runtime o varias |
| N6 | determinismo, SourceLink, SBOM | procedencia de npm, SBOM | metadatos, `SOURCE_DATE_EPOCH`, SBOM | SBOM y procedencia unificados |
| N7 | compuerta común | compuerta común | compuerta común | orquestación de compuertas |

Las celdas son el temario que cada núcleo debe verificar, no afirmaciones: las marcadas «a verificar» y todos los nombres de mecanismos se confirman con fuente oficial antes de pasar a la guía.

### 4.3 Actor × núcleo (qué le toca a cada uno)

| Actor | Lidera | Aplica | Verifica |
|---|---|---|---|
| ACT-DEV | — | N2, N3, N4, N5 | su build local antes del push |
| ACT-ARQ | N0, N2, N3, N4, N8 | — | coherencia entre núcleos |
| ACT-OPS | N5, N6, N7 | — | compuertas y procedencia |
| ACT-REV | — | N7 (lista de verificación) | diffs de N2, N3, N4, N5 |

## 5. Uso en la guía

- La §2 de la guía reproduce las tablas de §1–§3 (versión editada) y es la única definición; el resto de la guía usa los IDs o los nombres cortos.
- Cada sección temática §4–§11 tiene una subsección «Aplicación por escenario» que recorre ESC-01…ESC-05 y dice qué cambia por contexto, con la matriz §4.1 como control de completitud.
- El Anexo B (listas de verificación) se organiza por actor (ACT-DEV, ACT-ARQ, ACT-OPS, ACT-REV).
- El caso disparador se narra como un recorrido ESC-01 → ESC-02/ESC-04 en CTX-NET con código heredado, y reaparece en CTX-POLI en la §11.
