---
doc_id: PRC-COMO-INTERVENIR
doc_type: proceso
title: Cómo intervenir el sistema documentador de Colmenar
description: Instancia de Cómo intervenir para Colmenar; escenario, ubicaciones, guion, compuerta y decisiones.
status: borrador
origin: ia-generated
confidence: media
owner: equipo de la app
last_review: 2026-11-02
audience: [humano, desarrollo]
traces: [FIC-FICHA]
version: 0.1
---

# Cómo intervenir el sistema documentador de Colmenar

Propuesta sujeta a D-09, D-11 y D-12 (decisiones de una persona, ficha §4).

## 1. Escenario y clases activas

Unión de «app sin roles» y «panel con roles», por los cinco perfiles con permisos distintos. Clases activas: CL-01,
CL-02, CL-03, CL-04, CL-06, CL-07, CL-12, CL-13 y CL-14 (esta última, con el sitio público).

## 2. Dónde vive cada pieza

- Ficha: `docs/_diseno/ficha-diseno-documental.md`. Requerimientos: `docs/_requisitos.md`.
- Gobierno (esquema, audiencias, línea de base, controles de entrega, este proceso): `docs/_gobierno/`.
- Documentación técnica: `docs/tecnica/`. Ayuda al usuario final: en este repositorio, por perfil e idioma.
- `AGENTS.md`, `README.md` y `CHANGELOG.md`: raíz.
- Registro de prefijos (A-02): `.docs-guard/tools/docs-guard/prefijos.txt`. Esquema (A-03):
  `.docs-guard/tools/docs-guard/esquemas/cuerpo.schema.json`. Excepciones: `.docs-guard/tools/docs-guard/excepciones.txt`.

## 3. Guion de validación local

Copia del proyecto en `.docs-guard/` y copia de origen intacta en `.docs-guard-origen/`, fuera de `docs/`:

```bash
.docs-guard/scripts/ci-local.sh esquema docs
.docs-guard/scripts/ci-local.sh trazas docs
.docs-guard-origen/scripts/ci-local.sh autoprueba docs
```

## 4. Workflow y runner de la compuerta

`.github/workflows/docs-guard.yml`, en la máquina Linux del proyecto (`{etiqueta-runner}`), con la copia con huella
del guion. La huella cubre `dg.py` y `ci-local.sh`.

## 5. Quién decide y delegación

Lo de clase H lo decide una persona (ficha §4). La delegación del merge que describe el README del proyecto está
pendiente de versionarse: hasta que el acta esté en el árbol, fusiona una persona. Todo cambio que toque alertas o
tratamientos necesita el visto bueno del técnico sanitario jefe.

## 6. Excepciones a la plantilla

Ninguna por ahora. Agregar una excepción por huella es clase H.

## Aprobación

Aprobado por: pendiente. Fecha de aprobación: pendiente.
