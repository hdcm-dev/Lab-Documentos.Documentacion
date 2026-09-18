# Bitácora 00 — Fuente literal de «esto último que escribiste»

**Fecha:** 2026-09-18
**Origen:** respuesta del asistente en la conversación del 2026-09-18, a la consulta del PO: «en mi cabeza quedó hacer una página razor, inyectar el servicio, y de ahí entre página y services paso las entidades planas… podés darme contexto cómo se piensa cada una de esas entidades que aparecen en la jerarquía clean».
**Uso:** DR-01 del ciclo 1. El texto se archiva sin editar; la tabla del final traza cada afirmación a su sección del entregable.

---

## Texto literal

> Tu idea (una página Razor que inyecta un servicio y recibe objetos planos) está bien, y la guía hace eso mismo en el front. La diferencia está en qué recibe la página: no son entidades del dominio sino **DTOs**. Al principio se parecen mucho, porque tienen los mismos campos, y por eso parecen duplicados. Se separan porque cada uno responde una pregunta distinta y cambia por un motivo distinto.
>
> ## Cada objeto responde una pregunta
>
> | Objeto | Ejemplo | Pregunta que responde | Dónde vive | Cambia cuando… |
> |---|---|---|---|---|
> | **Entity** | `Producto` | ¿Qué es cierto en el negocio? | Domain | cambian las reglas del negocio |
> | **Value Object** | `Dinero` | ¿Qué valor tiene sentido por sí solo, sin identidad? | Domain | cambia el concepto |
> | **Command / Query** | `CrearProductoCommand` | ¿Qué quiere hacer el usuario? | Application | cambia el caso de uso |
> | **Response DTO** | `ProductoResponseDto` | ¿Qué le prometo al que consume la API? | Contracts | cambia el contrato (con cuidado, porque rompe a los clientes) |
> | **ViewModel** | `ProductoListItemViewModel` | ¿Qué necesita mostrar esta pantalla? | Front | cambia el diseño |
> | **Form model** | `ProductoFormViewModel` | ¿Qué edita el usuario en el formulario? | Front | cambia el formulario |
> | **Persistence model** | `ProductoDbModel` | ¿Qué forma tiene la tabla? | Infrastructure | cambia el esquema. Casi nunca hace falta: ver más abajo |
>
> ## El recorrido de un producto
>
> Leyendo un producto:
>
> ```
> fila SQL ─(EF Core)─▶ Producto ─(handler)─▶ ProductoResponseDto ─(JSON/HTTP)─▶
>   servicio del front ─▶ ProductoResponseDto ─(mapper)─▶ ProductoListItemViewModel ─▶ página
> ```
>
> Creando un producto:
>
> ```
> página ─▶ ProductoFormViewModel ─▶ CrearProductoRequestDto ─(HTTP)─▶ CrearProductoCommand
>   ─▶ Producto.Create(...)  ← acá se verifica "precio > 0"
>   ─▶ EF Core ─▶ fila SQL
> ```
>
> La entidad nunca sale del backend. La página solo recibe DTOs y ViewModels.
>
> ## "Pero la entidad es la que mapea la base de datos"
>
> Sí, y en Clean también lo hace. La diferencia es de dónde viene el mapeo:
>
> - En tu idea, la clase **sabe** que la mapean: tiene `[Table]`, `[Key]` y setters públicos para que EF la cargue.
> - En Clean, la mapean **desde afuera**. `ProductoConfiguration`, en Infrastructure, le dice a EF cómo guardarla, y `Producto` no se entera. Por eso la guía dice que el `ProductoDbModel` separado casi nunca hace falta: EF mapea la entidad directamente con Fluent API. Solo se justifica cuando hay una base heredada con nombres como `prod_id` que no querés arrastrar al dominio.
>
> ## Por qué no alcanza con una sola clase plana
>
> Por dos necesidades que chocan:
>
> 1. **La página necesita setters públicos** para hacer `@bind-Value="producto.Precio"`. **La entidad necesita setters privados** para que nadie ponga un precio negativo sin pasar por `Create`. Una misma clase no puede cumplir las dos cosas.
> 2. **Lo que viaja a la pantalla es un contrato.** Si la página recibe la entidad, cualquier campo nuevo en la tabla (un costo interno, un hash) llega al cliente. En Blazor WASM, además, el front corre en el navegador y ni siquiera tiene el ensamblado del dominio.
>
> ## Cuándo tu idea es la correcta
>
> Si la app es **Blazor Server, sin API aparte y con un CRUD de pocas reglas**, el esquema página → servicio → EF con una sola clase es una arquitectura en capas válida (Transaction Script). Tener seis objetos por concepto sería ceremonia. El costo aparece recién cuando:
> - se suma un segundo cliente (MAUI, otra app), que es cuando nace la API y con ella los DTOs;
> - las reglas empiezan a repetirse en varias páginas, que es cuando conviene tener una entidad con comportamiento.
>
> Un término medio que suele funcionar: **la entidad mapeada por EF, por un lado, y lo que la página bindea (un DTO o un form model), por otro**. Con esa separación ya resolvés el choque de los setters y el filtrado de campos, sin montar toda la cebolla.

---

## Trazabilidad afirmación → sección del entregable

| # | Afirmación de la fuente | Destino | Ajuste por decisión de la mesa |
|---|---|---|---|
| F-01 | La página recibe DTOs, no entidades | §6.2, §7.2 d | — |
| F-02 | Se parecen al principio y se separan porque cambian por motivos distintos | §7.1 (columna «cambia cuando») | — |
| F-03 | Tabla de siete objetos | §7.1 + columna «Existe solo si…» (DR-19) | Nombres: `ProductoResponse`, `CrearProductoRequest`, `ProductoFormModel` (DR-12) |
| F-04 | Recorrido de lectura y de escritura | §7.3, diagrama 3 | `ProductoDto` entre handler y controller (DA-2) |
| F-05 | La entidad nunca sale del backend | §7.3, §8.3 | Condicionado a E-A (HC-23) |
| F-06 | La entidad se mapea desde afuera con Fluent API | §5.4 | — |
| F-07 | `ProductoDbModel` solo con base heredada | §7.2 g, escenario E-C | — |
| F-08 | Setters públicos vs. privados | §3.3, §7.4 | Evidencia L10 |
| F-09 | El contrato filtra campos; WASM no tiene el ensamblado de dominio | §5.2 (L15), §7.4 | Ajuste del ciclo 2 (C-22): §7.4 dice que el ensamblado de `Domain` podría descargarse al navegador pero que no habría base ni repositorio que respalden a la entidad; el punto de la fuente (la página no trabaja con la entidad) se conserva |
| F-10 | Blazor Server + CRUD de pocas reglas = Transaction Script válido | §7.5, §9.2, E-A | Atribución a Fowler verificada en su catálogo (DR-10) |
| F-11 | Señales: segundo cliente; reglas repetidas | §9.3 | — |
| F-12 | Término medio | §7.5, §9.2 escalón intermedio | — |

Registro de voz: la fuente es un diálogo en segunda persona («tu idea»); el entregable la reescribe en exposición impersonal («el esquema página → servicio → EF»), por DR-18.
