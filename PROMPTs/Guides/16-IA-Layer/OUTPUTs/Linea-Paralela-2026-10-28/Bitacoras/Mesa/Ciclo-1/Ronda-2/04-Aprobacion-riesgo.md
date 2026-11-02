---
doc_id: BIT-16-C1-R2-04-riesgo
doc_type: aprobacion-de-parches
title: Aprobación del juez de riesgo e irreversibilidad — ciclo 1, ronda 2, vuelta 1
status: entregado
origin: agent
owner: juez de riesgo e irreversibilidad (REED-16 §9.6; M§5.5)
last_review: 2026-10-28
audience: [presidencia, cuerpo-auditor, aplicación]
traces: [Mesa/Ciclo-1/Ronda-2/03-Parches.md, Mesa/Ciclo-1/Ronda-2/02-Voto-riesgo.md, Mesa/Ciclo-1/07-Dictamen-Presidencia.md, Mesa/Ciclo-1/04-Aprobacion-riesgo.md, M§5.5, REED-16 §12]
---

# Aprobación del juez de riesgo — ciclo 1, ronda 2, vuelta 1

**Qué pregunto en cada parche:** (1) si sale mal, ¿se puede deshacer?; (2) ¿qué riesgo le queda al lector o al laboratorio si se aplica tal cual?; (3) el chequeo obligatorio de M§5.5: **¿corrige en la capa donde nació el defecto?** Igual que en la vuelta del ciclo 1, una *condición* es una restricción de ejecución que la aplicación cumple sin volver al cuerpo auditor; cuando lo que falta es diseño, el parche vuelve como `MEJORAR_PLAN`.

## 0. Verificaciones propias (E1, 2026-10-28T14:07-03:00)

Las corrí en una carpeta del scratchpad de la sesión, fuera de `OUTPUTs/`; nada de lo de abajo se escribió en el repositorio salvo este archivo.

1. **Compuerta v2 de P2-01, tal cual está en 03-Parches** (extraje el bloque `bash` del parche sin tocarlo; `RPRIV_LISTA` con un token inexistente, así que `identificadores` no se mide acá; `RPRIV_SINTETICOS` con las dos líneas del parche):
   - sobre `OUTPUTs/`: `patrones=1 identificadores=0 cabeceras=0`, rc=1; `--detalle` lista sólo `Ronda-2/evidencia-senior-dotnet/R2-cuerpo-salida.txt:3`. Sin sintéticos: `cabeceras=3`, rc=1. **Reproduce la prueba de diseño de las 13:56.** La única coincidencia de patrón sigue siendo la ruta del home en la línea 16 de `Ronda-2/evidencia-AH-01-seguridad/README.md`;
   - caso rojo del parche (un `cap.jsonl` con el objeto en una sola línea y un `Authorization`): `cabeceras=1`, rc=1. Coincide;
   - **caso rojo 2, mío:** el mismo encabezado en un `cap.json` con formato indentado (`"<clave-de-cabeceras>": {` y la clave en la línea siguiente) y en un `.jsonl` con un espacio después de los dos puntos: `cabeceras=0`, **rc=0**. La compuerta deja pasar una credencial real;
   - **caso rojo 3, mío:** el mismo objeto de una línea dentro de un bloque ```` ```json ```` de un `guia.md`: `cabeceras=0`, **rc=0**. El patrón no mira `*.md`, y la guía es Markdown.
   - Probé además un patrón tolerante a espacios y saltos (`grep -Pzo` con `\s*`): detecta los casos 2 y 3, pero sobre `OUTPUTs/` con `*.md` incluido arrastra párrafos enteros de la bitácora (el `[^}]*` multilínea cruza tablas). O sea, la corrección existe pero es diseño, no un ajuste de la aplicación.
2. **Caché por fuera de las herramientas (P2-06).** `Ronda-2/evidencia-operacion-telemetria/PC02-salida.txt`, l. 13: con caché caliente, «llamadas al cliente guionado=0 … resultados de herramienta vistos por el cliente=0», respuesta «2». Un acierto **no vuelve a ejecutar las herramientas de lectura**: si entre los dos pedidos la persona dio de alta o de baja una localidad, la sesión recibe el «2» viejo. La clave con `SessionId` no lo evita, porque el riesgo no es de cruce sino de frescura. P-03 y P2-06 no dicen nada de vencimiento ni de invalidación. Además, la métrica de la sonda se llama `movilidadurbana.ai.cache.aciertos` (l. 14) y el parche escribe `ia.cache.aciertos`.
3. **Sonda D2 de P2-05.** `D-sonda-aprobacion-y-sesiones-Program.cs` l. 76 arma el contenedor con `new ServiceProviderOptions { ValidateScopes = validar }`, sin `ValidateOnBuild`. «Falla en cada llamada, no al arrancar» describe esa configuración, no el host web de Development, que el parche mismo marca como no probado.
4. **Capa de P2-05.** `Nucleos/N6-Caso-Movilidad-Urbana.md` T1 (l. 111) sigue diciendo «**No verificado**: qué `IServiceProvider` recibe `AIFunctionArguments.Services` cuando el cliente es singleton», y su tabla de antipatrones (l. 413) dice «Mezcla sesiones o falla al resolver». Ese «no verificado» es justamente lo que D2 midió, y ninguno de los dos lugares está en el destino de P2-05.
5. **Lectura del streaming (P2-02).** La boleta (`00-Boleta.md` l. 46) dice que en la opción A sale «**la página de streaming de tokens**», y P-05 del ciclo 1 (03-Parches l. 263) la lista como pieza aparte del chat. La página de chat con `EventoDelAsistente` es otra pieza (P-14 (3), P-40), firme.
6. **Segundo servidor (P2-10).** La consulta del segundo servidor (`Ronda-2/Consulta-*-ollama.md`), l. 53: el contenedor quedó **arriba** a pedido de la consulta, en el equipo que es el respaldo de contingencia de la estación caída; el modelo se descarga a los 10 min sin uso, pero el contenedor no.
7. `git status` no cambió desde mi voto (13:49): `16-IA-Layer/` sigue sin seguimiento. Todo lo de esta ronda es reversible; el primer commit y push de `OUTPUTs/` sigue siendo el único acto irreversible a la vista.

## 1. Resultado

**15 parches: 13 `APLICAR` (5 con condiciones), 1 `MEJORAR_PLAN` (P2-01), 0 `NO_APLICAR`, 0 `ESCALAR`.** Ninguno dispara REED-16 §12: ninguno toca `Lab-E2E.WebBlazor`, manda datos afuera, usa un proveedor con costo ni reabre una DC. P2-04 deja registrada la divergencia de la prueba «piedra» en lugar de endurecer la copia, que es lo que evita la escalada; la acepto así.

**P2-01 vuelve** porque es la compuerta que custodia el único acto irreversible y, como está escrita, da rc=0 con una credencial real en dos formatos comunes (§0.1). Una compuerta que pasa en falso es peor que no tenerla, porque cierra el criterio. Lo que no depende del script se puede aplicar ya (ver §3).

**Lectura del streaming que adopta esta aprobación (P2-02):** la de P2-02. «Streaming de tokens» de C1-48 = A es la página o el ejemplo dedicado a `GetStreamingResponseAsync` y `ChatResponseUpdate`, que vive en `Examples/02`. La página de chat de la demo conserva `IAsyncEnumerable<EventoDelAsistente>` con `EtapaIniciada`, `TextoParcial` y `Final`. Motivo desde el riesgo: la boleta nombra «la página de streaming» como pieza (§0.5), y sacar `TextoParcial` del chat no reduce superficie, porque el texto llega a la misma página por `Final` con la misma codificación de Razor; en cambio, rompería la prueba de P-40 y la cancelación, que es un control. La lectura literal queda descartada.

## 2. Condiciones de ejecución

| Parche | Condición | Por qué, desde el riesgo |
|---|---|---|
| P2-05 | (a) La frase 2 se acota a lo medido: «con `ValidateScopes = true` y sin `ValidateOnBuild`, como en la sonda, falla en cada llamada a la herramienta, no al construir el contenedor». (b) Nota de una línea en N6 T1 (cierra el «No verificado» con D2) y en la fila del antipatrón de N6 (l. 413), que remite a P2-05: «comparte un único espacio entre conversaciones, sin error». (c) Si un snippet de los derivados (N2 l. 277, N5 l. 239 y l. 448) registra `AddChatClient` por defecto con herramientas que resuelven servicios scoped, lleva la misma remisión. | (a) Evita una garantía nueva no medida («no falla al arrancar») sobre el host real. (b)(c) Chequeo de capa: la duda nació en N6 T1, y «falla al resolver» es la mitad que D2 mostró que no ocurre con `false`. |
| P2-06 | (a) M8 y la guía dicen que un acierto de caché no vuelve a ejecutar las herramientas de lectura y puede devolver un dato que ya cambió (PC02 l. 13). (b) Por defecto, **la demo no usa caché de respuestas** sobre pedidos con herramientas que leen datos de la sesión; la caché se enseña en `Examples/09`. Si la redacción la quiere en la demo, la clave suma una versión de los datos de la sesión y entra una cuarta prueba: lectura cacheada → alta → mismo texto → fallo de caché. (c) El nombre de la métrica es el que asierta la prueba de `Cableado/`; la guía no escribe dos nombres. | Una respuesta vieja después de una baja es una garantía falsa sobre datos de la persona. La verificación del parche ya contempla «si la demo usa caché»; la condición fija el valor seguro por defecto. |
| P2-10 | (a) Junto a «el apagado lo decide la presidencia», la nota registra el estado del contenedor (arriba, límites 14 CPU / 34 GiB, `KEEP_ALIVE` 10 min) y que el equipo es el respaldo de contingencia. (b) La fila «Apagado del segundo servidor» de 06-Plan §8 suma «a decidir antes del cierre del ciclo 1». (c) Ningún texto nuevo nombra el equipo ni el contenedor (sigue mi condición de P-37). | Mientras nadie decide, el respaldo de contingencia queda ocupado sin fecha. Es reversible (un `stop`), pero tiene que tener dueño y plazo. |
| P2-07 | Ninguna herramienta publicada por MCP en `Examples/08` es un `ApprovalRequiredAIFunction` (el parche lo deja en C): el filtro `EsDeLectura` se prueba por reflexión además de por nombre. | Una herramienta de escritura envuelta que cae en el catálogo filtrado se ejecutaría sin aprobación por MCP. |
| P2-02 | La lectura del streaming es la de §1; la aplicación la escribe en la nota de P2-02 con la cita de `00-Boleta.md` l. 46. | La aprobación tiene que dejarla escrita (verificación del parche). |

Condiciones transversales que siguen vigentes: toda redacción in situ por R-PRIV se hace con copia previa fuera de `OUTPUTs/` (mi condición (a) de P-01); nada se borra ni se renombra en la bitácora fuera de esa excepción; nada escribe en `Lab-E2E.WebBlazor`.

## 3. Decisiones por parche

| Parche | Decisión | Capa correcta | Fundamento desde el riesgo |
|---|---|---|---|
| P2-01 | **MEJORAR_PLAN** | sí: la compuerta en el pedido (REED-16 §9.1) y la fuga donde se escribió (README) | El script da rc=0 con una credencial real en JSON indentado o con espacio, y en un bloque de un `.md` (§0.1, rojos 2 y 3). Ver la mejora abajo. |
| P2-02 | APLICAR (§2) | sí: N6 Anexo A, 03-Marco fila N6, BIT-16-04 y 06-Plan, donde se fijó el perímetro | Menor superficie en la pieza que el lector copia entera; MCP sale con su control completo a `Examples/08`. Reversible por nota. |
| P2-03 | APLICAR | sí: N6, BIT-16-04 (R-C02, MI-14, M3) y D-11, donde nacieron las ramas | Es el de mayor reducción de riesgo: sin herramientas que escriban no hay baja sin confirmar (D6 10/10 con los dos modelos), y B1 y B4 son invariantes deterministas. El 404 declarado como no-control evita una garantía falsa. |
| P2-04 | APLICAR | sí: BIT-16-04 MI-05/R-C03/M2 y N6 Anexo A | La normalización queda en núcleo y testeable sin modelo; enum 5 y nombre de 61 se rechazan con 0 `SaveAsync`. La divergencia de «piedra» queda declarada como costo de no endurecer la copia: no la convierto en escalada. |
| P2-05 | APLICAR (§2) | parcial: falta N6 T1, donde nació el «no verificado» (condición (b)) | Corrige el riesgo más alto del lote con el título exacto que pedí; la prueba (a)–(c) con caso rojo detecta el defecto medido. |
| P2-06 | APLICAR (§2) | sí: N5 §4.1–4.2 y R-C07/M8 | Descarta la doble capa que contaba doble los tokens y mantiene la clave con sesión obligatoria. Queda un riesgo de frescura que el parche no ve (§0.2), cubierto por la condición. |
| P2-07 | APLICAR (§2) | sí: BIT-16-04 §6.3, N4 antipatrones y fila MCP, N6 C6 | M13 completo con 400/401/403/200 medidos y el Origin que exige la especificación; catálogo único filtrado a lectura. M7 con supresión complementaria cierra el cruce por resta. |
| P2-08 | APLICAR | sí: M10, N1 §2.6, N2 tabla de vías | Saca de la demo un comportamiento distinto en silencio (`TopK`, `MaxOutputTokens`) y prohíbe credenciales en el cuerpo. Mediciones con fecha; reversible. |
| P2-09 | APLICAR | sí: N3b, N5 G4, R-C08/MI-18 | Reemplaza supuestos por lo medido (truncado silencioso a 2050) y suma una regla operativa (mismo `num_ctx`) que evita recargas que ocupan el único hueco. |
| P2-10 | APLICAR (§2) | sí: BIT-16-04 tensión 4/MI-02/MI-03 y `Sondeo-Entorno` | El rótulo declara el dato de riesgo (ninguno confirma antes de borrar) y cumple R-LLM-3e en D1 y D3 «para ese pedido». El 2b con su cifra medida, no con la de la web. |
| P2-11 | APLICAR | sí: N5 §2.6/§4.6/§8.4 y R-C09/MI-16 | El juez nunca como compuerta y fuera de la demo; las condiciones duras (razonamiento apagado, `num_ctx` ≥ 8192) evitan puntajes `Inconclusive` leídos como resultado. |
| P2-12 | APLICAR | sí: N5 P7 y MI-19/M14 | Inyección con el campo real y su precondición; la tasa L como observada y el control en M3. Salida codificada en la UI de confirmación. |
| P2-13 | APLICAR | sí: integración (EA-6, tensión 1, MI-01, MI-24, M11) y RV-17 | Quita garantías falsas (N ≥ 96 por aproximación normal, «A por defecto» por una tasa). Verifiqué que ≥ 6 discordantes en un sentido da p bilateral 2·0,5⁶ = 0,031. |
| P2-14 | APLICAR | sí: N1 §2.13, N4 §2.1/§2.2/§2.9, N6 §2, N0b D-07 | Sin riesgo operativo; la marca `[C: término de C1-32]` con compuerta impide cerrar sin la decisión de la presidencia. |
| P2-15 | APLICAR | sí: REED-16 §6.2 y 06-Plan §8 | Mantiene bloqueado «validado» y fija qué levanta cada bloqueo con pruebas concretas; barato y reversible. |

### Mejora pedida para P2-01

1. **Patrón:** que detecte el objeto `<clave-de-cabeceras>` no vacío con espacios y saltos de línea entre la clave, los dos puntos y la llave. Para `*.json`, `*.jsonl` y `*.ndjson`, propongo un recuento estructural (`python3 -I` o `jq`, cualquier objeto `<clave-de-cabeceras>` con al menos una clave), no regex; para `*.txt` y `*.log`, regex de una línea con `[[:space:]]*` alrededor de los dos puntos.
2. **Alcance en Markdown:** sobre la raíz de la guía, `Examples/` y `Demos/`, contar también `*.md` (bloques de código). Si el bloque rotulado como antipatrón de RV-01 necesita el objeto, se declara por valor exacto en `RPRIV_SINTETICOS`, como los de PC-03, nunca excluyendo el archivo. Sobre `OUTPUTs/`, el cuerpo auditor decide si mira `*.md` (el multilínea ingenuo arrastra párrafos: §0.1) y lo deja escrito.
3. **Verificación:** suma mis rojos 2 (JSON indentado y con espacio) y 3 (bloque en `.md`), que tienen que dar rc=1, además del rojo del parche y del 0 sobre `OUTPUTs/` después de aplicar.
4. **Lo que puede aplicarse ya, sin esperar la mejora:** la redacción in situ de (b), con copia previa fuera de `OUTPUTs/` y la salida antes y después con el script v1; el criterio de cierre de (c) (salida guardada, la exclusión del commit no cierra, `identificadores=0` antes del primer commit); y RV-01 ampliada de (d). Sólo el script v2 y su prueba vuelven al cuerpo auditor.

## 4. Vetos

Ninguno. Nada de lo aprobado es irreversible mientras `16-IA-Layer/` siga sin seguimiento. La condición del primer commit de `OUTPUTs/` sigue siendo el barrido del dictamen §2 más la compuerta de P2-01 **con la mejora**: el v2 tal cual no alcanza para cerrarla.
