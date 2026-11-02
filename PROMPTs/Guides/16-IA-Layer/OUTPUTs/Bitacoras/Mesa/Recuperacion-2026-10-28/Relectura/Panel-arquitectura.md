# Panel · arquitectura (relectura integral de la guía 0.11.0)

Rol: capas, adaptadores, composición, la demo como integración y coherencia entre partes. A ciegas: no leí otros paneles. Guía sin editar.

## arquitectura-01 · mayor · §4.3 «Lo que la prueba no ve», §13.12 (ADR-11)
- **Problema.** Las reglas de `ArquitecturaTests` prohíben por nombre de ensamblado (`OllamaSharp`, `OpenAI`) y por namespace `…Infrastructure*`, y sólo recorren el ensamblado de la demo. El SDK vive además en `Examples/_Comun/MovilidadUrbana.Asistente.Comun` (`FabricaDeClientes`, namespace `…Comun.AI`, con `PackageReference` a OllamaSharp), que la demo referencia. Un tipo de Domain o Application que llame a `FabricaDeClientes.CrearChatOllama` no da violación: el uso del SDK queda un salto más abajo.
- **Evidencia.** `Demos/…/tests/…/Cableado/ArquitecturaTests.cs` líneas 20, 27-43 (predicados) y 101-102 (compara `r.Assembly.GetName().Name`); `Examples/_Comun/MovilidadUrbana.Asistente.Comun/MovilidadUrbana.Asistente.Comun.csproj` línea 14; demo `src/…csproj` línea 30. La guía lista como únicos agujeros el `global using` sin uso y el `nameof`.
- **Propuesta.** Declarar este tercer agujero en §4.3 y §13.12 o cerrar la regla prohibiendo también `…Comun.AI` (y `…Comun.Pruebas`) fuera de Infrastructure.AI y Program; no afirmar que la regla lo cubre sin una mutación roja que lo pruebe.

## arquitectura-02 · mayor · §3.1 (fila «AI LAYER · LLM») y §14.2
- **Problema.** La tabla ubica «`IChatClient` y el adaptador del proveedor» en Infrastructure/AI, y el comentario de `AddAI` dice «el SDK del proveedor sólo aparece acá y en la capa única». La creación del cliente de Ollama y la capa de opciones están en `Examples/_Comun`, fuera de la solución de la demo; el diagrama de §14.2 no muestra esa dependencia de la demo hacia el árbol de ejemplos.
- **Evidencia.** `Infrastructure/AI/DependencyInjection.cs` líneas 38-46; §13.3 «Demo.» ya nombra `FabricaDeClientes` en `_Comun`.
- **Propuesta.** Una línea en §3.1/§14.2: el adaptador se arma en la biblioteca común compartida con los ejemplos, que la demo referencia como proyecto; o un nodo en el diagrama.

## arquitectura-03 · menor · `AddAI` y Anexo de variables (`EMB_PLAN`)
- **Problema.** En la composición de producción, `EMB-C` registra `GeneradorDeEmbeddingsEstable`, un doble del namespace `…Comun.Pruebas`, y el modo guion un `ClienteDeDemostracion`. La guía describe `EMB-C` como «sin modelo de embeddings» y no dice que la raíz de composición registra un doble de pruebas.
- **Evidencia.** `Infrastructure/AI/DependencyInjection.cs` líneas 6 y 44; guía, fila `EMB_PLAN`.
- **Propuesta.** Nombrar el doble en la fila de `EMB_PLAN` (o en §5.5) y aclarar que es un modo de demostración y no un patrón para CTX-PROD.

## arquitectura-04 · menor · §13.12 «Consecuencias»
- **Problema.** «Cuatro reglas cubren Domain, el SDK y las herramientas» omite la regla de Application (`Application_SinInfrastructureNiSdk`). §4.3 dice «otras cuatro reglas» contando la quinta, lo que también confunde el conteo.
- **Evidencia.** `ArquitecturaTests.cs` líneas 27, 36, 45, 57, 66 (cinco reglas: Domain, Application, SDK, herramientas, Presentación).
- **Propuesta.** «Cuatro reglas cubren Domain, Application, el SDK y las herramientas; la quinta…», y en §4.3 «otras tres reglas siguen en el archivo; la quinta…».

## Nota
Sin mensajes ajenos a la carta durante el trabajo. Sin cifras nuevas.
