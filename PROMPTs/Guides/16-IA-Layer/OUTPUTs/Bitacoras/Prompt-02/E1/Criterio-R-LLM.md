# E1 · Criterio R-LLM previo (escrito antes de correr, 2026-11-01)

Etapa E1 del plan integrado (`../05-Plan-Integrado.md` §5, E1). Este archivo fija qué cuenta como resultado **antes** de la primera llamada a un modelo. No se edita después de la primera corrida; su sha256 queda en `../Ejecucion/E1.md`.

## Índice

1. [Definiciones](#1-definiciones)
2. [Entorno fijo](#2-entorno-fijo)
3. [T-qwen (D-04 c)](#3-t-qwen-d-04-c)
4. [E-2 (U-1.2)](#4-e-2-u-12)
5. [T-3 MCP (D-06 a)](#5-t-3-mcp-d-06-a)
6. [Qué invalida una corrida](#6-qué-invalida-una-corrida)

## 1. Definiciones

- **Corrida:** una ejecución completa de la consola del ejemplo con `--verificar` contra el modelo, por `tools/verificar.sh correr <carpeta> --con-modelo`, sobre una copia de la guía 0.11.0 en `{dir-de-trabajo}`, con su propio `RLLM_DIR` (registro R-LLM aparte por corrida).
- **Llamada con herramienta:** una línea `tipo: "llamada"` del registro R-LLM con `modelo` `qwen3.5:4b` y `herramientas` no vacío (el modelo emitió `tool_calls` y la capa ejecutó la función).
- **Corrida con `tool_calls`:** rc 0 de la consola **y** al menos una llamada con herramienta en su registro.
- **k/n:** corridas con `tool_calls` sobre corridas válidas, con intervalo Clopper-Pearson al 95 % (`tools/verificar.sh tasa k n`).

## 2. Entorno fijo

- Sólo la estación 1 (Ollama 0.40.11, `qwen3.5:4b` digest `d8b0f5e9760c`), con turno [recurso de modelo] del gestor; un pedido a la vez; `num_ctx` 8192 fijado por el arnés y leído en `/api/ps`; `keep_alive 0` al cerrar cada corrida.
- Precondición del arnés (versión y digest) en cada corrida; si no coincide, la corrida es «no medido».
- Memoria: `docker stats` del contenedor del Ollama al menos una vez con el modelo cargado; se compara contra 5 GiB (C-9.1).
- Estación 2 apagada: no se usa. Sin emuladores ni KVM.

## 3. T-qwen (D-04 c)

- Ejemplos: 08, 09, 11, 12, 13, 16; **5 corridas** cada uno.
- **Pasa** un ejemplo con ≥ 4 de 5 corridas con `tool_calls`. Menos de 4: **NO VERIFICADO** y vuelve a la mesa antes de E3 (I-07).
- **12, criterio declarado de antemano:** el registro archivado del 2026-10-29 muestra `hash_herramientas` = sha256 de la cadena vacía en todas sus llamadas (el redactor y el corrector no reciben herramientas; `resumir_encuesta` la llama el código). Si la copia confirma que 12 no ofrece herramientas al modelo, el criterio de `tool_calls` **no aplica** a 12 y se informa así a la mesa; para 12 se cuenta sólo «corrida válida con rc 0» como dato informativo.
- Se informan también, sin umbral: llamadas con herramienta / llamadas totales, duración por corrida y `prompt_eval_count` medio.
- Determinismo: los ejemplos fijan temperatura 0 y semilla 42; cinco corridas iguales no son cinco muestras independientes. Se declara junto a k/n.

## 4. E-2 (U-1.2)

Sin modelo. Medición estática sobre la copia: para cada `Examples/NN-*/Application/**/*.cs`, ¿usa `IChatClient`/`Microsoft.Extensions.AI` (cliente), define o monta herramientas (`AIFunction`, `AIFunctionFactory`, `[Description]` de función), toca almacén (`DbContext`, `Sqlite`, repositorio de `Infrastructure`) o define workflow (`Microsoft.Agents.AI.Workflows`, `Executor`, `WorkflowBuilder`)? Resultado: tabla 17 × 4 con el archivo y la línea de cada coincidencia. No hay umbral; alimenta la declaración de la excepción I-5 (D-02 a).

## 5. T-3 MCP (D-06 a)

- Ejemplo 13 sobre una copia **instrumentada sólo en `{dir-de-trabajo}`**: el `HttpClient` del transporte del cliente MCP recibe un `DelegatingHandler` que escribe, por cada pedido y respuesta, el método JSON-RPC, la cabecera `MCP-Protocol-Version` y la `protocolVersion` del cuerpo de `initialize`.
- Corre con `--fake --verificar` (la negociación es entre cliente y servidor MCP; el modelo no participa) con turno `build`.
- **Pasa** si: (a) la versión que devuelve `NegotiatedProtocolVersion` coincide con la cabecera `MCP-Protocol-Version` de los pedidos posteriores a `initialize`; (b) el paquete resuelto es `ModelContextProtocol` 2.3.0 (lista de paquetes del build); (c) queda el valor literal capturado. El valor esperado **no** se fija: se registra el que salga. Si sale 2026-07-28, D-06 a habilita a E9 a actualizar [REF-196]/[REF-199]; si sale otro, E9 escribe ése.

## 6. Qué invalida una corrida

Precondición del servidor que no coincide; `/api/ps` con otro modelo cargado antes de empezar; turno no concedido; registro R-LLM vacío. Una corrida invalidada no cuenta en n y se informa.

> **Nota de redacción** 2026-11-01: los nombres del gestor de turnos, de su envoltorio y del recurso de modelo se reemplazaron por marcadores entre corchetes (R-PRIV, clases «turnos» e «identificadores»; pendiente 4 de `Ejecucion/Verificacion-Etapa-2.md`, decidido en `Ejecucion/Pendientes-Etapa-2.md`). No se cambió nada más. El sha256 citado antes de correr, `c1d4979e1abfd3944a4a06fa7985ff3b0d1b0d98f87c7024aa273e81d7fede78`, corresponde al texto previo a esta nota; el nuevo se registra en `Ejecucion/Pendientes-Etapa-2.md`.
