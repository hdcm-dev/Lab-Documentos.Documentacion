---
doc_id: AUD-COLMENAR
doc_type: registro-audiencias
title: Registro de audiencias de Colmenar
description: Una fila por audiencia con nivel de acceso, superficie e incluye; fuente de la regla de entrega (A-12).
status: borrador
origin: ia-generated
confidence: media
owner: aplicador
last_review: 2026-11-02
audience: [desarrollo, po]
traces: [FIC-COLMENAR-DISENO]
---

# Registro de audiencias

Perfil mínimo más la extensión «superficie». La jerarquía (`incluye`) no está declarada en la descripción del
producto: cada rol se incluye sólo a sí mismo hasta que una persona decida otra cosa (clase H). Regla
`nivel-vs-repo`: este repositorio es público, así que aquí sólo viven fuentes de nivel `publico` o `producto`.

| Audiencia | incluye | Nivel de acceso | Superficie | Punto de aplicación |
| --- | --- | --- | --- | --- |
| publico-general | — | publico | sitio web | build del sitio |
| productor | — | producto | app Android | servidor (API) |
| peon-de-campo | — | producto | app Android | servidor (API) |
| tecnico-sanitario | — | producto | app iOS | servidor (API) |
| administracion | — | producto | app Windows | servidor (API) |
| inspector-sanitario | — | restringido | pendiente (acceso no decidido) | servidor (API) |
