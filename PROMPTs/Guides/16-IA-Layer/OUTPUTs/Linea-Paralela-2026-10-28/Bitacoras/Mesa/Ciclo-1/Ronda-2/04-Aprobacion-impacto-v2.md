---
doc_id: BIT-16-C1-R2-04-impacto-v2
doc_type: aprobacion
title: Aprobación de la ronda 2, vuelta 2 (juez de impacto)
status: emitido
origin: agent
owner: juez de impacto
last_review: 2026-10-28
audience: [mesa, aplicación, presidencia]
traces: [Mesa/Ciclo-1/Ronda-2/03-Parches.md (Vuelta 2, P2-06), Mesa/Ciclo-1/Ronda-2/04-Aprobacion-impacto.md (P2-06, mejoras 1-4), Mesa/Ciclo-1/Ronda-2/evidencia-operacion-telemetria/PC02-*, Mesa/Ciclo-1/Ronda-2/evidencia-aprobacion-impacto/P206v2-*, Mesa/Ciclo-1/07-Dictamen-Presidencia.md, IA.Prompts/Base/Mesa-Evaluadora.md §5.5]
---

# Aprobación de la ronda 2, vuelta 2: juez de impacto

Parche juzgado: **P2-06, vuelta 2** (`03-Parches.md`, sección «Vuelta 2»). Criterio: qué le pasa al lector que copia lo que la guía va a decir. Esta es la segunda y última vuelta de P2-06 (M§5.5: máximo 2 vueltas), así que no queda lugar para otro `MEJORAR_PLAN`.

## 0. Evidencia propia

Hice un experimento sin modelo, porque la vuelta 2 afirma algo que el XML del paquete no alcanza a probar: qué método de lectura usa `GetStreamingResponseAsync`.

- **Fuente:** `Ronda-2/evidencia-aprobacion-impacto/P206v2-Program.cs`, `P206v2-Sonda.csproj` y `P206v2-salida.txt`.
- **Entorno:** `mcr.microsoft.com/dotnet/sdk:10.0` (SDK 10.0.403, runtime 10.0.14), MEAI 10.11.0.0 y `Microsoft.Extensions.Caching.Memory` 10.0.0, con el volumen `<volumen-nuget>`.
- **Comando:** `<envoltorio-de-turnos> build aprob-impacto "P2-06 v2: lectura de caché por streaming en MEAI 10.11.0" 20 -- docker run --rm -v <trabajo>:/w -w /w -v <volumen-nuget>:/root/.nuget/packages mcr.microsoft.com/dotnet/sdk:10.0 bash -c "dotnet run -c Release"`. Se borraron `bin/` y `obj/` al terminar.
- **Cliente:** uno falso que cuenta llamadas y emite tres fragmentos por streaming. La subclase de `DistributedCachingChatClient` cuenta por separado las lecturas y las escrituras de cada método.

| # | Caso | Salida (`P206v2-salida.txt`) |
|---|---|---|
| [1] | Streaming ×2 con `CoalesceStreamingUpdates` por defecto (efectivo `True`) | llamadas al cliente = 1; **`ReadCacheAsync` llamadas = 2, aciertos = 1; `ReadCacheStreamingAsync` llamadas = 0**; `WriteCacheAsync` = 1; `WriteCacheStreamingAsync` = 0 |
| [1] | Streaming ×2 con `CoalesceStreamingUpdates = false` | llamadas = 1; `ReadCacheAsync` = 0; **`ReadCacheStreamingAsync` llamadas = 2, aciertos = 1**; `WriteCacheStreamingAsync` = 1 |
| [2] | `GetResponseAsync` ×2 | llamadas = 1; `ReadCacheAsync` aciertos = 1 |
| [3] | Caso rojo de (2b): sólo `ReadCacheAsync`, streaming, Coalesce por defecto | llamadas = 1; **contador = 1** |
| [3'] | Lo mismo con `CoalesceStreamingUpdates = false` | llamadas = 1; **contador = 0** |
| [4] | Regla (a): almacén compartido, instancia por scope que lee la versión al crearse, `[SessionId, VersionDeDatos]` | después de la escritura (v 0→1): **fallo de caché** (1 llamada) |
| [4] | Caso rojo `[SessionId]` | después de la escritura: **ACIERTO (respuesta vieja)**, 0 llamadas |
| [5] | `ChatOptions.ConversationId` con valor, ×2 | llamadas = 2: no cachea |
| [5'] | `EnableCaching` sobrescrito a `false`, 2 normales y 2 por streaming | llamadas = 4: compila y desactiva los dos caminos |

**Lectura.** Con el valor por defecto (`CoalesceStreamingUpdates = true`), `GetStreamingResponseAsync` lee y escribe por `ReadCacheAsync` y `WriteCacheAsync`. El XML del paquete (`lib/net10.0/Microsoft.Extensions.AI.xml`, l. 717-720) dice que `ReadCacheStreamingAsync` «is used when there is a call to `GetStreamingResponseAsync`». Eso sólo es cierto con `CoalesceStreamingUpdates = false`. La documentación no describe el comportamiento.

## 1. Las mejoras que pedí en la vuelta 1

| Mejora (04-Aprobacion-impacto, P2-06) | ¿Atendida? | Comentario |
|---|---|---|
| (1) Regla para los datos que cambian, elegida y con motivo | **sí** | (b) en la demo, (a) en `Examples/09` y (c) descartada por servir datos viejos. El límite de (a) está declarado (no ve escrituras fuera del caso de uso). Mi sonda [4] confirma la regla (a) y su caso rojo con la forma exacta del parche: instancia por scope, almacén compartido y versión leída al crearse |
| (2) Prueba (4) en `Cableado/` | **sí** | Con caso rojo. Ya corrió en mi sonda: el verde da fallo y el rojo da acierto |
| (3) «Lo que se pierde» suma la frescura | **sí** | Punto 2, con la cita a l. 13 |
| (4) P2-15 suma la (4) | **sí** | Pasa a «las cinco» |

Las mejoras de los otros jueces también entran (nombre único, limitador fuera de la cadena con remisión a M9, condiciones (a)-(c) de riesgo). Comprobé el nombre: `movilidadurbana.ai.cache.aciertos` está en `PC02-Program.cs` l. 23 y en `PC02-salida.txt` l. 14, 23 y 38.

## 2. Defecto nuevo de la vuelta 2: el camino por streaming está explicado al revés

La vuelta 2 sumó, por pedido de costo-beneficio, tres afirmaciones que mi sonda refuta con la configuración por defecto:

1. En M8: «En MEAI 10.11.0, `GetStreamingResponseAsync` lee la caché con `ReadCacheStreamingAsync` y no con `ReadCacheAsync`. Por eso, si sólo se sobrescribe el primero, los aciertos por streaming no se cuentan.» Es **falso por defecto** ([1], [3]). Sólo es cierto con `CoalesceStreamingUpdates = false` ([1], [3']).
2. En la verificación (2b): «El caso rojo, una subclase que sólo sobrescribe `ReadCacheAsync`, tiene que dejar el contador en 0». Con el valor por defecto da **1** ([3]). La prueba, tal como está escrita, falla en `Cableado/` sin que haya ningún defecto en el código, o, peor, la redacción "arregla" la prueba sin entender por qué.
3. En la reversión: «el conteo por `ReadCacheStreamingAsync`, porque sin él el contador miente en el camino por streaming». Por defecto no miente. Miente sólo si alguien pone `CoalesceStreamingUpdates = false`.

**Impacto en el lector.** El código del fragmento está bien: con las dos sobrescrituras cuenta 1 por acierto en los dos modos, y nunca cuenta doble, porque en cada acierto se llama uno solo de los dos métodos ([1]). El daño está en la explicación. El lector aprende un modelo falso de MEAI, corre la prueba roja que la guía le da, la ve fallar y concluye que la guía está mal o que su entorno está roto. Es el tipo de error que la guía promete no cometer: una afirmación sobre una versión fijada, sin medir.

**Por qué no es `MEJORAR_PLAN`.** Es la vuelta 2 (M§5.5). La corrección es de texto, está medida y no cambia ni el código, ni la regla, ni el orden, ni la capa. Devolverlo a auditoría no agrega información. Por eso apruebo con la corrección vinculante de §3, y la aplicación la incorpora al texto de P2-06.

## 3. Decisión

| Parche | Decisión | ¿Capa correcta? | Fundamento | Corrección vinculante para la aplicación |
|---|---|---|---|---|
| P2-06 (vuelta 2) | **APLICAR**, con corrección vinculante | **sí**. El defecto nació en M8/R-C07 (integración) y en la sección de pipeline de N5 §4.1-4.2. El parche corrige ahí, y propaga a 06-Plan, RV-03, P2-15 y `PIPE` por remisión, sin tocar otra capa | Atiende mis cuatro mejoras de la vuelta 1. La regla (a) y su caso rojo ya están medidos en mi sonda [4]. Le cierra al lector el caso más dañino que quedaba: la respuesta vieja después de un alta o una baja, con 0 spans y sin error. El defecto nuevo es de explicación y se corrige sin otra vuelta | Ver C-1 a C-5 |

**C-1 (M8, reemplazo de dos oraciones).** Donde dice «En MEAI 10.11.0, `GetStreamingResponseAsync` lee la caché con `ReadCacheStreamingAsync` y no con `ReadCacheAsync`. Por eso, si sólo se sobrescribe el primero, los aciertos por streaming no se cuentan. Además, `CoalesceStreamingUpdates` vale `true` por defecto, así que un acierto por streaming llega en menos fragmentos que la respuesta original.», se lee:

> «En MEAI 10.11.0, `GetStreamingResponseAsync` lee la caché según `CoalesceStreamingUpdates`. Con el valor por defecto (`true`), junta los fragmentos en una `ChatResponse`, la guarda y la lee con `ReadCacheAsync`. Con `false`, guarda la lista de fragmentos y la lee con `ReadCacheStreamingAsync`. Se sobrescriben los dos para que el contador no dependa de esa opción. En cada acierto se llama uno solo de los dos, así que no hay doble conteo (`evidencia-aprobacion-impacto/P206v2-salida.txt`, casos [1] y [3]). La documentación XML del paquete atribuye el streaming a `ReadCacheStreamingAsync` sin esa salvedad.»

La frase sobre «menos fragmentos» sale, o queda en C, porque nadie la midió.

**C-2 (verificación (2b), reemplazo).** Se lee:

> «(2b) Por `GetStreamingResponseAsync`, en los dos modos. (i) Con `CoalesceStreamingUpdates` por defecto: 0 llamadas al cliente y contador en 1. (ii) Con `CoalesceStreamingUpdates = false`: 0 llamadas y contador en 1. Caso rojo, sólo en (ii): una subclase que sólo sobrescribe `ReadCacheAsync` deja el contador en 0. En (i) esa misma subclase da 1, y la prueba lo afirma, para que nadie la invierta.»

P2-15 sigue diciendo «las cinco», y la (2b) incluye los dos modos.

**C-3 (reversión).** «El conteo por `ReadCacheStreamingAsync`, porque sin él el contador miente en el camino por streaming» pasa a «las dos sobrescrituras, porque sin la de `ReadCacheStreamingAsync` el contador deja de contar en cuanto alguien pone `CoalesceStreamingUpdates = false`».

**C-4 (estados en C que ya se pueden levantar).** Mi sonda compiló y corrió la firma de `ReadCacheStreamingAsync`, la sobrescritura de `EnableCaching(IEnumerable<ChatMessage>, ChatOptions?)` y su valor por defecto con `ConversationId` ([5], [5']). El «Estado» de P2-06 y el comentario del fragmento («no se compiló») pasan a citar `P206v2-salida.txt`. Siguen en C hasta `Cableado/` sólo en el sentido de M8: la validación del núcleo sigue pidiendo las cinco pruebas allí.

**C-5 (barridos).** Además de los de la vuelta 2, `grep -n "ReadCacheStreamingAsync y no con ReadCacheAsync"` = 0 sobre BIT-16-04, N5 y la guía. La aplicación copia `P206v2-*` a `Integracion-Evidencia/C-operacion-demo/`, junto a `PC02-salida.txt`.

**Lo que no cambia.** Rama A, el nombre único, la clave con sesión y versión, la regla (b)/(a)/(c), el limitador en la entrada HTTP (M9), «Lo que se pierde» y los derivados (P-42, P-03, P2-02 `PIPE`, P2-15, RV-03, 06-Plan §3 fila `09` y §4 CTRL-08). La fila `09` del 06-Plan dice «por `GetResponseAsync` y por `GetStreamingResponseAsync`», y se mantiene, porque el contador da 1 por los dos caminos.

**Si la presidencia no admite la corrección vinculante en esta vuelta,** mi voto pasa a `NO_APLICAR` sólo para las tres frases de §2, como deuda declarada. El resto se aplica igual, porque esas tres frases son la única diferencia entre aplicar y no aplicar. No hay disparador de REED-16 §12: es una elección técnica dentro de las restricciones.

## 4. Nota para P2-15

Con C-2, P2-15 levanta el bloqueo de N5 §4.2 con las cinco pruebas de P2-06, y la (2b) incluye los dos modos. No cambia nada más.
