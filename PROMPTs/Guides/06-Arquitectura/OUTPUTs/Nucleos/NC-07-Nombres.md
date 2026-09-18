# NC-07 — Convención de nombres

**Pregunta del lector:** ¿en qué idioma nombro y con qué sufijo?

## Regla (DC-2)
- Inglés: arquitectura, capas, patrones, sufijos y operaciones estándar (`Domain`, `Repository`, `Handler`, `Command`, `Query`, `Dto`, `ViewModel`, `AddAsync`, `GetById`, `Create`, páginas scaffold `Index`/`Details`/`Form`/`Home`).
- Español: conceptos del problema (`Producto`, `Pedido`, `Dinero`) e intenciones del usuario (`CrearProductoCommand`, `ObtenerProductosQuery`).
- Prosa en español.

## Base externa
Convenciones de capitalización de .NET (PascalCase para tipos y miembros públicos): Microsoft Learn, «Capitalization Conventions» / «Naming Guidelines». En el repo: `Guides/Organizacion-Estilo-Patrones-Codigo/40-Nomenclatura/`.

## Preguntas guía
- `CrearProductoCommand`: ¿por qué «Crear» en español y «Command» en inglés? → intención del usuario vs. patrón.
- `AddAsync` del repositorio: ¿por qué inglés? → operación estándar del patrón, no glosario del problema.
