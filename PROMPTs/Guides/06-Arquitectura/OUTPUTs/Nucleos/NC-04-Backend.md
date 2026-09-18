# NC-04 — El backend por proyecto

**Pregunta del lector:** ¿qué va en Domain, Application, Infrastructure y WebAPI?

## Contenido
- **Domain**: entidades, value objects, excepciones, eventos, interfaces de repositorio (DC-3). Cero paquetes de infraestructura.
- **Application**: casos de uso (Command/Query + Handler), validación de entrada, interfaces de servicios técnicos, DTOs internos. Orquesta, no decide reglas.
- **Infrastructure**: DbContext, configuraciones Fluent API, repositorios, servicios externos, registro DI (`AddInfrastructure`).
- **WebAPI**: controllers o minimal APIs delgados, middleware de errores, composition root.

## Decisiones a resolver
- CQRS con o sin MediatR (DA-4: licencia). Alternativa: handlers inyectados directamente.
- AutoMapper vs. mapeo manual (DA-4).
- Validación: FluentValidation (Apache-2.0) vs. DataAnnotations.

## Defectos heredados
- X-03 `nameof(GetById)` sin acción definida.
- `ExceptionHandlingMiddleware` mencionado sin mostrar; decidir si se ejemplifica (ProblemDetails, RFC 9457).

## Evidencia
Proyecto de ejemplo que compila y responde: `POST /api/productos` 201, `GET` 200 con JSON, `POST` con precio negativo → 400/422 con ProblemDetails (E1).
