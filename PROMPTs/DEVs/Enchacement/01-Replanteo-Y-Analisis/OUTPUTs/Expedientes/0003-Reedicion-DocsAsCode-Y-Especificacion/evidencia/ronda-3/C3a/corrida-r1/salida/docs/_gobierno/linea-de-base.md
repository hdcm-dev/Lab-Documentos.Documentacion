---
doc_id: FIC-LINEA-BASE
doc_type: anexo
title: Línea de base y controles de entrega de Colmenar
description: Informe de línea de base de la adopción (A-08) y tabla de controles de entrega y punto de uso (A-13).
status: borrador
origin: ia-generated
confidence: media
owner: equipo de la app
last_review: 2026-11-02
audience: [humano, desarrollo]
traces: [FIC-FICHA]
---

# Línea de base y controles de entrega de Colmenar

Proyecto nuevo: la línea de base es 0 por construcción. Medida sobre la copia del repositorio en el commit leído, con
la compuerta de origen. El archivo de excepciones de la copia del proyecto queda vacío.

## Línea de base por control

| Control | Carpeta | Hallazgos | Estado propuesto |
| --- | --- | --- | --- |
| PR-1 enlaces | docs y AGENTS.md | pendiente: lychee sin caché | avisa |
| PR-2 esquema | docs | 0 | bloquea con el par rojo/verde corrido |
| PR-3 anti-inyección | docs y AGENTS.md | 0 | bloquea con el par rojo/verde corrido |
| PR-4 estructura | docs y AGENTS.md | pendiente: markdownlint sin caché de npm | avisa |
| PR-5 trazas | docs | 0 | bloquea con el par rojo/verde corrido |
| PR-6 contrato | docs | no aplica: el contrato de la API vive en un repo ajeno | avisa |
| PR-7 fijadas | docs | 0 | avisa |

Volver obligatorio el check en la plataforma es decisión de una persona.

## Controles de entrega y de punto de uso

Todos avisan hasta tener su par rojo/verde corrido; ninguno tiene par hoy.

| Control | Estado | Par rojo/verde |
| --- | --- | --- |
| audiencia-vocabulario | avisa | pendiente |
| delivery-clave-cercana | avisa | pendiente |
| nivel-vs-repo | avisa | pendiente |
| cruce-de-audiencia | avisa | pendiente |
| indice-sin-fuga | avisa | pendiente |
| paquete-sin-fuga | avisa | pendiente |
| ampliacion-de-acceso | avisa | pendiente |
| contrato-por-exposicion | avisa | pendiente |
| contexto-resuelve | avisa | pendiente |
| anclas extendidas | avisa | pendiente |
| traduccion-atrasada | avisa | pendiente |
| anti-inyeccion-en-recursos | avisa | pendiente |
| pruebas de entrega pareadas | avisa | pendiente: sin servidor ni API en el árbol |
