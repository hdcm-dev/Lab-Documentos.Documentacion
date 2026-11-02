---
doc_id: BIT-16-C1-04-impacto
doc_type: aprobacion-de-parches
title: Aprobación del juez de impacto — ciclo 1, vuelta 1
status: entregado
origin: agent
owner: juez de impacto (REED-16 §9.6; M§5.5)
last_review: 2026-10-28
audience: [presidencia, cuerpo auditor, aplicación, redacción]
traces: [REED-16 §9.6, §9.7, §12, §13; M§5.5, M§6; Mesa/Ciclo-1/03-Parches.md; Mesa/Ciclo-1/02-Voto-impacto.md; Mesa/Ciclo-1/02-Revision-Homogeneidad.md]
---

# Aprobación del juez de impacto — ciclo 1, vuelta 1

**Función.** Decido por parche `APLICAR`, `MEJORAR_PLAN`, `NO_APLICAR` o `ESCALAR` desde la pregunta de impacto: *¿qué le pasa al lector de la guía (y a quien aplica el parche) si esto entra así?* Antes de cada decisión corrí el chequeo obligatorio de M§5.5: **¿el parche corrige en la capa donde nació el defecto?**

**Qué verifiqué en la fuente (2026-10-28, entre 11:20 y 11:30 -03).** No compilé ni corrí nada contra el modelo. Por R-PRIV, no transcribo direcciones, usuarios ni rutas del home.

| Verificación | Resultado | Parche |
|---|---|---|
| Digest del índice `ollama/ollama:0.40.11` en Docker Hub (API `hub.docker.com/v2/repositories/ollama/ollama/tags/0.40.11`, consultada 2026-10-28 11:27 -03) | `sha256:dea72d1e…322d8`, publicado el 2026-10-24T17:09Z: coincide con P-10. `latest` ya apunta a otro digest (2026-10-27): fijar 0.40.11 es una decisión, no la última versión, y la receta tiene que decirlo así | P-10 |
| `GHSA-2fmv-rv2c-59x7` (medium) y `GHSA-846f-f764-76mx` (high), API de avisos de GitHub, misma fecha | Publicados el 2026-10-13. Afectan a `System.Security.Cryptography.Pkcs` `>= 9.0.0, <= 9.0.20`, entre otros rangos; 9.0.11 está adentro; corregido en 9.0.21 y 10.0.13 | P-32 |
| NUnit en `api.nuget.org/v3-flatcontainer/nunit/index.json` | La última versión listada es 5.0.0 | P-17 |
| Wilson 95 % para 2/10 | [0,057; 0,510]: coincide con P-02 | P-02 |
| N para un intervalo de ancho ≤ 0,2 con p ≈ 0,5 | Con 96, la semiamplitud de Wilson es 0,098: el «N ≥ 96» se sostiene | P-02 |
| Semiamplitud de Wilson con 10–20 casos | ±0,17 (16/20) a ±0,23 (8/10) con acuerdo cerca de 0,8; con acuerdo 0,5, ±0,20 (20) a ±0,26 (10) | P-38 |
| Hoy, en `OUTPUTs/` | 21 líneas con ruta del home en 9 `.md`; 1 archivo con dirección de host de la tailnet (`Reanudar.md`). La cifra se mueve mientras el ciclo escribe, así que el número no cierra nada: cierra la salida del script | P-01 |
| Hoy, en los nueve núcleos | `Validación del núcleo` = 0 en todos; `Aplicación por escenario` = 0 en N1–N5 y 2 en N3b; `ESC-0` = 0 en N1–N5 | P-04, P-34 |
| Referencias por número de sección de la guía dentro de 03-Parches | P-06 usa la numeración vieja en ocho filas, y RV-02, RV-03, RV-04 y RV-12 citan secciones por número viejo, aunque P-07 diga que «las RV citan secciones por su título» | P-06, P-07 |

## 1. Resumen

| Resultado | Parches |
|---|---|
| `APLICAR` | P-01 a P-05, P-08 a P-44 (42 parches; cuatro condicionados con las dos ramas diseñadas, P-05, P-17, P-23 y P-35, y algunos con un ajuste que no pide otra vuelta, como P-27, P-34 y P-38: se detallan en la columna de condiciones) |
| `MEJORAR_PLAN` (vuelta 1 de 2) | **P-06** y **P-07**: la numeración de secciones |
| `NO_APLICAR` | ninguno |
| `ESCALAR` | ninguno. Ningún parche dispara REED-16 §12. El único disparador posible es el tipo 6 (empate persistente), y sólo si la segunda ronda de C1-48, C1-40/C1-62, C1-55 o C1-38 empata dos veces |

**Capa.** Los 44 parches corrigen en la capa de origen. Los casos en que lo miré con más cuidado:

- **P-16**: el defecto nace en el caso base (la política dice cosas que el código no hace cumplir). El parche no toca el caso base, que no se puede tocar (REED-16 §12, fila 3). Lo enuncia como lo hace el código y registra la diferencia como deuda heredada. Es lo correcto.
- **P-19 y P-20**: la cifra mal atribuida nació en N3b. El parche corrige N3b y desde ahí propaga.
- **P-26**: la frase sale de `Mesa/I-01`, un insumo del PO. El parche corrige N4 y la integración, y a I-01 sólo le deja una nota. El defecto de la guía nace en N4, que la tomó sin verificarla, y ahí se corrige.
- **P-30 y P-21**: el defecto nace en el laboratorio (el `grep` con dos agujeros, cuatro cifras mal derivadas de los jsonl). Las dos correcciones van al laboratorio.

## 2. Decisiones por parche

| Parche | Decisión | ¿Capa correcta? | Fundamento (impacto) | Condición o ajuste |
|---|---|---|---|---|
| P-01 | APLICAR | sí | Si no entra, el primer commit publica una dirección de la tailnet con usuario, y rutas del home que en la máquina del lector no existen. El daño es irreversible. El parche trae el comando fijo (`rpriv.sh`), el caso rojo fuera del repo y la rama alternativa para el caso de que la presidencia rechace la excepción a sólo agregado. No le encuentro un hueco que dañe al lector | Va primero (03 §4.1). La redacción in situ de los registros espera el dictamen de la presidencia; `Reanudar.md` se redacta en las dos ramas. El rótulo de RV-01 reemplaza a los «medido en estación 1» de P-21 y P-37 en todo texto que llegue a la guía |
| P-02 | APLICAR | sí (N0b → integración) | Hoy el lector encuentra dos sentidos de «falso aceptado» y una cifra (2/10) que no sostiene umbral. El parche deja un solo sentido, lo separa de la invariante y de la métrica de producto, y en la guía pone «no medido». Verifiqué el Wilson y el N ≥ 96 | RV-02 cita secciones por título (ver P-07) |
| P-03 | APLICAR | sí (N5 / integración) | Es el S1 que más le cuesta al lector: copiaría una cola sin techo presentada como mitigación de LLM10. El parche fija el techo, el 503 con `Retry-After` y la cancelación, y no le vende ningún orden del pipeline antes de PC-02. La condición de la clave de caché con `SessionId` cierra el cruce que había señalado riesgo | La elección de rama si PC-02 falla es del jurado de aprobación de la vuelta en que PC-02 se corra, con la salida guardada. Hasta entonces, M8 queda neutral. RV-03 por título |
| P-04 | APLICAR | sí (núcleo) | Sin esta tabla, el lector no sabe qué recomendación vale para su escenario: hoy `ESC-0` da 0 en N1–N5. La regla «ninguna celda en blanco» evita que un vacío se lea como «aplica» | RV-04 tiene que decir «cada sección de tema» por título, no «§3–§7» (con la estructura de P-07, las secciones de tema son otras) |
| P-05 | APLICAR (condicionado) | sí (N6 / integración) | La regla común («una pieza entra a la demo sólo si la necesita una afirmación E1, con todos sus controles») es la que protege al lector de una demo inflada. El mapeo D1–D7 → ESC → CTX no depende de la segunda ronda | La columna «en la demo» se llena con la rama que gane la segunda ronda de C1-48 (mayoría ≥ 3 sobre la opción). Dos empates seguidos → ESCALAR tipo 6 |
| P-06 | **MEJORAR_PLAN** | sí (integración) | Las decisiones están bien fundadas, incluido el descarte de PR-7: era un «revisar si», y RD-PO-1, posterior, lo contesta. Pero la nota que se va a escribir en BIT-16-04 manda contenido a secciones con la numeración vieja, que P-07 cambia. Por ejemplo: PR-2 «por qué ahora» → «guía §1», que en P-07 es el mapa conceptual, que no define nada; PR-4 «¿un agente o varios?» → «§6», que en P-07 es conocimiento, no agentes; PR-8 CAG → «§5», que es abstracciones; PR-11 despliegue → «§7», que es agentes; PR-19 → «§4», que es la capa de IA. Quien redacte pone el contenido en la sección equivocada, y el lector lo busca donde no está | Reescribir la columna «Destino» citando la sección por su título de P-07 (o por número nuevo y título juntos). Correspondencia que surge de P-07: «por qué ahora» → §2; PR-4, PR-5 y PR-18 → «Agentes, herramientas y orquestación»; PR-8 → «Estrategias de conocimiento»; PR-9 → «Marco de referencia»; PR-10 → «Estrategias de conocimiento» y «Operar, evaluar y asegurar»; PR-11 → «Operar, evaluar y asegurar; despliegue»; PR-19 → «Hablar con un modelo desde .NET». Verificación agregada: ninguna fila cita un número de sección sin título |
| P-07 | **MEJORAR_PLAN** | sí (integración) | La estructura es buena y es la que el lector necesita: un mapa que dice «estoy en ESC-xx con CTX-yy → qué aplico», presupuesto y reglas de compresión. Pero el parche afirma dos veces que «las RV citan secciones por su título» y que por eso «siguen valiendo» si se revierte. Es falso hoy: RV-02 («guía §2 y §7»), RV-03 («guía §7»), RV-04 («§3–§7») y RV-12 («guía §5 y §8») citan números viejos. Aplicada así, RV-04 exige el bloque de escenarios en «Marco de referencia» y lo omite en «Operar, evaluar y asegurar» | (1) Reescribir RV-02, RV-03, RV-04 y RV-12 de 03 §3 por título de sección. (2) Agregar a la nota una tabla de correspondencia «§ vieja de BIT-16-04 §8 → § nueva y título», para que los registros previos que citan la numeración vieja sigan siendo legibles. (3) Corregir la frase de reversión. P-09 y P-28 se aplican después de la vuelta 2 de P-07 (03 §4.3) |
| P-08 | APLICAR | sí | Sin esto, la guía le hablaría al lector en ids de bitácora que no puede seguir. Las tres RV son verificables | — |
| P-09 | APLICAR | sí | Que una pregunta tenga una sola respuesta vigente es lo que evita que el lector lea dos criterios contradictorios | Después de la vuelta 2 de P-07 (la columna «sección» depende de esa numeración) |
| P-10 | APLICAR | sí (pedido / integración) | La receta es lo que permite que el lector reproduzca algo. Verifiqué el digest en Docker Hub. La compuerta «clon limpio sin caché NuGet» es la que detecta que funciona sólo en la estación de laboratorio | El Anexo E dice «0.40.11 fijada a propósito; `latest` es posterior» con la fecha, para que el lector no crea que es la última |
| P-11 | APLICAR | sí | Sin una clase de opciones única, el lector arrastra literales y un timeout por defecto que ya se probó insuficiente (168 s en una llamada). La validación al arrancar y el 400 previo al modelo le ahorran fallas silenciosas | RV-12 por título |
| P-12 | APLICAR | sí | Corrige la premisa refutada («mezcla sesiones» pasa a «pierde la sesión sin error», con PC-11), que era lo que un lector se iba a llevar como hecho. La prueba P-10 en las dos configuraciones le muestra el fallo silencioso | — |
| P-13 | APLICAR (parcial) | sí | El ADR del estado de la conversación es firme y no depende del perímetro. Las ramas A y B del contrato están diseñadas | La rama la fija P-35 después de la segunda ronda. En la rama A, PC-12 se responde antes de redactar |
| P-14 | APLICAR | sí | La salida como texto, sin `MarkupString`, es lo que impide que el lector copie una vía de XSS (LLM05:2025). Declarar qué se trae de la Web evita que crea que la demo es independiente | — |
| P-15 | APLICAR | sí (núcleo → integración) | El diagrama es lo primero que el lector copia. Con herramientas y MCP del lado de salida, entendería la arquitectura al revés | — |
| P-16 | APLICAR | sí (enunciado en el núcleo, deuda en el caso base) | Hoy el lector creería que hay un máximo de 60 y un catálogo de provincias que el código no hace cumplir. Las pruebas de comportamiento heredado se lo muestran | — |
| P-17 | APLICAR (condicionado) | sí | La copia con cierre de compilación, `diff -r` = 0 y la normalización fuera del árbol copiado resuelve la objeción que nadie había contestado (02-Revision-Homogeneidad §3.2) | La rama sale de la segunda ronda de C1-38 votando la ubicación con carpeta. La guía explica en una frase por qué el CP no ASCII se rechaza por la vía de IA y no por la vía normal (P-16), con la prueba «piedra» como evidencia, para que el lector no lo tome por una incoherencia |
| P-18 | APLICAR | sí (N6) | Agregados sin `Nombre` ni `Edad` y la advertencia de celda chica: el lector no expone datos personales sin saberlo | — |
| P-19 | APLICAR | sí (N3b / N5) | Quitar el 93× evita que el lector espere de `qwen3.5:4b` un beneficio que en la medición fue parcial | — |
| P-20 | APLICAR | sí | Que el truncado sea silencioso es lo más dañino del tema: el lector cree que el modelo leyó todo. La regla de presupuesto y la comparación con el largo medido lo detectan | La parte de qwen3.5:4b queda «no medido» hasta correr P-08 (pendiente de BIT-16-04) |
| P-21 | APLICAR | sí (laboratorio) | Una tabla reproducible por `cifras.py` reemplaza cuatro cifras mal derivadas que el lector habría usado para dimensionar | Rótulo de RV-01 en todo lo que llegue a la guía |
| P-22 | APLICAR | sí (N3 → integración) | Llamar recall a lo que es hit@k le hace sobreestimar al lector la calidad de su recuperación. La línea de azar está bien acotada a «un relevante» | La parte de demo sigue a P-05 |
| P-23 | APLICAR (condicionado) | sí | La regla «no se suma una pieza que el perímetro votado no tiene» protege la coherencia de la demo | Rama por la segunda ronda de C1-55 |
| P-24 | APLICAR | sí | Sin esto, el lector toma un N = 1 como prueba de que A es mejor que B | — |
| P-25 | APLICAR | sí | `Inconclusive` en lugar del verde silencioso es lo que le dice al lector que una prueba no corrió | — |
| P-26 | APLICAR | sí (N4) | Saca `npx -y` contra terceros y `= true;` en la aprobación, que el lector copiaría tal cual, y reemplaza los dominios ajenos (RD-PO-3) | — |
| P-27 | APLICAR | sí | Los controles con prueba y el corte definido le dan al lector una lista que puede exigir | Ajuste de forma: el título dice «M1–M14» y el texto define M15; en la aplicación se titula «M1–M15». La reversión «restituye M1–M12» se mantiene |
| P-28 | APLICAR | sí (fundación / pedido) | Las anclas mal citadas de REED-16 §9.1 C2 harían que la compuerta mida contra la tabla equivocada | Después de la vuelta 2 de P-07 |
| P-29 | APLICAR | sí | Un snippet «ejecutado» que no compila con .NET 10 es la falla más directa que el lector va a tener | — |
| P-30 | APLICAR | sí (laboratorio) | El test por reflexión con caso rojo prueba la regla de dependencias. El `grep` tenía dos agujeros | — |
| P-31 | APLICAR | sí | Glosario unívoco y catálogo de referencias: el lector no se encuentra un término con dos sentidos | — |
| P-32 | APLICAR | sí (pedido / integración) | Verifiqué los dos GHSA y el rango que incluye 9.0.11. Que la ruta por defecto dé cero NU19xx es lo que evita que el lector herede una dependencia vulnerable | — |
| P-33 | APLICAR | sí (N1 / N1b) | El lector no fija un muestreo que el fabricante desaconseja, ni da por hecho que `TopK` llega al servidor | — |
| P-34 | APLICAR | sí (pedido / núcleo) | Impide que entren a la guía las dos afirmaciones S1 de N0b y N5 antes de su parche. En el voto había dicho «no bloquea la redacción», y esta precisión lo mejora sin contradecirlo | Ajuste mecánico de verificación: la nota de cada núcleo contiene la cadena «Validación del núcleo», así que `grep -c` daría 2 y no 1. El criterio pasa a «el encabezado `## Validación del núcleo (ciclo 1)` aparece una vez por registro» |
| P-35 | APLICAR (condicionado) | sí | La parte común (toda escritura confirmada, M3 como invariante, ESC-03 nunca escribe y la frase sobre integridad frente a exactitud) es lo que más protege al lector y no depende de la rama | Rama por la segunda ronda con PC-13 cerrada como E3. Dos empates → ESCALAR tipo 6 |
| P-36 | APLICAR | sí | El rótulo «provisional; no se comparó con el 2b» impide que el lector crea que el 4b se eligió por ser mejor | — |
| P-37 | APLICAR | sí (laboratorio) | Corrige una causa inventada («no corre»). Usar el equipo de respaldo como cómputo bajo demanda entra en el rol que el PO le dio a ese equipo, y el contenedor es propio. No toca el servidor dado de baja, así que no es REED-16 §12 fila 4 | Las menciones «P-03 y P-07» se refieren a pendientes de BIT-16-04, no a parches (ver §3). En la guía, el equipo no se nombra (RV-01) |
| P-38 | APLICAR | sí | Sin juez en la demo y con «no medido», el lector no confunde un juez local mal calibrado con una compuerta | Precisión: «±0,17 a ±0,22» vale para un acuerdo cercano a 0,8. Con acuerdo 0,5 llega a ±0,26 con 10 casos. La guía declara el p supuesto o da el peor caso |
| P-39 | APLICAR | sí | La limitación de `/v1` (sin `num_ctx` por pedido) le explica al lector por qué la demo no usa el selector de proveedor | — |
| P-40 | APLICAR | sí | El lector ve progreso y puede cancelar durante una espera de minutos | — |
| P-41 | APLICAR | sí | Evita que filtre `ChatMessage` a Application | — |
| P-42 | APLICAR | sí | Con una sola constante, el lector no se queda con 0 spans sin saber por qué (R6) | Sigue a P-03 |
| P-43 | APLICAR | sí | Una dimensión mal declarada da búsquedas sin sentido y nada lo avisa. Que la aplicación no arranque es el aviso | — |
| P-44 | APLICAR | sí (N5) | Registra el `NO_PROCEDE` real de la propuesta (un campo que no existe en el código) y saca `Examples/11` | — |

## 3. Condiciones transversales de la aplicación

1. **Colisión de ids.** En 03-Parches, «P-nn» nombra a la vez parches del ciclo y pendientes de BIT-16-04 (por ejemplo «sólo P-03 y P-07» en P-37, «P-08 con qwen3.5:4b» en P-20, «MI-23, P-10» en P-12). Quien aplique puede leer un pendiente como un parche y revalidar lo que no corresponde. Al escribir cada nota, los pendientes se citan como «pendiente P-nn de BIT-16-04» y los parches como «Parche P-nn (ciclo 1)». Esto no cambia el contenido de ningún parche, y la guía no hereda ninguno de esos ids (RV-08).
2. **Orden.** Se mantiene el de 03 §4, con una sola diferencia: P-09 y P-28 esperan la vuelta 2 de P-06 y P-07.
3. **Segunda ronda.** Para los cuatro parches condicionados, aplicar quiere decir aplicar la rama que gane con mayoría ≥ 3 sobre la opción (02-Revision-Homogeneidad §3.1). Si la segunda ronda empata, la tercera votación no existe: corresponde ESCALAR por REED-16 §12, tipo 6.
4. **Verificación.** Todo criterio de verificación de un parche se corre y se guarda en `Mesa/Ciclo-1/05-Aplicacion.md` y en `aplicacion/` (REED-16 §9.7). Si falla, se revierte el parche y el ítem vuelve como regresión. Ningún «verde» se declara sin su salida guardada.

## 4. Para la vuelta 2 (P-06 y P-07)

El cuerpo auditor entrega los dos parches con las correcciones de §2 y nada más. Las decisiones de P-06 y la estructura de P-07 no se reabren. La verificación de la vuelta 2 es mecánica: `grep -nE "guía §[0-9]|§[0-9]–§[0-9]"` sobre la nota de P-06 y sobre 03 §3 da 0 citas sin título, y la tabla de correspondencia de P-07 cubre todas las secciones de la tabla vieja de BIT-16-04 §8.
