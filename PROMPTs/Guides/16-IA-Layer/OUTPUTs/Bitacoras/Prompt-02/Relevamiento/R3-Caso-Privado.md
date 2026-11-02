# R3 — Caso privado (resumen abstracto)

Caso: un servicio privado de notificaciones push con back office (API de envío, panel web de administración, SDK cliente para apps móviles, base relacional con procedimientos). Hoy no incorpora IA. El detalle queda en un informe privado (<privado>).

Capacidades de IA que se evaluarían para la guía:
- Redacción asistida de mensajes en el back office, con validación determinista posterior.
- Consulta en lenguaje natural sobre historial y métricas de envío mediante herramientas tipadas de solo lectura (sin SQL libre).
- Clasificación y resumen de fallos de entrega para diagnóstico.
- Segmentación de destinatarios propuesta por IA y confirmada por una persona.
- Asistente de operación/desarrollo con RAG sobre la documentación del proyecto.

Restricciones que el caso enseña: acciones irreversibles (envío masivo) sólo con confirmación humana; respeto del aislamiento por inquilino en cada herramienta; protección de datos personales de destinatarios.
