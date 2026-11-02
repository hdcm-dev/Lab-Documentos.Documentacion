# Evidencia de «Arquitectura de software», relectura integral (ciclo 2), 2026-10-28

Sondas corridas sobre COPIAS de trabajo (nunca sobre la guía), con el recurso «build», en
`mcr.microsoft.com/dotnet/sdk:10.0` y el volumen de paquetes del laboratorio. Las copias se borraron al terminar.

| Archivo | Qué es |
|---|---|
| `01-sonda-reglas-de-examples13.cs.txt` | prueba agregada a una copia de la demo: aplica a la demo las reglas R2–R6 de `Examples/13` (familias de `Capas.cs` traducidas a los espacios de nombres de la demo) |
| `02-salida-sonda-reglas.txt` | salida: R2, R4, R5 en 0; **R3 rojo** (las herramientas de `Infrastructure.AI` usan `LocalidadService` y `ResultadosDeEncuestaService`, la mutación `HerramientaEnInfrastructure` de §4.6.2); **R6 rojo** (Presentation → `OpcionesDeIA`/`OpcionesDeConcurrencia` en 3 tipos, y → `SessionContext` concreto en `App`, `Routes` y `CookieDeSesionMiddleware`, además de la excepción heredada) |
| `03-sonda-generico-de-metodo-demo.cs.txt`, `04-…-examples13.cs.txt` | caso rojo nuevo: un tipo «del núcleo» que nombra `ChatMessage` sólo como argumento genérico de un método (`s.AddSingleton<ChatMessage>()`) |
| `05-salida-generico-de-metodo.txt` | motor de la demo: 0 hallazgos; motor de `Examples/13`: 1 hallazgo |

Nota sobre R5 = 0: la sonda incluye `MovilidadUrbana.Asistente.Infrastructure.Persistence` en «persistencia», y
`ComposicionDeIA.cs` l. 79 registra `AddScoped<ILecturaDeResultados, LecturaDeResultadosEf>()`; el motor de la demo no lo
ve porque `LecturaDeResultadosEf` aparece sólo como argumento genérico de método (el mismo agujero de 05).

Lectura estática (sin corrida): `Examples/13/.../Composicion.cs` registra `HerramientasDeLectura` y ningún tipo llama a
`Catalogo()`; `Examples/05/.../Infrastructure/Persistence/AlmacenDeRequisitos.cs` l. 2 y 6 usan `Microsoft.Extensions.AI`
y `...Infrastructure.AI`; `Examples/10/.../Infrastructure/Workflows/WorkflowDeAlta.cs` l. 2 y 46 toman `LocalidadService`;
`Demos/.../Agregado/Presentation/Controllers/AsistenteController.cs` l. 22 aplica `[EnableRateLimiting]` a la clase entera.
