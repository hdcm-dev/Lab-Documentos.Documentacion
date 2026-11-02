---
doc_id: BIT-16-C1-R2-04-CB
doc_type: aprobacion
title: Aprobación del juez de costo-beneficio, segunda ronda del ciclo 1, vuelta 1
status: entregado
origin: agent
owner: juez de costo-beneficio (REED-16 §9.4)
last_review: 2026-10-28
audience: [presidencia, cuerpo auditor, aplicación]
traces: [Ronda-2/03-Parches.md, Ronda-2/02-Voto-costo-beneficio.md, Mesa/Ciclo-1/07-Dictamen-Presidencia.md, Ronda-2/00-Boleta.md, Ronda-2/Consulta-operacion-telemetria.md, Ronda-2/Consulta-AH-02-formal.md, Ronda-2/Consulta-AH-01-seguridad.md]
---

# Aprobación del juez de costo-beneficio, segunda ronda, vuelta 1

Función: **¿el beneficio justifica el costo?**, más el chequeo obligatorio de capa (¿el parche corrige donde nació el defecto?). Mido el costo en código y pruebas que hay que mantener, en turnos de modelo y en el riesgo de retrabajo o de escalada.

**Resultado:** 12 APLICAR, 3 MEJORAR_PLAN (P2-03, P2-06, P2-10), 0 NO_APLICAR, 0 ESCALAR. Los 15 parches corrigen en la capa correcta. Ninguno pide corridas nuevas contra el modelo, y ninguna de mis mejoras las pide.

## 1. Comprobaciones propias de esta vuelta

Todas son de lectura o de cálculo, sin turnos de modelo.

- **Aritmética de las cifras que entran en la guía** (`python3 -I`, Wilson 95 %, z = 1,96): 12/16 → [0,505; 0,898]; 40/40 → [0,912; 1]; 5/6 → [0,436; 0,970]; 0/10 → [0; 0,278]; 10/10 → [0,722; 1]; 1/10 → [0,018; 0,404]. McNemar exacto con 6 discordantes en un mismo sentido: p = 2·0,5⁶ = 0,031. Cota para 0/10: 1 − 0,05^(1/10) = 0,259. Costo del juez (P2-11): de 60 a 120 evaluaciones × 34 s = 34–68 min en el segundo servidor, y × 154 s = 2,57–5,13 h en la estación. **Todo coincide** con P2-10, P2-11, P2-12 y P2-13.
- **API de caché de MEAI 10.11.0** (documentación XML del paquete en la caché local de NuGet, `microsoft.extensions.ai/10.11.0/lib/net10.0/Microsoft.Extensions.AI.xml`). `CachingChatClient` y `DistributedCachingChatClient` exponen `ReadCacheAsync` y también `ReadCacheStreamingAsync`. Sobre el segundo, la documentación dice: «This is used when there is a call to `IChatClient.GetStreamingResponseAsync`». `CoalesceStreamingUpdates` vale `true` por defecto. La sonda `evidencia-operacion-telemetria/PC02-Program.cs` (l. 90–95) sobrescribe sólo `ReadCacheAsync`. Esto motiva la mejora de P2-06.
- **Cifras de recarga** (`Consulta-operacion-telemetria.md`, tabla de PC-06). Con el 4b, el paso 3 («sin `num_ctx`, cargado con 8192», que es la recarga al alternar) da 10,48–16,06 s con N = 5. El rango 10,5–22,8 s con N = 15 junta el paso 1 (frío, 11,51–19,20), el paso 2 (carga con 8192, 11,36–22,80) y el paso 3. Esto motiva la mejora de P2-10.
- **Texto de la boleta, C1-48 A** (`00-Boleta.md` l. 46): «Quedan afuera de la demo […] `AyudaRag` y **la página de streaming de tokens**». Esto decide la lectura que P2-02 deja a la aprobación.
- **P2-01 (b):** `grep -c` del prefijo del home sobre `evidencia-AH-01-seguridad/README.md` da 1, lo mismo que encontró el diseño.
- **Presupuesto R-LLM-5:** `Consulta-AH-02-formal.md` l. 93 dice «unas 90 llamadas: entra una tasa de tarea mínima (K = 10 × m = 5 = 50) o cuatro tasas de pedido de m = 10». Es «entra», no «llena», así que no hay contradicción.

## 2. Dictamen por parche

| Parche | Decisión | Capa correcta | Fundamento de costo-beneficio |
|---|---|---|---|
| P2-01 | **APLICAR** | Sí | Es un grep más sobre capturas que ya existen, con la prueba de diseño en rojo y en verde. Cubre una fuga irreversible desde el primer commit. La exclusión por valor exacto, y no por archivo, es la forma barata que no abre agujeros. Una precisión de uso, sin cambiar el parche: el `rc` del script es el AND de los tres recuentos. Sobre `OUTPUTs/`, mientras no haya commit, se corre con una `RPRIV_LISTA` de prueba que no coincida con nada (como hizo el diseño), para que el `rc` sólo refleje `patrones` y `cabeceras`. La lista privada se usa en el barrido previo al primer commit (dictamen §2). La aplicación lo deja escrito en 05-Aplicacion. |
| P2-02 | **APLICAR** | Sí | Es la rama barata que voté: D7, `AyudaRag` y el candidato se pagan una sola vez en `Examples/`. **Ratifico la lectura del parche sobre el streaming.** El texto votado dice «la página de streaming de tokens»: lo que sale de la demo es la página dedicada a `GetStreamingResponseAsync` y `ChatResponseUpdate`, que pasa a `Examples/02`. Eso es la lectura literal, no una interpretación. La página de chat de la demo conserva `EventoDelAsistente` con `EtapaIniciada`, `TextoParcial` y `Final` (P-14 y P-40 firmes). La alternativa del parche (sacar `TextoParcial`) contradice dos parches firmes y la prueba E1 de P-40. Eso costaría una escalada sin ningún beneficio, así que queda descartada. |
| P2-03 | **MEJORAR_PLAN** | Sí | La rama B es la barata: no hay almacén pendiente ni endpoint, y B1–B4 y D3 se prueban con dobles. La mejora está en una verificación. «Prueba por reflexión: ninguna `AIFunction` registrada en la demo invoca un método de escritura» no se puede hacer con reflexión, porque la reflexión de .NET no ve el cuerpo de los métodos. Hacerla exigiría analizar IL, que es caro y frágil. Ver la mejora abajo. |
| P2-04 | **APLICAR** | Sí | Hay un archivo fuera del árbol copiado y `diff -r` = 0. Las dos validaciones nuevas (`Enum.IsDefined` y el largo de 60) cuestan dos pruebas con dobles y cierran hallazgos E1 de AH-01. Registrar la divergencia de «piedra» en lugar de endurecer el endpoint copiado es lo correcto en costo: endurecer la copia es lo más caro del bloque y contradice C1-53 = A. No la elevo. |
| P2-05 | **APLICAR** | Sí | Es texto y una prueba (a)–(c) sin modelo que corrige una frase ya refutada con E1. Sobre la condición del título: si la redacción no encuentra en el momento la cita oficial del valor por defecto de `ValidateScopes` por entorno, tiene que tomar la salida de costo cero, que es el título en términos de `ValidateScopes = false`. No debe abrir una investigación por eso. |
| P2-06 | **MEJORAR_PLAN** | Sí | La rama A es la correcta y la más barata (voto C1-37 = B). Pero el contador, tal como está escrito, no cuenta los aciertos por streaming. En MEAI 10.11.0, `GetStreamingResponseAsync` lee la caché con `ReadCacheStreamingAsync` (documentación XML del paquete), y la sonda y el texto de M8 sólo sobrescriben `ReadCacheAsync`. La página de la demo transmite `TextoParcial` (P2-02). Si la demo usa caché, `ia.cache.aciertos` daría 0 aunque haya aciertos, y M8 se validaría en `Cableado/` con una métrica rota en el camino real. Arreglarlo cuesta unas líneas y una prueba con doble. Descubrirlo después cuesta corregir la guía publicada. |
| P2-07 | **APLICAR** | Sí | M13 ya compiló y corrió en la consulta (casos [A]–[G]). Lo que sigue es portarlo a `Examples/08`. El catálogo único es una sola fuente de herramientas, más barata de mantener que dos definiciones. M7 de CTX-PROD es texto con fuentes citadas. M6 concurrente se prueba sin modelo. |
| P2-08 | **APLICAR** | Sí | La tabla sale de mediciones ya pagadas, y el servidor falso de `Examples/01` la reproduce sin modelo. La regla de credenciales en `DelegatingHandler` es gratis y evita una fuga. Sacar el selector de la demo le quita una variante degradada que habría que probar en cada corrida. |
| P2-09 | **APLICAR** | Sí | Reemplaza un argumento refutado con E1 y E2, sin corridas nuevas. La prueba del handler sobre un NDJSON fijo es determinista y barata. La regla «mismo `num_ctx` en todos los clientes» evita recargas de 10 a 16 s en el único hueco de concurrencia, que es un beneficio operativo medido. |
| P2-10 | **MEJORAR_PLAN** | Sí (laboratorio / §R.6) | El rótulo del 4b frente al 2b es correcto, cumple R-LLM-3e en D1 y D3 y no pide otra corrida. La mejora está en la fila (2) propuesta para §R.6, «recarga del 4b al alternar `num_ctx`: carga de 10,5–22,8 s, N = 15». Esa fila mezcla la carga en frío (paso 1) y la carga con 8192 (paso 2) con la recarga al alternar (paso 3: 10,48–16,06 s, N = 5). P2-09 cita 10,5–16,1 s para lo mismo, y §R.6 es la tabla única de cifras: así la guía terminaría con dos números para un mismo hecho. El defecto nace en la consulta (línea 97 de `Consulta-operacion-telemetria.md`) y P2-10 lo copia. Se corrige en §R.6, que es la capa donde vive la cifra, con una nota fechada en la consulta. También resuelvo lo que el parche dejó a la aplicación: **entran las cinco filas** (con la (2) corregida), porque cada una tiene su archivo crudo. Volver a decidir en la aplicación cuesta una vuelta más sin información nueva. |
| P2-11 | **APLICAR** | Sí | Reemplaza «no medido» con cifras ya pagadas, que verifiqué aritméticamente. La demo sigue sin juez y no se calibra con 10–20 casos. Las tres condiciones medidas evitan corridas `Inconclusive` que gastarían turnos sin resultado. |
| P2-12 | **APLICAR** | Sí | El trabajo caro (la sonda L y la sonda A) ya se hizo. Lo que queda es texto y una prueba M14 con cliente falso. Un caso real del dominio (`Localidad.Nombre`) rinde más que el `Comentario` hipotético y no agrega código: `Examples/11` sale. La tasa L va como observación, con «el control sigue siendo M3». |
| P2-13 | **APLICAR** | Sí | La regla R-LLM es texto, y sus umbrales verifican (§1). Reemplazar el N ≥ 96, que viene de la aproximación normal, por R-LLM-3d no obliga a correr nada ahora. La compuerta `grep -L "estimando:"` cuesta nada. La tensión 1 reescrita con 12/16 y su estimando quita una afirmación refutable. |
| P2-14 | **APLICAR** | Sí | Son notas en los núcleos con fuentes fechadas y un experimento que ya compiló. Deja el sentido de «workflow» marcado `[C: término de C1-32]` en lugar de decidirlo, que es la forma más barata de no frenar la redacción de §7 y de no cerrar sin la decisión de la presidencia. No es una escalada de REED-16 §12. |
| P2-15 | **APLICAR** | Sí | Confirma el voto que cambié en esta ronda. Esperar las pruebas en `Cableado/` cuesta menos que reescribir N5 §4.2 después. Por la mejora de P2-06, «las tres de P2-06» pasan a ser cuatro: también la variante por streaming, si la demo usa caché. La aplicación lo agrega a la nota de P2-15. |

## 3. Mejoras pedidas (MEJORAR_PLAN)

### P2-03, verificación de B1

Donde dice «prueba por reflexión en `Cableado/`: ninguna `AIFunction` registrada en la demo invoca un método de escritura de un caso de uso», va:

> «En `Cableado/`: (i) el conjunto de nombres de las `AIFunction` que registra la demo (bucle y, si lo hubiera, MCP) es **igual** a una lista cerrada de herramientas de lectura declarada en la prueba; agregar una herramienta sin actualizar la lista hace fallar la prueba; (ii) cada herramienta registrada se invoca con argumentos válidos sobre repositorios espía, y el recuento de `SaveAsync` y `DeleteAsync` da 0.»

Cuesta lo mismo o menos que la reflexión, no necesita analizar IL y detecta el caso real: alguien que registra una herramienta nueva que escribe. La prueba de reflexión de P2-07 (ningún parámetro de herramienta con `sesion` o `session` en el nombre) sí se puede hacer por reflexión y queda como está.

### P2-06, contador de aciertos por streaming

En la nota de M8 y en N5 §4.1, donde dice «incrementado al sobrescribir `ReadCacheAsync` cuando devuelve una respuesta», va:

> «incrementado al sobrescribir `ReadCacheAsync` y `ReadCacheStreamingAsync` cuando devuelven un valor (MEAI 10.11.0: `GetStreamingResponseAsync` lee la caché con `ReadCacheStreamingAsync`; `CoalesceStreamingUpdates` es `true` por defecto, así que el acierto por streaming llega en menos fragmentos que la respuesta original).»

La verificación (2) de P2-06 suma la variante **por `GetStreamingResponseAsync`**: caché caliente → 0 llamadas al cliente, `ia.cache.aciertos` = 1. Es obligatoria en la demo si la demo usa caché, porque su página transmite. El snippet de `PC02-Program.cs` queda en C para ese punto hasta que compile la versión con los dos métodos (recurso `build`, `mcr.microsoft.com/dotnet/sdk:10.0`). P2-15 cuenta esta prueba entre las que levantan el bloqueo de N5 §4.2.

### P2-10, fila (2) de §R.6

La fila (2) se reemplaza por:

> «(2) recarga del 4b al alternar `num_ctx` (paso 3 de PC-06, sin `num_ctx` con el modelo cargado con 8192): 10,5–16,1 s de `load_duration`, N = 5, estación (`evidencia-operacion-telemetria/PC06-qwen3.5-4b-corto.jsonl`). Aparte, como referencia de carga y no de recarga: carga en frío 11,5–19,2 s y carga con `num_ctx` 8192 11,4–22,8 s, N = 5 cada una.»

Se agrega una nota fechada al pie de la consecuencia «§R.6 (cifras)» de `Consulta-operacion-telemetria.md` que remite a esta fila. Así la cifra de P2-09 y la de §R.6 son la misma. Verificación: `grep -n "22,8"` en la guía, sólo en la fila de carga y nunca junto a «alternar» o «recarga». Las cinco filas entran a §R.6.

## 4. Nota para la aplicación y la presidencia

- Ninguna de las tres mejoras consume turnos de modelo: son una prueba con espías, unas líneas y una prueba con doble, y la corrección de una fila.
- Lectura de «streaming de tokens» (P2-02): queda **ratificada la del parche** (§2). La presidencia no tiene que decidir nada sobre este punto.
- Lo que sigue elevado no cambia con esta aprobación: C1-32 y el apagado del segundo servidor.
