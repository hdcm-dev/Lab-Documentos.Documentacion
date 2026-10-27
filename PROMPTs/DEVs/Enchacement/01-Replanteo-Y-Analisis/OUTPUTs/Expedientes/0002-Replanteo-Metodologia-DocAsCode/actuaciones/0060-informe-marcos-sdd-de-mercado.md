---
doc_id: EXP0002-F0060
doc_type: informe
title: Informe del despacho I06 — marcos SDD de mercado frente a los dos SDD propios
status: vigente
origin: agent
owner: presidencia de la mesa de Replanteo y análisis DocAsCode
last_review: 2026-10-26
audience: [mesa, jurado, comisiones, presidencia, PO]
traces: [TP:18, TP:20, TP:28-30, C00:173, C00:218, N02, N04, N06, R03, R04, R06, I04, I05, I06]
---

| Campo | Valor |
| --- | --- |
| Tipo | informe |
| Fecha | 2026-10-26 |
| Autor | Investigador de industria, despacho I06 |
| Corrige | — |

# Informe I06 — Marcos SDD de mercado

Insumos leídos: tool-prompt completo; R03, R04 y R06 completos; R01 §12; C00 (filas 173 y 218); IA.SDD (`Master-Prompt.md`, `Rules-Documentacion.md`, `Deriva-Rules.md`, `Index-Knowledge.md`, expediente 0003). Bitácora de respaldo, con citas por línea, 19 fuentes y huellas: `/LAB/Lab-Documentos/Lab-Documentos.Documentacion/PROMPTs/DEVs/Enchacement/01-Replanteo-Y-Analisis/OUTPUTs/Bitacoras/I06-Marcos-SDD-De-Mercado.md`.

## Índice

1. [Qué se relevó](#1-qué-se-relevó)
2. [Hallazgos](#2-hallazgos)
3. [Propuesta: adoptar y no adoptar](#3-propuesta-adoptar-y-no-adoptar)
4. [Excepciones a conocimientos](#4-excepciones-a-conocimientos)
5. [No verificado y huella](#5-no-verificado-y-huella)

## 1. Qué se relevó

Se relevaron cinco marcos, todos con fuente primaria consultada el 2026-10-26:

| Marco | Fuente y versión |
| --- | --- |
| GitHub Spec Kit | MIT, v1.2.3 del 2026-10-22 |
| AWS Kiro | Propietario, anunciado el 2025-07-14 |
| Tessl | Anuncio 2025-09-23 y documentación vigente |
| OpenSpec | v1.15.0 del 2026-10-24 |
| BMad Method | v6.12.4 del 2026-10-14 |

Además se leyeron:

- **AGENTS.md** (Linux Foundation).
- Dos análisis críticos: Böckeler, martinfowler.com, 2025-10-15; Thoughtworks Radar, anillo *Assess*, 2025-11-05.

Cada marco se leyó con seis preguntas: artefactos, ubicación, versionado de la spec frente al código, documentación, orquestación y conocimiento compartido. Después se contrastó con el SDD de workspace (IA.SDD, que consumen Lab-Documentos y Geometría) y con el SDD-B. La matriz completa está en §10 de la bitácora.

## 2. Hallazgos

| Id | Hallazgo | Evidencia |
| --- | --- | --- |
| I06-H1 | Ningún marco de mercado tiene proceso de documentación de **usuario final**; todos producen artefactos de ingeniería. IA.SDD la excluye por norma | Spec Kit `templates/` y `spec-driven.md:93`; Kiro *hooks*; `/IA/SDD/IA.SDD/SDD/Devs/Rules/Rules-Documentacion.md:102` |
| I06-H2 | Spec Kit **no fija** qué pasa con la spec tras entregar. Nombra tres modelos (flow-back, flow-forward, living) y pide declararlo en la constitución | `docs/concepts/spec-persistence.md:3-8`, `:130-151` |
| I06-H3 | OpenSpec separa la norma vigente (`specs/`) del cambio (`changes/` con delta AGREGADO/MODIFICADO/QUITADO) y **fusiona al archivar**. Es la forma mecánica de la reintegración que el SDD-B no ejerce | `docs/concepts.md:46-50`, `:391-397`, `:507`; R04 §6, §9.4 |
| I06-H4 | El mercado comparte conocimiento **instalado con versión fija** (Tessl `tessl.json`; bundles de Spec Kit con SHA-256), con regla explícita de cuándo vive en el repo y cuándo en un registro. El SDD-B tiene un fork divergente (1.x frente a 2.x/3.x) | `configuration.md:246-261`; `repository-plugins.md`; `bundles.md:3-5`; R04 §7.3; R03 §7.3 |
| I06-H5 | Kiro: *steering* global con precedencia del workspace, specs en el repo y repo central con submódulos entre equipos. OpenSpec «Stores» ofrece la planificación en un repo propio compartido por varios repos de código | kiro.dev/docs/steering; kiro.dev/docs/specs/best-practices; openspec.dev/docs/stores |
| I06-H6 | El control automático de deriva doc↔código existe en el mercado como **auditoría que abre PR** (Tessl docs-audit) o como *hooks* (Kiro). Ningún CI propio tiene chequeo documental | docs.tessl.io «Keep docs in sync»; R06 §6; R03 §9.1 |
| I06-H7 | La crítica de la industria es el exceso de ceremonia y de Markdown difícil de revisar. BMad responde con caminos por tamaño del cambio | F12, F19; BMad «Choose a Planning Path»; R04 §5.3 (pipeline del SDD-B sin uso desde 2026-08-29) |
| I06-H8 | Lo que los SDD propios hacen mejor: procedencia y migración normativa, evidencia D9 con sensado de deriva, y expediente con mesa y refutador | `/IA/SDD/IA.SDD/SDD/Devs/Orchestrator/Master-Prompt.md:94-161`; `Deriva-Rules.md:21-23`; R01 §12 |
| I06-H9 | AGENTS.md es el único formato transversal a todas las herramientas. IA.SDD ya lo emite y Lab-Documentos no lo tiene | agents.md; `Rules-Documentacion.md:287-294`; R03 §4.2 |

## 3. Propuesta: adoptar y no adoptar

Es **criterio propio** fundado en §2. La mesa decide.

**Adoptar como práctica, no como herramienta:**

| Id | Práctica | Fuente | Escalón |
| --- | --- | --- | --- |
| A1 | Declarar por proyecto el modelo de persistencia de la spec | I06-H2 | Piloto Geometría; regla de IA.SDD (enlaza con el expediente 0003 de IA.SDD, tramos F2/F3 pendientes) |
| A2 | El expediente cierra fusionando su delta en la norma | I06-H3 | Piloto y SDD-B |
| A3 | Manifiesto de conocimientos con alias + versión fija; copia local sólo con excepción | I06-H4 | Escalón 3 |
| A4 | Precedencia explícita workspace → proyecto | I06-H5 | Escalón 3 |
| A5 | Auditoría de deriva asesora (abre PR o informe), junto a chequeos deterministas bloqueantes en el workflow `runs-on: [self-hosted, i7infra-dev]` | I06-H6 | Escalón 1 |
| A6 | Caminos por tamaño del cambio, con «trivial» sin expediente | I06-H7 | Todos |
| A7 | `AGENTS.md` en todo repo | I06-H9 | Escalón 1 |
| A8 | Repo `.Documentacion` sólo como «store» para lo que abarca varios repos o no se despliega | I06-H5 | Insumo para N02 |

**No adoptar:**

| Id | Qué se descarta | Motivo |
| --- | --- | --- |
| N1 | Reemplazar IA.SDD por una herramienta de mercado | No cubre usuario final; Kiro y Tessl son propietarios; se pierde I06-H8 |
| N2 | *Spec-as-source* | No determinismo medido por F12; choca con D9 |
| N3 | Spec que muere con la rama (spec-first puro) | Es lo que F12 critica de Spec Kit |
| N4 | Distribución por MDM o registro en la nube | Desproporcionado para un mantenedor único |
| N5 | Los nueve artículos de Spec Kit tal cual | Se toma la idea de constitución, no su contenido |
| N6 | EARS obligatorio | Duplica la cadena NB → CU → RN |

**Aporte a las decisiones de la presidencia:**

- **(2) Arquitectura del sistema documentador.** El mercado no aporta audiencias de usuario ni publicación; esas piezas salen de I04/I05.
- **(5) X2.** Queda confirmado por contraste: en todos los marcos de mercado el SDD es un paquete externo instalado, no un índice.

## 4. Excepciones a conocimientos

| Conocimiento (§) | Propuesta en su lugar | Impacto |
| --- | --- | --- |
| `/IA/SDD/IA.SDD/SDD/Devs/Rules/Rules-Documentacion.md:102`, `:723`, `:801`, `:1003` (usuario final fuera de alcance) | Incluir la documentación de usuario en el sistema documentador | Apartamiento en el destino o cambio de norma; decide la mesa (R06 §10) |
| `<SDD-B>/Prompts/Conocimientos/README.md:25-35` (extensión por fork y copia), según R04 §7.1 | A3: referencia con versión fija | Lista de versiones y chequeo de desalineación en CI; escalón 3 |
| `Knowledge-Mesa-De-Expertos-A-Pedido` 3.1 y `Expediente-Rules` 1.1 (todo cambio de norma por expediente) | A6: camino trivial por umbral | Hay que fijar el umbral y quién lo aplica; es propuesta, no apartamiento consumado |

## 5. No verificado y huella

**No verificado:**

- El reposicionamiento de Tessl del 2026-01-29: sólo hay una reseña de terceros.
- La ruta exacta de la constitución en Spec Kit 1.x: no se corrió `specify init`.
- Ninguna herramienta se ejecutó; un ensayo en contenedor `--rm` sobre una copia de la demo queda propuesto para el escalón 1.
- La lista completa de disparadores de *hooks* de Kiro.
- Otros marcos (Amazon Q, Cursor, Agent OS) no se relevaron.

**Huella:** se descargaron 24 archivos públicos a un directorio de trabajo `fc-work/docascode/I06/` del anfitrión. Se borró al cerrar. No se usaron contenedores.

Sigue: incorporación del informe I06 al mapa de núcleos (N06, N02, N04) y consideración por las comisiones · presidencia
