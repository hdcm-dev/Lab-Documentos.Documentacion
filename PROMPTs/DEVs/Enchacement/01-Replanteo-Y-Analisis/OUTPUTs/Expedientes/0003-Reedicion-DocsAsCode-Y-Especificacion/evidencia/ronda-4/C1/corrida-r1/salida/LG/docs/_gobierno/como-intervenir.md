---
doc_id: PRC-COMO-INTERVENIR
doc_type: proceso
title: Cómo intervenir en la documentación de Lab-Geometria
description: Los seis campos de la instancia de Cómo intervenir con los datos del proyecto Lab-Geometria.
status: borrador
origin: ia-generated
confidence: media
owner: Product Owner
last_review: 2026-11-02
audience: [desarrollo, agente, po]
traces: [FIC-FICHA]
---

# Cómo intervenir en la documentación

Propuesta sujeta a D-09, D-11 y D-12 de la [ficha](../_diseno/ficha-diseno-documental.md), que siguen abiertas.

## 1. Escenario y clases activas

Panel con roles: dos roles con permisos distintos, alumno (`Student`) y administrador (`Administrator`). Clases activas:
CL-01 a CL-09, CL-12 y CL-13 (CL-04 y CL-05 con su control pendiente). Sin sitio publicado, sin CL-14.

## 2. Dónde vive cada pieza

| Pieza | Dónde |
| --- | --- |
| Especificación (marco SDD) | `SDD/` de este repositorio |
| Sistema documentador nuevo | `docs/` de este repositorio |
| Ayuda en el punto de uso | Microtexto de `src/GeometriaFactory.Web/Components/` |
| Contrato REST | Generado en ejecución: `/openapi/v1.json` |
| `AGENTS.md` | Raíz de cada repositorio; en éste, derivado de `SDD/Docs/Producto/11-Documentacion/Contrato-Agentes.md` |
| Índice para agentes, análisis y prompts | Repositorio hermano `Lab-Geometria.Documentacion` (`ia-db/`, `Analisis/`, `PROMPTs/`) |
| README y registro de cambios | `README.md` y `changelog.md` de cada repositorio |

## 3. Guion de validación local

Desde la raíz del repositorio, con las herramientas en la caché (`DOCS_GUARD_CACHE`):

```bash
.docs-guard-origen/scripts/ci-local.sh autoprueba docs
for g in enlaces esquema ai estructura trazas contrato fijadas; do .docs-guard/scripts/ci-local.sh "$g" docs; done
```

La autoprueba corre con la copia de origen, intacta; los grupos, con la copia del proyecto, que trae el registro de
prefijos, el esquema y las excepciones de este repositorio.

## 4. Workflow y runner de la compuerta

`.github/workflows/docs-guard.yml`, en `ubuntu-latest`, la misma etiqueta que el workflow `ci` del proyecto. Corre los
mismos pasos que el guion local, sobre `docs/`.

## 5. Quién decide y si hay delegación

Lo de clase H lo decide el Product Owner. En este repositorio el agente fusiona con los checks en verde y sin reserva,
por decisión del Product Owner citada en `AGENTS.md` y no versionada como acta; con reserva, entrega el enlace y espera.
El pull request de adopción lleva reserva (decisiones H abiertas) y lo fusiona una persona.

## 6. Excepciones a la plantilla

El corpus `SDD/` no se verifica con esta compuerta: tiene su propio método y su propio esquema. `AGENTS.md` no se edita
acá: el cambio va a su fuente, el contrato de agentes.
