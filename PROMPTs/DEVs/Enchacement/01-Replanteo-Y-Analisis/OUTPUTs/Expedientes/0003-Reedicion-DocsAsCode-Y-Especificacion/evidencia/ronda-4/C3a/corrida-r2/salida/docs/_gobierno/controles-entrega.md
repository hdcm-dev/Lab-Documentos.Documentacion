---
doc_id: FIC-CONTROLES-ENTREGA
doc_type: anexo
title: Controles de entrega y de punto de uso — Colmenar
description: Tabla de controles de entrega (A-13). Todos avisan hasta tener su par rojo/verde corrido (DE-30).
status: borrador
origin: ia-assisted
confidence: baja
owner: aplicador
last_review: 2026-11-02
audience: [humano, desarrollo]
traces: [FIC-DISENO-DOCUMENTAL]
---

# Controles de entrega y de punto de uso — Colmenar

Propuesta (A-13, D-10 y D-18). Cada control **avisa** hasta tener su par rojo/verde corrido; ninguno bloquea sin él
(I-15, DE-30). Los pares que dependen de la autorización dependen de la API externa, no recibida: quedan `pendiente`.

| Control | Estado | Par rojo/verde |
| --- | --- | --- |
| audiencia-vocabulario | avisa | pendiente — requiere A-12 con audiencias resueltas |
| delivery-clave-cercana | avisa | pendiente |
| nivel-vs-repo | avisa | pendiente — niveles sin decidir (D-18) |
| cruce-de-audiencia | avisa | pendiente |
| indice-sin-fuga | avisa | pendiente — índice en repo hermano no recibido |
| paquete-sin-fuga | avisa | pendiente — repo del paquete no recibido |
| ampliacion-de-acceso | avisa | pendiente |
| contrato-por-exposicion | avisa | pendiente — contrato en la API externa |
| contexto-resuelve | avisa | pendiente — resolvedor de ayuda sin existir (D-13) |
| anclas (extendidas) | avisa | pendiente |
| traduccion-atrasada | avisa | pendiente — recursos localizados no anclados (D-13, D-16) |
| anti-inyeccion-en-recursos | avisa | pendiente |
| pruebas de entrega pareadas (200 con contenido / ≠200 sin contenido) | pendiente | pendiente — punto de cumplimiento en la API externa |
