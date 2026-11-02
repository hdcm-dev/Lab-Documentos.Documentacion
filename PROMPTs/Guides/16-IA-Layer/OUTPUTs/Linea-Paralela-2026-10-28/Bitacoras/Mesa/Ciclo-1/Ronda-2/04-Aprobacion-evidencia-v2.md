---
doc_id: BIT-16-C1-R2-04-EVID-V2
doc_type: aprobacion-de-parches
title: Aprobación de la segunda ronda del ciclo 1, vuelta 2 — juez de evidencia (P2-06)
status: entregado
origin: agent
owner: juez de evidencia de la mesa de aprobación
last_review: 2026-10-28
audience: [presidencia, aplicación, cuerpo auditor]
traces: [Mesa/Ciclo-1/07-Dictamen-Presidencia.md; Mesa/Ciclo-1/Ronda-2/03-Parches.md §Vuelta 2 P2-06; Mesa/Ciclo-1/Ronda-2/04-Aprobacion-*.md (vuelta 1); Ronda-2/evidencia-operacion-telemetria/PC02-*; Ronda-2/evidencia-aprobacion-evidencia/P2-06v2-*; M§5.5; REED-16 §12]
---

# Aprobación de la segunda ronda del ciclo 1, vuelta 2 — juez de evidencia

Decido sobre la vuelta 2 de **P2-06** (`03-Parches.md`, «Vuelta 2»). Contesto dos cosas: si lo que afirma tiene respaldo, y si corrige en la capa donde nació el defecto (M§5.5). Las rutas son relativas a `OUTPUTs/Bitacoras/`. R-PRIV: acá no hay direcciones, puertos, usuarios ni credenciales. Las reglas de §0 de mi vuelta 1 siguen valiendo. Como esta es la segunda y última vuelta (M§5.5: «máximo 2 vueltas»), el ajuste que pongo abajo va con el texto de reemplazo completo, para que la aplicación lo copie sin interpretar nada.

## 1. Verificaciones que hice hoy (2026-10-28, 14:15–14:40 -03)

| # | Qué | Fuente o comando | Resultado |
|---|---|---|---|
| W1 | Nombre del contador | `Ronda-2/evidencia-operacion-telemetria/PC02-Program.cs` l. 23; `PC02-salida.txt` l. 14 y 23 | `CreateCounter<long>("movilidadurbana.ai.cache.aciertos")`. En la salida: `métrica movilidadurbana.ai.cache.aciertos (LongSum): :n=1,suma=1`. **Coincide.** Mi ajuste de la vuelta 1 queda atendido |
| W2 | Acierto sin herramientas, doble conteo y spans de la rama A | `PC02-salida.txt` l. 6–14 y 34 | Fría: `orchestrate_tools`, `chat`, `execute_tool …`, `chat`. Caliente: `llamadas … =0; spans … =0; resultados de herramienta … =0`. Doble capa: `input:n=3,suma=48` frente a 24. **Coincide** |
| W3 | Documentación XML de MEAI 10.11.0 | `microsoft.extensions.ai/10.11.0/lib/net10.0/Microsoft.Extensions.AI.xml` (caché local de NuGet) | `ReadCacheStreamingAsync`: «This is used when there is a call to `GetStreamingResponseAsync`». `CoalesceStreamingUpdates`: «The default is `true`». `EnableCaching`: «returns `true` as long as the options does not have a `ConversationId` set». **El texto existe como lo cita el parche**, pero la documentación de `ReadCacheStreamingAsync` no dice que dependa de `CoalesceStreamingUpdates`. Por eso hizo falta W4 |
| W4 | **Qué método lee la caché por streaming** (sonda sin modelo, cliente con guion) | `Ronda-2/evidencia-aprobacion-evidencia/P2-06v2-Program.cs` + `P2-06v2.csproj`. Recurso `build`: `<envoltorio-de-turnos> build aprobacion-evidencia-v2 "…" 20 -- docker run --rm -v <trabajo>:/w -v <volumen-nuget>:/root/.nuget/packages -w /w mcr.microsoft.com/dotnet/sdk:10.0 sh -c 'dotnet run -c Release'`. Salida: `P2-06v2-salida.txt` (SDK 10.0.403, runtime 10.0.14, MEAI 10.11.0.0) | Con `CoalesceStreamingUpdates = true`, **que es el valor por defecto**, el acierto por streaming pasa por `ReadCacheAsync=1/1 acierto; ReadCacheStreamingAsync=0/0` y escribe con `WriteCacheAsync`. Con `false`: `ReadCacheAsync=0/0; ReadCacheStreamingAsync=1/1`. **La afirmación del parche es falsa con los valores por defecto** (ver §2) |
| W5 | Caso rojo de (2b) | misma sonda, bloques [2] y [2c] | Subclase que sólo sobrescribe `ReadCacheAsync`: con el valor por defecto, `aciertos contados=1`, así que el caso rojo **no da 0** y la prueba (2b), tal como está escrita, falla por el lado equivocado. Con `CoalesceStreamingUpdates=false`, `aciertos contados=0`: ahí el hueco existe y el caso rojo lo detecta |
| W6 | Regla (b), sobrescritura de `EnableCaching` | bloque [3] | `false` si hay `Tools`: dos pedidos con herramientas dan `llamadas=4` (no cachea). Dos pedidos sin herramientas dan `llamadas=1` (cachea). **Compila y hace lo que dice el parche.** Sale de C para la firma `protected override bool EnableCaching(IEnumerable<ChatMessage>, ChatOptions?)` |
| W7 | Regla (a), una instancia por scope con `CacheKeyAdditionalValues = [SessionId, VersionDeDatos]` | bloque [4] | Con la versión en la clave, la lectura después de la escritura (v0 → v1) da `llamadas=2 → fallo`. Caso rojo, sólo `[SessionId]`: `llamadas=0 → ACIERTO`. **Coincide con la prueba (4) y su caso rojo** |
| W8 | Limitador fuera de la cadena | `Mesa/Ciclo-1/03-Parches.md` l. 185–207 (P-03) | `AddRateLimiter`, `AI:Concurrencia:Permisos` y `AI:Concurrencia:Cola`, 503 con `Retry-After`, y «El límite va en la entrada HTTP, no dentro del pipeline de `IChatClient`». **Coincide** con la remisión de M8 a M9 |
| W9 | Firma de `ReadCacheStreamingAsync` del snippet | W4 compiló `protected override async Task<IReadOnlyList<ChatResponseUpdate>?> ReadCacheStreamingAsync(string key, CancellationToken ct)` | **Compila.** El snippet `CacheConContador` con los dos métodos ya no tiene que quedar en C por la firma. Lo que todavía no está probado es la composición en `Examples/09` |

Intermedios en `{dir-de-trabajo}/aprobacion-evidencia-v2/`, con `bin/` y `obj/` borrados. Ninguna corrida fue contra el modelo, así que R-LLM no aplica.

## 2. El defecto que queda

Lo que el parche afirma (M8 y la fila de la tabla de mejoras):

> «En MEAI 10.11.0, `GetStreamingResponseAsync` lee la caché con `ReadCacheStreamingAsync` y no con `ReadCacheAsync`. Por eso, si sólo se sobrescribe el primero, los aciertos por streaming no se cuentan.»

Lo que midió W4: con `CoalesceStreamingUpdates = true`, que es el valor por defecto que el mismo parche cita, `GetStreamingResponseAsync` guarda la respuesta ya unida con `WriteCacheAsync` y la lee con `ReadCacheAsync`. `ReadCacheStreamingAsync` se usa sólo con `CoalesceStreamingUpdates = false`. La sonda PC-02, con un solo método sobrescrito, ya contaba los aciertos por streaming con los valores por defecto (W5: 1).

Qué se mantiene y qué no:

- **El diseño queda en pie.** Sobrescribir los dos métodos es correcto y necesario: si alguien pone `CoalesceStreamingUpdates = false`, sin el segundo método el contador marca 0 (W5, [2c]). En los dos modos se usa uno solo de los dos caminos, así que no hay doble conteo y vale «1 por acierto, no por fragmento» (W4).
- **Lo que está mal es la explicación y la prueba.** El caso rojo de (2b), «sólo `ReadCacheAsync` → 0», con los valores por defecto da 1. La prueba quedaría roja por una causa que no existe, o alguien la «arreglaría» quitando el caso rojo. Lo mismo pasa con la reversión («sin él el contador miente en el camino por streaming»): con el valor por defecto no miente.
- La frase sobre los fragmentos («llega en menos fragmentos que la respuesta original») no está medida. En W4 la respuesta fría y la caliente dieron 3 fragmentos cada una. La documentación sólo dice que la caché «intenta» unirlos para reducir el número. La frase pasa a «puede llegar en menos fragmentos».

La corrección cambia una explicación, una cifra esperada y un rótulo de prueba. No cambia el diseño ni la regla elegida. Es una cita corregida con evidencia que ya corrió, así que entra como **ajuste vinculante**, con el texto de §3 para copiar tal cual.

## 3. Ajuste vinculante de P2-06 (vuelta 2)

La aplicación hace estos reemplazos en el texto de la vuelta 2 antes de pegarlo en los destinos, y los registra en `Ronda-2/05-Aplicacion.md`:

1. **M8**, en lugar de la frase que va de «Se incrementa al sobrescribir…» hasta «…no por fragmento.»:
   > «Se incrementa al sobrescribir `ReadCacheAsync` y `ReadCacheStreamingAsync` cuando devuelven un valor. En MEAI 10.11.0, `GetStreamingResponseAsync` lee la caché con `ReadCacheAsync` cuando `CoalesceStreamingUpdates` vale `true` (el valor por defecto: guarda la respuesta ya unida), y con `ReadCacheStreamingAsync` cuando vale `false` (sonda `P2-06v2-salida.txt`, bloque [1]). Sobrescribir los dos deja el contador correcto en los dos modos. Con un solo método, el contador marca 0 en el modo que no cubre (bloque [2c]). Un acierto por streaming puede llegar en menos fragmentos que la respuesta original. El contador cuenta 1 por acierto, no por fragmento.»
2. **Tabla de mejoras, fila de costo-beneficio:** «El contador se incrementa en `ReadCacheAsync` y en `ReadCacheStreamingAsync`, con la nota sobre `CoalesceStreamingUpdates`: con `true`, el valor por defecto, el streaming lee por `ReadCacheAsync`, y con `false` lee por `ReadCacheStreamingAsync`.»
3. **Verificación (2b)**, reemplazada por: «(2b) Lo mismo por `GetStreamingResponseAsync`, con `CoalesceStreamingUpdates` en `true` y en `false`: 0 llamadas al cliente y el contador en 1 en los dos casos. El caso rojo, una subclase que sólo sobrescribe `ReadCacheAsync`, con `CoalesceStreamingUpdates = false`, tiene que dejar el contador en 0. Así se demuestra que la prueba detecta el hueco.»
4. **Reversión, segundo punto:** «el conteo en los dos métodos de lectura, porque sin `ReadCacheStreamingAsync` el contador marca 0 con `CoalesceStreamingUpdates = false`».
5. **Estado:** donde dice «El contador por `ReadCacheStreamingAsync`, la regla (a) y la sobrescritura de `EnableCaching` no se probaron», se lee: «El contador por los dos métodos, la regla (a) con una instancia por scope y la sobrescritura de `EnableCaching` se probaron en una sonda (`Ronda-2/evidencia-aprobacion-evidencia/P2-06v2-salida.txt`), no en `Cableado/`.» La condición de no declarar validado M8 hasta las cinco pruebas en `Cableado/` sigue igual.
6. **Rótulo del snippet:** «La firma de `ReadCacheStreamingAsync` es la que documenta el XML del paquete y no se compiló» pasa a «y compiló en `P2-06v2-Program.cs`». El fragmento sigue en C hasta que compile **dentro de `Examples/09`**.
7. **Derivados:** en la fila de 06-Plan §3 `09`, «por `GetResponseAsync` y por `GetStreamingResponseAsync`» pasa a «por `GetResponseAsync` y por `GetStreamingResponseAsync` con `CoalesceStreamingUpdates` en `true` y en `false`». RV-03 y P2-15 no cambian: la prueba sigue llamándose (2b).
8. La aplicación copia `P2-06v2-salida.txt` a `Integracion-Evidencia/C-operacion-demo/` junto con `PC02-salida.txt`.

Si la aplicación no puede incorporar estos reemplazos tal cual, no hay otra vuelta: P2-06 pasa a deuda con este motivo, y M8 queda bloqueado por P2-15.

## 4. Decisión

| Parche | Decisión | ¿Capa donde nació? | Fundamento | Ajuste |
|---|---|---|---|---|
| P2-06 (vuelta 2) | **APLICAR con ajuste vinculante** | **Sí.** El orden nació en R-C07 y en N5 §4.1/§4.2, la clave y el contador en M8, y el limitador en M9. La nota corrige cada uno en su lugar, y los derivados (P2-02 `PIPE`, P2-15, RV-03, 06-Plan) van por remisión, sin reescribir capas ajenas | Las cinco mejoras están atendidas: un solo nombre, el medido (W1); regla (b)/(a) con (c) descartada, con la regla (a) y su caso rojo reproducidos (W7) y `EnableCaching` probado (W6); limitador fuera de la cadena, en coherencia con P-03 (W8); condiciones de riesgo (a)–(c). El doble conteo y los 0 spans siguen respaldados (W2). La única afirmación falsa es la del mecanismo de streaming (W4, W5): una corrección de cita con evidencia ya corrida, que no toca el diseño | §3, puntos 1–8 |

ESCALAR: no corresponde. Ninguno de los disparadores de REED-16 §12 aplica, porque no hay cambio de alcance, ni ítem sin mayoría, ni decisión irreversible.
