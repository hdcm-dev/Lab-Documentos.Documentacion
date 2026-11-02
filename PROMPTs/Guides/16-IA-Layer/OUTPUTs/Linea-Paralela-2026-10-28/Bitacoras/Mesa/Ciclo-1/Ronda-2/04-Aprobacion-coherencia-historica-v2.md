---
doc_id: BIT-16-C1-R2-04-COH-V2
doc_type: aprobacion
title: Aprobación del juez de coherencia histórica, ronda 2 del ciclo 1, vuelta 2 (P2-06)
status: entregado
origin: agent
owner: juez de coherencia histórica (REED-16 §9.4)
last_review: 2026-10-28
audience: [presidencia, cuerpo-auditor, aplicación]
traces: [Ronda-2/03-Parches.md (P2-06 vuelta 2), Ronda-2/04-Aprobacion-coherencia-historica.md (mejora «P2-06 — ubicar el limitador»), Ronda-2/04-Aprobacion-evidencia.md (V8), Ronda-2/04-Aprobacion-impacto.md (P2-06), Ronda-2/04-Aprobacion-costo-beneficio.md (P2-06), Ronda-2/04-Aprobacion-riesgo.md (P2-06), Ronda-2/evidencia-operacion-telemetria/PC02-*, Mesa/Ciclo-1/03-Parches.md (P-03, P-42, RV-03), BIT-16-04 (R-C07, M8, M9, MI-15 l. 355), N5 §4.2 (nota P-03), 07-Dictamen-Presidencia.md]
---

# Aprobación de coherencia histórica — ronda 2, vuelta 2: P2-06

**Pregunta fija.** ¿El parche es coherente con DC-01…DC-08, I-06, BIT-16-04, el ciclo 1 y el dictamen de presidencia? ¿Corrige en la capa donde nació el defecto?

## Decisión

| Parche | Decisión | ¿Capa correcta? |
|---|---|---|
| P2-06 (vuelta 2) | **APLICAR**, con una precisión de aplicación sobre el limitador (§3) | Sí |

## 1. Capa

El orden del pipeline nació en R-C07 y en N5 §4.1/§4.2. La clave de caché nació en M8 y el nombre de la fuente en MI-15/P-42. La vuelta 2 deja la nota en esos mismos lugares: R-C07, M8, MI-15, N5 §4.1 y §4.2. También anota los derivados del plan (06-Plan §3 fila 09, §4 CTRL-08, §6 RV-03) y el nodo `PIPE` de §6.2 por la nota consolidada de P2-02, que fue lo que pedí en la vuelta 1. Todo va por nota fechada. No reescribe texto de la bitácora, y la excepción del dictamen §1 no se usa.

Precisión de forma: en «Derivados», «RV-03 reemplazada» se lee como RV-03 reemplazada **por nota** en 06-Plan §6, como dice «Destino». No se edita la fila in situ.

## 2. Coherencia con lo firme y con la vuelta 1

| Punto | Comprobación | Resultado |
|---|---|---|
| C1-37 = B (4-1) | La cadena es caché → `UseFunctionInvocation` → `UseOpenTelemetry` → cliente. La doble capa queda sólo como alternativa descartada, por el doble conteo medido (PC02-salida.txt l. 34: `input n=3 suma=48`, frente a 24 en l. 11) | Coherente. Mi voto por la doble capa perdió, y la vuelta 2 no lo reabre |
| C1-37-clave = A (5-0) | `CacheKeyAdditionalValues` con `SessionId`, y además `VersionDeDatos` en la rama (a). La salida l. 56–61 muestra el cruce sin sesión y los dos fallos con sesión. «No se revierte» fija la condición | Coherente |
| Nombre único (V8 de evidencia) | `TelemetriaDeIA.AciertosDeCache = "movilidadurbana.ai.cache.aciertos"`, el que emitió la sonda (PC02-Program.cs l. 23; salida l. 14 y 23). `ia.cache.aciertos` desaparece y se barre con grep en la guía | Coherente con P-42/MI-15: BIT-16-04 l. 355 ya ubica el `Counter<long>` en el `Meter` de `TelemetriaDeIA.Fuente`, y la sonda lo crea en `new Meter(Fuente)` (l. 22). P-42 suma la constante como derivado |
| Conteo por streaming (costo-beneficio) | Lo verifiqué en la documentación XML del paquete (`~/.nuget/packages/microsoft.extensions.ai/10.11.0/lib/net10.0/Microsoft.Extensions.AI.xml`, 2026-10-28): `CachingChatClient.ReadCacheStreamingAsync` (l. 717), `DistributedCachingChatClient.ReadCacheStreamingAsync` (l. 1086), `CoalesceStreamingUpdates` (l. 680) y `EnableCaching(IEnumerable<ChatMessage>, ChatOptions)` (l. 751) existen en 10.11.0 | Coherente con P2-02: la página de la demo transmite `TextoParcial` (P-14, P-40 firmes). El caso rojo (2b) evita que la métrica quede rota en el camino real |
| Regla para datos que cambian (impacto, riesgo) | La demo aplica (b): por defecto no registra la caché. (a) va en `Examples/09`, con su límite declarado. (c) queda descartada con motivo. «Lo que se pierde» suma la frescura, y la frase «no vuelve a ejecutar las herramientas» respalda PC02 l. 13 | Coherente con P2-03 (la demo sin herramientas de escritura en el modelo; las escrituras por la operación normal): la condición de (a), «sin herramientas que escriban», se cumple en `Examples/09`. También es coherente con el perímetro de C1-48 = A: la técnica se enseña en el ejemplo dedicado y la demo conserva el valor seguro. `EnableCaching` queda en C hasta que compile, y eso no afirma lo que no se midió |
| Ubicación del limitador (mi mejora de la vuelta 1) | La nota dice que el limitador sale de la cadena y que es el de P-03/M9 (`AddRateLimiter`, `PermitLimit`/`QueueLimit` por configuración, 503 con `Retry-After`). En §6.2, `PIPE` lo pone en la entrada HTTP | Atendida. M8 y M9 ya no se leen como contradictorios |
| Pruebas y P2-15 | Pasan a ser cinco: (1), (2), (2b), (3), (4), más la demo si usa caché. P2-15 lo toma por remisión, y el bloqueo de N5 §4.2 se levanta con esas cinco | Coherente con la vuelta 1 de impacto y de costo-beneficio y con mi APLICAR de P2-15 |
| Reversión | Se pueden revertir la rama de P-03 y la regla (a)/(b)/(c), siempre por nota con su motivo. La clave con sesión, el conteo por streaming y el nombre único no se revierten | Coherente: lo irreversible es lo que está medido o votado 5-0 |

## 3. Precisión de aplicación: la rama condicional del limitador

La frase «Si se lo mantiene dentro de la cadena, la nota dice la posición y la prueba (2) de P-03 lo verifica ahí» viene de mi mejora de la vuelta 1. Ahora que la cotejo con el texto firme de P-03 (03-Parches l. 207; N5 l. 307; BIT-16-04 l. 673), veo que P-03 dice: «El límite va en la entrada HTTP, no dentro del pipeline de `IChatClient`». La rama condicional no contradice P-03 si se lee como lo que es: una advertencia para la aplicación del lector, no una opción de la guía. Para que la relectura integral no la tome como una puerta que P-03 cerró, la aplicación agrega a la misma nota esta frase:

> «En la demo y en `Examples/09` el limitador no está dentro de la cadena (P-03). La guía no presenta esa variante como opción. Si una aplicación la mantiene además del de la entrada HTTP, declara la posición y la prueba (2) de P-03 la verifica ahí.»

Esto no cambia la sustancia del parche ni pide otra vuelta. Corrige una redacción que nació en mi propia mejora.

## 4. Nota para la presidencia

- No hay ESCALAR: P2-06 no cambia el alcance de REED-16 §12 ni el caso único (I-06).
- El orden de 03 §4 se mantiene: P2-15 se aplica después de P2-06 con el conteo de cinco pruebas.
