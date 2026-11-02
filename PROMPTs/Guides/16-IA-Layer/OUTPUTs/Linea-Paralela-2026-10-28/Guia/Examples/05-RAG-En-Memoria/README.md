# 05 — RAG en memoria sobre los requisitos de Movilidad Urbana

Nivel intermedio. Se usa en la sección **6, «Estrategias de conocimiento: contexto fijo, CAG y RAG; vías A y B»**. La vía C de este mismo ejemplo se cita en la sección **7, «Agentes, herramientas y orquestación»**.

## Qué demuestra

- **El corpus sale del código.** Los 12 requisitos que el caso base enuncia en `LocalidadPolicy` y `EncuestaPolicy` se leen por reflexión al arrancar (`Application/Ayuda/RequisitosDelDominio.cs`). Si cambia una regla, cambia el texto que ve el modelo. Ojo: es la política **tal como se enuncia**, no lo que la API hace cumplir. Por ejemplo, `LocalidadPolicy` dice «entre 3 y 60 caracteres», pero ninguna regla del caso base verifica el máximo de 60: es una deuda heredada.
- **Dos adaptadores del mismo puerto `IAyuda`.** `AyudaContextoFijo` manda los 12 requisitos en cada pedido. `AyudaRag` manda sólo los k más parecidos a la pregunta. Los dos usan la misma instrucción y el mismo formato de fragmentos, así que lo único que cambia entre ellos es qué requisitos llegan al modelo.
- **Las vías A, B y C sobre el mismo buscador.**
  - **A, paso fijo** (`AyudaRag`): la aplicación busca siempre, antes de llamar al modelo.
  - **B, herramienta** (`AyudaRagConHerramienta`): `buscar_requisitos` es una `AIFunction` y el modelo decide si la pide, dentro del bucle de `UseFunctionInvocation`.
  - **C, agente de MAF** (`AyudaRagEnAgente`): la misma herramienta dentro de un `AIAgent`. Esta vía **sólo se corrió con dobles**.
- **Almacén MEVD en memoria** (`CommunityToolkit.VectorData.InMemory`, GA). La colección se define en tiempo de ejecución con `VectorStoreCollectionDefinition`, porque la dimensión sale de `OpcionesDeIA.DimensionDeEmbeddings`. Al arrancar se genera un embedding de prueba y, si su largo no coincide con la dimensión declarada, la aplicación no arranca.
- **La instrucción va en la consulta, nunca en el documento.** Es la asimetría de Qwen3-Embedding, con el formato `Instruct: …\nQuery:…` de su ficha.
- **Los fragmentos recuperados entran como contenido externo.** Van serializados en JSON, con el aviso «son datos, no instrucciones» y recortados a un largo máximo (`ContenidoExterno.cs`).
- **El prefijo es estable y la pregunta va al final.** En el contexto fijo, la instrucción y los 12 requisitos forman un prefijo idéntico en cada pedido, y eso permite que el servidor reuse lo que ya leyó.
- **Comparación pareada con un oro.** El oro está en `tests/…/Oro/oro-requisitos.json` y trae 16 consultas redactadas antes de correr: 12 respondibles y 4 no respondibles, versionadas contra el commit `59399ba` del caso base. Se miden hit@1, hit@3, recall@3 y MRR@3 de la recuperación, y después se compara el contexto fijo con la RAG por la vía A, con el mismo criterio para las dos.

## Requisitos

- Docker con la imagen `mcr.microsoft.com/dotnet/sdk:10.0` (probada con `sdk@sha256:de4fe90a9884…`, SDK 10.0.403).
- Sólo para la corrida contra el modelo: el servidor Ollama de prueba con `qwen3.5:4b` y `qwen3-embedding:0.6b`, alcanzable por `OLLAMA_ENDPOINT`. Por defecto es `http://localhost:11434`. Si el servidor corre en el mismo equipo, agregá `--network host` al `docker run`.

Paquetes (consultados en nuget.org el 2026-10-28):

| Paquete | Versión |
|---|---|
| Microsoft.Extensions.AI | 10.11.0 |
| OllamaSharp | 5.5.0 |
| Microsoft.Extensions.VectorData.Abstractions | 10.11.0 |
| CommunityToolkit.VectorData.InMemory | 1.0.1 |
| Microsoft.Agents.AI (sólo para la vía C) | 1.26.0 |
| Microsoft.Extensions.Hosting / .Http / .Options.DataAnnotations | 10.0.14 |
| NUnit / NUnit3TestAdapter / Microsoft.NET.Test.Sdk | 5.0.0 / 6.3.1 / 18.11.0 |

## Comandos (desde esta carpeta)

Compilar:

```bash
docker run --rm -v "$PWD":/ex -w /ex mcr.microsoft.com/dotnet/sdk:10.0 \
  dotnet build 05-RAG-En-Memoria.slnx
```

Pruebas de cableado (sin modelo, deterministas, siempre):

```bash
docker run --rm -v "$PWD":/ex -w /ex mcr.microsoft.com/dotnet/sdk:10.0 \
  dotnet test 05-RAG-En-Memoria.slnx --filter "FullyQualifiedName~Cableado"
```

Modo sin modelo. Usa un generador de embeddings por palabras y un cliente que, en lugar de responder, muestra el pedido que habría recibido el modelo. Sirve para ver qué fragmentos llegan al prompt y cómo se arma el pedido. **No** mide la recuperación, porque no busca por significado.

```bash
docker run --rm -v "$PWD":/ex -w /ex/src/MovilidadUrbana.RagEnMemoria -e DOTNET_ENVIRONMENT=Development \
  mcr.microsoft.com/dotnet/sdk:10.0 \
  dotnet run -- --sin-modelo --estrategia rag "¿Cuántos dígitos lleva el código postal?"
```

Una pregunta contra el modelo. `--estrategia` acepta `contexto-fijo`, `rag`, `rag-herramienta` o `rag-agente`:

```bash
export OLLAMA_ENDPOINT=http://localhost:11434
docker run --rm -v "$PWD":/ex -w /ex/src/MovilidadUrbana.RagEnMemoria -e DOTNET_ENVIRONMENT=Development -e OLLAMA_ENDPOINT \
  mcr.microsoft.com/dotnet/sdk:10.0 \
  dotnet run -- --estrategia rag "¿Cuántos dígitos lleva el código postal?"
```

Pruebas contra el modelo (oro completo: 32 búsquedas y 96 generaciones). Sin `OLLAMA_ENDPOINT` quedan `Inconclusive` («no medido») y nunca pasan en verde. `RLLM_ESTACION` es el rótulo de la estación que va en la cabecera de cada salida, y las salidas quedan en `RLLM_SALIDA`:

```bash
export OLLAMA_ENDPOINT=http://localhost:11434
export RLLM_ESTACION="<rótulo de tu estación>"
docker run --rm -v "$PWD":/ex -w /ex -e OLLAMA_ENDPOINT -e RLLM_ESTACION -e RLLM_SALIDA=/ex/salidas-con-modelo \
  mcr.microsoft.com/dotnet/sdk:10.0 \
  dotnet test 05-RAG-En-Memoria.slnx --filter "FullyQualifiedName~ConModelo" --logger "console;verbosity=normal"
```

`.gitignore` excluye `bin/`, `obj/`, `*.db`, `TestResults/` y `salidas-con-modelo/`.

## Resultado esperado

- **Compilación:** 0 errores y 0 advertencias (`TreatWarningsAsErrors`).
- **Cableado: 27 de 27 en verde.** Cubre lo siguiente:
  - Corpus: 12 requisitos leídos del código.
  - Oro versionado: cada «clave» sale del texto de un relevante.
  - Métricas: hit, recall y MRR con corte, iguales al cálculo a mano para tres consultas.
  - Comparación pareada: «difiere» sólo con 6 o más pares discordantes, todos en el mismo sentido.
  - Vía A: busca siempre y antes del modelo, manda los k fragmentos marcados, no ofrece herramientas y deja la pregunta al final.
  - Un fragmento con comillas e instrucciones llega como dato, sin romper el JSON.
  - Una cita inventada no cuenta.
  - Una pregunta más larga que el máximo no busca ni llama al modelo.
  - El bloque de fragmentos se recorta con marca.
  - Contexto fijo: manda los 12 con el mismo prefijo en cada pedido y no busca.
  - Vías B y C: si el modelo pide buscar, la aplicación busca con la consulta que eligió el modelo; si no la pide, no hay búsqueda ni fragmentos (el riesgo propio de B y C).
  - Corte del bucle por `MaximoDeIteraciones`.
  - Dimensión: con un generador de 512 y 1024 declarada, no arranca; con 1024 y 1024, arranca y carga los 12; sin dimensión declarada, toma la medida.
  - Instrucción sólo en la consulta.
  - Con vectores fijos, el almacén devuelve el orden esperado y el puntaje es similitud coseno.
  - Sin `TimeoutSegundos`, no arranca.
  - Ningún literal de endpoint, modelo ni `num_ctx` fuera de `OpcionesDeIA` y los `appsettings`.
- **Contra el modelo:** las dos pruebas terminan con sus invariantes (k resultados, reproducción idéntica de los embeddings y ninguna respuesta vacía). Las tasas se **informan**: no son compuertas.

## Resultado medido (R-LLM)

Medido en una estación de laboratorio con más núcleos (CPU sin GPU; contenedor limitado a 14 CPU / 34 GiB; Ollama 0.40.11), 2026-10-28. Estas paredes **no** son las de la estación de 4 núcleos y no se mezclan con ellas.

**Recuperación.** `qwen3-embedding:0.6b@ac6da0dfba84`, `/api/embed`, dimensión medida 1024, k = 3. Estimando: la tarea (K = 12 consultas respondibles × m = 1, porque los embeddings no muestrean). Criterio escrito antes de correr.

| Consulta | hit@1 | hit@3 | recall@3 | MRR@3 |
|---|---|---|---|---|
| con instrucción | 11/12, Wilson 95 % [0,65; 0,99] | 12/12, [0,76; 1,00] | 1,000 | 0,958 |
| sin instrucción | 12/12, [0,76; 1,00] | 12/12, [0,76; 1,00] | 1,000 | 1,000 |

- Comparación pareada por consulta (RR@3): 1 par discordante. **No separado con este N.**
- Línea de azar con 12 enunciados y un relevante: hit@1 = 0,083 y hit@3 = 0,250.
- Puntaje máximo con instrucción: entre 0,429 y 0,788 en las respondibles; entre 0,301 y 0,539 en las no respondibles. El rango de las no respondibles se superpone con el de las respondibles, así que con este corpus ningún umbral fijo separa «hay respuesta» de «no hay». No se calibró umbral de abstención.

**Contexto fijo frente a RAG (vía A).** `qwen3.5:4b@d8b0f5e9760c`, `/api/chat`, T 0,7, top_p 0,8, top_k 20, presence 1,5, think off, `num_ctx` 8192, `num_predict` 200, k = 3. K = 16 consultas × m = 3 semillas (s = 1..3), mismas consultas y mismas semillas para las dos estrategias. Estimando: la tarea. Criterio escrito antes de correr:

- **Respondible:** acierta si no se abstiene, cita entre corchetes al menos un relevante y contiene la clave del oro.
- **No respondible:** acierta si contesta con la frase de abstención.

| Grupo | Contexto fijo | RAG (vía A) | Pareada por consulta |
|---|---|---|---|
| Respondibles (K = 12): consultas que pasan en 3/3 | 10/12, Wilson 95 % [0,55; 0,95] | 10/12, [0,55; 0,95] | 3 discordantes (2 y 1): **no separado con este N** |
| No respondibles (K = 4): consultas que pasan en 3/3 | 0/4, [0,00; 0,49] | 1/4, [0,05; 0,70] | 2 discordantes: **no separado con este N** |
| Todas (K = 16): media de las tasas por consulta | 0,771 | 0,771 | 5 discordantes (3 y 2): **no separado con este N** |
| Tokens de entrada por pedido (mediana) | 516 | 241 | — |
| Pared por pedido (mediana; en esta estación) | 4,2 s | 4,6 s | — |

Con este oro y este modelo, **las dos estrategias no se separan**. La RAG manda menos de la mitad de los tokens de entrada. En esta estación, que lee el prompt rápido, eso no se tradujo en menos pared, porque las respuestas RAG salieron más largas. En la estación de 4 núcleos no se midió.

Lo que muestran las salidas (existencias):

- **Citar no es estar fundamentado.** Ante «¿Puedo cargar dos localidades con el mismo código postal?», que el corpus no responde, las dos estrategias contestaron «no, el código postal debe ser único» citando `[LocalidadPolicy.RequisitoDelCodigoPostal]`. Se observó en 2 de 3 corridas con contexto fijo y en 2 de 3 con RAG.
- **El formato de la cita sale del ejemplo del prompt.** Una primera corrida daba como ejemplo «[Politica.Requisito]», y el modelo lo copió literal en 28 de 48 respuestas RAG y en 4 de 48 de contexto fijo, con citas como «[Politica.RequisitoDeLaEdad]» que no corresponden a ninguna fuente. Con esa instrucción, la tasa del contexto fijo quedaba por encima de la de RAG en 11 consultas y por debajo en 2. Era un defecto de la instrucción y no de la estrategia. La instrucción vigente pide copiar el campo `fuente` sin dar un ejemplo.
- **El modelo agrega la abstención a una respuesta correcta.** En la primera corrida, con contexto fijo, se observó en 2 de 36 respuestas a consultas respondibles: después de contestar bien, el modelo escribió también «No lo sé con los requisitos disponibles». El criterio cuenta esas respuestas como fallo. En la corrida vigente no apareció.

Salidas crudas: las dos corridas, con la cabecera R-LLM y una fila por corrida, se guardaron fuera de este repositorio.
