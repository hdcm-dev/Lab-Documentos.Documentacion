---
doc_id: AUD-REGISTRO
doc_type: registro-audiencias
title: Registro de audiencias de Fábrica de Geometría
description: Perfil mínimo de audiencias y entrega con la extensión de superficie; una fila por audiencia con incluye y nivel.
status: borrador
origin: ia-generated
confidence: media
owner: Product Owner
last_review: 2026-11-02
audience: [desarrollo, po]
traces: [FIC-DISENO-DOCUMENTAL]
---

# Registro de audiencias

Perfil mínimo más la extensión «superficie». Cambiar la jerarquía es de clase H. El repositorio es público, así
que ninguna fuente de nivel mayor que `producto` vive acá (regla `nivel-vs-repo`).

| Audiencia | incluye | Nivel de acceso | Superficie | Punto de aplicación |
| --- | --- | --- | --- | --- |
| alumno | — | producto | Panel web | Servidor |
| administrador | — | producto | Panel web | Servidor |
| consumidor-api | — | publico | API REST `/v1/` y su documento OpenAPI | Servidor |
| desarrollo | — | publico | Repositorio | Repositorio |
