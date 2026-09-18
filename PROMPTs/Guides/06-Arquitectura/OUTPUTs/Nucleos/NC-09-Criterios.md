# NC-09 — Criterios de diseño para un problema real

**Pregunta del lector:** tengo un problema real; ¿qué estructura elijo y cuándo no conviene Clean?

## Contenido
- Del problema a la estructura: identificar conceptos del dominio, intenciones del usuario, consumidores (una app / varias), reglas de negocio (pocas / muchas), persistencia (nueva / heredada).
- Escala de opciones: página→EF (Transaction Script) → capas con servicio → Clean con casos de uso → Clean + CQRS con mediador. Monolito modular / microservicios fuera de alcance (remitir a la guía propia).
- Señales para subir de escalón: segundo cliente, reglas repetidas, tests del dominio, equipo que crece.
- Señales de sobre-ingeniería: seis objetos por concepto en un CRUD, mappers que copian campo a campo sin diferencia.
- Caso resuelto de punta a punta con el ejemplo conductor.

## Fuentes
Fowler, *Patterns of Enterprise Application Architecture* (2002): Transaction Script vs. Domain Model; Martin (2017); Microsoft Learn, «Common web application architectures» (eShopOnWeb).
