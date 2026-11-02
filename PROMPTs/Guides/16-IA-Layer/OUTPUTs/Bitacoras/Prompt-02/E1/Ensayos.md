# E1 · Ensayos

Etapa E1 del plan integrado (`../05-Plan-Integrado.md` §5). Criterio escrito antes de correr: `Criterio-R-LLM.md` (sha256 `c1d4979e1abfd3944a4a06fa7985ff3b0d1b0d98f87c7024aa273e81d7fede78`, 2026-11-01 16:41 -03). Evidencia redactada en `Evidencia/` (índice de hashes: `Evidencia/SHA256SUMS`, sha256 `c1c57fe11a0625289c77cda19fe713fa6f841785017a35acebddaea16d7f0078`; R-PRIV con las listas privadas: 0 hallazgos).

## Índice

1. [Rótulo común](#1-rótulo-común)
2. [Build y compuertas](#2-build-y-compuertas)
3. [E-2 · qué hay bajo `Application/`](#3-e-2--qué-hay-bajo-application)
4. [T-qwen · `qwen3.5:4b` con herramientas (D-04 c)](#4-t-qwen--qwen354b-con-herramientas-d-04-c)
5. [T-3 · versión de MCP (D-06 a)](#5-t-3--versión-de-mcp-d-06-a)
6. [U-9.1 · `OLLAMA_URL` y la pasarela retirada](#6-u-91--ollama_url-y-la-pasarela-retirada)
7. [Qué cambia para las etapas siguientes](#7-qué-cambia-para-las-etapas-siguientes)

## 1. Rótulo común

| Campo | Valor |
|---|---|
| Fecha | 2026-11-01, 16:39–18:21 -03 |
| Estación | estación 1 (Ollama 0.40.11, sólo CPU, contenedor con tope de 5 GiB); estación 2 apagada, no se tocó |
| Modelo | `qwen3.5:4b`, digest `d8b0f5e9760c` (precondición del arnés: `coincide: true` en cada corrida) |
| `num_ctx` | 8192, fijado por el arnés y leído en `/api/ps` tras la carga (`num_ctx_origen` `arnes-ps-tras-carga`) |
| Memoria | máximo muestreado 4,688 GiB de 5 GiB (93,8 %), 95 muestras cada 30 s (`Evidencia/memoria-ollama.txt`) |
| Turnos | `build` y el recurso de modelo del gestor, por [el envoltorio de turnos]; un pedido a la vez; `/api/ps` vacío al terminar |
| Guía | copia de 0.11.0 en `{dir-de-trabajo}` (sha256 del `.md` `c8defd83…7ce3d`) |

## 2. Build y compuertas

| Compuerta | Comando | rc | Resultado |
|---|---|---|---|
| build 0.11.0 (copia) | `tools/verificar.sh build` con turno `build` | 1 | 561/561 pruebas en 18 suites, consolas `--fake --verificar` y AC-6 bien; R-PRIV marcó **un** hallazgo en `tools/compuerta-referencias.sh` (la compuerta nueva, copiada a la copia antes del build, nombraba una ruta de contenedor bajo `/home`). Se corrigió la compuerta |
| build tras los cambios de E1 (copia nueva) | ídem | **0** | **561/561 en 18 suites**, R-PRIV 0 (`Evidencia/build-tras-E1.log`, sha256 de la consola original `3f062186…4ecda`) |
| `compuerta-ac7.sh` | `COMPUERTAS_DIR=… tools/compuerta-ac7.sh {guía}` | 0 | 0 coincidencias; autoprueba 40/40 |
| `compuerta-ac8.sh` | ídem | 0 | 0 fuera de excepciones (2 exceptuadas); autopruebas 5/5, lista 11/11 |
| `comparar-ac9.py bloques` | `python3 -I tools/comparar-ac9.py bloques` | 0 | 57 bloques, 0 diferencias |
| `compuerta-referencias.sh` (nueva) | `tools/compuerta-referencias.sh` | 0 | 0 rotas en 21 archivos (antes de corregir el README: 1, `comparar-bloques.py`, I-2) |
| `compuerta-rpriv.sh` | `tools/compuerta-rpriv.sh {guía}` | 0 | 0 hallazgos |

El criterio de aceptación de E1 («`verificar.sh build` igual que en 0.11.0, 561/561») se cumple con el renombre de 03 (D-03 b) incluido: el ensamblado `SalidaEstructurada.dll` sigue igual (25/25).

## 3. E-2 · qué hay bajo `Application/`

Medición estática (sin modelo) con `grep` sobre `Examples/NN-*/Application/**/*.cs` de la copia (`Evidencia/E-2-coincidencias.txt`, 78 líneas con archivo y línea). Número de archivos con coincidencia:

| Ejemplo | Cliente (`IChatClient` / `Microsoft.Extensions.AI`) | Herramientas (`AIFunction…`, `[Description]`) | Almacén (vectorial / EF) | Workflow (MAF) | Archivos `.cs` |
|---|---|---|---|---|---|
| 01 | 1 | 0 | 0 | 0 | 2 |
| 02 | sin `Application/` | | | | |
| 03 | 0 | 0 | 0 | 0 | 3 |
| 04 | 0 | 0 | 0 | 0 | 3 |
| 05 | 1 | 0 | 0 | 0 | 5 |
| 06 | 1 | 0 | 1 | 0 | 8 |
| 07 | 3 | 0 | 1 | 0 | 7 |
| 08 | 0 | 0 | 0 | 0 | 2 |
| 09 | 2 | 1 | 0 | 0 | 2 |
| 10 | 0 | 0 | 0 | 2 | 5 |
| 11 | 2 | 1 | 0 | 0 | 2 |
| 12 | 1 | 0 | 0 | 2 | 7 |
| 13 | 0 | 0 | 0 | 0 | 1 |
| 14 | 0 | 0 | 0 | 0 | 1 |
| 15 | 3 | 0 | 0 | 0 | 6 |
| 16 | 3 | 2 | 0 | 0 | 3 |
| 17 | 1 | 0 | 0 | 0 | 2 |

Lectura: 11 de 16 ejemplos con `Application/` ponen al menos uno de los cuatro mecanismos ahí; P-04 había medido 5 (01, 05, 07, 12, 17). Las herramientas están en 09, 11 y 16; el almacén en 06 y 07; el workflow en 10 y 12. Destino: la declaración D-02 a (`Cambios-Al-Libro.md` §3). C-1.4 se mantiene: no se mueve código.

## 4. T-qwen · `qwen3.5:4b` con herramientas (D-04 c)

Cinco corridas por ejemplo, cada una con su turno y su `RLLM_DIR` (`Evidencia/T-qwen/<ejemplo>/sN/`). «Con herramienta» = líneas `llamada` con `herramientas` no vacío sobre las llamadas al 4b de esa corrida.

| Ejemplo | k/n corridas con `tool_calls` | IC95 Clopper-Pearson | Llamadas con herramienta / totales (por corrida) | Duración por corrida | `prompt_eval_count` medio | Oráculos del ejemplo | Veredicto |
|---|---|---|---|---|---|---|---|
| 08 | 5/5 | [0,478; 1] | 1/3 | 83–87 s | 531 | `no-inventa` 2/2 en las 5 | **pasa** |
| 09 | 5/5 | [0,478; 1] | 2/4 | 120–150 s | 659 | `alta-con-aprobacion` 2/2 en las 5 | **pasa** |
| 11 | 5/5 | [0,478; 1] | 1/2 | 70–99 s | 545 | `agente-con-aprobacion` 1/1 en las 5 | **pasa** |
| 13 | 5/5 | [0,478; 1] | 1/2 | 44–50 s | 415 | `mcp-sesion-fija` 1/1 en las 5; protocolo negociado 2026-07-28 en las 5 | **pasa** |
| 16 | 5/5 | [0,478; 1] | 12/24 | 509–777 s | 548 | rc 0 e invariantes en las 5 | **pasa** |
| 12 | no aplica | — | 0/4 | 62–115 s | 287 | `porcentajes-del-servicio` 2 de 2 por variante, 0 vueltas | **no aplica** (criterio §3 de `Criterio-R-LLM.md`) |

- **12 no ofrece herramientas al modelo.** `hash_herramientas` es `e3b0c442…`, el sha256 de la cadena vacía, en las 20 llamadas: el redactor recibe los datos que trae el executor `Datos` (código), y el corrector no se llamó (0 vueltas). Lo que dice D-04 c sobre «ejemplos de herramientas» no le aplica; la mesa lo había incluido en la lista. Se informa a la mesa; no cambia ningún veredicto.
- **Determinismo.** Temperatura 0 y semilla 42: las cinco corridas de cada ejemplo dieron el mismo patrón de llamadas y el mismo `prompt_eval_count` (±1). k/n mide repetibilidad del montaje sobre el mismo servidor, no variabilidad del modelo; el IC95 se da porque el criterio lo pide, no porque las corridas sean independientes.
- **Memoria.** 4,688 GiB de 5 GiB como máximo: entra, con un margen del 6 %. Un segundo modelo cargado a la vez (embeddings) no entraría sin descargar el de chat.
- **Duración.** 16 es el único caro (24 llamadas, 8,5–13 min por corrida); el resto, menos de 2,5 min.

**Resultado de I-07:** `qwen3.5:4b` cumple D-04 c en los cinco ejemplos que llaman herramientas (08, 09, 11, 13, 16). Nada vuelve a la mesa por umbral.

## 5. T-3 · versión de MCP (D-06 a)

Copia del ejemplo 13 instrumentada **sólo en `{dir-de-trabajo}`** (un `DelegatingHandler` en el `HttpClient` del transporte del cliente; el repo no cambia), corrida con `--fake --verificar` y turno `build` (rc 0, invariantes cumplidas). Captura: `Evidencia/T-3/t3-captura.jsonl` (6 pedidos HTTP).

| Qué | Valor capturado |
|---|---|
| Paquetes resueltos (lista AC-6 del build) | `ModelContextProtocol` 2.3.0, `ModelContextProtocol.AspNetCore` 2.3.0, `ModelContextProtocol.Core` 2.3.0 |
| `NegotiatedProtocolVersion` (consola) | `2026-07-28` |
| Cabecera `MCP-Protocol-Version` de los 6 pedidos | `2026-07-28` en todos |
| Cuerpo | `_meta` con `io.modelcontextprotocol/protocolVersion: "2026-07-28"` |
| Métodos, en orden | `server/discover`, `tools/list`, `tools/call`, `tools/call`, `server/discover`, `tools/list` |
| Cabecera de las respuestas | vacía (el servidor no la devuelve) |
| Con modelo (T-qwen, 13) | «protocolo MCP negociado: 2026-07-28» en las 5 corridas |

**Diferencia con el criterio previo, declarada:** el criterio esperaba un `initialize` para leer de su cuerpo la `protocolVersion`. Con 2026-07-28 el SDK 2.3.0 no manda `initialize`: abre con `server/discover` y lleva la versión en `_meta` de cada pedido y en la cabecera. Las tres condiciones se cumplen igual: (a) negociada = cabecera, en todos los pedidos; (b) 2.3.0; (c) valor literal capturado.

**Resultado:** T-3 **pasa**. Se levanta la condición del veto de D-06 b: la versión `2026-07-28` queda verificada con rótulo completo (fecha, SDK 2.3.0, cabecera capturada).

## 6. U-9.1 · `OLLAMA_URL` y la pasarela retirada

- En la guía **no hay** valores por omisión que apunten a la pasarela retirada: los únicos defectos son `http://localhost:11434` (`ConfiguracionDelModelo.cs` l. 28; `tools/verificar.sh` l. 447; `Demos/…/tools/demo.sh` l. 135) y direcciones `.invalid` en pruebas. Nada que corregir dentro de la guía.
- El defecto de N-09 está **fuera del territorio de la guía 16**: el gestor de recursos compartido del workspace ([el gestor de recursos compartido], l. 67, `OLLAMA_URL` con defecto a la dirección vieja) y un repo ajeno (`AIProviderFactory.cs`). No se editaron: el gestor lo usan las otras sesiones. En E1 todas las corridas pasaron el endpoint explícito por variable de entorno, que no quedó escrito en ningún archivo. Queda como aviso para la coordinación (ver `../Ejecucion/E1.md`).

## 7. Qué cambia para las etapas siguientes

| Etapa | Cambio por los ensayos |
|---|---|
| E3 | Puede escribir `qwen3.5:4b` como modelo de referencia para herramientas (08, 09, 11, 13, 16) con este rótulo; 12 se describe como ejemplo **sin** herramientas ofrecidas al modelo. La declaración de I-5 usa la tabla E-2 (11 ejemplos), no la de P-04 (5). El presupuesto de memoria (93,8 % del tope) va al anexo de laboratorio como límite: no hay lugar para dos modelos cargados a la vez. |
| E5 | La prueba con modelo del caso Geometría puede apoyarse en `qwen3.5:4b` con herramientas; costo de referencia: 44–150 s por corrida de 2–4 llamadas en la estación 1, carga del modelo incluida. |
| E9 | Actualizar [REF-196]/[REF-199] a `2026-07-28` con esta evidencia (T-3), sin repetir el ensayo. Revisar si los comentarios del código que citan «MCP 2025-06-18» deben citar 2026-07-28 (decisión de E9; E1 no tocó código). |
| Mesa | Sacar 12 de la lista D-04 c (no llama herramientas). La pregunta de N-01 «¿qué modelo pasa a ser el de referencia?» queda contestada con evidencia: `qwen3.5:4b`. |
| Coordinación | Defecto de [el gestor de recursos] (U-9.1) fuera del territorio: avisar al dueño del gestor. |

> **Nota de redacción** 2026-11-01: los nombres del gestor de turnos, de su envoltorio y del recurso de modelo se reemplazaron por marcadores entre corchetes (R-PRIV, clases «turnos» e «identificadores»; pendiente 4 de `Ejecucion/Verificacion-Etapa-2.md`, decidido en `Ejecucion/Pendientes-Etapa-2.md`). No se cambió nada más. El sha256 del criterio citado al comienzo es el del texto previo a su nota de redacción; el nuevo está en `Ejecucion/Pendientes-Etapa-2.md`.
