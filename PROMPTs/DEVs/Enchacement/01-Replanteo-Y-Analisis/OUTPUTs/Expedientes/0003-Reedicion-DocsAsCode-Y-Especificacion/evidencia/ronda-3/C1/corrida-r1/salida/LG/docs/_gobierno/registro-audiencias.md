---
doc_id: AUD-REGISTRO
doc_type: registro-audiencias
title: Registro de audiencias y entrega de Lab-Geometria
description: Perfil mínimo de audiencias y entrega del panel con roles; fuente de la regla de entrega, en borrador.
status: borrador
origin: ia-assisted
confidence: media
owner: Product Owner
last_review: 2026-11-02
audience: [humano, po, desarrollo]
traces: [FIC-DISENO-DOCUMENTAL]
---

# Registro de audiencias y entrega

Perfil mínimo: roles con jerarquía declarada con `incluye:`, nivel de acceso y la regla `nivel-vs-repo`. Cambiar la
jerarquía es una decisión de clase H.

| Audiencia | incluye: | Nivel de acceso | Punto de aplicación | Par de entrega |
| --- | --- | --- | --- | --- |
| publico | — | `publico` | Repositorio | pendiente |
| alumno | publico | `producto` | Servidor (front y servicio de datos) | pendiente |
| administrador | alumno | `producto` | Servidor (front y servicio de datos), por rol | pendiente |
| desarrollo | publico | `publico` | Repositorio (el repo del código es de consulta pública) | pendiente |

Ninguna fuente pasa de `producto`: el repo del código es público. La regla `nivel-vs-repo` exige que una fuente `restringido` o `interno` viva en un repositorio o submódulo privado.
