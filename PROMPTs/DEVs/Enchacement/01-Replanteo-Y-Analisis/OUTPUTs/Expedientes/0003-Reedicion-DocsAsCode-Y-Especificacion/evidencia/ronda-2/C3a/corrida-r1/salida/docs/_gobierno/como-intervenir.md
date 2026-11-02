---
doc_id: PRC-COMO-INTERVENIR
doc_type: proceso
title: Cómo intervenir en la documentación de Colmenar
description: Escenario, ubicaciones, validación local, compuerta, decisiones y excepciones para intervenir en Colmenar.
status: borrador
origin: ia-generated
confidence: media
owner: pendiente (D-11)
last_review: 2026-11-01
audience: [desarrollo, agente]
traces: [FIC-DISENO-DOCUMENTAL]
version: 0.1
approved_by: pendiente
approval_date: pendiente
---

# Cómo intervenir

Propuesta sujeta a D-09, D-11 y D-12. Encabezado según la norma de calidad (`README.md:70-71`).

| Campo | Respuesta |
| --- | --- |
| Escenario y clases activas | Unión «panel con roles» y «servicio con paquetes», más CL-10 por el curso y CL-14 sujeta a D-03: CL-01 a CL-08 y CL-10 a CL-13 activas; CL-14 sujeta a D-03 (ficha A-01, §3) |
| Dónde vive cada pieza | Especificación, RRD, ayuda, documentación técnica, README y CHANGELOG: este repo; `AGENTS.md`: raíz de este repo y del paquete; índice para agentes: repo hermano `.Documentacion`; guía del curso: repo dedicado, en portugués (`README.md:89`); canales derivados: build del sitio |
| Guion de validación local | `.docs-guard/proyecto/scripts/ci-local.sh {grupo} {carpeta}` (copia con huella; pendiente de copiar) |
| Workflow y runner | `.github/workflows/docs-guard.yml` en el runner Linux de la cooperativa (`README.md:93`), `{etiqueta-runner}`; carril programado en `.github/workflows/docs-carril-programado.yml` |
| Quién decide y delegación | Programadora y asistentes fusionan con verificaciones verdes según el acta (`README.md:61-64`), salvo alertas o tratamientos, que esperan al técnico sanitario jefe (`README.md:65-66`). El acta no está en el árbol: hasta que esté, fusiona una persona |
| Excepciones a la plantilla | Compuerta como copia con huella en `.docs-guard/proyecto/` (registro `tools/docs-guard/prefijos.txt`, esquema `tools/docs-guard/esquemas/cuerpo.schema.json`, excepciones `tools/docs-guard/excepciones.txt`) y copia de origen intacta en `.docs-guard/origen/` para la autoprueba; frescura de 90 días para `doc_type: proceso` |
