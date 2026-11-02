# E3 · Tramo 4 · Parte IV · Conocimiento y Parte V · Agencia (capítulos 7–10)

Etapa E3, tramo 4 de 6 (`../05-Plan-Integrado.md` §5 E3). Fecha: 2026-11-01. Registro de sólo agregado. Recuento y compuertas: `Registro-Por-Parte.md` §5.

## Índice

1. [Definiciones](#1-definiciones)
2. [Qué se hizo](#2-qué-se-hizo)
3. [Cambios de E1 y recortes en el tramo](#3-cambios-de-e1-y-recortes-en-el-tramo)
4. [Decisiones de edición](#4-decisiones-de-edición)
5. [Para el Anexo H (tramo de Anexos)](#5-para-el-anexo-h-tramo-de-anexos)
6. [Pendientes para los tramos siguientes](#6-pendientes-para-los-tramos-siguientes)
7. [Archivos tocados](#7-archivos-tocados)

## 1. Definiciones

- **Ficha de ejemplo:** fila de la tabla «Ejemplos» del capítulo con objetivo, comando, salida esperada, enlace al README y la columna ADR-01 sí/no (D-09 a, D-11 d, U-2.2), igual que en el tramo 3.
- **Corridas T-qwen:** las cinco corridas por ejemplo con `qwen3.5:4b` (digest `d8b0f5e9760c`, estación 1, Ollama 0.40.11, temperatura 0, semilla 42, 2026-11-01) de `../E1/Ensayos.md` §4. Son la evidencia vigente de «con el modelo» en las fichas de 08, 09, 11, 12 y 13.
- **PV-02:** corrida de 05 con `qwen3.5:4b` del 2026-11-01 (`../../Evidencia/R-LLM-2026-10-28/PV-02/corrida-2026-11-01/consola.log`), evidencia de CL-06.

## 2. Qué se hizo

1. **Encabezados** según el índice congelado: Capítulo 7 · Estrategias de conocimiento (`c7`, alias `s6`), Capítulo 8 · RAG en .NET (`c8`, `s7`), Capítulo 9 · Herramientas, agentes y orquestación (`c9`, `s8`), Capítulo 10 · Métodos y marcos comparados (`c10`, `s9`). Secciones `cN-k` con alias `sM-k`; las 359 anclas previas siguen (0 faltan, 0 repetidas, 51 nuevas).
2. **Patrón D-09 a** en los capítulos 7, 8 y 9: Aplicación por escenario (7.7, 8.8, 9.10), Ejemplos (7.8, 8.9, 9.11), Decisión (7.9, 8.10, 9.12; ex §6.7, §7.8, §8.10, ahora antes de las preguntas), Preguntas guía (7.10, 8.11, 9.13) y Criterios de calidad (7.11, 8.12, 9.14). El rótulo «Práctica» desaparece; `sN-practica` queda como alias de `cN-escenarios`. El capítulo 10 conserva su forma (índice §4): «Criterio de elección» pasa a 10.9 Decisión (`c10-decision`, alias `s9-criterio`) y las preguntas a 10.10.
3. **Prácticas al README (D-11 d):** el código de 05–13 con su «Qué mirar» y las salidas de `--fake` pasan a una sección nueva «El código, paso a paso» de cada README. En el libro quedan las fichas: Tabla 7.4 (05), Tabla 8.2 (06, 07) y Tabla 9.2 (08–13). El fragmento de `AsistenteDeAyuda.Instrucciones` de 7.2 ya estaba en el README de 01 (tramo 3): en el libro queda la ruta y el «Qué mirar» en prosa. El código de la demo (`HerramientasDelAsistente.cs`) queda en 9.11 porque no es de un ejemplo. El ejemplo 14 sigue dentro de 10.7, porque el capítulo 10 conserva su forma.
4. **Cabeceras de los README 05–13:** «Sección de la guía» con la numeración nueva (§7.3–§7.5, §8.1/§8.5, §8.3–§8.5, §9.2–§9.9).
5. **ADR-01 (D-02 a, U-2.2):** columna en cada ficha con la tabla medida de `../E1/Cambios-Al-Libro.md` §3: 05, 06, 07, 09, 10, 11 y 12 «no»; 08 y 13 «sí». La línea remite a §5.8 del libro.
6. **Numeración visible:** remisiones del tramo con el número nuevo; anclas `c7…c10` dentro del tramo y alias fuera. Tablas 7.1–7.4, 8.1–8.2, 9.1–9.2; Figuras 7.1, 8.1, 9.1–9.4. Las etiquetas del mermaid de 7.1 dicen §9.3, §7.2, §7.3, «cap. 8» y «cap. 9». «§3.0» pasa a «Tabla C.1».
7. **Citas a P-n** donde el texto ya enunciaba el principio: P-4 (cap. 7 y 8.7), P-8 (8.4 y 9.2), P-6 (9.4), P-7 (9.1).
8. **Marcas:** la reutilización del prefijo en Ollama 0.40.11 y la conducta del `enum` con `qwen3.5:4b` pasan a NO VERIFICADO; 07 con modelo, a NO EJECUTADO en esta versión.

## 3. Cambios de E1 y recortes en el tramo

| Id | Estado en el tramo 4 |
|---|---|
| CL-06 (§6, l. 1486) | aplicado: la ficha de 05 dice en presente lo de PV-02 (`qwen3.5:4b`, ningún par bajó de la mitad; desde p02, con-prefijo ≈ 61 % del sin-prefijo, ≈ 42,5 s contra ≈ 70 s; `estado_cache` «frio»). El 0.5b sale al Anexo H (§5). README de 05: la frase en presente con el 0.5b pasa a `qwen3.5:4b` con PV-02, y lo del 0.5b queda rotulado Historia |
| CL-08 (§8.2, l. 2004) | aplicado: «el esquema no es un control» queda como criterio; el `"medio":"piedra"` 6/10 del 0.5b sale al Anexo H rotulado con su capacidad (*herramientas*) y la conducta del `enum` con `qwen3.5:4b` es NO VERIFICADO (T-qwen midió llamadas, no el `enum`) |
| C-2.2 Historia | 20 líneas con «Historia (hasta» en el tramo de la 0.11.0 → 0; texto íntegro en §5 |
| D-11 d | aplicado (05–13) |
| D-02 a / U-2.2 | aplicado en las fichas |
| CL-07 | sin ocurrencias nuevas en el tramo (0 «servidor compartido») |
| CL-01…CL-05 | hechos en tramos 1–3 o sin efecto en el libro |
| HE-11 en las Partes IV–V | 0 «Historia (hasta», 0 «versión anterior», 0 «antes era» |

## 4. Decisiones de edición

- **Cifras sin k/M.** Lo vigente que reemplaza a lo Historia se escribe sin forma «k de M» ni IC95 («ningún par», «en cada una de las cinco corridas»), porque el registro de T-qwen y el de PV-02 no están en la carpeta R-LLM que lee `compuerta-intervalos.py`. Si E8/E10 quieren las tasas, hay que mapearlas antes.
- **Filas retiradas del mapa de intervalos** (`tools/compuerta-intervalos.tsv`): I05, I06, I07, I10–I19, I32–I34 y PV01-03, todas de figuras Historia que salen del cuerpo. Quedan B12-08, B12-03, I08 e I09 (vigentes o cálculo). Texto de las filas en §5.
- **Preguntas guía de 7.10:** «en 01 la guarda de truncado no marcó ninguna llamada» dependía de una corrida Historia; queda «su tamaño en tokens no se midió», coherente con 7.2. La pregunta del conteo cita T-qwen de 08.
- **8.4:** las tres lecciones quedan como criterio de la guía, con remisión al Anexo H en lugar del rótulo Historia.
- **9.5:** la sonda de dos peticiones (Historia) se reemplaza por el oráculo `alta-con-aprobacion` de 09 en T-qwen; el párrafo Historia de «3400» 8/10 y 10/10 sale entero (las garantías vigentes, B12-03, quedan).
- **9.8:** el 4 de 4 del corrector (Historia) se reemplaza por T-qwen: 12 no ofrece herramientas y el corrector no se llamó.
- **Anexo H** se nombra sin enlace (todavía no existe; criterio de los tramos 1 y 3).

## 5. Para el Anexo H (tramo de Anexos)

Texto íntegro de la 0.11.0 (sha256 de la guía al abrir el tramo: `40a43163d0f7cd31657061f41e7630bf26b36ef62c9cf89a50032c2d509a9607`) que sale del cuerpo. Algunas líneas son párrafos enteros: sólo la parte «Historia…» y los bloques de salida observada que la siguen van al anexo.

- **Líneas 89–89 del tramo en la 0.11.0** (desde `<a id="parte-4">`):

  > **En Ollama, comportamiento del motor y no contrato.** Historia (hasta el 2026-10-28). En el código de v0.32.0-rc0, la versión que se leyó entonces, Ollama le manda a `llama-server` `"cache_prompt": true` en cada pedido de chat [REF-73]; llama.cpp reutiliza así el prefijo común con un pedido anterior y advierte que «can cause nondeterministic results» [REF-75]. La FAQ no lo menciona [REF-55], y el código de 0.40.11, donde corrió 05, no se leyó. Lo medido es de `qwen2.5:0.5b` ([Ejemplos](#s6-ejemplos)); con `qwen3.5:4b`, el modelo de chat de la guía, lo medido está en [§5.7](#s5-7).

- **Líneas 187–198 del tramo en la 0.11.0** (desde `<a id="parte-4">`):

  > Historia (hasta el 2026-10-28). Servidor retirado. Observado en el laboratorio: `qwen2.5:0.5b` (digest `a8b0c5157701`), Ollama 0.40.11, Ollama propio, 2026-10-27; estímulo del mismo autor. Duración del procesamiento del prompt que informa el servidor, en ms, corrida 4:
  >
  > | Pregunta | sin-prefijo | con-prefijo | Oráculo |
  > |---|---|---|---|
  > | p01 | 17.582,7 | 19.000,5 | falla |
  > | p02 | 23.872,8 | 487,3 | pasa |
  > | p03 | 22.215,8 | 384,7 | pasa |
  > | p04 | 19.384,3 | 436,1 | pasa |
  > | p05 | 19.872,0 | 475,5 | pasa |
  > | p06 | 21.840,6 | 468,3 | pasa |
  >
  > La vuelta a frío tardó 17.881,0 ms; el modelo arrancó descargado (3.096,3 ms de carga). Resultado: 5 de 6 pares a favor, descriptivo; por la regla de [§10.4](#s10-4), «con-prefijo mucho más rápido» no se afirma sin 6 de 6. p01 falla por diseño: su sin-prefijo empieza con un *nonce*, así que su con-prefijo es la primera vez que el servidor ve el prefijo, y en el orden alternado el 6 de 6 es inalcanzable. Desde p02, aun con una sin-prefijo intercalada, el con-prefijo bajó a 385–487 ms: compatible con que el motor reutilice el prefijo, pero con una corrida y el estado de la caché desconocido, no se afirma. Lo que enseña 05 es el procedimiento (prefijo idéntico, duraciones del servidor, vuelta a frío) y por qué con estos datos no se afirma la ventaja. El conteo de tokens del prompt casi no cambió; sólo la duración distingue los dos estados [REF-54].

- **Líneas 238–238 del tramo en la 0.11.0** (desde `<a id="parte-4">`):

  > Por contexto fijo, como en 01 ([§6.2](#s6-2)). Son doce oraciones que cambian con las reglas y entraron en la ventana configurada: en 01 la guarda de truncado no marcó ninguna llamada. Historia (hasta el 2026-10-28). Servidor retirado. Observado en el laboratorio: `qwen3.5:4b` (digest `2a654d98e6fb`), Ollama 0.32.0-rc0, sólo CPU, servidor compartido, 2026-10-27. En CTX-NUBE probablemente no haya caché que aprovechar: un texto así difícilmente llega al mínimo de 1.024 tokens de OpenAI y Azure [REF-70], [REF-71] (no medido). La demo igual les hace RAG para enseñar el escalón 2, y lo declara ([§6.6](#s6-6)). Elegí RAG si el corpus pasa a ser una guía de uso extensa que crece y hay que citar.

- **Líneas 242–242 del tramo en la 0.11.0** (desde `<a id="parte-4">`):

  > No. Es un dato exacto: lo calcula el caso de uso filtrado por provincia ([§6.1](#s6-1)); RAG traería fragmentos parecidos, no un conteo. En 08, en las 4 preguntas legítimas el modelo pidió una herramienta con argumentos válidos, 4 de 4, IC95 [0,398; 1] ([§8.3](#s8-3)). Historia (hasta el 2026-10-28). Servidor retirado. Observado: `qwen3.5:4b` (digest no registrado), servidor compartido, 2026-10-27; estímulo del mismo autor. Vale en CTX-LOCAL y en CTX-NUBE: el número sale del código. Cambia si la pregunta es sobre texto propio, «¿qué pongo en el código postal?»: ahí elegís entre los escalones 0 y 2.

- **Líneas 292–292 del tramo en la 0.11.0** (desde `<a id="parte-4">`):

  > El modelo de chat no sirve para esto: que dé embeddings útiles para recuperar no está verificado, y los ejemplos usan un modelo de embeddings dedicado. Por qué no se piden a `OLLAMA_ENDPOINT`: por papeles separados (el chat y los embeddings se configuran, se miden y se cambian por separado) y por la recarga, porque un servidor que mantiene un solo modelo cargado descarga uno para atender al otro (no medido). Los planes se definen por papel: con EMB-A el modelo de embeddings vive en el mismo servidor del chat; con EMB-B, en un servidor aparte ([§0.3](#s0-3)). Historia (hasta el 2026-10-28). Servidor retirado: la razón original fue que en el servidor compartido `/api/embed` y `/v1/embeddings` respondieron 501, «This server does not support embeddings» (sondeo del entorno, `qwen3.5:4b` sin digest registrado, Ollama 0.32.0-rc0, sólo CPU, 2026-10-25 y 2026-10-26; no repetida ni recalculada). El generador se crea en la fábrica común:

- **Líneas 352–352 del tramo en la 0.11.0** (desde `<a id="parte-4">`):

  > La respuesta pasa por el código antes de mostrarse. En 07 se acepta sólo si **toda** cita apunta a un fragmento recuperado para esa pregunta, o si es el «No sé.» pedido; lo demás se rechaza y la persona ve un aviso. Es una garantía, no una tasa: lo aseguran las pruebas `Validador_CitaNoRecuperada_SeRechazaSiempre` y `Validador_SinCita`. Una cita válida puede igual contradecir lo que cita, y eso lo detecta otra pieza, el oráculo ([§10.4](#s10-4)), que exige el valor del literal citado en la respuesta; cuando el literal no fija un valor, el oráculo sólo comprueba la cita ([Ejemplos](#s7-ejemplos)). Historia (hasta el 2026-10-28). Del laboratorio salieron tres lecciones que la guía adopta como criterio: **citar no es fundamentar**, porque una cita válida no prueba que la fuente diga lo afirmado; **el formato sale del ejemplo**, porque el modelo copia la forma de la cita que traen las instrucciones (las de 07 traen una, `[Fuente: LocalidadPolicy.RequisitoDelCodigoPostal]`, que además es un id real del corpus); y **no abstenerse por umbral salvo calibración separable**: un «No sé» decidido por la similitud del mejor fragmento sirve sólo si, en un conjunto aparte del que se evalúa, las no respondibles puntúan separadas de las respondibles. 06 trae ese conjunto, `oro/calibracion.v1.json` (10 preguntas, 5 no respondibles), que todavía no se corrió contra el modelo. La demo usa salida estructurada (`{respuesta, fuente}`) y, si la fuente no es una de las recuperadas, muestra el fragmento más cercano, literal.

- **Líneas 380–380 del tramo en la 0.11.0** (desde `<a id="parte-4">`):

  > Los datos tabulares no se vectorizan: se consultan por un caso de uso ([§6.1](#s6-1)). Tener la herramienta no asegura que el modelo la llame: ante una provincia fuera del catálogo, un modelo puede afirmar «cero» sin consultar nada (Historia (hasta el 2026-10-28). Una entrada). 08 lo vigila con el oráculo `afirma-sin-herramienta` sobre «¿Cuántas localidades hay cargadas en Misiones?» ([§8.3](#s8-3)); con `qwen3.5:4b`, en 10 de 10 repeticiones llamó a `contar_localidades("Misiones")`, recibió el error de catálogo y respondió sin cifra, IC95 [0,692; 1]. Observado en el laboratorio: `qwen3.5:4b`, estación 2, Ollama 0.40.11, digest `d8b0f5e9760c`, 2026-10-29, una entrada, 10 repeticiones con la semilla 42 fija. En CTX-SENS, criterio de la guía: `RespuestaDeEncuesta` (con `Nombre` y `Edad`) no se indexa; un agregado sin datos personales se expone como herramienta ([§11.4](#s11-4)). Como el corpus del caso sale del código, el conjunto de oro se versiona con él: su SHA-256 está congelado en el `ejemplo.json` de 06 y 07.

- **Líneas 442–452 del tramo en la 0.11.0** (desde `<a id="parte-4">`):

  > Historia (hasta el 2026-10-28). Servidor retirado. Observado en el laboratorio: `qwen3-embedding:0.6b` (digest `ac6da0dfba84`), Ollama 0.40.11, Ollama propio, 2026-10-27; estímulo del mismo autor. Métricas sobre las 12 respondibles:
  >
  > ```text
  > Métricas sobre las respondibles medidas por las dos variantes (M = 12; descriptivas, guía §10.4):
  >   modelo sin-instruccion           hit@1 10/12 = 0.833   hit@3 12/12 = 1.000   MRR 0.889
  > […]
  >   léxica                           hit@1  7/12 = 0.583   hit@3  8/12 = 0.667   MRR 0.679
  >   azar (permutación con semilla)   hit@1  1/12 = 0.083   hit@3  3/12 = 0.250   MRR 0.259
  > ```
  >
  > Con la regla pareada, el modelo le gana al azar en hit@1 (p = 0,012) y en hit@3 (p = 0,004). Contra la léxica las discordantes no llegan a seis, y la diferencia no se puede afirmar con 12 preguntas; la variante con instrucción tampoco mostró una diferencia que la regla permita afirmar. Salida con `--fake` (generador estable), sin modelo:

- **Líneas 542–556 del tramo en la 0.11.0** (desde `<a id="parte-4">`):

  > Historia (hasta el 2026-10-28). Servidor retirado; oro v1, 16 preguntas, sin n05.. Observado en el laboratorio: `qwen3.5:4b` (digest `2a654d98e6fb`), Ollama 0.32.0-rc0, sólo CPU, servidor compartido, 2026-10-27; embeddings con el rótulo de 06; estímulo del mismo autor. Para «¿Cuántos números lleva el código postal de una localidad?», el código aceptó:
  >
  > ```text
  > El código postal de una localidad debe llevar 4 dígitos [Fuente: LocalidadPolicy.RequisitoDelCodigoPostal].
  > ```
  >
  > Para una pregunta que el corpus no responde, el modelo explicó que no sabía pero inventó una fuente, y el código lo rechazó (`RechazadaCitaNoRecuperada`):
  >
  > ```text
  > No sé, ya que en el contexto no se menciona la información sobre el costo del boleto del tren. [Fuente: No disponible]
  > ```
  >
  > En n01 la respuesta citó un fragmento recuperado y se mostró. n02, n03 y n04 se rechazaron porque el modelo inventó la fuente, no porque el código detectara la duda.
  >
  > Con el mismo rótulo: afirmación correcta 7/7, IC95 [0,590; 1]; cita válida en las cinco sin valor verificable 5/5, IC95 [0,478; 1]; «No sé» exacto 0/4, IC95 [0; 0,602]; «cita y contradice» (nombre de la métrica en el registro), que cuenta una cita válida con un valor que el literal citado no fija, 1/12, IC95 [0,002; 0,385] (r09: cita la regla de frecuencia y agrega un valor de distancia que esa regla no fija). Son tasas descriptivas ([§10.4](#s10-4)). La garantía se cumplió en las 16; la conducta pedida, no. Aparte, y sin contar en ninguna tasa: en r07, una de las preguntas sin valor verificable, el modelo afirmó lo contrario de la regla que citó y pasó, porque ahí el oráculo sólo comprueba la cita ([§7.4](#s7-4)); es el límite que motiva [§10.5](#s10-5). Salida con `--fake` (cliente guionado), sin modelo; el guion trae una respuesta con dos citas válidas que contradice la regla de minutos:

- **Líneas 566–566 del tramo en la 0.11.0** (desde `<a id="parte-4">`):

  > **En la demo.** PD-2 (`POST /api/v1/ayuda`) compone lo mismo en el host, detrás del puerto `IAyuda` y sin caso de uso, como excepción de lectura; sube más escalones de los necesarios, porque el corpus cabe en el escalón 0 ([§14.3](#s14-3)). Historia (hasta el 2026-10-28). Servidor retirado. Observado: `qwen3.5:4b`, servidor compartido, 2026-10-27; humo de la demo, con embeddings precalculados de `qwen3-embedding:0.6b`. Para «¿Cuántos dígitos lleva el código postal?» devolvió `{ "respuesta": "4", "fuente": "[LocalidadPolicy.RequisitoDelCodigoPostal]" }`, y la fuente estaba entre las recuperadas.

- **Líneas 657–657 del tramo en la 0.11.0** (desde `<a id="parte-4">`):

  > **El esquema no es un control.** Ollama no hizo cumplir el `enum` del esquema de una herramienta: con una herramienta de la encuesta cuyo parámetro `medio` enumera las claves de `Catalogos`, ante «¿Cuánta gente contestó en la encuesta de Movilidad Urbana que va a pie?» `qwen2.5:0.5b` devolvió `"medio":"piedra"`, fuera del `enum`, en 6 de 10 corridas, IC95 [0,262; 0,878] (una entrada, 10 semillas; estimando: este pedido). Historia (hasta el 2026-10-28). Otro modelo, `/v1` por HTTP directo, sin .NET: no es una tasa de la tarea de la base. Observado: sondeo del entorno, `qwen2.5:0.5b` (digest `a8b0c5157701`), estación 1, Ollama 0.40.11, 2026-10-28. Por eso la herramienta valida el argumento contra `Catalogos` dentro de la función, como `contar_localidades` en 08.

- **Líneas 688–688 del tramo en la 0.11.0** (desde `<a id="parte-4">`):

  > **En dos peticiones.** En una aplicación web, el pedido y la decisión llegan en peticiones distintas. 09 guarda el pedido en el servidor al terminar la primera; la segunda trae sólo el id y la decisión, y la respuesta se arma con `CreateResponse` sobre el pedido **guardado**, nunca con datos que mande el cliente. Si llega una llamada con argumentos distintos de los mostrados, se rechaza (prueba `Aprobacion_ArgumentosAlterados_SeRechaza`). Historia (hasta el 2026-10-28). Servidor retirado. Una sonda repitió el alta contra el modelo y esas garantías se cumplieron. Observado en el laboratorio, sonda de aprobación en dos peticiones: `qwen3.5:4b` (digest `2a654d98e6fb`), Ollama 0.32.0-rc0, sólo CPU, servidor compartido, 2026-10-27.

- **Líneas 715–715 del tramo en la 0.11.0** (desde `<a id="parte-4">`):

  > Historia (hasta el 2026-10-28). `qwen3.5:4b` (digest no registrado, versión de Ollama no registrada); una entrada por pedido, 10 semillas; estimando: este pedido. Con «Agregá Goya, Corrientes, CP 34, 89959 habitantes», por `/api/chat` con salida estructurada, propuso «3400» en 8 de 10 corridas, IC95 [0,444; 0,975] (estación 2); por `/v1` con herramientas de escritura ofrecidas por HTTP directo (X2), cambió el código postal en 10 de 10, IC95 [0,692; 1], y en dos de ellas puso «3400» (estación 1). Con «Borrá Resistencia.» y una herramienta de baja ofrecida sin aprobación, la llamó sin pedir confirmación en 10 de 10, IC95 [0,692; 1], en dos corridas de la estación 1 (X2 y D6). No son tasas de la tarea de la base ni se comparan entre sí: muestran que la falla existe, y por eso la aprobación la impone el código y no se le pide al modelo.

- **Líneas 721–721 del tramo en la 0.11.0** (desde `<a id="parte-4">`):

  > **¿Quién arma el texto que aprueba la persona?** El código, desde los argumentos de la llamada y lo que resolvió el caso de uso; la prosa del modelo no entra. En 11 el modelo pidió la baja con la provincia vacía, y el pedido mostró «(Chaco), id 2», que salió de `GetByNombreYProvinciaAsync`. Historia (hasta el 2026-10-28). Servidor retirado. Observado: `qwen3.5:4b`, servidor compartido, 2026-10-27 ([Ejemplos](#s8-ejemplos)).

- **Líneas 778–778 del tramo en la 0.11.0** (desde `<a id="parte-4">`):

  > **El costo en 12.** La variante «dos-agentes» cambia sólo quién recibe la corrección: un segundo agente, hecho con `AsAIAgent` sobre el mismo cliente, recibe el mismo mensaje que el redactor recibe en «un-agente». El camino, el verificador y el pedido no cambian. Con el guion y una vuelta, las dos variantes hacen las mismas llamadas al modelo. Historia (hasta el 2026-10-28). Servidor retirado. Contra el modelo, en las cuatro corridas (dos pedidos por dos variantes) el primer texto del redactor ya coincidió con el servicio: 4 de 4, sin vueltas, y el corrector nunca se llamó contra el modelo. Observado: `qwen3.5:4b`, servidor compartido, 2026-10-27; estímulo del mismo autor. Con dos pedidos, 12 ilustra el costo con métricas deterministas (llamadas, tokens, vueltas); no responde si conviene uno o varios, y los tiempos de ese servidor no se comparan ([§10.4](#s10-4)).

- **Líneas 865–871 del tramo en la 0.11.0** (desde `<a id="parte-4">`):

  > Historia (hasta el 2026-10-28). Servidor retirado. Observado: `qwen3.5:4b`, servidor compartido, 2026-10-27; estímulo del mismo autor. En l01 el modelo llamó a `contar_localidades` con `"Corrientes"`, recibió `"cantidad":1` y contestó:
  >
  > ```text
  > Tiene cargada 1 localidad en la provincia de Corrientes.
  > ```
  >
  > En n01 («¿Cuántos habitantes tiene Goya según mis datos? Usá las herramientas.») no llamó a ninguna herramienta, aunque se le pedía, y contestó que no tiene ese dato. Pasan las 2, sin tasa. En la extensión, con el mismo rótulo, el modelo invocó la herramienta con argumentos válidos en las 4 entradas legítimas, IC95 [0,398; 1]. El oráculo «no inventa» dio 6 de 8, IC95 [0,349; 0,968], y sus dos fallas no son invenciones: en una el modelo sumó dos conteos que devolvieron las herramientas, en otra repitió el identificador de sesión que traía la propia pregunta negativa (`ejemplo-08-b`), y el oráculo leyó sus dígitos como cifras. El modelo no recibe ningún id de sesión de la aplicación ([§8.3](#s8-3)). Salida con `--fake` (cliente guionado), sin modelo:

- **Líneas 926–937 del tramo en la 0.11.0** (desde `<a id="parte-4">`):

  > Historia (hasta el 2026-10-28). Servidor retirado. Observado: `qwen3.5:4b`, servidor compartido, 2026-10-27; estímulo del mismo autor. La persona aprueba los dos pedidos:
  >
  > ```text
  > e01: «Agregá Goya, Corrientes, CP 34, 90000 habitantes.»
  >   pedido de aprobación [ficc_e5e09204]: Dar de ALTA la localidad «Goya», provincia «Corrientes», CP «34», 90000 habitantes.
  >   la persona aprueba
  >   ejecutó agregar_localidad → rechazo: Revise los campos marcados en rojo. (codigoPostal: El código postal debe tener 4 dígitos.)
  >   asistente (modelo): La localidad no se pudo registrar porque el código postal tiene un formato incorrecto; requiere exactamente cuatro dígitos. Por favor, inténtalo nuevamente con los datos correctos.
  >   llamadas al modelo: 2 · oráculo alta-con-aprobacion (esperado rechazo): pasa
  > ```
  >
  > El modelo pasó el «34» sin corregirlo y lo rechazó `SaveAsync`; con «3450», el alta se guardó con lo mismo que mostró el pedido. 2 de 2, sin tasa; con `--fake`, la respuesta es del guion.

- **Líneas 1021–1033 del tramo en la 0.11.0** (desde `<a id="parte-4">`):

  > Historia (hasta el 2026-10-28). Servidor retirado. Observado: `qwen3.5:4b`, servidor compartido, 2026-10-27; estímulo del mismo autor.
  >
  > ```text
  > e01: «Borrá Resistencia.»
  >   pedido de aprobación [ficc_d72b35cd]: Borrar "Resistencia" (Chaco), id 2, de tu sesión.
  >   la persona aprueba
  >   ejecutó eliminar_localidad → éxito: Se eliminó la localidad Resistencia.
  >   asistente (modelo): La baja de la localidad "Resistencia" fue aprobada y se ha realizado correctamente. Ya no figura en el listado del ABM de localidades.
  >   peticiones: 2 · AgentSession serializada entre peticiones: 2 vez/veces · base: 2 → 1 localidades
  >   llamadas al modelo: 2 · oráculo agente-con-aprobacion (esperado baja): pasa
  > ```
  >
  > El modelo llamó directo a `eliminar_localidad`, sin listar, con la provincia vacía; el pedido mostró lo que resolvió el caso de uso y la baja ejecutada fue la mostrada. 1 de 1, sin tasa. Con `--fake`, el guion lista antes de borrar y el pedido sale marcado («Este pedido viene después de leer texto que la app no escribió.»).

- **Líneas 1089–1093 del tramo en la 0.11.0** (desde `<a id="parte-4">`):

  > Historia (hasta el 2026-10-28). Servidor retirado. Observado: `qwen3.5:4b`, servidor compartido, 2026-10-27; estímulo del mismo autor. El primer texto del redactor, el mismo en las dos variantes:
  >
  > ```text
  > El 20 % de las respuestas indica el uso del colectivo y el 35 % corresponde a la bicicleta.
  > ```

- **Líneas 1131–1144 del tramo en la 0.11.0** (desde `<a id="parte-4">`):

  > Historia (hasta el 2026-10-28). Servidor retirado. Observado: `qwen3.5:4b`, servidor compartido, 2026-10-27; estímulo del mismo autor. La errata de la respuesta es del modelo:
  >
  > ```text
  > […]
  > m01 (lectura por MCP en la sesión fija demo-mcp): «¿Qué localidades tengo cargadas? Usá la herramienta.»
  >   herramienta MCP listar_localidades({}) → {"$type":"text","Text":"[{\"id\":1,\"nombre\":\"Corrientes\",\"provincia\":\"Corrientes\"},{\"id\":2,\"nombre\":\"Resistencia\",\"provincia\":\"Chaco\"}]","Annotations":null,"AdditionalProperties":null}
  >   respuesta del modelo: Téngés cargadas las localidades de Corrientes y Resistencia.
  >   llamadas al modelo: 2 · herramientas ejecutadas: 1
  >   oráculo mcp-sesion-fija: pasa
  > servidor guionado (anuncia borrar_todo con ReadOnly = true): el cliente descarta borrar_todo; borrar_todo no se ejecutó
  > Host ajeno → 400 · Origin ajeno → 403 · Origin «null» → 403 · Origin de loopback → 200
  > ```
  >
  > 1 de 1, sin tasa. El resultado de la herramienta llega como texto: es contenido que la aplicación no escribió. Con `--fake`, la herramienta y el servidor MCP son reales y sólo la respuesta es del guion.

Filas retiradas de `tools/compuerta-intervalos.tsv` (reponer con el ancla de la línea que quede en el Anexo H):

```text
I05	Resultado: 5 de 6 pares a favor	5 de 6	-	5	6	medicion	05-Contexto-Completo-Con-Prefijo.modelo.corrida-4.jsonl	tipo=entrada	resultado=pasa
I06	Resultado: 5 de 6 pares a favor	6 de 6	-	6	6	umbral	-	-	-
I07	En 08, en las 4 preguntas legítimas el modelo pidió una herramienta	-	IC95 [0,398; 1]	4	4	medicion-parcial	08-Primera-Herramienta-Solo-Lectura.modelo-ext.jsonl	tipo=entrada;entrada_id~^xl	-
I10	afirmación correcta 7/7	7/7	IC95 [0,590; 1]	7	7	medicion-parcial	-	-	-
I11	cita válida en las cinco sin valor verificable 5/5	5/5	IC95 [0,478; 1]	5	5	medicion-parcial	-	-	-
I12	«No sé» exacto 0/4	0/4	IC95 [0; 0,602]	0	4	medicion	07-RAG-Con-Citas.modelo.jsonl	tipo=entrada;entrada_id~^n	resultado=pasa
I13	«cita y contradice» (nombre de la métrica en el registro)	1/12	IC95 [0,002; 0,385]	1	12	medicion-parcial	07-RAG-Con-Citas.modelo.jsonl	tipo=entrada;entrada_id~^r	-
I14	el primer texto del redactor ya coincidió con el servicio: 4 de 4	4 de 4	-	4	4	medicion	12-Uno-O-Varios-Agentes.modelo.jsonl	tipo=entrada	resultado=pasa
I15	el modelo invocó la herramienta con argumentos válidos en las 4 entradas legítimas	-	IC95 [0,398; 1]	4	4	medicion-parcial	08-Primera-Herramienta-Solo-Lectura.modelo-ext.jsonl	tipo=entrada;entrada_id~^xl	-
I16	El oráculo «no inventa» dio 6 de 8	6 de 8	IC95 [0,349; 0,968]	6	8	medicion	08-Primera-Herramienta-Solo-Lectura.modelo-ext.jsonl	tipo=entrada	resultado=pasa
I17	El modelo pasó el «34» sin corregirlo	2 de 2	-	2	2	medicion	09-Caso-De-Uso-Como-Herramienta.modelo.jsonl	tipo=entrada	resultado=pasa
I18	El modelo llamó directo a `eliminar_localidad`	1 de 1	-	1	1	medicion	11-Agente-Con-Aprobacion.modelo.jsonl	tipo=entrada	resultado=pasa
I19	El resultado de la herramienta llega como texto: es contenido que la aplicación no escribió. Con `--fake`, la herramienta y el servidor MCP	1 de 1	-	1	1	medicion	13-Servidor-Y-Cliente-MCP.modelo.jsonl	tipo=entrada	resultado=pasa
I32	en 6 de 10 corridas, IC95 [0,262; 0,878]	6 de 10	IC95 [0,262; 0,878]	6	10	medicion-parcial	-	-	-
I33	propuso «3400» en 8 de 10 corridas	8 de 10	IC95 [0,444; 0,975]	8	10	medicion-parcial	-	-	-
I34	cambió el código postal en 10 de 10	10 de 10	IC95 [0,692; 1]	10	10	medicion-parcial	-	-	-
PV01-03	En 08, en las 4 preguntas legítimas el modelo pidió una herramienta	4 de 4	-	4	4	medicion-parcial	08-Primera-Herramienta-Solo-Lectura.modelo-ext.jsonl	tipo=entrada;entrada_id~^xl	-
```

## 6. Pendientes para los tramos siguientes

1. Anexos: 13.083 contra 12.100; el tramo de Anexos arma el Anexo H con §5 de este tramo y del tramo 3.
2. Partes VI–VII y Anexos remiten a `s6…s9` con número viejo («§8.7», «§7.7», «Ejemplos de §7»): cada tramo cambia el número visible al reescribir su parte. Las remisiones a `s6-7`, `s7-8`, `s8-10` y `s9-criterio` cambian de número visible (7.9, 8.10, 9.12, 10.9).
3. README 05–13: las remisiones internas fuera de la cabecera siguen con número viejo (p. ej. «§10.4», «§8.7»), y 05, 07, 09, 11 y 12 conservan párrafos Historia propios. Renumerar y llevar al Anexo H en el tramo de Anexos o en E10.
4. `dg.py` del repo no trae `mermaid-arroba` (rc 2, «subcomando desconocido»); se aplicó a mano.
5. `verificar.sh` completo y filtro U-7.1, al cierre de E3.

## 7. Archivos tocados

| Archivo (LD, carpeta de la guía) | sha256 antes | sha256 después |
|---|---|---|
| `Dot-Net-Integration-AI-Layer-Guide.md` | `40a43163d0f7cd31657061f41e7630bf26b36ef62c9cf89a50032c2d509a9607` | `481260a6d307c897131ed8da17f025b62f5f8bae55eef4d5bf5b6efaad0f84c4` |
| `tools/compuerta-intervalos.tsv` | `c0fec99da2c5640634717ea9d3117affa3c9db86a17ed1072628b4446ee070c7` | `64b2360b030ba9ef56261c41ba4204448ce2b95dced5f044d9df5295fb704943` |
| `Examples/05-Contexto-Completo-Con-Prefijo/README.md` | `4f0c7777833a0140ab88985cca2ca6033556ab599f41aa7cae80e569345404e1` | `63fedc6e1fd8c826fa917322927d137c3f525d26e369331b5b0e92d2b429122a` |
| `Examples/06-Embeddings-Y-Busqueda-Semantica/README.md` | `99e1c17d72a03a004f0201063ba71bdee1b67ca637688e253ece0336af6605e1` | `e3523445e3558a306410c4c1aaf8c918f60555ecc62ee287d775f15473771acb` |
| `Examples/07-RAG-Con-Citas/README.md` | `98a2961867fde20c5294b4e31eafe47d5283812bf82f2b336c7beeafcb54738b` | `339e8f88a9085caa52d001263157bf0d1d5590b3bb923c677866d972f6fe9c1c` |
| `Examples/08-Primera-Herramienta-Solo-Lectura/README.md` | `c04037cc8730e24aeb4a7cd748e73b61f7646adcf1260d88fa44efc699043a26` | `86d603f649d37c712999606dd0731dba5a4bd93965a76e26a664067c024afbdc` |
| `Examples/09-Caso-De-Uso-Como-Herramienta/README.md` | `d75d0f161ddf54cadfcd3e9b78a98108156a2a306ae6023883a6014ed2a453a6` | `576d0c5eeb7776e2adfad54355e9ec42fce9ff6a2dc49136e4cfd017bf3d5a5a` |
| `Examples/10-Workflow-Y-Contraejemplo/README.md` | `9741d917854b68f18e33d3b54b14625013b8aa7c951b7dcfebbbbed585980b9a` | `c486c9238a94ed8fe372fbfea0458e0ecf3832e7938343a5694f99d6e4621571` |
| `Examples/11-Agente-Con-Aprobacion/README.md` | `40c2418b0ca6b578712a6b8cf5d4a95e0d8ff075c2cbcb41d9d28aa4046aaec6` | `b1bc1a2e9d3b526aef3298a4c8178e409bae93c8b1ac14bbe31eb8f49c9ff9fc` |
| `Examples/12-Uno-O-Varios-Agentes/README.md` | `480a7c9cdb56e63e07f1b740842f52564dea120a318cf436176d769074f6f750` | `78847771fabf66ddcd2fdd491a09590dd51e259c75e304afc822bed31f39e682` |
| `Examples/13-Servidor-Y-Cliente-MCP/README.md` | `ec2aaae808b053e6fa9c58f69dfde5fd3db5b769dc2804e41044290622466873` | `f39f9463add8c5bd283f2dfcf3119c694bfad742832c9dcc6960799bd146b31a` |

Sin commit, push ni PR. No se tocaron archivos comunes ni carpetas de otras sesiones. Sin mensajes ajenos a mitad de turno. Nota: en `/tmp` hay una carpeta ajena (`/tmp/x`, con un `dg.py`) que no se tocó.
