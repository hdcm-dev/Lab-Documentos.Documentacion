# Folio 012 — Resolución parcial: cierre de la ronda de estructura y plan de elaboración

| Campo | Valor |
| --- | --- |
| Tipo | resolucion |
| Fecha | 2026-11-07 |
| Autor | presidencia de la mesa |
| Corrige | — |

Secciones de Mesa-De-Expertos-A-Pedido 3.1 leídas: las del presidente (§1–§8). La presidencia
consolida sin juzgar: el juicio es el del jurado (folio 011).

## Cuenta de folios de la ronda de estructura

Comisiones convocadas: 5 (folios 005–009) + refutador (010) + jurado composición (003) + jurado
veredicto (011) = 8 informes; fichas de excepción: 0. La cuenta cierra. Hallazgos: 45 PROCEDE, 0 NO
PROCEDE, 0 ARCHIVA (folio 011 §1). Rondas completas: 1 → el cierre de esta fase es **por decisión y
no por criterio** (la regla de cierre de la clase se cumplió: las cuatro preguntas del caso están
respondidas sin «depende», folio 011 §2–§4).

## Lo que esta resolución adopta

1. El temario de 11 núcleos, el marco ESC/CTX/ACT, la estructura documental de 15 piezas y la
   estructura interna común, tal como los vota el folio 011 (§2, §3, §4). Sin reescritura.
2. La verificación nueva de la presidencia sobre el obstáculo del banco: `POST /api/embed` responde
   `{"error":"This server does not support embeddings. Start it with --embeddings"}` (comando:
   `curl /api/embed -d '{"model":"qwen3.5:4b","input":"hola mundo"}'`). Rige el camino alternativo
   declarado por el jurado para el doc 09 (biblioteca local de embeddings, eje no fijo declarado);
   la habilitación del banco entra al lote del PO.
3. El lote al PO (folio 011 §5) se le presenta en la sesión en esta misma fase, con sus defaults;
   ninguna fila se asienta por silencio y nada queda bloqueado mientras tanto.

## Plan de elaboración (fase 3 — aplicación; la mesa no redacta)

Roles fuera del panel, con carta de mandato archivada en `evidencia/` antes del despacho:
- **Redactor estructural** (cartas 014): M3 `Convenciones.md` y M1 `Marco-De-Referencia.md` primero;
  M2 `Cohesion-Global.md` y M0 `IA-Model-Guide.md` al final, con el conjunto ya escrito.
- **Redactor temático** (carta 011): un agente por núcleo (11), estructura interna del folio 011 §4,
  frontmatter `IAM-NN`, laboratorios sólo en su documento dueño (mapa de PREGUNTA 4).
- **Verificador técnico** (carta 012): corre cada ejemplo operable contra el banco (folio 004),
  pega salidas reales recortadas, marca «ilustrativo» lo no corrible, deja su constancia en
  `despacho/verif-NN.md` y la evidencia cruda en `evidencia/local/` (no versionada: gitignored, fuera del repo público) con huella.
- **Editor académico** (carta 013): conformidad con M3, voz narrativa, estructura, enlaces.

Secuencia por pieza temática: redactor → verificador → editor (tubería, sin barrera entre piezas).
Barrera única antes de M2/M0. La ronda 2 de la mesa (revisión del borrador completo) sigue a esta
fase y precede a la entrega por Conformacion-Pull-Request-Automatico 2.0.

Sigue: folio 013 (bitácora de elaboración incorporada o informe de verificación global, según
llegue) · despachos abiertos: redactores estructurales y temáticos, verificadores, editores
(workflow de elaboración) · insumos: folios 001–011, cartas 011–014 de evidencia · si se corta acá,
se invalida la elaboración en curso; temario, marco y estructura aprobados quedan.
