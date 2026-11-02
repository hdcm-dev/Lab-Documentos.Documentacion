# Matriz de recuperación (guía 16, mesa de recuperación, 2026-10-28)

Relator. Fuentes: los seis `Inventario-*.md` de esta carpeta (estado-base, entorno, aportes-guia, aportes-lab, decisiones, rpriv), con 147 unidades en total.

**Convenciones.** Acá, «base» es la línea restaurada en las rutas canónicas, que es la BASE por decisión del PO. «Insumo» es la línea archivada en `OUTPUTs/Linea-…-2026-10-28/` (sólo lectura). Las estaciones se nombran por rol: «estación 1» es la estación de laboratorio de 4 núcleos y «estación 2» la estación con más núcleos. No se escriben nombres de equipos, recursos privados del gestor, endpoints ni rutas del home. Hay dos inventarios con la misma numeración APOR: las unidades del inventario de aportes de guía se citan **APOR-G-NN** y las del de laboratorio **APOR-L-NN**.

**Cómo se lee cada ítem.** A = incorporar el aporte del insumo o aplicar la corrección a la base, y se dice cómo. B = mantener la base tal cual. C, D… = variantes reales. El jurado vota la opción por clave (DECI-09).

**Agrupación.** Primero van los ítems globales (REC-01 a REC-05). Después el lote obligatorio (REC-06). Al final, los ítems de contenido, agrupados por raíz y deduplicados (REC-07 en adelante). Cada ítem tiene una sola severidad: la más alta de las unidades que agrupa.

---

## 1. Ítems globales

### REC-01 · Versión y estado de la guía después de la recuperación
- **Origen:** ESTA-18, ESTA-24, global (a)
- **Severidad:** S3
- **Contexto:** la guía está en 0.10.1, «en revisión», con `last_review` 2026-10-27. Tiene 5.128 líneas, 177 REF y los mecanismos sanos. La recuperación va a cambiar contenido (rótulos de entorno, aportes del insumo) y todavía falta la re-corrida con modelo. Pasar a «publicada» es una decisión del PO que sigue abierta (07 §9).
- **Opciones:**
  - **A.** Al terminar de aplicar el plan de recuperación, subir a **0.11.0** (es un cambio de contenido, no un parche) y poner la fecha de la integración. El estado sigue en «en revisión» hasta que cierren la re-corrida (REC-02) y la relectura integral (REC-03). Recién entonces se le propone al PO pasar a publicada.
  - **B.** Mantener 0.10.1 y el estado actual hasta que cierre todo. Durante la recuperación no se toca el encabezado.
  - **C.** Subir a 0.10.2 por cada lote aplicado (versión de parche), y a 0.11.0 sólo cuando cierre la relectura.

### REC-02 · Cuándo y contra qué servidor se re-corren las pruebas ConModelo (REED-16: probar todo)
- **Origen:** ESTA-22, ENTO-03, ENTO-04, ENTO-11, ENTO-13, APOR-G-01, APOR-L-01, DECI-13, DECI-20, DECI-21, DECI-27, global (b)
- **Severidad:** S1
- **Contexto:** todas las cifras con modelo de la base se midieron en dos servidores que ya no existen. Uno es el servidor compartido, con Ollama 0.32.0-rc0 y qwen3.5:4b@2a654d98e6fb, que aparece 29 veces como «Observado» en la guía. El otro es el «Ollama propio» con 0.40.11, que tiene 6 rótulos y digests que hoy coinciden con los de las estaciones. El 4b vigente es d8b0f5e9760c, otro artefacto. El insumo midió en las estaciones vigentes. Allí, la estación 1 con carga hizo cortar 07 por timeout de 300 s y la estación 2 es unas 10 veces más rápida en lectura del prompt. El insumo da el presupuesto R-LLM-5: unos 27 s por llamada del 4b, es decir unas 90 llamadas por turno de 45 min. El tope TOPE_LAN_S y las clases K/H/L/M de §E.5 se calibraron en el servidor compartido. La re-corrida depende de REC-07 (arnés) y REC-08 (num_ctx). El segundo servidor se gestiona según ELV-02: queda arriba durante la recuperación, con cupo 1, y se apaga al cierre con inventario.
- **Opciones:**
  - **A.** Hacer una fase con modelo única, **después** de integrar y antes de la relectura. Se re-corre **todo** lo que la guía rotula como observado: la fase 3 de `verificar.sh --con-modelo`, las extensiones, la estabilidad, los tres humos de la demo, DEP-03, DEP-09 y DEP-13. La estación 2 toma lo pesado (07, 08 ext., 11, 12, 13, 16, juez y demo) y la estación 1 lo corto y sin carga. Cada corrida lleva criterio previo con sha256, registros nuevos fuera del árbol, columna «servidor» y el presupuesto §E.5 recalculado desde R-LLM-5. F.4 y §4.2 se reescriben con el resultado. Lo que falle por causas del entorno se informa como «no medido».
  - **B.** No re-correr. Toda cifra de los dos servidores retirados se rotula «medido en un servidor de laboratorio retirado, 2026-10-2x; historia».
  - **C.** Re-correr sólo las piezas con tasa citada (03, 04 y 08 ext., 06, 07, 15, 16) y 05 (cocientes), con el reparto de estaciones de A. Lo demás se rotula como historia (variante de ESTA-22).
  - **D.** Como A, pero todo en la estación 2, que es más rápida y sin carga ajena. La estación 1 queda sólo para la salud y la comprobación de digests.

### REC-03 · Relectura integral posterior
- **Origen:** global (c), ESTA-08, ESTA-23
- **Severidad:** S2
- **Contexto:** la presidencia anunció que, después de aplicar el plan, se relee la guía integrada. En el insumo, la relectura se hizo sobre una guía de 4.107 líneas. Ahora la guía base tiene 5.128 líneas y va a crecer con la recuperación.
- **Opciones:**
  - **A.** Relectura integral **sobre la guía recuperada y ya re-corrida** (después de REC-02). Lee el panel completo de la mesa (8 especialistas y el jurado de 5) con las compuertas mecánicas (AC-5 a AC-10, verificar-markdown, barrido R-PRIV ampliado y conteo de REC-21). Los 13 informes del insumo entran como insumo (ver REC-04).
  - **B.** Relectura integral sobre la guía recuperada **antes** de la re-corrida, y una pasada corta de cifras después.
  - **C.** No hacer relectura integral: releer sólo las secciones que tocó la recuperación, con un panel reducido (seguridad, estadística y didáctica).

### REC-04 · Los 13 informes de relectura del insumo
- **Origen:** global (d), RPRI-18
- **Severidad:** S3
- **Contexto:** los 13 `Informe-*.md` revisan la guía del insumo, que tiene otra numeración y otro texto. Muchos de sus hallazgos de fondo ya están en esta matriz a través de los inventarios de aportes. Según RPRI-18, traen nombres de equipos y otras fugas.
- **Opciones:**
  - **A.** No tratarlos acá como hallazgos. Pasan como **insumo de la relectura integral** (REC-03), copiados pieza por pieza con las redacciones de RPRI-18 y el barrido ampliado en 0. Cada lector usa la tabla de correspondencia DECI-30 y descarta lo que no aplica a la base.
  - **B.** Tratarlos en esta mesa como hallazgos sobre la base, uno por uno. Hay que mapear cada uno a la base antes de integrar.
  - **C.** Descartarlos: lo que valía ya lo cubren los inventarios de aportes. Quedan archivados en la línea archivada, sólo como referencia.

### REC-05 · ESC-001, embeddings y publicación de la demo
- **Origen:** global (e), ESTA-24, ENTO-05, ENTO-06, APOR-L-10, DECI-20
- **Severidad:** S2
- **Contexto:** ESC-001 le preguntaba al PO si instalar qwen3-embedding en el servidor de la LAN, que ya no existe. Las dos estaciones vigentes tienen qwen3-embedding:0.6b@ac6da0dfba84. En la práctica rige EMB-B. EMB-A está definido como «en el servidor de la LAN», y el código trata A y B igual. La razón de «embeddings nunca en OLLAMA_ENDPOINT» era el 501 del servidor compartido (l. 1596, A.12). Hoy el mismo servidor sirve las dos cosas. El motivo que queda es la recarga con MAX_LOADED_MODELS=1 (estación 2), que no está medido. La publicación de la demo, el commit (AC-10 y la guía) y el paso a publicada siguen como decisiones del PO.
- **Opciones:**
  - **A.** Cerrar ESC-001 como «sin objeto», con notas fechadas en Ciclo-3/08-Cierre y en 07 §9, y sacarla de los pendientes del PO. Redefinir EMB-A como «en el mismo servidor del chat» y EMB-B como «en un servidor aparte», **sin cambiar el código**. En A.12, la razón pasa a ser «papeles separados y recarga», y el 501 queda como historia. Actualizar los comentarios de ConfiguracionDelModelo.cs y PredicadoDeSalto.cs. Re-medir 06, 07 y PD-2 dentro de REC-02 con OLLAMA_EMBED_ENDPOINT por variable. La publicación de la demo, el commit y el estado se le presentan al PO **después** de REC-03, sin commit en esta mesa.
  - **B.** Como A, pero **quitar EMB-A del código**: queda un solo plan, con el endpoint de embeddings explícito. Hay que recompilar y volver a correr las pruebas.
  - **C.** Mantener ESC-001 abierta, reformulada como «¿qué estación sirve los embeddings?», y elevarla al PO junto con la publicación de la demo.

---

## 2. Lote obligatorio (mecánico)

### REC-06 · Lote obligatorio: R-PRIV, re-rotulado por el entorno caído, notas de bitácora y arreglos del arnés y de los README
- **Origen:** RPRI-01, RPRI-02, RPRI-03, RPRI-05, RPRI-06, RPRI-08, RPRI-09, RPRI-12, RPRI-14, RPRI-16, RPRI-17, RPRI-18, RPRI-20, ESTA-21, ESTA-27, ENTO-14, ENTO-07, ENTO-08, ENTO-12, ENTO-15, ENTO-16, ENTO-17, ENTO-18, ENTO-19, ENTO-04 (salidas-07), ESTA-06, ESTA-07, ESTA-10, ESTA-11, ESTA-13, ESTA-16, ESTA-17, ESTA-19, ESTA-20, ESTA-23, ESTA-26, APOR-L-19, APOR-L-24, APOR-G-28, APOR-G-26
- **Severidad:** S1 (por RPRI-16)
- **Contexto:** ninguna de estas unidades tiene una alternativa razonable. Se aplican todas o ninguna. Las fallas de build no suman ítems: la base dio 443/443 y la demo 70/70 (ESTA-01 y ESTA-02).

**Contenido del lote:**
1. **R-PRIV en el repo público.**
   - Volúmenes, contenedor y etiqueta a variables con valores neutros en `tools/verificar.sh`, `demo.sh` y `compose.yaml` (RPRI-01 a RPRI-03).
   - Comentario y patrón de AC-7 sin rangos literales, armados en tiempo de ejecución (ESTA-27).
   - README de 05 en tono neutral, sin emuladores ni sesiones (ENTO-14).
   - En la tabla de variables, `RLLM_MAQUINA` lleva un rol y nunca un nombre de equipo (RPRI-06).
   - `salidas-07.v1.json` no se toca. Se declara por valor exacto como histórico, con una nota en el README de 15 que diga que es un estímulo de 2026-10-27, de un servidor retirado (RPRI-05, ENTO-04).
   - Compuerta v2 más el barrido ampliado, con el patrón de usuario@máscara afinado (RPRI-17, RPRI-19).
   - Listas de AC-7 y AC-8 mudadas fuera del repo y ampliadas (ESTA-21).
2. **R-PRIV en la bitácora.**
   - I-06:10 en paráfrasis y fuera de `rd-po-4.excepciones` (RPRI-08).
   - Teléfono y gestor del PO por marcadores en I-06:27-29 y 06:123 (RPRI-09).
   - `OUTPUTs/Reanudar.md` fuera de todo commit (lo mueve la presidencia a la línea archivada) (RPRI-16).
   - Marcadores `{dir-de-trabajo}` y `{dir-de-sesion}` (RPRI-12).
   - Nombre del curso genérico, transcripciones resumidas y PNG de terceros excluidos (RPRI-14).
   - Esta carpeta, sólo con roles (RPRI-20).
   - Importación desde la línea archivada pieza por pieza, con barrido en 0 (RPRI-18).
3. **Re-rotulado por el entorno caído.**
   - Frases de arquitectura que presentan el compartido como el entorno actual pasan a historia: l. 288, 3383, 4877 y 4890. El glosario conserva el concepto (ENTO-08).
   - §5.7 l. 1012 pasa a historia, con la fila de §R.4 al lado, rotulada (ENTO-12).
   - 07 aclara que el caso e5 es una respuesta guionada de un servidor retirado, y la bitácora lleva una nota sobre RV-11 (ENTO-15).
   - F.4 y §4.2 pasan a tres servidores (el compartido retirado y las dos estaciones) con los digests vigentes, una vez que haya resultado de REC-02 (ENTO-07).
   - Examples/README aclara que el tope es para servidores ajenos (ENTO-18).
4. **Sondeo vigente.** En `B/Sondeo-Entorno.md` va una nota fechada: «§0–§8 son historia». Se agrega el §R completo con su procedencia, y los crudos van después de pasar la compuerta R-PRIV. En `B/README` va una nota que actualiza la convención R-PRIV con los dos roles vigentes y explica la equivalencia del recurso de la estación 1 antes y después del 2026-10-28 (ENTO-16).
5. **Notas fechadas de la bitácora (sólo agregado).**
   - En 07: las tres deudas cerradas de §8.1 y §8.2 (ESTA-17) y la cifra corregida de §6, 104 rutas con 5 falsos positivos (ESTA-06).
   - En Bitacoras/README: 08 y AC-6 resueltas en 06 §2.1 (APOR-L-19, ESTA-09, ESTA-10).
   - Redaccion/secciones queda como histórico, con una línea que remite a la guía (ESTA-23).
6. **Arnés y README.**
   - Reponer en `tools/` el comparador de AC-9 (bloques y cifras) (ESTA-07) y escribir `tools/contar.sh` con la regla del plan §C, antes de integrar (ESTA-20).
   - `ac6()` vacía `paquetes/` al entrar (ESTA-10).
   - `recalcular-oraculos.sh` acepta un segundo directorio de oráculos (ESTA-11).
   - El verificador de la guía tiene un archivo de excepciones o rutas completas de la demo (ESTA-06).
   - El README de 15 usa el contenedor (R-HOST) (ESTA-13). Examples/README incluye el párrafo de E.5 (ESTA-16). El README de 05 dice «corrida 1» (ESTA-26).
   - Procedimiento de la fase con modelo: `RLLM_DIR` siempre fuera del árbol y descarga con keep_alive 0 al terminar cada fase (ENTO-19, ENTO-10).
7. **Anexo D y referencias.**
   - Consultar REF-142 y los autores que faltan, sin datos de memoria (ESTA-19).
   - Las referencias del insumo entran sólo con la unidad que las usa, con el formato de la base (APOR-G-28).
   - «del todo» se mantiene en §7.6 (APOR-G-26).
   - Todo lo portado se re-rotula y apunta su procedencia a 8fb4c3a. No entra el muestreo de la ficha del modelo (APOR-L-24).
8. **Gestor (fuera del repo).** La presidencia le pide al gestor tres cosas: que `OLLAMA_URL` no tenga una dirección por defecto, una rama de salud para la estación 2 y que su protocolo incluya la regla «nunca emuladores ni KVM» (ENTO-17). Esta mesa no lo toca.

**Después del lote:** volver a correr `verificar.sh build` (n/n), `demo.sh pruebas`, `diff-base.sh`, `diff-dominio.sh`, AC-6, AC-7 y AC-8, y el barrido ampliado en 0 sobre la guía y sobre esta carpeta.

- **Opciones:**
  - **A.** Aplicar el lote completo, en el orden 1 → 8, con verificación al final.
  - **B.** No aplicar el lote.

---

## 3. Ítems de contenido (por raíz)

### REC-07 · Arnés y recursos para re-correr en el entorno vigente
- **Origen:** ENTO-01, ENTO-02, ESTA-25, RPRI-04, RPRI-11, ENTO-13
- **Severidad:** S1
- **Contexto:**
  - El gestor ya no tiene el recurso del «Ollama propio». Con TURNO_CMD definido, las fases 2 y 4 y `demo.sh embeddings` mueren antes de llamar.
  - El nombre del recurso del servidor compartido lo heredó la estación 1, y el arnés rotula fijo `OLLAMA_SERVIDOR=compartido` y `RLLM_MAQUINA=compartido` (verificar.sh l. 406, 496 y 503; demo.sh l. 138). Una re-corrida quedaría registrada en silencio como «compartido».
  - Los digests que exige verificar.sh coinciden con las dos estaciones.
  - RPRI-04 propone renombrar el recurso a un papel neutro. Ese nombre aparece en 19 líneas de verificar.sh, en ejemplo.json y en los README.
  - RPRI-11 es la misma clase, pero en la bitácora y en capturas fijadas por hash.
- **Opciones:**
  - **A.** Cambio mínimo en el repo. `OLLAMA_SERVIDOR` y `RLLM_MAQUINA` se leen del entorno, con el valor actual como defecto (una línea en cada lugar). El rótulo de las estaciones lo fija la presidencia, sin nombres de equipo. Un adaptador TURNO_CMD **fuera del repo**, recuperado del rescate al directorio de trabajo, traduce los papeles «propio» y «compartido» a los recursos de las estaciones, y `OLLAMA_PROPIO_URL_CMD` lee la variable. Los ejemplo.json y la bitácora quedan como están, y la bitácora lleva una nota de equivalencia.
  - **C.** A más el renombre de RPRI-04 en el repo. Los ejemplo.json, verificar.sh y los README pasan a papeles neutros (`modelo-compartido` y `modelo-propio`), `TOPE_LAN_S` pasa a `TOPE_COMPARTIDO_S` y el cambio es atómico, verificado con `--fake` y ArnesTests. En la bitácora, la prosa se generaliza y las capturas que alimentan recálculos quedan como están, con sus valores declarados históricos (RPRI-11). Sigue un dictamen fechado sobre la clase (C1-39).
  - **D.** C sin tocar la bitácora (RPRI-11 sólo informa hasta el dictamen).
  - **B.** Mantener la base. La re-corrida no es posible en el laboratorio vigente sin cambios, y eso deja REC-02 sin camino.

### REC-08 · Ventana de contexto: valor para la re-corrida y regla «mismo num_ctx»
- **Origen:** ENTO-09, APOR-G-05, DECI-22, DECI-25
- **Severidad:** S2
- **Contexto:** la base registró num_ctx 65536 en el compartido, y la fase del propio fija 8192. Las estaciones cargan con 4096. Sin num_ctx, Ollama 0.40.11 recarga con 4096 según la configuración del servidor (PC-06). Alternar valores recarga el 4b en 10,5 a 16,1 s (N=5, estación 1). Por /v1 el valor llega como otro. Con eso, la pregunta abierta de la base («¿/v1 sin num_ctx recarga?») queda cerrada.
- **Opciones:**
  - **A.** La re-corrida usa **8192** en todas las fases, cargado dentro del turno para que /api/ps lo informe. En §5.4/§5.5/§12.4 se suma la regla «el mismo num_ctx en todos los clientes de un modelo», con la cifra de recarga rotulada. La pregunta abierta se cierra con una nota fechada que cita PC-06. Los README se re-rotulan después.
  - **B.** Re-correr con el valor por defecto del servidor (4096), sin sumar la regla.
  - **C.** Re-correr con 8192, como en A, sin sumar la regla a la guía.

### REC-09 · Cancelación de streaming sin excepción (OllamaSharp 5.5.0)
- **Origen:** APOR-L-02
- **Severidad:** S2
- **Contexto:** en Examples/01 de la base, `AsistenteDeAyuda.cs` (l. 46-70) agrega la respuesta al historial después del `await foreach` sin mirar el token. No hay prueba de cancelación. El insumo midió con el mismo paquete «no cancelada» en 10/10: la enumeración termina sin lanzar y el parcial se guarda como completo.
- **Opciones:**
  - **A.** Portar a 01 de la base el chequeo de `ct.IsCancellationRequested` después del foreach: no agregar el parcial y marcar la vuelta como cancelada. Sumar dos pruebas de cableado con GuionChatClient (el proveedor que lanza y el que termina en silencio) y un párrafo en §5, rotulado después de REC-02.
  - **B.** Mantener 01 como está.
  - **C.** No cambiar el código. Declarar la limitación en §5 como antipatrón con la evidencia del insumo, rotulada.

### REC-10 · Vía nativa frente a /v1: qué viaja y qué no
- **Origen:** APOR-G-06, APOR-L-04, DECI-23 (sin la parte de credenciales)
- **Severidad:** S2
- **Contexto:** la tabla de §5.6 de la base tiene 4 filas y dice «/v1 no admite tool_choice». El insumo midió con captura del cuerpo por un servidor falso:
  - Por /v1, TopK se descarta en silencio.
  - MaxOutputTokens viaja como `max_completion_tokens` y no acota: se pidieron 3 tokens y salieron 30 a 57.
  - El cliente sí envía `tool_choice:auto`. Que el servidor lo cumpla no está medido.
  - El mensaje tool viaja distinto por cada vía.
  - CachedInputTokenCount llega null.
- **Opciones:**
  - **A.** En Examples/02 de la base, sumar una prueba de cableado que capture el cuerpo por las dos vías. En §5.6, sumar las filas de TopK, MaxOutputTokens y formato del mensaje tool, y corregir la de tool_choice a «el cliente lo envía; el servidor no lo honra según [REF-51]». El «3 → 57» se re-mide en REC-02 antes de afirmarlo.
  - **B.** Mantener la tabla de la base.
  - **C.** Sólo precisar la frase de tool_choice, sin agregar filas ni pruebas.

### REC-11 · Credenciales fuera del cuerpo del pedido
- **Origen:** APOR-G-08, DECI-23 (parte de credenciales)
- **Severidad:** S2
- **Contexto:** OllamaSharp 5.5.0 serializa en el cuerpo JSON las cabeceras que se le pasan al pedido. Quien cambie a un proveedor con clave puede dejarla en las capturas de cuerpo que la guía enseña a guardar. La base no trata cómo viajan las credenciales. Por R-PRIV ampliado, la propiedad no se puede nombrar en el repo.
- **Opciones:**
  - **A.** Sumar la regla en §11.6/A.12 sin nombrar la propiedad: las credenciales van en el HttpClient o en un DelegatingHandler, nunca en las cabeceras del pedido. Sumar al arnés la compuerta «cabeceras=0» sobre las capturas.
  - **B.** Mantener la base.
  - **C.** Sumar sólo la regla en prosa, sin la compuerta.

### REC-12 · Caché de respuestas: sesión y versión de datos en la clave
- **Origen:** APOR-G-09, APOR-L-06, DECI-18
- **Severidad:** S2
- **Contexto:** Examples/17 usa UseDistributedCache con la clave por defecto. §12.3 y ADR-09 presentan «un acierto no vuelve a ejecutar las herramientas» como ventaja. El insumo muestra dos casos rojos. Sin sesión en la clave, B recibe la respuesta de A, lo que en CTX-SENS es una fuga. Con herramientas sobre datos mutables, un acierto sirve datos viejos. Además, con CoalesceStreamingUpdates=false, la caché que sólo cuenta ReadCacheAsync da 0 aciertos. Hay coincidencia en que la demo no usa caché.
- **Opciones:**
  - **A.** En 17 de la base: clave con `[SessionId, VersionDeDatos]` leídos en cada pedido, caso rojo de dos sesiones, caso rojo de una escritura seguida de un acierto viejo y contador por los dos caminos de lectura. En §12.3 y ADR-09: la sesión y la versión van en la clave, y no se cachea con herramientas sobre datos mutables. Se matiza el diagrama de §5.4.
  - **B.** Mantener la base.
  - **C.** Sólo prosa en §12.3 y ADR-09 (las dos reglas), sin código nuevo en 17.

### REC-13 · Límite de concurrencia
- **Origen:** APOR-G-10, APOR-L-07
- **Severidad:** S2
- **Contexto:** la base declara como deuda que la demo no limita (l. 3463, 4495 y ADR-09), y §12.3 propone una capa con RateLimiter en el pipeline del cliente. El insumo tiene `LimitadorDelModelo`: un ConcurrencyLimiter singleton en la entrada HTTP, compartido por la API y la página Blazor, que responde 503 con Retry-After. Está probado: cuatro pedidos simultáneos dan 3×200 y 1×503. Su razón es NUM_PARALLEL=1 con pedidos de 167 s.
- **Opciones:**
  - **A.** Portar LimitadorDelModelo a la demo de la base, con sus opciones y una prueba de 4 simultáneos **determinista**, que no dependa del orden (AH-02-07). §12.3 recomienda la entrada HTTP y deja la capa del cliente como alternativa. Se ajustan l. 3463 y 4495, ADR-09 y la tabla de delta, con la procedencia.
  - **B.** Mantener la base, con la deuda declarada.
  - **C.** Sólo prosa: la entrada HTTP como recomendación en §12.3, la capa del cliente como alternativa y la demo sin cambios.

### REC-14 · Ciclo de vida: Singleton que cruza sesiones y Scoped en Blazor
- **Origen:** APOR-G-11, APOR-L-11, DECI-24, APOR-G-12
- **Severidad:** S2
- **Contexto:** ADR-12 enuncia «ningún estado de conversación en un singleton», y las pruebas usan siempre ValidateScopes=true. El insumo midió los dos casos. Con Singleton y false, B ve y borra lo de A sin error. Con true, falla en cada llamada a la herramienta y no al construir el contenedor. Lo cita DI overview §Scope validation. En Blazor Interactive Server, Scoped es el circuito, y no sirve para un DbContext Scoped (AddDbContextFactory).
- **Opciones:**
  - **A.** Sumar la prueba roja concurrente con barrera, en los casos (a) a (c), a la pieza que arma las herramientas por sesión (08 o la demo), y citarla en ADR-12, §13.13 y el Anexo B. Verificar que la demo registre la fábrica de DbContext y sumar el párrafo del circuito en §5.5/§13.13, con sus referencias.
  - **B.** Mantener la base.
  - **C.** Sólo prosa (la frase medida y el párrafo del circuito, con las citas), sin la prueba roja.

### REC-15 · Elección del modelo de chat y su rótulo
- **Origen:** APOR-G-18, DECI-13, DECI-28, APOR-L-23, ENTO-15 (alternativa 7b)
- **Severidad:** S2
- **Contexto:** la base eligió el 4b porque era el modelo residente, sin compararlo con otro. Su alternativa, qwen2.5:7b-instruct, no existe en ningún servidor vigente. El insumo midió el 2b frente al 4b con N = 10 semillas:
  - D3: el 4b falló 0/10 y el 2b 10/10.
  - D1: el 4b inventó el CP en 10/10 y el 2b en 1/10.
  - D6: ninguno de los dos confirma antes de borrar (10/10).
  - El 35b-a3b ocupa 21 GiB y es unas 4 veces más lento.
  
  Los dos inventarios no coinciden. El de guía propone citar D1, D3 y D6 con sus límites. El de laboratorio advierte que la tabla es por /v1, con una herramienta de baja que la base no tiene, que el propio insumo la declara no trasladable y que por eso no hay que citarla.
- **Opciones:**
  - **A.** Mantener el 4b y fijar el digest vigente (verificado en un turno). Sumar en §5.7/F.4/ADR-03 un rótulo de elección «provisional» con D1, D3 y D6 recalculados con Clopper-Pearson, rotulados por estación, con el estimando «este pedido» y el límite declarado de que es otra composición, por /v1, y no trasladable. D6 se cita en §8.5 como existencia. La alternativa 7b se quita o se rotula como historia.
  - **B.** Mantener el 4b y fijar el digest vigente, sin citar la tabla del insumo. Si hace falta, el modelo provisional se re-mide con la demo de la base en REC-02. La alternativa 7b se quita o se rotula.
  - **C.** Mantener la base tal cual (digest viejo y alternativa 7b). Contradice REC-02 y el lote.

### REC-16 · Dato inventado con forma válida (CP 34 → 3400)
- **Origen:** APOR-G-19, APOR-L-17
- **Severidad:** S2
- **Contexto:** §8.5 l. 2010 argumenta que «quien no deja escribir es SaveAsync». El insumo vio que el 4b, ante «No inventes ni corrijas», devolvió 3400 en 8/10 en la estación 2, y que 3400 pasa las reglas. La GarantiaDelTexto de la base (un número sólo vale si aparece en la entrada) es la respuesta correcta. Lo que no está mostrado es que cubra el CP.
- **Opciones:**
  - **A.** Sumar a §8.5 el caso rotulado y recalculado. Verificar que el descarte «no está en el texto» cubra todos los campos, o extenderlo, con una prueba sin modelo que proponga 3400. Re-correr 03, 10 y PD-3 en REC-02, con el estímulo «CP 34» y la tasa «CP distinto de 34» con criterio previo.
  - **B.** Mantener §8.5 y sólo re-correr 03, 10 y PD-3 en REC-02.
  - **C.** Mantener la base sin cambios.

### REC-17 · Huecos del dominio heredado: CP con dígitos no ASCII y nombre de más de 60 caracteres
- **Origen:** APOR-L-08, DECI-12
- **Severidad:** S2
- **Contexto:** `^\d{4}$` acepta dígitos arábigo-índicos. `LargoMaximoDelNombre = 60` está declarado y no se aplica (grep). La guía, en l. 1075, dice «entre 3 y 60». Un nombre de 61 caracteres que propone el modelo pasa las reglas. La base ubica el normalizador en Infrastructure/AI (ADR-08) y ya endurece H1 a H5 con la fila «Modificado a causa de la IA».
- **Opciones:**
  - **A.** Escribir primero dos pruebas de cableado en la base: «٣٤٥٠» y 61 caracteres, que tienen que rechazarse sin SaveAsync. Si fallan, endurecer LocalidadRules (dígitos 0-9 y largo máximo) dentro de la fila «Modificado a causa de la IA» de la tabla de delta, y volver a correr AC-5 y AC-10.
  - **C.** Las mismas pruebas, pero el endurecimiento va en el normalizador del adaptador de IA, sin tocar Domain. La guía declara que la API copiada no lo hace cumplir.
  - **B.** No endurecer. Declararlo en §14.1 como «declarado, no aplicado» y corregir o rotular l. 1075.

### REC-18 · LLM juez: evaluadores, control de «no interpretable» y corrida pendiente
- **Origen:** APOR-G-13, APOR-G-14, DECI-14, DECI-29
- **Severidad:** S2
- **Contexto:** la base usa como juez a qwen2.5:0.5b, que dio 0/52 interpretables. Recomienda Relevance y Groundedness. El insumo, con el 4b, vio que una respuesta incorrecta sacó 4 en Relevance y Coherence, mientras que Completeness y Equivalence le dieron 1 (N=1). El razonamiento agota los 800 tokens, y cada evaluación cuesta unos 34 s en la estación 2. Una prueba del insumo pasó en verde con todas las métricas Inconclusive. El arnés de 15 de la base cuenta las interpretables. La salida `--fake` de l. 2992 (51/52) puede leerse como una medición.
- **Opciones:**
  - **A.** Sumar a §10.6 lo que vio el laboratorio, como existencia, y sumar EquivalenceEvaluator con el oro a Examples/15 y §10.5. Verificar dos cosas: que una métrica sin Interpretation o con diagnóstico Error cuente como no interpretable, y que el juez pase por la capa de opciones (razonamiento apagado y num_ctx ≥ 8192). Agendar en REC-02 la corrida del juez en la estación 2, con el presupuesto de DECI-29 y la advertencia de familia. El 0/52 queda como historia, y la salida `--fake` se rotula como cableado.
  - **C.** Sólo la verificación de «no interpretable», el rotulado del 0/52 y de `--fake`, y la corrida del juez en la estación 2, sin cambiar los evaluadores.
  - **B.** Mantener la base.

### REC-19 · Método estadístico: intervalo, estimando, existencia y caída del servidor
- **Origen:** APOR-G-15, APOR-G-16, APOR-G-17, DECI-15, DECI-07
- **Severidad:** S2
- **Contexto:** la base usa la entrada distinta como unidad y Clopper-Pearson. El insumo usa Wilson, el estimando «este pedido / la tarea» y suma la aserción de «existencia». También dice que una excepción de red a mitad de corrida es «no medido». El experimento AH-02 del insumo (ICC 0,29, efecto de diseño 3,0) respalda la unidad de la base. Mezclar intervalos rompe la homogeneidad (C5). La regla pareada coincide (DECI-07).
- **Opciones:**
  - **A.** Mantener Clopper-Pearson y la unidad de la base. Toda cifra importada se recalcula con Clopper-Pearson y se rotula «una entrada, N semillas». El script de verificación del insumo se adapta a Clopper-Pearson y se usa como compuerta. Se suman a §10.4, A.10 y E.6 la etiqueta del estimando, la aserción de existencia y la regla «caída de red = no medido», y se revisa cómo manejan los ConModelo/ de la base las excepciones de red.
  - **C.** Como A, pero sin el estimando: sólo existencia y «no medido».
  - **D.** Pasar toda la guía a Wilson y al estimando del insumo. Hay que recalcular las 365 cifras de la base.
  - **B.** Mantener la base sin agregados.

### REC-20 · Escrituras en la demo: herramienta con aprobación o AccionPropuesta
- **Origen:** DECI-10
- **Severidad:** S2
- **Contexto:** la base tiene herramientas de escritura con ApprovalRequiredAIFunction, el pedido armado por el código y una política de origen, con 70/70 pruebas. Las sondas DEP-09 y el humo de PD-6 corrieron en el servidor retirado. El insumo no tiene escrituras: usa una AccionPropuesta que confirma la persona. Su evidencia vigente X2 (el 4b borra sin confirmar en 10/10) y D6 muestra justamente por qué la aprobación la tiene que imponer el código.
- **Opciones:**
  - **A.** Mantener la base. En ADR-06, sumar la AccionPropuesta como alternativa descartada, con su motivo. En §8.5/§11.3, citar X2 y D6 rotulados por estación y con el estimando «este pedido». Re-correr DEP-09 y el humo de PD-6 en REC-02.
  - **C.** Mantener la base y re-correr DEP-09 y PD-6, sin citar la evidencia del insumo.
  - **D.** Adoptar el diseño del insumo, con la demo sin escrituras. Reabre la demo construida y AC-4.
  - **B.** Mantener la base tal cual, sin re-correr.

### REC-21 · Truncado silencioso con el 4b y guarda que lanza
- **Origen:** APOR-G-04, APOR-L-03
- **Severidad:** S2
- **Contexto:** la base mide sólo con el 0.5b (DEP-03: 5.714 frente a 2.050, en un servidor retirado). Su GuardaDeTruncado estima y marca el registro, sin cortar. El insumo midió en la estación 2 que el 4b recibe 5.114 frente a 2.050 tokens (3/3) y que el largo depende del tokenizador (5.114 frente a 5.134). También tiene DetectorDeContextoTruncado, que lanza una excepción. Las dos guardas se complementan.
- **Opciones:**
  - **A.** Re-correr DEP-03 en REC-02 y actualizar l. 1013 con la regla «4096 → 2.050». Sumar la fila del 4b y la frase del tokenizador en §5.4/§6.5. Mostrar el detector que lanza como alternativa de CTX-PROD, sin reemplazar GuardaDeTruncado. Declarar que la calibración de caracteres por token es por modelo y verificar que la guarda estime con el modelo de la llamada.
  - **C.** Re-correr DEP-03 y sumar la fila y la frase del tokenizador, sin el detector que lanza.
  - **B.** Mantener la base (la cifra queda como historia por el lote).

### REC-22 · Reuso de prefijo observado (prompt_eval_cached_count)
- **Origen:** APOR-G-03, APOR-G-07, APOR-L-05
- **Severidad:** S2
- **Contexto:** la base dice en l. 1395 que con el 4b el reuso no está medido. EstadoDeCache queda en «desconocido», y §6.4 dice «si el adaptador lo informa». El insumo tiene LectorDePrefijoCacheado, un DelegatingHandler que lee el NDJSON porque OllamaSharp 5.5.0 no lo expone. Está probado con NDJSON fijo, y con el 4b observó tokens cacheados mayores que 0 en 10/10 (estación 2) y una caída de 71,7 s a 26,0 s (N=1, estación 1).
- **Opciones:**
  - **A.** Portar el lector a `_Comun` con su prueba sobre NDJSON fijo y llenar `estado_cache` con el valor observado. Reemplazar en §6.3/§6.4 «si el adaptador lo informa» por el hecho y el camino. Re-correr 05 en REC-02 y actualizar l. 1395 y la deuda de 05 con una nota fechada.
  - **C.** Sólo prosa: el hecho, el camino y la cifra del insumo rotulada como existencia, sin código.
  - **B.** Mantener la base.

### REC-23 · Inyección indirecta: cifra vigente, «repite el texto» y garantía en una sola frase
- **Origen:** APOR-G-20, APOR-G-27, DECI-05
- **Severidad:** S3
- **Contexto:** la base da 0/6 por variante, del servidor retirado. El insumo, con otra composición sin escritura, vio que el modelo repitió el texto inyectado en 10/10, que es salida insegura hacia la persona, y propone enunciar la garantía en una sola frase: «ninguna escritura depende del texto: o no hay herramienta que escriba, o toda escritura espera aprobación con su contrato». El vector (Localidad.Nombre) coincide.
- **Opciones:**
  - **A.** Re-correr 16 en REC-02 con el estimando. Sumar a §11.2/§11.7 la observación «repitió el texto», rotulada y redactada sin negaciones dobles. Usar la frase única como enunciado de la garantía en §11.2, con remisión a §8.5.
  - **C.** Re-correr 16 y adoptar la frase única, sin la observación del insumo.
  - **B.** Mantener la base (la cifra queda como historia por el lote).

### REC-24 · Ollama sin autenticación y la imagen que escucha en todas las interfaces
- **Origen:** APOR-G-21
- **Severidad:** S2
- **Contexto:** E.3 pide que el servidor escuche fuera del loopback, sin advertencia. La imagen fijada por digest trae el comodín en OLLAMA_HOST, y Ollama no autentica. El compose y la demo de la base ya publican bien.
- **Opciones:**
  - **A.** Advertir en E.3, §12.6 y §11.6 que se publique sólo a la interfaz del bridge o a 127.0.0.1, nunca a todas, y que Ollama no autentica. Dejar constancia de que la imagen se verificó por digest.
  - **B.** Mantener la base.

### REC-25 · MCP: versión negociada, escrituras frente a la descripción del cliente, catálogo y token
- **Origen:** APOR-G-23, APOR-L-09, ESTA-14
- **Severidad:** S3
- **Contexto:** el Anexo F, l. 5061, dice que la negociación 2026-07-28 es una «inferencia no verificada». El insumo la midió. `Garantias.DescripcionDelCliente` compara sólo las lecturas. El insumo suma tres cosas: el caso de lista blanca con una herramienta peligrosa marcada ReadOnly, un catálogo único de AIFunction y un Bearer revisado después de Origin. La seguridad de Origin ya coincide. El token en loopback no es OAuth 2.1, y la guía no implementa autorización.
- **Opciones:**
  - **A.** Sin token. Registrar NegotiatedProtocolVersion en 13 y actualizar l. 5061. Extender la garantía a las escrituras, con su prueba sin modelo. Sumar el caso ReadOnly que no decide y la prueba «tools/list = esquema del bucle». El catálogo único queda declarado como alternativa.
  - **C.** A más el Bearer por DelegatingHandler, con sus cuatro pruebas de orden (Origin → token), declarado como «no es OAuth 2.1».
  - **D.** A más migrar 13 al catálogo único.
  - **B.** Mantener la base (sólo la garantía de lecturas).

### REC-26 · Prueba de arquitectura: la quinta regla de ADR-11 y las mutaciones
- **Origen:** ESTA-15, APOR-L-12
- **Severidad:** S3
- **Contexto:** la demo tiene 4 reglas, y ADR-11 promete una quinta. §13.12 reconoce que nada acota la excepción de Presentación a Chat.razor. El insumo tiene seis reglas, mutaciones que dan rojo, agujeros declarados y una prueba de que las excepciones siguen existiendo. También muestra que un grep, como el de AC-5, no detecta R4.
- **Opciones:**
  - **A.** Sumar la quinta regla: la que acota Presentación → Infrastructure/AI a Chat.razor. Sumar los casos rojos de mutación Cuerpo y Atributo, declarar los agujeros en §4 y ADR-11, y no presentar el grep de AC-5 como prueba suficiente.
  - **C.** Como A, pero la quinta regla es una de las del insumo: «Infrastructure no usa casos de uso» o «el adaptador de IA no conoce el acceso a datos». Lo de Chat.razor sigue declarado.
  - **D.** Sólo la quinta regla (la de A), sin mutaciones.
  - **B.** Quitar la promesa de ADR-11 y dejar las 4 reglas.

### REC-27 · Sesión serializada alterada en MAF
- **Origen:** APOR-G-22, APOR-L-16
- **Severidad:** S3
- **Contexto:** MAF 1.26.0 ejecuta lo que dice la sesión deserializada. El insumo tiene un caso rojo y una guarda que compara con la copia aprobada, y declara el límite: si se comprometen los dos almacenes, la guarda no alcanza. La base cubre los argumentos alterados en el pedido. Falta verificar si cubre la sesión guardada alterada (AgenteConAprobacionTests.cs).
- **Opciones:**
  - **A.** Verificar en 11. Si falta, sumar el caso rojo y la guarda, y en §8.7 el hecho, la condición y el límite.
  - **C.** Sólo sumar a §8.7 el hecho y la condición, sin código.
  - **B.** Mantener la base.

### REC-28 · RAG y embeddings: abstención por umbral, citas y determinismo
- **Origen:** APOR-L-13, APOR-L-14, APOR-L-22, DECI-11
- **Severidad:** S3
- **Contexto:** el insumo midió en las estaciones vigentes que, con qwen3-embedding, la abstención por umbral no se separa (una no respondible puntuó 0,46 y la correcta 0,37). También vio que el formato de cita del ejemplo del prompt se copia (28/48), que citar no es fundamentar, y que los embeddings son deterministas (128/128). La base, en 07, da «No sé» 0/4, y su perímetro de la demo con RAG en PD-2 se mantiene (DECI-11, sin evidencia nueva).
- **Opciones:**
  - **A.** Mantener el perímetro de la base. Revisar si las instrucciones de 07 y PD-2 traen un ejemplo de cita. Sumar a §6 y §10 las lecciones «no abstenerse por umbral salvo calibración separable», «citar no es fundamentar» y «el formato sale del ejemplo», rotuladas. Agregar al oro de 07 una no respondible cercana a una regla real. Re-correr 06 en REC-02 con un conjunto de calibración aparte y anotar el determinismo si se confirma. Barrido de frases que comparen contexto fijo y RAG sin corrida.
  - **C.** Sólo las lecciones en prosa, rotuladas como del insumo, sin re-correr ni tocar el oro.
  - **B.** Mantener la base.

### REC-29 · Herramienta no pedida: el modelo afirma un dato sin consultar
- **Origen:** APOR-L-18, ENTO-20
- **Severidad:** S3
- **Contexto:** ante una provincia fuera del catálogo, el insumo vio que el modelo no pidió ninguna herramienta (0/10) y afirmó «cero» en 3/10 a 4/10. El oráculo por regex no lo detecta. Además, en la estación 1, qwen2.5:0.5b devolvió un valor fuera del enum en 6/10: Ollama no hace cumplir el enum. Las dos observaciones refuerzan criterios que la base tiene sin un caso observado.
- **Opciones:**
  - **A.** Sumar a 08 o 09 el estímulo de la provincia fuera del catálogo, con un oráculo «afirma un número sin herramienta», y la lección en §7. Sumar a §8.2 la evidencia del enum, rotulada «estación de laboratorio de 4 núcleos, 0.40.11, 2026-10-28».
  - **C.** Sólo las dos observaciones en prosa, rotuladas, sin estímulo nuevo.
  - **B.** Mantener la base.

### REC-30 · Migración desde Semantic Kernel y Workflows: trampas que no dan error
- **Origen:** APOR-L-15, APOR-L-21, APOR-G-24, DECI-16
- **Severidad:** S3
- **Contexto:** el insumo documenta trampas que fallan en silencio, con casos rojos:
  - En la migración de SK: sin UseKernelFunctionInvocation la llamada no se ejecuta, AIFunctionFactory no lee [KernelFunction] y un KernelFunction en MAF da «Function failed.».
  - En Workflows: YieldOutputAsync sin declarar lanza en ejecución.
  - El gestor de group chat del paquete es RoundRobin.
  
  En el glosario, la base da «flujo de trabajo» como equivalente de «workflow», que es justo la forma que el insumo excluye.
- **Opciones:**
  - **A.** Sumar dos o tres casos rojos sin modelo a 14 y una línea en §9.7. Sumar el caso rojo de Yield a 10 y, en §8.8, «con el gestor que trae el paquete, por turnos (código)». En el Anexo C, «— (no se traduce)», con barrido de las tres formas. BuildSequential no entra.
  - **C.** Sólo prosa en §9.7 y §8.8 y la corrección del glosario, sin casos rojos.
  - **B.** Mantener la base.

### REC-31 · Agregados en CTX-PROD: celda mínima y supresión complementaria
- **Origen:** APOR-G-25
- **Severidad:** S3
- **Contexto:** §11.4 da agregados sin Nombre ni Edad, pero sin celda mínima. El insumo suma TamanoMinimoDeCelda, la supresión complementaria y el límite de cruces, con la Ley 25.326 (arts. 2 y 28, InfoLEG) y ResDAC como práctica.
- **Opciones:**
  - **A.** Sumar el párrafo a §11.4 y las referencias a D.9, en prosa y sin código.
  - **C.** A más un control en el ejemplo de agregados, con su prueba sin modelo.
  - **B.** Mantener la base.

### REC-32 · Definición de agente
- **Origen:** DECI-17
- **Severidad:** S3
- **Contexto:** para la base, el agente dirige su propio proceso (escalón 3) y la llamada con herramientas es el escalón 1. Para el insumo, alcanza un bucle con UseFunctionInvocation. Las dos definiciones son incompatibles: con la del insumo, PD-1, PD-5 y PD-6 serían agentes. C5 exige un solo sentido.
- **Opciones:**
  - **A.** Mantener la definición de la base. Sumar a §8.1/Anexo C una línea sobre el uso amplio del término y tomar «MCP es transporte, no un nivel de orquestación» si falta.
  - **C.** Adoptar la definición del insumo y reescribir la escalera.
  - **B.** Mantener la base sin la nota.

### REC-33 · Régimen R-PRIV de la bitácora: sólo agregado, contenedores y capturas
- **Origen:** DECI-26, RPRI-10, RPRI-11 (bitácora), RPRI-13
- **Severidad:** S3
- **Contexto:** la base dejó abierto el conflicto entre R-PRIV y «sólo agregado» y redactó en el lugar. El dictamen del insumo resuelve dos cosas. Por §1, R-PRIV le gana a «sólo agregado», y sólo para borrar lo prohibido. Por §2, los identificadores se permiten hasta el commit, con un barrido en 0 antes. Hay 84 líneas con contenedores, volúmenes y redes del laboratorio en 31 archivos, y unas 571 líneas que nombran la herramienta y el recurso de turnos. Parte de esas líneas está en capturas fijadas por hash o que alimentan recálculos. Las rutas desde la raíz del workspace ya son públicas (RPRI-13).
- **Opciones:**
  - **A.** Adoptar el dictamen §1–§2. En prosa y planes, usar marcadores (`<ollama>`, `<volumen-nuget>`, `<red-del-arnés>`, «gestor de turnos del laboratorio (privado)»). En los .log que nada fija por hash, `sed` por mapa de valor exacto, con un diff que muestre que sólo cambian esos tokens. Las capturas que alimentan recálculos (R-LLM *.jsonl, tsv) quedan, con los valores declarados históricos. Las rutas del workspace quedan. Barrido en 0 antes de cualquier commit.
  - **C.** Como A, pero sin tocar los .log: todas las capturas quedan con valores declarados.
  - **B.** Mantener la base: la bitácora tal cual hasta que lo decida la otra mesa.

### REC-34 · Coincidencias sin acción
- **Origen:** DECI-01, DECI-02, DECI-03, DECI-04, DECI-06, DECI-07, DECI-08, DECI-09, DECI-19, DECI-30, ESTA-01 a ESTA-05, ESTA-09, RPRI-07, RPRI-15, APOR-L-20
- **Severidad:** S4
- **Contexto:** las dos líneas coinciden en el principio rector, MCP fuera de la demo, el juez como tendencia, que la sesión la pone el código, los estímulos sólo de Movilidad Urbana, la regla pareada, la cobertura de escenarios, la boleta por opción y la forma de la copia del caso base. La base compila y prueba sana, la pieza 08 ya no está rechazada y AC-6 está resuelta. La convención Ignore de NUnit se mantiene: queda una oración opcional en §10.2 si se verifica cómo aparece con 4.3.2. DECI-30 es la tabla de correspondencia que se usa al renumerar remisiones.
- **Opciones:**
  - **A.** Registrar como coincidentes, sin acción. DECI-30 se usa en todo traslado. La oración de NUnit entra sólo si la verificación de build la confirma.
  - **B.** Reabrir alguna. La boleta tiene que nombrar cuál y por qué.

### REC-35 · Limpieza de paquetes sin uso
- **Origen:** ESTA-12
- **Severidad:** S4
- **Contexto:** hay tres PackageVersion sin referencia en Examples/Directory.Packages.props. F.1 los declara sin uso. Retirarlos cambia `paquetes_hash`. Falta confirmar el transitivo de Agents.AI.Abstractions.
- **Opciones:**
  - **A.** Retirar los tres, volver a correr build y AC-6, actualizar F.1, anotar el `paquetes_hash` nuevo y confirmar el transitivo.
  - **B.** Mantenerlos, declarados en F.1.

---

## 4. Orden de aplicación propuesto (sujeto a las votaciones)

1. REC-06 (lote obligatorio), puntos 1, 2, 5 y 6, más `tools/contar.sh` y el comparador de AC-9, antes de integrar contenido.
2. REC-07 y REC-08: arnés y ventana listos para re-correr.
3. Ítems de contenido aprobados (REC-09 a REC-33), con build y pruebas sin modelo después de cada uno y medición con `contar.sh` antes y después de cada fusión.
4. REC-02: fase con modelo, después REC-06 punto 3 (F.4 y rótulos) y REC-05.
5. REC-01 (versión), REC-03 (relectura con REC-04) y, al final, las decisiones del PO.

Un mismo ítem nunca mezcla cifras de dos servidores sin la columna «servidor».
