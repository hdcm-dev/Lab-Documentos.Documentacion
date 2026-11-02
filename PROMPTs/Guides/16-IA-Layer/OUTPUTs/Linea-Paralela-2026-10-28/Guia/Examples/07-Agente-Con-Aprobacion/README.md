# 07 · Agente con aprobación

Del chat con herramientas al agente de MAF, y escrituras que esperan a la persona, con el caso de Movilidad Urbana:
el mismo `IChatClient` que contesta «¿Cuántas localidades hay en Chaco?» con una herramienta pasa a ser un agente de
Microsoft Agent Framework con sesión de varios turnos, y ese agente puede **proponer** «Borrá Resistencia», pero la baja
no se ejecuta hasta que la persona la aprueba.

- **Nivel:** intermedio.
- **Sección de la guía:** §7, «Agentes, herramientas y orquestación» (el paso de herramienta a agente mínimo y a agente
  de MAF; `ApprovalRequiredAIFunction` y el contrato de aprobación). La sección de la demo (§9) remite acá: en la demo
  ninguna herramienta escribe y la escritura es una propuesta que la persona confirma con la operación normal; este
  ejemplo muestra el otro camino, con la aprobación de MAF, y lo que hay que custodiar para usarlo. También lo cita
  §8, «Operar, evaluar y asegurar» (inyección con solicitud de confirmación).
- **Modo sin modelo:** sí. `--sin-modelo` usa un cliente guionado que pide las herramientas como lo haría un modelo
  obediente; las pruebas de `Cableado/` corren siempre sin servidor.

## Qué demuestra

1. **Del chat al agente sobre el mismo `IChatClient`.** El cliente se compone una sola vez (OllamaSharp →
   `UseFunctionInvocation` con el corte del bucle por configuración). `DelChatAlAgente/LlamadaUnica.cs` le pasa la
   herramienta en `ChatOptions.Tools`; `DelChatAlAgente/AgenteDeMaf.cs` lo envuelve con `AsAIAgent(instructions:,
   name:, tools:)` y conversa en una `AgentSession`, que guarda el historial entre turnos. La herramienta
   `contar_localidades` delega en `LocalidadService` del caso base.
2. **El agente usa el bucle que ya tenía el cliente.** Con un cliente falso que pide la herramienta en cada vuelta, la
   llamada única y el agente cortan en el mismo número de llamadas (4, con `MaximoDeIteraciones = 3`): MAF no agrega
   otro bucle con sus valores por defecto.
3. **`ApprovalRequiredAIFunction` sobre las escrituras.** El catálogo del agente tiene dos herramientas de lectura
   (`contar_localidades`, `listar_localidades`) y dos de escritura (`eliminar_localidad`, `agregar_localidad`)
   envueltas en `ApprovalRequiredAIFunction`. Cuando el modelo pide una escritura, MAF corta el turno con un
   `ToolApprovalRequestContent` y no ejecuta nada.
4. **La decisión es explícita.** `Aprobacion.PedirAprobacionAsync` le pregunta a un `IAprobador` con un plazo: si no
   contesta (`null`) o vence el plazo, la decisión es «no». En ningún lugar hay un `aprobado = true` cableado.
5. **El contrato de aprobación (A1–A5).**
   - **A1. Todo vive en el servidor.** `AlmacenDeAprobaciones` y `AlmacenDeConversaciones` no salen ni entran por la
     API. El puerto `IAsistenteConAprobacion` sólo recibe texto, ids y la decisión: no hay por dónde mandar una sesión.
   - **A2. El id que ve el cliente es un aleatorio del servidor** (128 bits), atado a `SessionId + ConversacionId`.
     No es el `RequestId` de MAF, que es `"ficc_"` + el `CallId` que generó el proveedor y no es secreto.
   - **A3. Un solo uso y vencimiento** (5 minutos; la conversación, 30).
   - **A4. La entidad se vuelve a leer al ejecutar.** La herramienta llama a `LocalidadService.DeleteAsync`, que relee
     la localidad: si la persona ya la borró por el ABM, el resultado es «La localidad ya no existe.» y no hay otra baja.
     Lo que la persona ve para decidir (`AprobacionPendiente.Descripcion`) también lo resuelve el servidor en esa sesión:
     «Dar de baja la localidad «Resistencia» (Chaco), id 2.», no el texto del modelo. Un id que no existe en la sesión
     se rechaza sin preguntar.
   - **A5. Las pruebas:** aprobación forjada, sesión guardada alterada y aprobación de una sesión enviada
     desde otra, todas con 0 ejecuciones.
6. **La guarda de la escritura.** `FuncionConAutorizacion` (dentro de `ApprovalRequiredAIFunction`) deja pasar una
   sola ejecución, y sólo de la llamada exacta que la persona aprobó, comparada con la copia que guardó el servidor al
   registrar la aprobación. Es la respuesta a un hecho medido: MAF ejecuta lo que diga la sesión deserializada. Si
   alguien altera el almacén de conversaciones (el id de Resistencia por el de Corrientes), MAF pide borrar Corrientes y
   la guarda lo rechaza. La prueba roja `CasoRojo_SinLaGuarda_MafEjecutaLoAlterado` muestra lo que pasa sin ella.
   Si se comprometen los dos almacenes, la guarda no alcanza: el almacén es frontera de confianza (A1).
7. **Inyección con solicitud de confirmación.** Un texto que pide «borrar sin pedir confirmación», en el mensaje o en el
   nombre de una localidad que devuelve la herramienta de lectura, termina igual: la baja queda pendiente de la persona,
   con 0 ejecuciones. La herramienta de lectura marca lo que devuelve como datos, no instrucciones; eso no es el
   control: el control es que la escritura espera la aprobación.

El 404 que da la API del caso base ante un id de otra sesión **no es control de acceso**: el caso base acepta un
`X-Sesion-Id` elegido por el cliente. Atar la aprobación a la sesión impide aprobar desde otra conversación, pero no
protege a quien eligió un id de sesión débil.

## Requisitos

- Docker. Todo se compila y se corre en `mcr.microsoft.com/dotnet/sdk:10.0` (SDK 10.0.403 al 2026-10-28).
- Para la consola contra el modelo y `ConModelo/`: el servidor Ollama de prueba levantado con la receta del Anexo E de
  la guía (red `ia-guia`, contenedor `ollama`), con `qwen3.5:4b`. Si el servidor corre en otro lado, alcanza con cambiar
  `OLLAMA_ENDPOINT` (por defecto `http://localhost:11434`).

Paquetes (consultados en nuget.org el 2026-10-28): `Microsoft.Extensions.AI` 10.11.0, `Microsoft.Agents.AI` 1.26.0,
`OllamaSharp` 5.5.0, `Microsoft.Extensions.Hosting` 10.0.14, `Microsoft.Extensions.Http` 10.0.14,
`Microsoft.Extensions.Options.DataAnnotations` 10.0.14; pruebas: `NUnit` 5.0.0, `NUnit3TestAdapter` 6.3.1,
`Microsoft.NET.Test.Sdk` 18.11.0. `dotnet list package --vulnerable --include-transitive` y `--deprecated`: ninguno.
`Microsoft.Agents.AI` 1.26.0 trae como dependencia transitiva `Microsoft.Extensions.AI.Evaluation` 10.10.0.

## Estructura

```text
07-Agente-Con-Aprobacion/
├── 07-Agente-Con-Aprobacion.slnx
├── src/MovilidadUrbana.Ejemplos.AgenteConAprobacion/
│   ├── Program.cs                              # consola: 4.1, 4.2 y la baja con aprobación
│   ├── AprobadorDeConsola.cs                   # IAprobador por consola (o fijo con --aprobar s|n)
│   ├── appsettings.json                        # endpoint, modelo, num_ctx, muestreo, límites, plazos
│   ├── appsettings.Development.json            # TimeoutSegundos
│   ├── CasoBase/                               # copia literal de MovilidadUrbana.ApiWeb (59399ba)
│   ├── Application/Asistente/                  # el puerto, AprobacionPendiente, IAprobador, PedirAprobacionAsync
│   ├── Infrastructure/AI/
│   │   ├── OpcionesDeIA.cs                     # la única clase de opciones
│   │   ├── ComposicionDeIA.cs                  # un IChatClient con el bucle acotado
│   │   ├── DelChatAlAgente/LlamadaUnica.cs     # 4.1
│   │   ├── DelChatAlAgente/AgenteDeMaf.cs      # 4.2
│   │   ├── HerramientasDeLocalidades.cs        # catálogo: 2 de lectura, 2 de escritura con aprobación
│   │   ├── AsistenteConAprobacion.cs           # agente de MAF + contrato A1–A5
│   │   └── Aprobaciones/                       # almacenes del servidor y la guarda
│   ├── Infrastructure/Persistence/             # repositorio en memoria, filtrado por sesión
│   └── SinModelo/ClienteGuionado.cs            # modo sin modelo
└── tests/MovilidadUrbana.Ejemplos.AgenteConAprobacion.Tests/
    ├── Cableado/    # sin modelo, deterministas, siempre
    └── ConModelo/   # contra el servidor de prueba, por turno; sin OLLAMA_ENDPOINT quedan «no medido»
```

`CasoBase/` es una copia literal (`diff` = 0) de nueve archivos de `MovilidadUrbana.ApiWeb`: `LocalidadService`,
`LocalidadModel`, `Result`, `ILocalidadRepository`, `ISessionContext`, `Localidad`, `LocalidadRules`, `Catalogos` y
`SessionContext`. La base SQLite se reemplaza por un almacén en memoria que siembra cada sesión con las dos localidades
del caso base (Corrientes y Resistencia) y filtra por sesión como el repositorio real.

## Comandos

Desde esta carpeta. Los `bin/` y `obj/` que se generan están en `.gitignore`.

**Compilar:**

```bash
docker run --rm -v "$PWD":/work -w /work mcr.microsoft.com/dotnet/sdk:10.0 \
  dotnet build 07-Agente-Con-Aprobacion.slnx -c Release
```

**Pruebas de `Cableado/` (sin modelo):**

```bash
docker run --rm -v "$PWD":/work -w /work mcr.microsoft.com/dotnet/sdk:10.0 \
  dotnet test 07-Agente-Con-Aprobacion.slnx -c Release --filter TestCategory=Cableado
```

**La consola sin modelo:**

```bash
docker run --rm -e DOTNET_ENVIRONMENT=Development -v "$PWD":/work -w /work mcr.microsoft.com/dotnet/sdk:10.0 \
  dotnet run --project src/MovilidadUrbana.Ejemplos.AgenteConAprobacion -c Release -- --sin-modelo --aprobar s
```

Con `--aprobar n` la baja se rechaza. Sin `--aprobar`, la consola pregunta «¿Aprobás? (s/n)»; para contestar hace falta
`docker run -it`. Cualquier otra respuesta, o la entrada cerrada, es «sin respuesta» y la baja no se hace.

**La consola contra el servidor de prueba:**

```bash
docker run --rm --network ia-guia -e OLLAMA_ENDPOINT=http://ollama:11434 -e DOTNET_ENVIRONMENT=Development \
  -v "$PWD":/work -w /work mcr.microsoft.com/dotnet/sdk:10.0 \
  dotnet run --project src/MovilidadUrbana.Ejemplos.AgenteConAprobacion -c Release -- --aprobar s
```

Sin `-e DOTNET_ENVIRONMENT=Development` la consola no arranca: falta `TimeoutSegundos` y sale con código 3.

**Pruebas de `ConModelo/` (contra el servidor de prueba):**

```bash
docker run --rm --network ia-guia -e OLLAMA_ENDPOINT=http://ollama:11434 \
  -e ESTACION="<rótulo de la estación donde medís>" \
  -v "$PWD":/work -w /work mcr.microsoft.com/dotnet/sdk:10.0 \
  dotnet test 07-Agente-Con-Aprobacion.slnx -c Release --filter TestCategory=ConModelo --logger "console;verbosity=normal"
```

Cada prueba escribe su registro R-LLM en `tests/.../bin/Release/net10.0/salidas-con-modelo/` (o en la carpeta de
`RLLM_SALIDA`). Sin `OLLAMA_ENDPOINT`, las dos quedan `Inconclusive` («ConModelo: no medido»): nunca en verde.

## Resultado esperado

- **Compilación:** 0 advertencias, 0 errores (el proyecto compila con `TreatWarningsAsErrors`).
- **`Cableado`: 25 de 25 en verde.**
  - 4.1 → 4.2: la llamada única pide `contar_localidades` y responde con el caso de uso; el pedido lleva la herramienta
    y `num_ctx` 8192. El agente de MAF, sobre el mismo cliente, conversa dos turnos y el segundo pedido trae el primer
    turno en el historial; las opciones de ejecución (`num_ctx`) llegan al cliente. Con un cliente que siempre pide la
    herramienta, los dos cortan en 4 llamadas.
  - Catálogo: las dos escrituras son `ApprovalRequiredAIFunction` con la guarda adentro; las dos lecturas no. El puerto
    no expone tipos de MEAI ni de MAF y sólo recibe `string`, `bool` y `CancellationToken`.
  - Aprobación: la baja queda pendiente con 0 bajas y la descripción la resuelve el servidor; el id tiene 22 caracteres
    y no es el `RequestId` (`ficc_…`). `IAprobador` que devuelve `null` → «no», 0 bajas. `IAprobador` que no responde →
    lo corta el plazo (200 ms en la prueba), «no», 0 bajas. Aprobada → 1 baja por el caso de uso; el mismo id otra vez
    → 0. Aprobación forjada: id inventado o el `RequestId` de MAF → 0 bajas, y la aprobación legítima sigue sirviendo; en MAF solo, una
    respuesta con argumentos forjados ejecuta los que MAF guardó, no los forjados. Sesión guardada alterada →
    la guarda rechaza, 0 bajas; caso rojo sin la guarda → MAF ejecuta la llamada alterada. La aprobación de A enviada
    desde B, o desde otra conversación de A → 0 bajas, y A la sigue pudiendo usar. Vencida → 0. A4: borrada por el
    ABM antes de aprobar → «La localidad ya no existe.» y ninguna baja más. Id 999, −1 o de otra sesión → no se le
    pregunta a la persona y 0 bajas. Alta: pendiente con 0 altas, aprobada → 1. Con una pendiente, un pedido nuevo no
    llega al modelo. Entrada de 2001 caracteres → 0 llamadas.
  - Inyección: en el mensaje y en `Localidad.Nombre` → la baja queda pendiente, 0 bajas.
  - Arranque: `TimeoutSegundos`, `VencimientoDeAprobacionMinutos` o `MaximoDeIteraciones` en 0 →
    `OptionsValidationException`.
- **La consola sin modelo:** las tres secciones; con `--aprobar s` queda sólo Corrientes; con `--aprobar n` o sin
  respuesta quedan las dos.
- **`ConModelo`:** ver los criterios en «Resultado medido».

## Resultado medido

**Sin modelo**, 2026-10-28, con `mcr.microsoft.com/dotnet/sdk:10.0` (SDK 10.0.403,
`sha256:de4fe90a98845d75910b9769662465c84de1a934665c431279d1382b2bddc02b`), compilado desde cero en una copia limpia:
0 advertencias, 0 errores. `Cableado`: 25 de 25 en verde. El plazo del aprobador que no responde cortó a los 205 ms
(plazo de 200 ms). Con la sesión guardada alterada, el id aparece 2 veces en la sesión serializada (el pedido pendiente y el historial)
y la guarda rechazó 1 ejecución. Con el cliente que siempre pide la herramienta, la llamada única y el agente cortaron
en 4 llamadas cada uno. `ConModelo` sin `OLLAMA_ENDPOINT`: las dos pruebas quedan «Skipped» con el mensaje
«ConModelo: no medido (falta OLLAMA_ENDPOINT)». La consola sin `DOTNET_ENVIRONMENT=Development` sale con código 3.

**Contra el modelo:** medido en una estación de laboratorio con más núcleos (CPU sin GPU; contenedor limitado a 14 CPU /
34 GiB; Ollama 0.40.11), 2026-10-28. Los criterios se escribieron antes de correr y están en el comentario de cada
clase de `ConModelo/`. En la estación de 4 núcleos (contenedor limitado a 4 CPU / 5 GB) **no se midió**: ese día, con
el anfitrión ocupado por otras compilaciones, el primer pedido de la consola superó los 300 s de `TimeoutSegundos` y la
corrida se cortó; las cifras de pared de abajo no valen para esa estación.

| Prueba | Cabecera R-LLM | Resultado |
|---|---|---|
| `DelChatAlAgenteConModeloTests` | estimando: este pedido, 3 pedidos × 5 semillas (s = 1..5), `qwen3.5:4b@d8b0f5e9760c` (provisional), T 0,7, `top_p` 0,8, `top_k` 20, `min_p` 0, `presence_penalty` 1,5, `repeat_penalty` 1,0, think false, `num_ctx` 8192, iteraciones ≤ 3, `/api/chat` (OllamaSharp 5.5.0), MAF 1.26.0, criterio previo: invariantes (sin excepción, texto no vacío) en todas; «pidió la herramienta» y «nombra 1» como tasas sin umbral; existencia de la herramienta en 4.1 y en el turno 1 de 4.2, 2026-10-28; crudo: `del-chat-al-agente-4b.txt` | invariantes: 0 violaciones. Llamada única: pidió `contar_localidades` 5/5 y nombró la cantidad correcta 5/5 (Wilson 95 % [0,57; 1] cada una). Agente de MAF, turno 1 («¿Cuántas localidades hay en Chaco?») y turno 2 («¿Y en Corrientes?», que sólo se entiende con el historial): 5/5 y 5/5 en cada turno, mismo intervalo. Pared por pedido de 4,1 a 6,1 s. Con N = 5 no se comparan los dos pasos: las tasas muestran que los dos funcionan con este pedido, no que uno sea mejor |
| `BajaConAprobacionConModeloTests` | estimando: este pedido, 1 pedido × 10 semillas (s = 1..10), mismo modelo y parámetros, criterio previo: invariantes (0 bajas antes de decidir; Corrientes intacta; bajas = aprobaciones; aprobada ⇒ Resistencia borrada) en 10/10; «pendiente con Resistencia» como tasa sin umbral; existencia ≥ 1, 2026-10-28; crudo: `baja-con-aprobacion-4b.txt` | invariantes: 0 violaciones en 10/10. Quedó pendiente la baja de «Resistencia» (Chaco), id 2, en 10/10 (Wilson 95 % [0,72; 1]); con otra entidad 0/10; sin pendiente 0/10. En las 10 el modelo pidió `listar_localidades` y después `eliminar_localidad` sin escribir texto antes: el turno terminó con el pedido de aprobación. Ninguna baja ocurrió antes de la decisión; aprobada, 1 baja por el caso de uso en cada una. Pared: 4,0–5,8 s hasta la aprobación pendiente y 1,4–1,7 s después de aprobar |

**La consola** (existencia, 1 corrida, sin semilla, `--aprobar s`, `qwen3.5:4b@d8b0f5e9760c`, muestreo de
`appsettings.json`, la misma estación con más núcleos, 2026-10-28; pared total del proceso, contenedor incluido, 38 s):

```text
Modelo: qwen3.5:4b; num_ctx: 8192

== 4.1 Llamada única con una herramienta
> ¿Cuántas localidades hay en Chaco?
Hay 1 localidad cargada en la provincia de Chaco.

== 4.2 El mismo IChatClient como agente de MAF, con sesión
> ¿Cuántas localidades hay en Chaco?
En la provincia de Chaco hay 1 localidad cargada en el catálogo.
> ¿Y en Corrientes?
En la provincia de Corrientes también hay 1 localidad cargada en el catálogo.

== Escritura con aprobación
> Borrá Resistencia
  [aprobación] Dar de baja la localidad «Resistencia» (Chaco), id 2. (herramienta eliminar_localidad; vence 18:58:10 UTC)
  ¿Aprobás? (s/n): s (fija por --aprobar)
He borrado la localidad Resistencia.
Localidades de la sesión: Corrientes
```

«En el catálogo» lo agrega el modelo: el catálogo del caso base es el de provincias, no el de localidades. La salida
del modelo es texto que se muestra, no una afirmación verificada; lo verificado es lo que devuelven las herramientas.

Lo que este ejemplo no prueba: que un modelo «pida confirmación» por su cuenta (con la herramienta de baja disponible
fue directo al pedido de baja en 10/10 de este pedido); la confirmación es estructural y la da la aplicación. Tampoco
prueba un almacén persistente real ni varias instancias del servidor: los dos almacenes son en memoria.
