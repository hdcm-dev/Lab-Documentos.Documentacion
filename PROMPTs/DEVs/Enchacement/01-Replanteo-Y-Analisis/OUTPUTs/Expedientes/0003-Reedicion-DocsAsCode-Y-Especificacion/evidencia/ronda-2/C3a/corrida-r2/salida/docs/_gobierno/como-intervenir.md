---
doc_id: PROC-COMO-INTERVENIR
doc_type: proceso
title: Cómo intervenir en la documentación de Colmenar
description: Dónde vive cada pieza documental de Colmenar, cómo se valida, quién decide y qué se aparta de la plantilla.
status: borrador
origin: ia-generated
confidence: media
owner: pendiente (lo designa una persona, D-11)
last_review: 2026-11-01
audience: [desarrollo, agente, qa]
traces: [FDD-FICHA-DISENO]
version: 0.1
---

# Cómo intervenir en la documentación de Colmenar

**Propuesta sujeta a D-09, D-11 y D-12** (ficha de diseño documental, §4). Encabezado de la norma de calidad:
código `PROC-COMO-INTERVENIR` (pendiente: el formato de código que usa la norma no está en el repositorio); versión
0.1; aprobó: pendiente; fecha de aprobación: pendiente; revisión cada 90 días como máximo.

## 1. Escenario y clases activas

Panel con roles unido a servicio con paquetes (D-01). Clases activas: CL-01, CL-02, CL-03, CL-04, CL-06, CL-07,
CL-10, CL-12, CL-13; CL-08 y CL-14 dependen de D-12 y D-03. Detalle y motivos: ficha, §3.

## 2. Dónde vive cada pieza

| Pieza | Dónde |
| --- | --- |
| Especificación y ficha de diseño (CL-01) | `docs/_diseno/` y `docs/especificacion/` de este repositorio |
| Registro de requerimientos documentales (CL-02) | `docs/_requisitos.md` |
| `AGENTS.md` (CL-03) | Raíz de este repositorio y del repositorio del paquete |
| Referencia desde comentarios (CL-04) | En el código de este repositorio y en el del paquete |
| Ayuda al usuario final (CL-06) | `docs/ayuda/`, por perfil y por idioma (español, portugués) |
| Documentación técnica (CL-07) | `docs/tecnica/` |
| Curso de la escuela (CL-10) | Repositorio dedicado, en portugués, con ancla fijada a un SHA de este |
| Este proceso (CL-12) | `docs/_gobierno/como-intervenir.md` |
| README y CHANGELOG (CL-13) | Raíz de este repositorio |

## 3. Guion de validación local

`docs-guard/proyecto/scripts/ci-local.sh {grupo} docs` antes de abrir el pull request. La copia todavía no existe:
falta la compuerta de origen (pendiente).

## 4. Workflow y runner de la compuerta

Workflow `.github/workflows/docs-guard.yml` en el runner Linux de la cooperativa, etiqueta `{etiqueta-runner}`. La
Mac prestada no entra en la compuerta documental: ninguna pieza de clase D sale sólo del build de iOS. Pendiente:
el workflow (A-07) no se escribió.

## 5. Quién decide y delegación

- Lo de clase H lo decide una persona; la lista está en la ficha, §4.
- Delegación de merge declarada por el dueño del producto para la programadora y los asistentes, con verificaciones
  en verde, salvo alertas y tratamientos. El acta no está en el repositorio: hasta que se asiente, fusiona una
  persona.
- Todo cambio que toque alertas o tratamientos necesita el visto bueno del técnico sanitario jefe.

## 6. Excepciones a la plantilla

- La compuerta corre como copia con huella en `docs-guard/proyecto/` (registro de prefijos y esquema propios) más una
  copia intacta en `docs-guard/origen/` para la autoprueba; el registro de prefijos (A-02) es
  `docs-guard/proyecto/tools/docs-guard/prefijos.txt`.
- Los procedimientos llevan el encabezado de la norma de calidad y se revisan cada 90 días.
