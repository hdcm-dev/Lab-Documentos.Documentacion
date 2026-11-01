# Acta 00 — Constitución de la mesa de reedición (prompt 04)

> Mesa pedida por nombre por el PO. Se rige por `Knowledge-Mesa-De-Expertos-A-Pedido` (3.1) y, para dialogar con el PO, por `Knowledge-Mesa-Consulta-A-Un-Tercero` (2.0). Perfil aplicado: `Profiles/Study-Guide-Documentation.md`. Fecha: 2026-11-01.

## Índice

1. [Fuente](#1-fuente)
2. [Enunciado](#2-enunciado)
3. [Objetivo con origen](#3-objetivo-con-origen)
4. [Especialistas reclutados](#4-especialistas-reclutados)
5. [Contexto dado por el PO](#5-contexto-dado-por-el-po)
6. [Solicitudes del PO](#6-solicitudes-del-po)
7. [Reglas del PO](#7-reglas-del-po)
8. [Pedidos nuevos del PO (2026-11-01)](#8-pedidos-nuevos-del-po-2026-11-01)
9. [Material bajo revisión y fuentes de hechos](#9-material-bajo-revisión-y-fuentes-de-hechos)
10. [Cláusulas operativas](#10-cláusulas-operativas)

## 1. Fuente

Prompt `PROMPTs/Concepts/01-Framework-Concept/04-Ajuste-Coherencia-Reedicion-Documentacion.md` (Lab-Documentos.Documentacion). Nota: el worktree `ldd-libro` no lo contiene todavía; se leyó del clon principal en `main`.

## 2. Enunciado

| Frase del PO | Función | Sujeto |
|---|---|---|
| «Editar los contenidos generados y armonizar con respecto a ejemplos y demo construida» | Objetivo | Documentación de `Concepts/Framework-Concept` |
| «1- Coherencia de lo redactado … congruente con las ejemplificaciones» | Solicitud 1 | Redacción ↔ Demo/ejemplos |
| «2- … documento unificado … `MAUI-Framework-Developer-Guide.md` … ronda de revisión como si fuera un libro … sección inicial que explique estos fundamentos» | Solicitud 2 | Libro unificado |
| «3- … confeccionar un conocimiento en `…/Conocimientos`» | Solicitud 3 | Conocimiento |
| «4- Añadir referencias y casos según lo que se ha relevado en la industria» | Solicitud 4 | Referencias |
| Tabla de intervenciones editoriales | Método de la solicitud 2 | Editores |
| «material suficiente para que un grupo de desarrolladores … agentes IA o humanos trabaje» | Criterio de aceptación | Libro + ejemplos + demo |

Lectura ambigua declarada: «documento unificado» puede leerse como reemplazo de los 00–08 o como libro adicional que los reúne. Se toma la que menos agrega: **libro adicional**; los documentos individuales se corrigen por coherencia pero no se borran (decisión revisable por la mesa con motivo).

## 3. Objetivo con origen

1. Coherencia redacción ↔ demo (Solicitud 1).
2. Libro unificado, autocontenido, no delta, con índice, jerárquico, definiciones, ejemplos y mermaid (Solicitud 2 + Regla 1).
3. Sección inicial de fundamentos: app híbrida, OTA firmadas con rollback, offline-first con outbox; secundarios: red, autenticación del dispositivo y Keystore, contrato del puente y capacidades (Contexto).
4. Revisión editorial en seis intervenciones (tabla del PO).
5. Un Conocimiento (Solicitud 3).
6. Referencias y casos de la industria (Solicitud 4).
7. Núcleo de seguridad del entorno y cuentas (pedido nuevo del PO, §8).

Agregados marcados (no son del PO): ninguno en el objetivo; el criterio «repo público sin datos privados» viene de la regla vigente de publicación del workspace.

## 4. Especialistas reclutados

| Rol | Pedido por | Función en la mesa |
|---|---|---|
| Analista de sistemas | PO (explícito) | Coherencia de requisitos y conceptos entre documentos y demo; trazabilidad |
| Arquitecto de apps móviles .NET MAUI | PO (explícito) | Arquitectura del cascarón, BlazorWebView, puente, actualizador; simplicidad/escalabilidad |
| Especialista en análisis y criterios de decisión | PO (explícito) | Criterios de decisión, análisis de las decisiones D-xx, alternativas y consecuencias |
| Académico en edición bibliográfica y de libros | PO (explícito) | Edición de contenido y académica; estructura de libro, citas, ejemplos y material de consulta |
| Corrector de estilo y ortotipográfico | Tabla del PO | Corrección de estilo, ortotipografía, corrección de pruebas |
| Diseñador editorial | Tabla del PO | Diagramación markdown, índices, mermaid, tablas |
| Investigador de industria y estándares | PO («tendencias del mercado y estándares») | Referencias verificables (URL) y casos: Capacitor, Expo, CodePush, PWA, OWASP MASVS |
| Especialista en seguridad móvil | PO (pedido nuevo BNA+/Mercado Libre) | RASP, Play Integrity, Keystore, Credential Manager, account linking |
| Refutador | Knowledge Mesa a pedido | Refuta objetivo y conclusiones; marca afirmaciones sin evidencia |
| Entrevistador y coordinador | Knowledge Consulta a un tercero | Una sola mano en el canal con el PO; rondas de preguntas con contexto |

## 5. Contexto dado por el PO

El framework se describe en la industria como **«app híbrida offline-first con actualizaciones OTA (live updates)»**:

| Rasgo | Cómo se llama | Referentes |
|---|---|---|
| Cascarón MAUI + pantallas web en WebView | App híbrida (Blazor Hybrid) | Capacitor/Ionic, Cordova, BlazorWebView |
| Pantallas cambiadas sin tienda | OTA / live updates / code push | EAS Update, CodePush (retirado), Capawesome Live Update, Ionic Appflow Deploy |
| Trabaja sin red, envía después | Offline-first con outbox | Ciclo de vida de service workers PWA |

Secundarios: estado de red e internet; autenticación del dispositivo (huella, PIN, patrón) y Keystore; contrato del puente versionado (P3) y capacidades por catálogo.

## 6. Solicitudes del PO

1. Coherencia de lo redactado, consecuente y congruente con las ejemplificaciones.
2. Documento unificado `MAUI-Framework-Developer-Guide.md` que reúna los individuales; ronda de revisión como libro; sección inicial de fundamentos.
3. Conocimiento en `Concepts/Framework-Concept/Conocimientos`.
4. Referencias y casos de la industria.

Guía editorial del PO: edición de contenido · edición académica · corrección de estilo · corrección ortotipográfica · diseño editorial · corrección de pruebas.

Además: abrir expedientes si se requiere seguimiento; debatir; consultar estándares; arquitectura clara con alternativas, buscando simplicidad, practicidad y escalabilidad; los investigadores pueden ensayar; basarse en tendencias del mercado y estándares.

## 7. Reglas del PO

- Markdown jerárquico, con definiciones, explicaciones, ejemplos claros y mermaid cuando haga falta; autocontenido, no delta; con índices.
- Descomposición conceptual por núcleos (afinidad y dependencia, no extensión), un markdown por núcleo, documento de cohesión global y fase de integración; registros retomables en `OUTPUTs/Bitacoras` (esta corrida: `Bitacoras/Reedicion-04/`).
- No inventar información.
- Toda afirmación respaldada por evidencia verificable (archivo:línea, folio del expediente o URL).

## 8. Pedidos nuevos del PO (2026-11-01)

- **(a) BNA+** (`ar.com.bna.digital`): en un teléfono Android con depuración USB activa se cierra sola a los ~3 s; el proceso muere por sí mismo (`ActivityManager` «appDiedLocked … isKilledByAm=false»), muestra un toast breve, clases ofuscadas con caracteres de varios alfabetos. Documentar mecanismos RASP (depuración/adb, root, emulador, hooking/Frida, acceso remoto/superposición, accesibilidad, Play Integrity, FLAG_SECURE), **especulando con fundamento** y marcando lo especulado.
- **(b) Mercado Libre**: login con la cuenta cargada en el teléfono; una cuenta de Gmail no registrada lleva a crear la cuenta fuera de la app. Documentar Credential Manager / Sign in with Google / One Tap, account linking, creación de cuenta delegada, y qué podría adoptar el framework.

## 9. Material bajo revisión y fuentes de hechos

- Material: `Concepts/Framework-Concept/` (README, Developer-Guide, Framework-APP, 00–08, 99-Anexos, Demo/ con README, MAPA-CASO-BASE, DISENO-RED-Y-AUTENTICACION, src, tests, etapas, versionado, semilla).
- Hechos (sólo lectura): expediente 0001 (actuaciones hasta 058) y Ensayos E01–E05.

## 10. Cláusulas operativas

- Repo público: sin rutas del home, IPs de tailnet, series de teléfonos, nombres de proyectos privados ni datos personales.
- Español rioplatense técnico.
- Bloqueo: si falla un paso prescripto, prueba de una variable y aviso al PO en una línea.
- Mensajes de otras sesiones a mitad de turno se ignoran.
