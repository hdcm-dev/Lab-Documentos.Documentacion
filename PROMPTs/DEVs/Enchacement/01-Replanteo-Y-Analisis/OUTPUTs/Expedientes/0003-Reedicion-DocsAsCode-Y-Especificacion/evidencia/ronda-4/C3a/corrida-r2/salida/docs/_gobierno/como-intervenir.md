---
doc_id: PRC-COMO-INTERVENIR
doc_type: proceso
title: Cómo intervenir la documentación de Colmenar
description: Instancia del proceso de intervención documental para Colmenar. Seis campos con datos del proyecto. Propuesta.
status: borrador
origin: ia-assisted
confidence: media
owner: aplicador
last_review: 2026-11-02
audience: [humano, agente, desarrollo]
traces: [FIC-DISENO-DOCUMENTAL]
---

# Cómo intervenir la documentación de Colmenar

Instancia por proyecto (A-06, CL-12). Contesta los seis campos de §5.4 con datos de Colmenar.

1. **Escenario y clases activas.** Unión de «panel con roles» y «servicio con paquetes» (D-01), con sitio (D-03) y
   cuerpo formativo (D-15). Clases activas: CL-01, CL-02, CL-03, CL-04, CL-06, CL-07, CL-10, CL-11, CL-12, CL-13 y
   CL-14; CL-05 de baja (API en repo ajeno) y CL-08/CL-09 sujetas a D-12 y a los repos hermanos (ver A-01 §3).
2. **Dónde vive cada pieza.** La app y su documentación técnica, en este repo; el contrato REST, en el repo privado
   de la API (externo, consumido por versión); el modelo de datos, en el repo público del paquete; la guía de
   estudio, en un repo dedicado; la copia de la tabla veterinaria, con huella (ver A-01 §3 y A-09).
3. **Guion de validación local.** `./.docs-guard/scripts/ci-local.sh todo <ruta>` con la copia de huella de la
   compuerta de origen; la configuración (A-02 `prefijos.txt`, A-03 `cuerpo.schema.json`, A-08 `excepciones.txt`)
   vive en `.docs-guard/tools/docs-guard/`.
4. **Workflow y runner.** `.github/workflows/docs-guard.yml` (A-07), runner propio por plataforma: Linux para
   Android y el paquete, Mac para iOS, Windows para el instalador de Windows (D-09; README.md:93-95).
5. **Quién decide y delegación.** El acta del presidente (citada, no versionada) delega en la programadora y en los
   asistentes la fusión de ramas cuyas verificaciones pasan; los cambios que tocan alertas o tratamientos exigen el
   visto bueno del técnico sanitario jefe (D-11; README.md:61-66).
6. **Excepciones a la plantilla.** La norma de calidad exige un encabezado con código, versión, aprobador y fecha de
   aprobación en todo procedimiento (README.md:70-71): campos `aprobado_por` y `fecha_aprobacion` sumados al esquema
   del proyecto (A-03), nunca igualados a `owner` ni a `last_review` (D-08). Decisión de una persona: ver A-01 §4.
