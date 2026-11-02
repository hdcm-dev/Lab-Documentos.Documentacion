---
doc_id: BIT-16-C1-R2-04-RIESGO-V2
doc_type: aprobacion-de-parches
title: Aprobación del juez de riesgo, ronda 2, vuelta 2 (P2-06)
status: emitido
origin: agent
owner: juez de riesgo
last_review: 2026-10-28
audience: [mesa, presidencia, aplicación]
traces: [Ronda-2/03-Parches.md §P2-06 vuelta 2 (l. 528 y ss.), Ronda-2/04-Aprobacion-riesgo.md (P2-06, condiciones (a)–(c)), Ronda-2/evidencia-operacion-telemetria/PC02-*, 04-Integracion.md l. 158 y l. 550, 06-Plan-De-Redaccion.md §3 y §8, Mesa-Evaluadora.md l. 270]
---

# Aprobación del juez de riesgo, ronda 2, vuelta 2

Alcance: sólo P2-06, vuelta 2. Reemplaza entera la vuelta 1 de §2, que no se aplicó. Es la segunda y última vuelta de MEJORAR_PLAN que admite el marco (M, l. 270: «Máximo 2 vueltas»). Por eso, lo que encuentro abajo entra como condición vinculante de la aplicación y no como una tercera vuelta.

## 1. Verificaciones hechas

| # | Qué verifiqué | Fuente o comando | Resultado |
|---|---|---|---|
| R1 | Nombre del contador | `PC02-Program.cs` l. 23: `CreateCounter<long>("movilidadurbana.ai.cache.aciertos")`; `PC02-salida.txt` l. 14 y 23: `métrica movilidadurbana.ai.cache.aciertos (LongSum): :n=1,suma=1` | coincide con el parche. Un solo nombre |
| R2 | Acierto sin herramientas | `PC02-salida.txt` l. 13: «llamadas al cliente guionado=0; spans … =0; resultados de herramienta vistos por el cliente=0» | coincide. La frase entra en M8 y en «Lo que se pierde» |
| R3 | `EnableCaching` existe y su valor por defecto | XML de `microsoft.extensions.ai` 10.11.0 (caché local de NuGet, `lib/net10.0/Microsoft.Extensions.AI.xml`, l. 751–764): «The default implementation returns true as long as the options does not have a ChatOptions.ConversationId set» | coincide con el texto del parche |
| R4 | `CacheKeyAdditionalValues` | mismo XML, l. 1079–1081: propiedad `get; set` de `DistributedCachingChatClient`, de cada instancia | coincide. Es estado de la instancia, no del pedido (ver §2) |
| R5 | `GetCacheKey` sobrescribible | mismo XML, l. 1095: `DistributedCachingChatClient.GetCacheKey(messages, options, additionalValues)` | existe. Sirve para la condición de §2 |
| R6 | Scope de la demo | `04-Integracion.md` l. 158 («por petición o por circuito») y l. 550 («circuito Interactive Server»); `06-Plan` §2, `Demos/MovilidadUrbana.Asistente/` con página de chat Blazor | la página de la demo vive en un circuito: un scope dura toda la conexión, no un pedido HTTP |
| R7 | R-PRIV en el parche | lectura del texto exacto | sin direcciones, puertos, hosts ni credenciales |

## 2. Hallazgo residual (frescura, rama (a))

El parche sostiene que (a) vale porque «la instancia de `DistributedCachingChatClient` se crea por scope y lee `VersionDeDatos` al crearse» y porque «toda escritura llega en otro pedido HTTP, con otro scope que lee la versión nueva». Eso vale con scope por pedido, como en una API mínima. En un circuito Interactive Server (R6) no vale: la instancia se crea una vez por circuito, `CacheKeyAdditionalValues` queda fijo con la versión de ese momento (R4), y la escritura confirmada no cambia la clave de esa instancia. Por ejemplo: la persona pregunta «¿qué localidades cargué?», da de alta una y vuelve a preguntar en el mismo circuito. Recibe la respuesta vieja con 0 spans, que es justamente la garantía falsa que la regla quería evitar.

Hoy el riesgo no se materializa. La demo usa (b) por defecto, y (a) vive en `Examples/09`. Pero el parche deja abierta la salida «si la redacción quiere caché en la demo… pasa a (a)», y en ese camino el mecanismo falla. Además, la prueba (4) tal como está escrita («versión de 0 a 1») pasa igual si el doble crea una instancia nueva entre las dos lecturas. No detectaría el defecto.

## 3. Mis condiciones de la vuelta 1

| Condición (04-Aprobacion-riesgo.md, P2-06) | Estado en la vuelta 2 |
|---|---|
| (a) M8 y la guía dicen que un acierto no vuelve a ejecutar las herramientas | cumplida: M8 y «Lo que se pierde» (2) |
| (b) La demo no cachea pedidos con herramientas de lectura por defecto | cumplida: la regla (b) es el valor por defecto |
| (c) Un solo nombre de métrica, el que afirma la prueba | cumplida: `TelemetriaDeIA.AciertosDeCache`, con el barrido de `ia.cache.aciertos` = 0 |

## 4. Decisión

| Parche | Decisión | Capa correcta | Fundamento |
|---|---|---|---|
| P2-06 (vuelta 2) | **APLICAR con condición vinculante** | sí: el orden y la clave nacieron en R-C07/M8 y en N5 §4.1–4.2, y ahí se corrigen; MI-15 y P-42 por la constante | atiende las cinco mejoras y mis tres condiciones con evidencia propia verificada (R1–R5). Queda el hallazgo de §2, que se cierra con una condición de texto y de prueba, sin otra vuelta (M, l. 270) |

**Condición vinculante de la aplicación (sin vuelta nueva):**

1. En la regla (a), «lee `VersionDeDatos` al crearse» se reemplaza por esto: **la versión se lee en cada pedido, no al crear la instancia**. Se logra sobrescribiendo `GetCacheKey` para que sume la versión vigente de la sesión, o fijando `CacheKeyAdditionalValues` antes de cada llamada. La razón «toda escritura llega en otro pedido HTTP, con otro scope» queda sólo como caso de la API, y se agrega: «en un circuito Interactive Server el scope dura toda la conexión, así que una versión leída al crear la instancia queda vieja». El fragmento de `CacheConContador` sigue en nivel C hasta que compile.
2. La prueba (4) de `Cableado/` hace la lectura cacheada, la escritura confirmada y la segunda lectura **con la misma instancia del cliente**. Caso rojo adicional: la versión leída al crear la instancia da acierto.
3. Si la demo pasa a (a), esta prueba (4) corre con la misma instancia por circuito.

Reversión: si la aplicación elige (b) también para `Examples/09`, la condición queda sin objeto y se dice así en la nota. No se revierten el nombre único, el conteo por `ReadCacheStreamingAsync` ni la sesión en la clave.

Derivados que no cambian: P2-15 («las cinco»), RV-03, CTRL-08 y PIPE de §6.2, tal como los escribe el parche. La condición 2 se lee dentro de la prueba (4) que ya cuentan.
