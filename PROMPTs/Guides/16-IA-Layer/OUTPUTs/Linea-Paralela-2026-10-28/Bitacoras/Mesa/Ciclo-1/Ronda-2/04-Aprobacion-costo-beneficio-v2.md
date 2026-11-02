---
doc_id: BIT-16-C1-R2-04-CB-V2
doc_type: aprobacion
title: Aprobación del juez de costo-beneficio, segunda ronda del ciclo 1, vuelta 2
status: entregado
origin: agent
owner: juez de costo-beneficio (REED-16 §9.4)
last_review: 2026-10-28
audience: [presidencia, cuerpo auditor, aplicación]
traces: [Ronda-2/03-Parches.md (Vuelta 2, P2-06), Ronda-2/04-Aprobacion-costo-beneficio.md, Mesa/Ciclo-1/07-Dictamen-Presidencia.md, Ronda-2/evidencia-operacion-telemetria/PC02-salida.txt]
---

# Aprobación del juez de costo-beneficio, segunda ronda, vuelta 2

Función: **¿el beneficio justifica el costo?**, más el chequeo obligatorio de capa. Esta vuelta juzga sólo P2-06 vuelta 2, que reemplaza entera a la vuelta 1 de §2 (no aplicada).

**Resultado:** P2-06 → **APLICAR**. Capa correcta: sí. No pide turnos de modelo; sí pide una compilación con el recurso `build`, que ya estaba prevista.

## 1. Comprobaciones propias (sin turnos de modelo)

Fuente: documentación XML del paquete, `~/.nuget/packages/microsoft.extensions.ai/10.11.0/lib/net10.0/Microsoft.Extensions.AI.xml`, leída el 2026-10-28.

- `CachingChatClient.ReadCacheStreamingAsync(String, CancellationToken)` (l. 717–720): «This is used when there is a call to `IChatClient.GetStreamingResponseAsync`». `DistributedCachingChatClient` lo sobrescribe (l. 1086). Esto confirma la base de la mejora que pedí en la vuelta 1 y de la prueba (2b).
- `CoalesceStreamingUpdates` (l. 680): existe y su `true` coalesce los fragmentos. La frase «1 por acierto, no por fragmento» es coherente con el snippet, que incrementa una sola vez por lista devuelta.
- `CachingChatClient.EnableCaching(messages, options)` (l. 751–764): existe; en `remarks` dice que la implementación por defecto devuelve `true` mientras `options` no tenga `ConversationId`. Coincide palabra por palabra con lo que afirma el parche para la regla (b).
- `DistributedCachingChatClient.CacheKeyAdditionalValues` (l. 1079–1081): existe y es de instancia («augment the other values used to inform the cache key»). Sostiene la regla (a) y la condición de la clave con sesión.

## 2. Juicio de costo-beneficio

| Elemento | Costo | Beneficio | Juicio |
|---|---|---|---|
| Un solo nombre, `TelemetriaDeIA.AciertosDeCache` = `"movilidadurbana.ai.cache.aciertos"` | Una constante más en P-42 y un grep | Elimina dos nombres para un mismo instrumento; la prueba (2) falla si el nombre cambia | Barato y cierra retrabajo. Se aplica |
| Conteo por `ReadCacheStreamingAsync` + prueba (2b) con caso rojo | Unas líneas y una prueba con doble | La métrica deja de dar 0 en el camino real de la demo, que transmite | Es exactamente la mejora que pedí. El caso rojo es lo que hace que la prueba valga. Se aplica |
| Regla (b) en la demo, sin caché por defecto | Cero: es no registrar algo | Ningún dato viejo tras alta o baja; nada que mantener en la demo | La rama más barata posible. Se aplica |
| Regla (a) en `Examples/09` (`VersionDeDatos`) + prueba (4) con caso rojo | Un valor por sesión, un incremento en los casos de uso que escriben y una prueba | Enseña la caché con herramientas sin servir datos viejos; el límite está declarado | Se paga una vez, en el ejemplo donde se enseña la caché. Justificado |
| (c) descartada | — | Evita una garantía falsa que costaría corregir la guía publicada | Correcto |
| Limitador fuera de la cadena (M9) | Cero: M9 ya existe y ya tiene su prueba | Quita una contradicción entre R-C07 y M9 | Se aplica |
| Snippet en nivel C hasta compilar | Una compilación con `build` | No publica una firma no compilada (`ReadCacheStreamingAsync`) | Correcto |

**Capa.** El defecto nació en la integración (R-C07, M8) y en N5 §4.1, que copiaron el hueco de la sonda; la sonda es evidencia y no se reescribe (sólo agregado). El parche corrige M8, R-C07, MI-15 y N5, y arrastra los derivados (P-42, P2-15, RV-03, 06-Plan fila `09` y CTRL-08, `PIPE` por la nota de P2-02). Es la capa correcta.

## 3. Precisiones para la aplicación (no cambian el parche)

1. **La rama opcional del limitador no se toma.** El parche deja a la aplicación la posibilidad de «mantener además un limitador dentro de la cadena». No hay información nueva que lo justifique y tomarla obliga a reescribir la nota y a mover la prueba (2) de P-03. Decido en costo: el limitador queda sólo en la entrada HTTP (M9). Si alguien quiere abrir esa rama, la abre con una nota y su motivo (la reversión del parche ya lo prevé).
2. **Dónde vive `VersionDeDatos` en `Examples/09`.** El snippet usa `version.Actual`, pero el parche no dice qué componente la guarda. Como debe sobrevivir entre scopes, va en el mismo almacén por sesión que ya existe (el de D-11, P2-03), no en un componente nuevo. Lo deja escrito la nota de `Examples/09` en el momento de compilar el snippet; no requiere otra vuelta.
3. **Barrido de `ia.cache.aciertos`.** El grep = 0 se corre sobre la guía, `Examples/` y `Demos/`. En la bitácora el nombre viejo queda en la vuelta 1 como antecedente, y eso es correcto por «sólo agregado».
4. **P2-15** pasa a «las cinco de P2-06», como dice el derivado. Esto sustituye la cuenta de «cuatro» de mi vuelta 1 (§2, fila P2-15), que no contemplaba la prueba (4).

## 4. Nota para la presidencia

Con esta vuelta, mis tres MEJORAR_PLAN de la vuelta 1 quedan así: P2-06 atendida y aprobada aquí. P2-03 y P2-10 se juzgan en sus propias vueltas. No hay nada para ESCALAR (REED-16 §12).
