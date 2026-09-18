# NC-03 — Los objetos de cada capa

**Pregunta del lector:** ¿qué clase uso para qué, si todas se parecen?

## Material de origen (conversación 2026-09-18, a incorporar con respuestas explicativas)

| Objeto | Ejemplo | Pregunta que responde | Dónde vive | Cambia cuando… |
|---|---|---|---|---|
| Entity | `Producto` | ¿Qué es verdad en el negocio? | Domain | cambian las reglas del negocio |
| Value Object | `Dinero` | ¿Qué valor tiene sentido por sí mismo, sin identidad? | Domain | cambia el concepto |
| Command / Query | `CrearProductoCommand` | ¿Qué quiere hacer el usuario? | Application | cambia el caso de uso |
| Response DTO | `ProductoResponseDto` | ¿Qué le prometo al consumidor de la API? | Contracts | cambia el contrato |
| ViewModel | `ProductoListItemViewModel` | ¿Qué necesita mostrar esta pantalla? | Front | cambia el diseño |
| Form model | `ProductoFormViewModel` | ¿Qué edita el usuario en el formulario? | Front | cambia el formulario |
| Persistence model | `ProductoDbModel` | ¿Qué forma tiene la tabla? | Infrastructure | cambia el esquema (casi nunca necesario) |

Y además: recorrido de ida y vuelta de un producto; «la entidad es la que mapea la base» (sí, desde afuera con Fluent API); por qué no alcanza una sola clase plana (setters públicos vs. privados; contrato que filtra campos; WASM no tiene el ensamblado de Domain); cuándo la clase única es correcta (Blazor Server + CRUD pequeño = Transaction Script, Fowler PoEAA 2002).

## Requerimiento del prompt
Cada pregunta de la tabla recibe una **respuesta explicativa** (patrón pregunta → respuesta en una línea → porqué → ejemplos ✅/❌).

## Evidencia
- Entity con setter privado: intento de asignación desde fuera → CS0272 (E1 a capturar).
- `Producto.Create(…, -5)` → excepción de dominio (E1 por test o ejecución).
- JSON real de `GET /api/productos` mostrando solo los campos del DTO (E1).
