# E1 · Cambios al libro (lista para E3)

Etapa E1 del plan integrado (`../05-Plan-Integrado.md` §5). Este archivo **no** edita la guía: enumera lo que E3 (y, donde se indica, E9) tiene que aplicar en `Dot-Net-Integration-AI-Layer-Guide.md`. Las líneas son de la guía 0.11.0 (sha256 `c8defd8324497c4279a3dfd57ce5d2757326ad966813a9f9797d0196d9b7ce3d`); E3 las vuelve a ubicar por ancla si el archivo cambió.

## Índice

1. [Definiciones](#1-definiciones)
2. [Cambios mecánicos de coherencia](#2-cambios-mecánicos-de-coherencia)
3. [Declaración de la excepción I-5 (D-02 a)](#3-declaración-de-la-excepción-i-5-d-02-a)
4. [Clasificación de las menciones de `qwen2.5:0.5b` (D-05 b)](#4-clasificación-de-las-menciones-de-qwen2505b-d-05-b)
5. [Lo que depende de los ensayos](#5-lo-que-depende-de-los-ensayos)
6. [Lo que ya se aplicó en E1 fuera del libro](#6-lo-que-ya-se-aplicó-en-e1-fuera-del-libro)

## 1. Definiciones

- **Corrige texto:** el libro cambia y el artefacto queda igual.
- **Corrige ejemplo:** cambia un archivo de `Examples/` o de `tools/` (ya hecho en E1, §6).
- **Declara divergencia:** el libro deja escrita la diferencia y su motivo.
- **Capacidad** (D-05 b): para qué se usa un modelo en una afirmación: *chat simple*, *humo* (prueba de que el servidor responde o de cómo tokeniza), *herramientas* (`tool_calls`) o *LLM juez*.

## 2. Cambios mecánicos de coherencia

| Id | Dónde (0.11.0) | Qué choca | Tipo | Cambio para E3 | Evidencia |
|---|---|---|---|---|---|
| CL-01 · I-1 (D-01 a) | §0.5, l. 179 | dice 57.234 palabras (129 %) y Anexos 12.532; `tools/contar.sh` da hoy 57.753 (130 %) | corrige texto | quitar las cifras; remitir a `tools/contar.sh` con fecha; la cifra medida pasa al anexo de laboratorio. El tope lo vota E2 (I-02) | `tools/contar.sh` → `Total 57753 44330 130%` (2026-11-01) |
| CL-02 · I-7 (C-1.3) | §3.1, l. 434 | el invariante remite a «dos excepciones rotuladas en §14.2», 3.400 líneas después | corrige texto | anunciar la excepción en §3.1 con una frase propia y remitir a §13.2/§14.2 | cita l. 434 |
| CL-03 · I-6 (D-08 a) | Parte II, l. 602 | rótulo «Fundamentos» con contenido de arquitectura y SDK | corrige texto | «Arquitectura y SDK» (lo aplica E2/E3 con la Parte I nueva) | R1 §4 |
| CL-04 · I-3 | E.3 y `Examples/README.md` | vocabulario distinto | — | **nada en el libro**: el libro ya usa «servidor de chat / segundo servidor»; se alineó el README (§6) | `Examples/README.md` §Variables, párrafo «Vocabulario» |
| CL-05 · I-4 (D-03 b) | — | `SalidaEstructurada.csproj` fuera de convención | corrige ejemplo | **nada en el libro**: el libro no nombra el `.csproj` (grep, §6) | `Ensayos.md` §2 |
| CL-06 · coherencia de modelo vigente | §6, l. 1486 | dice en presente «`qwen2.5:0.5b` muestra tiempos, no aciertos»; la corrida vigente de 05 es con `qwen3.5:4b` (PV-02, estación 1, 2026-11-01) | corrige texto | presente con `qwen3.5:4b` y PV-02; el 0.5b pasa al anexo «Procedencia» (D-10 a) | `../../Evidencia/R-LLM-2026-10-28/PV-02/corrida-2026-11-01/` |
| CL-07 · D-28 a | §2.x, E.3, A.12 | el papel «modelo compartido» como servidor ajeno | corrige texto | un solo proveedor (Ollama local por la API compatible con OpenAI); el papel sale del texto; los identificadores del arnés quedan como nombres históricos | `04-Aprobacion.md` D-28 |
| CL-08 · herramientas y 0.5b | §8.2, l. 2004 | afirma que `qwen2.5:0.5b` devolvió `"medio":"piedra"` 6/10 por `/v1` (estación 1, 2026-10-28); el relevamiento R4 (2026-11-01) midió una llamada con una herramienta **sin** `tool_calls` | declara divergencia | no son el mismo estímulo; la afirmación queda como Historia rotulada con su capacidad (*herramientas*) y la conducta vigente del `enum` se mide con `qwen3.5:4b` antes de E3 o queda «no verificado» (U-8.5) | `../Relevamiento/R4-Infra-Modelos.md` §4 |

## 3. Declaración de la excepción I-5 (D-02 a)

D-02 a: una línea en §4.6 y un rótulo en cada «En este laboratorio» afectado, con remisión a ADR-01; la demo es la referencia normativa. Qué ejemplos están afectados lo dice la medición E-2 (`Ensayos.md` §3), no una lectura:

| Ejemplo | Bajo `Application/` | Rótulo que lleva |
|---|---|---|
| 01 | cliente (`IChatClient`) | sí |
| 05 | cliente | sí |
| 06 | cliente y almacén (búsqueda vectorial) | sí |
| 07 | cliente y almacén (índice) | sí |
| 09 | cliente y herramientas | sí |
| 10 | workflow | sí |
| 11 | cliente y herramientas | sí |
| 12 | cliente y workflow | sí |
| 15 | cliente | sí |
| 16 | cliente y herramientas | sí |
| 17 | cliente | sí |
| 02, 03, 04, 08, 13, 14 | ninguno de los cuatro | no (02 no tiene `Application/`) |

Además, U-2.2: cada «En este laboratorio» dice en una línea si el ejemplo respeta ADR-01. La frase de E.1 (l. 4947) que hoy enumera «instrucciones, `IChatClient`, herramientas, el almacén o el workflow» queda, pero apoyada en esta tabla.

## 4. Clasificación de las menciones de `qwen2.5:0.5b` (D-05 b)

`grep -n 'qwen2.5:0.5b'` sobre la guía 0.11.0: **23 apariciones en 22 líneas** (el plan dice 22: son 22 líneas). Regla D-05 b: el 0.5b queda para chat simple y humo; las de herramientas pasan al 4b.

| Línea | Sección | Capacidad | Estado en el texto | Acción para E3 |
|---|---|---|---|---|
| 641 | §4.2 tabla «por qué ahora» | chat simple (familia del modelo chico) | vigente | queda |
| 661 | §4.2 | chat simple (segundo servidor retirado) | Historia | al anexo «Procedencia» (D-10 a) |
| 972 | §5.4 | humo (tokenización, 5.134 tokens) | Historia | al anexo «Procedencia» |
| 1032 | §5.7 | humo (sonda de `num_ctx`) | Historia | al anexo «Procedencia» |
| 1034 | §5.7 | chat simple (lo de §6.3 «no se traslada») | vigente, remite | queda, con remisión al anexo |
| 1166 | §5 ejemplos, 02 | chat simple | Historia | al anexo «Procedencia» |
| 1436 | §6.3 | chat simple (duraciones de 05) | presente | reescribir con la corrida PV-02 de `qwen3.5:4b` (CL-06) |
| 1486 | §6 ejemplos, 05 | chat simple | **presente, desactualizado** | CL-06 |
| 1534 | §6 ejemplos, 05 | chat simple | Historia | al anexo «Procedencia» |
| 2004 | §8.2 | **herramientas** | Historia | CL-08: medir con el 4b o «no verificado» |
| 2968 | §10.6 | LLM juez | Historia | al anexo «Procedencia» |
| 2972 | §10.6 | LLM juez (0/52 legibles) | Historia | al anexo «Procedencia» |
| 3042 | §10 ejemplos, 15 | LLM juez | Historia | al anexo «Procedencia» |
| 3090 | §10 preguntas | LLM juez | Historia | al anexo «Procedencia» |
| 3811 | §13.11 ADR-10 | LLM juez | Historia | al anexo «Procedencia»; el ADR conserva sólo lo vigente |
| 4072 | §14.6 | LLM juez | Historia | ídem |
| 4477 | A.12 | chat del segundo servidor | Historia entre paréntesis | queda la columna «vigente»; el paréntesis al anexo |
| 4950 | E.1, 02 | chat simple | Historia | ídem |
| 4953 | E.1, 05 | chat simple | Historia | ídem |
| 4963 | E.1, 15 | LLM juez | Historia | ídem |
| 4992 | E.3 | humo (digest esperado) | Historia | ídem |
| 5210 | F.4 | versión | Historia | queda en el Anexo F (es su lugar) |

Resumen: chat simple 9, humo 3, herramientas 1, LLM juez 8, versión 1. Ninguna mención **vigente** usa el 0.5b para herramientas; la única de herramientas (2004) es Historia.

## 5. Lo que depende de los ensayos

Se completa en `Ensayos.md`; aquí sólo el destino:

- **T-qwen (I-07):** el texto de §8 y del Anexo E que dice «servidor de chat, `qwen3.5:4b`» para 08, 09, 11, 13 y 16 se mantiene si T-qwen pasa (≥ 4/5) en cada uno; si no, E3 escribe «no verificado» para ese ejemplo y la mesa decide antes de E3. El resultado está en `Ensayos.md` §4.
- **T-3 MCP (D-06 a):** E9 actualiza [REF-196]/[REF-199] con la versión capturada (`Ensayos.md` §5) y la fecha de consulta de la ronda (U-8.4). Los comentarios de código que citan «MCP 2025-06-18» quedan como estaban hasta que E9 decida si la cita de la especificación cambia.
- **E-2:** §3 de este archivo.

## 6. Lo que ya se aplicó en E1 fuera del libro

| Archivo | Cambio | sha256 antes → después |
|---|---|---|
| `Examples/README.md` | I-2: `comparar-bloques.py` → `comparar-ac9.py` y suma `compuerta-referencias.sh`; I-3: vocabulario «servidor de chat / segundo servidor» con párrafo «Vocabulario»; default de `OLLAMA_PROPIO_MODEL` corregido a `qwen3.5:4b` (era `qwen2.5:0.5b`; el código dice `qwen3.5:4b`, `ConfiguracionDelModelo.cs` l. 36 y 72) | ver `../Ejecucion/E1.md` |
| `Examples/02-…`, `05-…`, `06-…`, `07-…`, `12-…`, `15-…/README.md` | I-3: «Ollama propio» / «servidor compartido» → «segundo servidor» / «servidor de chat» fuera de los bloques Historia | ver `../Ejecucion/E1.md` |
| `Examples/03-Salida-Estructurada/SalidaEstructurada.csproj` | D-03 b: renombrado a `03-Salida-Estructurada.csproj`, con `AssemblyName` `SalidaEstructurada` para no cambiar binarios ni registros | ver `../Ejecucion/E1.md` |
| `tools/compuerta-referencias.sh` + `.excepciones` | U-1.1: compuerta nueva | ver `../Ejecucion/E1.md` |
