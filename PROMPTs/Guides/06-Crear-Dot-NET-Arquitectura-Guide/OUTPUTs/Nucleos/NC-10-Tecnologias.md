# NC-10 — Decisiones tecnológicas y vigencia

**Pregunta del lector:** ¿qué librerías, qué versión y con qué licencia?

## A verificar con fuente (no afirmar sin ella)
- Versión de .NET: .NET 9 (STS) vs. .NET 10 (LTS). Política de soporte de Microsoft.
- MediatR: cambio de licencia (Lucky Penny Software, 2025) — confirmar versión y condiciones.
- AutoMapper: mismo caso — confirmar.
- FluentValidation: licencia vigente.
- Refit: generación por source generator — confirmar.
- EF Core versión alineada al runtime.
- Scalar / Swashbuckle: la plantilla `webapi` de .NET 9 dejó de incluir Swashbuckle y usa `Microsoft.AspNetCore.OpenApi` — confirmar.

## Criterio a enseñar
Toda dependencia de terceros se evalúa por: licencia, mantenimiento, alternativa nativa, costo de salida.
