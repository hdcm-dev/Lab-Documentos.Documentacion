# NC-06 — Estructura física de la solución

**Pregunta del lector:** ¿cómo ordeno carpetas y proyectos, y dónde viven los contratos?

## Estado vigente
`src/core`, `src/infrastructure`, `src/presentation` (WebAPI + WebFront + Desktop + Shared.UI), `src/shared/Contracts` (opcional), `tests/`.

## Problemas
- X-02: `presentation/` mezcla el anillo exterior del backend con aplicaciones que solo hablan HTTP.
- X-01/X-04: Contracts opcional es inconsistente con §13.
- Tests sin WebAPI ni clientes.

## Propuesta a la mesa (DA-1, DA-2)
```
src/
├── Backend/  (Core/Domain, Core/Application, Infrastructure, Presentation/WebAPI)
├── Clients/  (WebFront, Desktop, Shared.UI)
└── Shared/   (Contracts)
tests/
```
Contracts obligatorio cuando existe más de un consumidor .NET de la API.

## Evidencia
`dotnet sln list` y árbol real de la solución de laboratorio (E1).
