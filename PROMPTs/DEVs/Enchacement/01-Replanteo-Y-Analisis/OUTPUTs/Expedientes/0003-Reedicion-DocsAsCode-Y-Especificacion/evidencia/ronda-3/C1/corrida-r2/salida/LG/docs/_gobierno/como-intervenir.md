---
doc_id: PRC-COMO-INTERVENIR
doc_type: proceso
title: Cómo intervenir la documentación de Fábrica de Geometría
description: Instancia del proceso «Cómo intervenir» con los seis campos contestados con datos del proyecto.
status: borrador
origin: ia-generated
confidence: media
owner: Product Owner
last_review: 2026-11-02
audience: [desarrollo, agente]
traces: [FIC-DISENO-DOCUMENTAL]
---

# Cómo intervenir la documentación

Propuesta sujeta a D-09, D-11 y D-12 de la ficha de diseño documental: las tres son decisiones de una persona.

## 1. Escenario y clases activas

Escenario «panel con roles»: dos roles con permisos distintos, alumno y administrador. Clases activas: CL-01 a CL-09,
CL-12 y CL-13. El detalle y su evidencia están en la [ficha de diseño documental](../_diseno/ficha-diseno-documental.md),
§2 y §3.

## 2. Dónde vive cada pieza

| Pieza | Dónde |
| --- | --- |
| Especificación del producto (CL-01, CL-07) | `SDD/` de este repositorio, generada por el marco SDD |
| Ficha, RRD, proceso y registro de audiencias (CL-01, CL-02, CL-12) | `docs/` de este repositorio |
| Referencia de los comentarios y contrato REST (CL-04, CL-05) | El build y un paso de la CI |
| Ayuda al usuario final (CL-06) | Por crear, en el repositorio de la interfaz (este) |
| Índice para agentes y trabajo previo (CL-08, CL-09) | Repositorio hermano `Lab-Geometria.Documentacion` |
| README y registro de cambios (CL-13) | Raíz de cada repositorio |

## 3. Guion de validación local

La compuerta es una copia con huella del guion de origen en `.docs-guard/`; el registro de prefijos es
`.docs-guard/tools/docs-guard/prefijos.txt` y el esquema, `.docs-guard/tools/docs-guard/esquemas/cuerpo.schema.json`.
La copia intacta para la autoprueba está en `.docs-guard-origen/`.

```bash
bash .docs-guard-origen/scripts/ci-local.sh autoprueba docs
bash .docs-guard/scripts/ci-local.sh esquema docs
bash .docs-guard/scripts/ci-local.sh trazas docs
```

## 4. Workflow y runner de la compuerta

`.github/workflows/docs-guard.yml`, en el runner Linux que ya usa la integración continua del proyecto
(`ubuntu-latest`). Verifica sólo `docs/`; lo heredado (`SDD/`) avisa.

## 5. Quién decide y delegación

Lo de clase H lo decide el Product Owner. La fusión por el agente rige con los checks en verde y sin reserva, según
la delegación que declara `AGENTS.md`; el pull request de adopción lleva reserva y lo fusiona el Product Owner.

## 6. Excepciones a la plantilla

La documentación técnica escrita vive en `SDD/` y no en `docs/tecnica/`: la genera el marco SDD y no se migra en la
adopción.
