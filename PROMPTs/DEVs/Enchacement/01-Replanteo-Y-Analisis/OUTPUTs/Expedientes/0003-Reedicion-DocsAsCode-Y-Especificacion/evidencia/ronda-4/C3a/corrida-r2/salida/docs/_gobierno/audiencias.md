---
doc_id: AUD-REGISTRO-COLMENAR
doc_type: registro-audiencias
title: Registro de audiencias de Colmenar
description: Audiencias de entrega de Colmenar. Inventario declarado del producto; la autorización vive en la API externa, no recibida.
status: borrador
origin: ia-assisted
confidence: baja
owner: aplicador
last_review: 2026-11-02
audience: [humano, po, desarrollo]
traces: [FIC-DISENO-DOCUMENTAL]
---

# Registro de audiencias de Colmenar

Propuesta (A-12, D-18). Las cinco identidades salen del inventario declarado del producto (README.md:16-22). El
punto que las autentica (política, claim, esquema de autenticación) vive en el repo **privado de la API**, externo y
**no recibido** (README.md:46-47): por eso ninguna audiencia tiene `acceso propio` probado con ruta:línea en este
repo. Por la regla 1 de §3.2.1, cada una queda `pendiente` y abre su fila H en A-01 §4; sin punto de cumplimiento no
se les asigna nivel (regla 3, DE-31). La matriz audiencia × página es salida derivada del build, no este registro.

| Audiencia | Acceso propio (ruta:línea) | incluye: | Nivel | Punto de cumplimiento | Alcance |
| --- | --- | --- | --- | --- | --- |
| productor | pendiente — autorización en la API externa (README.md:46-47); declarado README.md:18 | plana (sin código de autorización para probar jerarquía) | pendiente (sin punto de cumplimiento en el repo) | pendiente — servidor de la API externa | «sólo lo suyo» declarado (README.md:18,24); sin código que filtre en el repo → no activado |
| peon-de-campo | pendiente — ídem; declarado README.md:19 | plana | pendiente | pendiente — servidor | no activado |
| tecnico-sanitario | pendiente — ídem; declarado README.md:20 | plana | pendiente | pendiente — servidor | no activado |
| administracion | pendiente — ídem; declarado README.md:21 | plana | pendiente | pendiente — servidor | no activado |
| inspector-organismo | pendiente — ídem; declarado README.md:22; acceso a la app sin decidir (README.md:105) | plana | pendiente (`restringido` o reporte, sin decidir) | pendiente — servidor | no activado |

Descartados: no hay homónimos ni valores de `audience:` que confundir, porque el repo no tiene código de
autorización (búsqueda negativa: `grep -rniE '\[Authorize|RequireRole|Roles *=' --include=*.cs .` → 0, rc=1).
