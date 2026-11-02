---
doc_id: RD-REGISTRO
doc_type: rrd
title: Registro de requerimientos documentales — Fábrica de Geometría
description: RRD inicial de la adopción del sistema documentador; cada fila espera la decisión de una persona.
status: borrador
origin: ia-generated
confidence: media
owner: Product Owner
last_review: 2026-11-01
audience: [desarrollo, agente, po]
traces: []
---

# Registro de requerimientos documentales — Fábrica de Geometría

> **Borrador de la adopción (A-04).** Propuesta del aplicador; ninguna fila está decidida. El rango `RD-01…RD-06`
> se comprobó libre sólo con `grep -rhoE '\b(RD|ANX|FCH|PRC)-[0-9]{2,5}\b'` sobre `LG` y `LGD` (salida vacía); el
> control de trazas de la compuerta, que es el instrumento de D-07, está pendiente (ficha A-01, D-07). Los
> instrumentos que nombran un control de la compuerta quedan sujetos a D-09 y D-10.

| ID | Audiencia | Tarea | Pieza | Criterio | Decisión |
| --- | --- | --- | --- | --- | --- |
| RD-01 | Alumno (rol `Student`) | Cargar y enviar su trabajo y entender las advertencias que el producto le devuelve | CL-06, ayuda por rol del alumno (ruta pendiente de D-05 en la interfaz) | Dado un alumno con cuenta habilitada, cuando abre la ayuda de su rol, entonces encuentra cómo cargar, enviar y leer las discrepancias, y ninguna página traza a un ID de la unidad que no le corresponde; instrumento: control de trazas de la ayuda (patrón 4 de §3.1) | pendiente |
| RD-02 | Administrador (rol `Administrator`) | Habilitar cuentas y dejar el desenlace de lo que la comisión entregó | CL-06, ayuda por rol del administrador (ruta pendiente de D-05) | Dado un administrador, cuando abre la ayuda de su rol, entonces encuentra la habilitación de cuentas y la revisión, y la ayuda no muestra nada del otro rol; instrumento: control de trazas de la ayuda | pendiente |
| RD-03 | Consumidor de la API | Integrar una aplicación propia contra la superficie pública versionada | CL-05, contrato `/openapi/v1.json` extraído en la CI | Dado un pull request que cambia un punto de acceso, cuando corre la CI, entonces el contrato extraído difiere del versionado y el diff queda en el pull request; instrumento: diff del contrato (hoy sin paso de extracción) | pendiente |
| RD-04 | Agente | Saber antes de proponer dónde está la documentación, qué guion corre y qué no decide | CL-03, `AGENTS.md` de cada repo | Dado un agente en la raíz de un repo, cuando lee `AGENTS.md`, entonces encuentra los tres punteros de la plantilla y sus enlaces resuelven; instrumento: control de enlaces | pendiente |
| RD-05 | Desarrollo | Intervenir la documentación sin preguntar dónde vive cada pieza ni quién decide | CL-12, `docs/_gobierno/como-intervenir.md` | Dado un cambio de documentación, cuando quien lo hace abre «Cómo intervenir», entonces los seis campos están contestados con datos del proyecto; instrumento: bloques entradas, salidas y validaciones | pendiente |
| RD-06 | Agente | Usar el índice de `LGD` sabiendo cuánto atrasa frente a `LG` | CL-08, `ia-db/` con `ia-db/source.lock` | Dado el índice anclado a un commit, cuando corre el carril programado, entonces el atraso en commits queda informado en un issue; instrumento: aviso de atraso (A-10) | pendiente |

Evidencia de las audiencias: papeles `Student` y `Administrator` (`LG/src/GeometriaFactory.Domain/Values/Role.cs:12-19`);
tareas del alumno y del docente (`LGD/ia-db/indexes/00_MASTER-INDEX.md:18-19`); la API se ofrece a aplicaciones
propias (`LGD/ia-db/indexes/00_MASTER-INDEX.md:27`); contrato en `/openapi/v1.json`
(`LG/src/GeometriaFactory.Api/Composition/ApiDocumentation.cs:37`); índice anclado a `4b114d7`
(`LGD/ia-db/README.md:38`).
