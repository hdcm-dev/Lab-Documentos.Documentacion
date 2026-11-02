# Descripción del PR de adopción (A-08 y A-13)

Reserva: este PR lleva decisiones H abiertas (D-09, D-11, D-12, D-18); lo fusiona una persona.

## A-08 — Línea de base

Proyecto nuevo: no hay documentos con frontmatter antes de la adopción (comando 1: `trazas=0`, `ids-duplicados=0`);
la línea de base de cada control sobre `docs` es 0 por construcción y se midió con la compuerta (ficha, §8).
`excepciones.txt` de `.docs-guard/` queda vacío.

| Control | Carpeta | Línea de base | Estado |
| --- | --- | --- | --- |
| PR-1 enlaces | docs | ver ficha §8 | bloquea si verde |
| PR-2 esquema | docs | 0 | bloquea |
| PR-3 ai | docs | 0 | bloquea (AI-3 avisa) |
| PR-4 estructura | docs | ver ficha §8 | bloquea si verde |
| PR-5 trazas | docs | 0 | bloquea |
| PR-6 contrato | docs | 0 (sin contrato) | avisa |
| PR-7 fijadas | docs | 0 | bloquea |

## A-13 — Controles de entrega y de punto de uso

Ninguno tiene par rojo/verde corrido: todos avisan (I-15, DE-30).

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
| pruebas de entrega pareadas | avisa | pendiente: sin servidor ni API en este repo |
