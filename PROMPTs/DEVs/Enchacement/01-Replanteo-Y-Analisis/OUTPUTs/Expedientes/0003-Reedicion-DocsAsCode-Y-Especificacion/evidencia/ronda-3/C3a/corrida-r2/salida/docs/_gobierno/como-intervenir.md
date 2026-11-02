---
doc_id: PRC-COLMENAR-INTERVENIR
doc_type: proceso
title: Cómo intervenir en la documentación de Colmenar
description: Instancia del proceso Cómo intervenir para Colmenar; propuesta sujeta a D-09 y D-11.
status: borrador
origin: ia-generated
confidence: media
owner: aplicador
last_review: 2026-11-02
audience: [desarrollo, agente]
traces: [FIC-COLMENAR-DISENO]
---

# Cómo intervenir

Propuesta sujeta a D-09, D-11 y D-12 (ver la ficha de diseño, sección 4).

1. **Escenario y clases activas.** Panel con roles, con sitio publicado y cuerpo formativo: CL-01 a CL-04, CL-06,
   CL-07, CL-10, CL-12 a CL-14.
2. **Dónde vive cada pieza.** Ficha en `docs/_diseno/`; gobierno en `docs/_gobierno/`; RRD en `docs/_requisitos.md`;
   técnica en `docs/tecnica/`; ayuda junto a la interfaz y en el sitio; guía de estudio en un repo dedicado, fijado por
   `source.lock`.
3. **Guion de validación local.** `.docs-guard/scripts/ci-local.sh {grupo} docs` (copia del proyecto, con el registro
   de prefijos en `.docs-guard/tools/docs-guard/prefijos.txt` y el esquema en
   `.docs-guard/tools/docs-guard/esquemas/cuerpo.schema.json`); la autoprueba corre desde la copia intacta
   `.docs-guard-origen/`.
4. **Workflow y runner.** `.github/workflows/docs-guard.yml`, en el runner Linux del proyecto (`{etiqueta-runner}`).
5. **Quién decide.** Lo de clase H, una persona; las delegaciones de merge quedan pendientes hasta que el acta esté
   versionada en el repo; los cambios que tocan alertas o tratamientos llevan el visto bueno del técnico sanitario jefe.
6. **Excepciones a la plantilla.** Ninguna por ahora; una excepción nueva es de clase H.
