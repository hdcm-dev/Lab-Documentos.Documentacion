---
doc_id: BIT-16-C2-INF-CAT-operacion-entrega-rendimiento
doc_type: informe-de-mesa
title: Relectura integral (ciclo 2) — Operación y entrega, con rendimiento y costo
status: emitido
origin: ai-assisted
last_review: 2026-10-28
traces: [REED-16 §10, 06-Plan-De-Redaccion §10, 07-Dictamen-Presidencia, 00-Compuertas-Redaccion]
---

# Operación y entrega (con rendimiento y costo) — relectura integral, ciclo 2

**Rol.** Observabilidad, límites, costo y latencia, despliegue, configuración y secretos; coherencia de los rótulos de
estación y de las cifras de latencia en toda la guía. Lectura a ciegas: no se leyó ningún otro `Informe-*.md` del
ciclo 2.

**Qué se leyó.** La guía completa, de punta a punta (4116 líneas, §0 a Anexo F); de `Examples/`, los `appsettings*.json`
de todos los ejemplos, los README de 01, 02, 03 y 09 en lo de configuración y cifras, y el código de configuración de
03; de `Demos/MovilidadUrbana.Asistente/`, `appsettings*.json`, el README (correr, límites para producción), la página
de chat (permiso del limitador) y la composición (timeout del `HttpClient`). Cotejo de cifras contra el Anexo E.4,
`Sondeo-Entorno.md` §R.6 y las consultas del ciclo 1.

**Qué se corrió** (turno `build`, `mcr.microsoft.com/dotnet/sdk:10.0` con el volumen `<volumen-nuget>`, sobre una copia
de la demo fuera del repositorio; nada quedó en la carpeta de la guía):

- E-OP-01: la demo en `Production` sin y con `AI__TimeoutSegundos` por variable.
- E-OP-02: la consola de la demo en `Development`, con un `OLLAMA_ENDPOINT` de host ficticio y sin red, ante un
  `POST /api/v1/asistente`; una vez como viene y otra con `System.Net.Http.HttpClient` en `Warning`.
- Ninguna prueba contra el modelo: los hallazgos no la necesitan (R-LLM no aplica).

Evidencia: `evidencia-CAT-operacion-entrega-rendimiento/` (E-OP-01, E-OP-02, E-OP-03 y los dos scripts).

## Hallazgos

### CAT-OP-01 · El presupuesto de R-LLM-5 usa una cifra que no está en la tabla única (S2, coherencia)

- **Ubicación.** Guía, Anexo E.5, regla 5 (l. 4051).
- **Evidencia (a, medida y cotejada).** La regla dice «con una mediana de unos 27 s por llamada del 4b en la estación de
  4 núcleos». E.4 afirma «Toda cifra de latencia de la guía sale de esta tabla» y para la llamada a herramienta del 4b
  en esa estación da 4,68 s y 4,75 s de mediana (l. 4018–4019); ninguna fila da 27 s. El 27 s viene de la sonda AH-02
  del ciclo 1 (`Consulta-AH-02-formal.md` l. 96: «59 llamadas en 25,4 min»), otra mezcla de operaciones. Un lector que
  cruce §2.5 (4,68 s), §7.13.2 y E.5 ve tres números para «una llamada del 4b» (E-OP-03 §1).
- **Propuesta.** Reemplazar la regla 5 por:
  > 5. **Presupuesto:** se calcula con la mediana de la operación que se va a medir (E.4), más la carga en frío. En la
  > estación de 4 núcleos va de 4,68 s (llamada a herramienta) a 26,37 s (propuesta de escritura); con la más lenta, un
  > turno de 45 minutos da unas 100 llamadas (una tasa de la tarea con K = 10 y m = 5, o cuatro tasas de un pedido con
  > m = 10). Lo que no entra se rotula «no medido».

### CAT-OP-02 · «De 4,65 a 4,96 s de mediana por serie» no son medianas (S3, coherencia)

- **Ubicación.** Guía, §7.13.2 (l. 2583).
- **Evidencia (a).** E.4 da medianas de 4,68 s y 4,75 s; 4,65 es el mínimo de la primera serie y 4,96 el máximo en
  caliente de la segunda (`Sondeo-Entorno.md` l. 288, «4,69–4,96 s»). El parche del ciclo 1 decía «4,65–4,96 s de
  mediana por serie (4,68 y 4,75 s)»: al pasar a la guía se perdió el paréntesis y quedó un rango presentado como
  mediana (E-OP-03 §2).
- **Propuesta.** Donde dice «una llamada a herramienta con el modelo cargado tardó de 4,65 a 4,96 s de mediana por
  serie, sin contar la carga (estación de 4 núcleos)» poner «una llamada a herramienta con el modelo cargado tardó
  4,68 y 4,75 s de mediana en dos series de 10, sin contar la carga (estación de 4 núcleos; E.4)».

### CAT-OP-03 · El rótulo dice «5 GB» y el límite medido es 5 GiB, frente a «34 GiB» de la otra estación (S3, coherencia)

- **Ubicación.** Guía: §0.5 (l. 220) y las ocho repeticiones del rótulo largo (l. 407, 408, 410, 412, 464, 2939,
  3090, 3435) más E.3 (l. 3998); README de `Examples/01`, `02`, `04`, `07`, `08` y de la demo; comentario de
  `Examples/02-Streaming/src/MovilidadUrbana.Streaming/appsettings.Development.json` (l. 4).
- **Evidencia (a).** El contenedor de la estación de 4 núcleos tiene `Memory=5368709120` (`X4-env-contenedor.txt`),
  5 GiB exactos; la otra estación se rotula en GiB. Los dos rótulos que §0.5 pide no comparar usan unidades distintas
  (E-OP-03 §3).
- **Propuesta.** Reemplazar `4 CPU / 5 GB` por `4 CPU / 5 GiB` en todas las ocurrencias del entregable
  (`sed -i 's#4 CPU / 5 GB#4 CPU / 5 GiB#g'` sobre la guía, los seis README y el `appsettings.Development.json` de 02;
  en el README de la demo el rótulo está partido en dos líneas, «4 CPU /» y «5 GB»: corregirlo a mano).

### CAT-OP-04 · El despliegue no dice cómo arranca la aplicación fuera de Development (S2, técnico)

- **Ubicación.** Guía, §8.12.2 (l. 3112–3128) y §9.8 (l. 3460); README de la demo, «Correr la demo» (l. 114).
- **Evidencia (a, medida).** La subsección «La aplicación» sólo muestra `dotnet run` con el SDK y
  `ASPNETCORE_ENVIRONMENT=Development`, y dice «Sin `ASPNETCORE_ENVIRONMENT=Development` la app no arranca». No hay
  `appsettings.Production.json` ni se dice cómo se declara el timeout en otro entorno, aunque ACT-OPS tiene como objetivo
  «Configurar endpoint, modelo y secretos por entorno» (§0.3). Medido (E-OP-01): con `Production` y sin variable,
  `OptionsValidationException` («The field TimeoutSegundos must be between 1 and 3600»); con
  `-e AI__TimeoutSegundos=300`, «Now listening» y «Application started».
- **Propuesta.** En §8.12.2, después de «Configuración por entorno, validada al arrancar», agregar:
  > - **Fuera de Development, el timeout por variable.** Ningún `appsettings.Production.json` lo trae: en otro entorno se
  >   declara con su fuente, por ejemplo `-e AI__TimeoutSegundos=300` (`__` en lugar de `:`). Medido el 2026-10-28 con la
  >   demo: en `Production` sin la variable, `OptionsValidationException`; con la variable, arranca. El valor se mide en la
  >   estación de ese entorno (Anexo A.1).
  > - **Es una corrida de laboratorio, no un artefacto.** `dotnet run` sobre la imagen del SDK compila al arrancar; una
  >   imagen de ejecución construida con `dotnet publish` no se armó en esta guía: no ejecutado.

  Y en el README de la demo, al final del ítem de `ASPNETCORE_ENVIRONMENT`: «En otro entorno, el valor va por variable:
  `-e AI__TimeoutSegundos=<valor medido>`.»

### CAT-OP-05 · `Examples/03` declara el timeout en el `appsettings.json` base, contra la regla de la guía (S3, coherencia)

- **Ubicación.** `Examples/03-Salida-Estructurada/src/MovilidadUrbana.SalidaEstructurada/appsettings.json` (l. 15);
  guía §5.3, decisión 1 (l. 977), y Anexo A.2 (l. 3586).
- **Evidencia (a).** La guía enseña «`TimeoutSegundos` sin valor por defecto… cada `appsettings.<entorno>.json` lo
  declara» y «el timeout sólo en el entorno que lo midió, para que un entorno nuevo no arranque con un valor heredado».
  `Examples/03` es el único que lo pone en el archivo base (los demás, en `appsettings.Development.json`, E-OP-03 §5):
  arranca igual en cualquier entorno con 300 s. Moverlo rompe las pruebas, que leen sólo `appsettings.json`
  (`tests/…/Dobles/Opciones.cs`, l. 11).
- **Propuesta.** Declarar la excepción en lugar de mover el valor. En §5.3, al final de la decisión 1: «Excepción
  declarada: `Examples/03-Salida-Estructurada` lo fija en su `appsettings.json` base porque sus pruebas leen ese
  archivo; en una aplicación va en el `appsettings.<entorno>.json`.» En el comentario del archivo, sumar «; está en el
  archivo base porque las pruebas lo leen de acá (excepción declarada en la guía, §5.3)».

### CAT-OP-06 · La demo escribe la URL del servidor en la consola, y bajar a `Warning` no alcanza (S3, seguridad)

- **Ubicación.** `Demos/MovilidadUrbana.Asistente/src/MovilidadUrbana.Asistente/appsettings.json` (l. 3) y
  `appsettings.Development.json` (l. 2); guía §5.3 (b) (l. 992), §8.5.4 (l. 2935), §9.8 (l. 3462), Anexo A.2
  (l. 3586) y B.3, ACT-OPS (l. 3702).
- **Evidencia (a, medida, E-OP-02).** La guía dice que bajando el nivel a `Warning` «ninguna captura publicada filtra el
  endpoint», y la lista de ACT-OPS pide que ninguna captura muestre la URL. La demo, el integrador, viene en
  `Information` sin bajar `System.Net.Http.HttpClient`: un solo pedido escribió el host y el puerto en 5 líneas. Con
  `Logging__LogLevel__System.Net.Http.HttpClient=Warning` quedó 1: si el servidor no responde,
  `OpenTelemetryChatClient` registra en `warn` `gen_ai.client.operation.exception` con la excepción, que nombra el
  host y el puerto. La regla de la guía tapa los pedidos que salen bien, no los que fallan.
- **Propuesta.** (a) En los dos `appsettings` de la demo, sumar `"System.Net.Http.HttpClient": "Warning"` al
  `LogLevel`. (b) En §9.8, reemplazar el tercer ítem por: «La demo baja `System.Net.Http.HttpClient` a `Warning`, así
  que los pedidos al servidor no se registran. Pero si el servidor no responde, `OpenTelemetryChatClient` registra en
  `Warning` la excepción con el host y el puerto (`gen_ai.client.operation.exception`; medido en la demo sin servidor,
  2026-10-28). Antes de publicar una captura de consola, se revisa igual.» (c) En §8.5.4, cambiar «y ninguna captura
  publicada filtra el endpoint» por «y los pedidos que salen bien no escriben el endpoint; la excepción de uno que falla
  sí lo nombra (§9.8)»; en B.3, ACT-OPS, «Ninguna captura publicada muestra la URL del servidor, ni en un pedido que
  falla (§5.3, §9.8)».

### CAT-OP-07 · La cola del limitador no se dimensiona con la latencia (S3, técnico)

- **Ubicación.** Guía, §8.6 (después de l. 2966); Anexo A.1, fila `Concurrencia` (l. 3544).
- **Evidencia (b, derivada de cifras de la guía y del código).** La guía elige `Permisos` 1, `Cola` 2 y
  `Retry-After: 30` («valores elegidos, no medidos») y mide sólo que el cuarto pedido recibe 503. No dice cuánto espera
  el que entra en la cola. Con un permiso, el último de la cola empieza cuando terminan los dos de adelante;
  `TimeoutSegundos` corre por llamada (`http.Timeout` en `ComposicionDeIA.cs` de la demo, l. 56), no por la espera; un
  turno de la demo con extracción hace dos llamadas (§9.4), y en la estación de 4 núcleos la propuesta de escritura tardó
  13,87–26,37 s de mediana con máximos de hasta 75,63 s (E.4). Además, la página pide el permiso antes de
  `ConversarAsync` (`ChatDelAsistente.razor`, l. 134), así que durante la espera no recibe ningún evento de etapa.
- **Propuesta.** En §8.6, después del párrafo de la prueba, agregar:
  > **La cola también es espera.** Con `Permisos` = 1, el último de la cola empieza recién cuando terminan los de
  > adelante, y `TimeoutSegundos` corre por llamada al servidor, no por la espera. En la estación de 4 núcleos un turno
  > con extracción hace dos llamadas, y la propuesta de escritura tardó 13,87–26,37 s de mediana, con máximos de hasta
  > 75,63 s (E.4): el último de la cola puede esperar minutos antes de su primera llamada, y la página, que pide el
  > permiso antes de llamar al núcleo, no muestra una etapa mientras tanto. `Cola` y `Retry-After` se eligen con la
  > latencia de la estación del entorno; la espera en cola no se midió.

  En A.1, fila `Concurrencia`, sumar a la pregunta: «¿cuánto espera el último de la cola con la latencia medida?».

### CAT-OP-08 · El costo del juez parece salir de una prueba que «no se corrió» (S3, evidencia)

- **Ubicación.** Guía, §8.9.2 (l. 3066 y 3074); Anexo E.4 (l. 4036–4037) y E.5 (l. 4073).
- **Evidencia (a).** §8.9.2 muestra `EvaluacionConJuezTests` con cuatro evaluadores, dice que «no se corrió» y, cuatro
  líneas después, da «Costo medido… 1285 s para un caso con siete evaluadores… 28 evaluaciones en 950 s». El costo
  salió de otra pieza, una sonda .NET del ciclo 1 con siete evaluadores de Quality 10.11.0 (Relevance, Coherence,
  Fluency, Groundedness, Retrieval, Completeness, Equivalence) sobre cuatro casos escritos a mano
  (`Consulta-{estación-2}-ollama.md`, l. 105). El lector no puede saber de dónde viene ni por qué son siete (E-OP-03 §4).
- **Propuesta.** En §8.9.2, empezar el ítem así: «**Costo medido**, con una sonda aparte de `ConModelo/` (siete
  evaluadores de `Microsoft.Extensions.AI.Evaluation.Quality` 10.11.0: Relevance, Coherence, Fluency, Groundedness,
  Retrieval, Completeness y Equivalence, sobre cuatro casos escritos a mano) y `qwen3.5:4b` como juez: …». En E.4, en
  las dos filas del juez, poner «(sonda aparte)» en la columna Operación.

## Revisado y bien

1. **La tabla única de cifras sostiene las cargas y los recortes.** Las tres cifras de carga que aparecen en la guía son
   filas distintas de E.4 y cada mención las usa en su sentido: 10,5–16,1 s de recarga al alternar `num_ctx` (§5.4,
   §6.4.3, §6.11.14, §8.8), 11,5–19,2 s de carga en frío (§8.12.1) y 34,51 s como primera llamada con carga (§2.5). Lo
   mismo pasa con los 19 tok/s → «unos 50 s por cada 1000 tokens» (§2.5, §6.4.3, §6.11.6, E.3) y con los 167 s que
   justifican el timeout de 300 s (§8.6, §9.8, README de la demo, comentario de 02 con «margen de 1,8x»).
2. **La cadena de observabilidad es coherente de punta a punta.** El orden caché → herramientas → telemetría →
   cliente, la constante de fuente única, el contador de aciertos, `EnableSensitiveData` sólo en Development, el OTLP
   sólo si hay colector y la doble instrumentación descartada dicen lo mismo en §8.5, CTRL-08, D-09, §8.13.12 y en el
   código de `Examples/09`.
3. **Configuración y secretos sin direcciones reales.** El endpoint sólo llega por `OLLAMA_ENDPOINT` y el versionado
   trae `http://localhost:11434`. La credencial va en un `DelegatingHandler`, nunca en el cuerpo, porque los encabezados
   por pedido de OllamaSharp viajan en el JSON. `Credencial` no está en `appsettings` (`AI__Credencial`), y
   *user-secrets* aparece con su advertencia de que no cifra. Todo eso es consistente entre §5.3, A.1, §8.12.3,
   §8.13.11 y los ejemplos.
