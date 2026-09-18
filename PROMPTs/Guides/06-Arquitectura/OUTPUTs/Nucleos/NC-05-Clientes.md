# NC-05 — Los clientes (WebFront, Shared.UI, Desktop)

**Pregunta del lector:** ¿cómo habla una página Blazor o MAUI con el backend?

## Contenido
- Página Razor → servicio inyectado por interfaz → HTTP → API. La página recibe DTOs, no entidades (NC-03).
- Capa de servicios del front: HttpClient manual vs. Refit (verificar la afirmación «genera la implementación en compilación»: Refit ≥ 6 usa source generators — a confirmar con fuente).
- Shared.UI (Razor Class Library) compartida entre Blazor web y MAUI Blazor Hybrid.
- Hybrid vs. WebView remoto.
- Autenticación con `DelegatingHandler`.
- Blazor Server vs. WebAssembly: en Server el código corre en el servidor y *podría* referenciar Application; la guía debe explicar por qué igual se separa o cuándo no (NC-09).

## Evidencia
- Cliente de consola o Blazor mínimo consumiendo la API (E1), o al menos `curl` como cliente HTTP genérico.
- MAUI: fuera del laboratorio (requiere workloads); se declara como fragmento ilustrativo.
