---
doc_id: PRC-COMO-INTERVENIR
doc_type: proceso
title: Cómo intervenir en la documentación de Colmenar
description: Instancia del proceso «Cómo intervenir» para Colmenar. Propuesta en borrador, sujeta a D-09, D-11 y D-12.
status: borrador
origin: ia-assisted
confidence: media
owner: pendiente (D-11)
last_review: 2026-11-02
audience: [desarrollo, agente, po]
traces: [FIC-DISENO-DOCUMENTAL]
---

# Cómo intervenir en la documentación de Colmenar

Propuesta del aplicador, en borrador: sujeta a D-09 (cómo corre la compuerta), D-11 (quién decide) y D-12 (canales
para agentes) de la ficha de diseño. Es un procedimiento escrito: la norma de calidad de la cooperativa le pide código
(`doc_id`), versión, quién lo aprobó y fecha de aprobación, y una revisión cada 90 días como máximo. Los campos
`version`, `aprobado_por` y `fecha_aprobacion` se llenan cuando una persona lo apruebe; hasta entonces, borrador.

## Escenario y clases activas

Unión de «panel con roles» (cinco perfiles con permisos distintos) y «servicio con paquetes» (el modelo de datos
compartido se publica como paquete .NET). Clases activas: CL-01 a CL-04, CL-06, CL-07, CL-10 a CL-14 según el catálogo
de la ficha; CL-05, CL-08 y CL-09 de baja, con su motivo en la ficha.

## Dónde vive cada pieza

| Pieza | Dónde |
| --- | --- |
| Ficha de diseño, especificación y RRD | `docs/_diseno/`, `docs/_requisitos.md` |
| Gobierno (este proceso, registro de audiencias, controles de entrega) | `docs/_gobierno/` |
| Documentación técnica | `docs/tecnica/` |
| Ayuda al usuario final | Carpeta de ayuda de la app (pendiente) y sitio público (pendiente) |
| Referencia del código | Build de la app; la del paquete, en el build de su repositorio |
| Curso de la escuela | Repositorio dedicado (pendiente), anclado por `source.lock` al SHA de la app |
| README, CHANGELOG y `AGENTS.md` | Raíz del repositorio |
| Copia de la compuerta | `.docs-guard/` (configuración del proyecto) y `.docs-guard-origen/` (intacta, para la autoprueba) |

## Guion de validación local

Desde la raíz del repositorio, con las herramientas ya en la caché:

```bash
.docs-guard-origen/scripts/ci-local.sh autoprueba docs
for g in enlaces esquema ai estructura trazas contrato fijadas; do .docs-guard/scripts/ci-local.sh "$g" docs; done
```

El registro de prefijos es `.docs-guard/tools/docs-guard/prefijos.txt`; el esquema de frontmatter,
`.docs-guard/tools/docs-guard/esquemas/cuerpo.schema.json`; las excepciones, `.docs-guard/tools/docs-guard/excepciones.txt`.

## Workflow y runner de la compuerta

`.github/workflows/docs-guard.yml`, en el runner Linux del proyecto (`{etiqueta-runner-linux}`), con la copia con
huella de la compuerta (propuesta sujeta a D-09). El carril programado está en `.github/workflows/docs-programado.yml`
y sólo avisa, con un issue.

## Quién decide y si hay delegación

Según el acta citada en el README y no versionada: la programadora fusiona sin el dueño del producto todo cambio con
las verificaciones en verde, y los asistentes automáticos fusionan sus propias ramas en las mismas condiciones; lo que
toca alertas o tratamientos no se fusiona sin el visto bueno del técnico sanitario jefe. Quién da ese visto bueno en
su ausencia: pendiente. El pull request de adopción lleva reserva y lo fusiona una persona.

## Excepciones a la plantilla

Ninguna por ahora. Los campos de la norma de calidad (`version`, `aprobado_por`, `fecha_aprobacion`) se suman al
esquema del proyecto; no se igualan a `owner` ni a `last_review`.
