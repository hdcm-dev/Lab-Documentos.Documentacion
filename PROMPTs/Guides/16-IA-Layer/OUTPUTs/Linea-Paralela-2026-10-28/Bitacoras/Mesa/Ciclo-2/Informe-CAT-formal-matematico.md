---
doc_id: BIT-16-C2-INF-CAT-formal-matematico
doc_type: informe-de-mesa
title: Relectura integral (ciclo 2) — informe del rol «Formal / matemático»
status: emitido
origin: ai-assisted
last_review: 2026-10-28
rol: CAT-formal-matematico
mandato: umbrales, cuantificadores, métricas (hit@k, recall@k, MRR, Wilson, tasas), fórmulas y estimando de cada número
evidencia: evidencia-CAT-formal-matematico/
---

# Informe CAT-formal-matematico — relectura integral, ciclo 2

## 1. Alcance y método

Leí la guía completa (`Dot-Net-Integration-AI-Layer-Guide.md`, 4116 líneas) de punta a punta, por partes. Dentro de mi mandato
bajé a `Examples/01`, `04`, `05` y `06` (pruebas `ConModelo/`, `Evaluacion/Oro.cs`, `EvaluacionDeRecuperacion.cs`) y a los
registros crudos de `evidencia-examples/04`, `05` y `06`. No leí otros `Informe-*.md`. No corrí nada contra el modelo: todo lo
que sigue sale de aritmética sobre las cifras publicadas y de la lectura del código y de los crudos.

Lo que verifiqué con cuenta propia (evidencia en `evidencia-CAT-formal-matematico/`):

- **Las 93 apariciones de k/n con intervalo de Wilson** en la guía (17 intervalos distintos) (`wilson.py`, `wilson-salida.txt`, z = 1,959964): todos
  coinciden a dos decimales.
- La cota exacta unilateral de 0/n, la prueba del signo con discordantes puros y mixtos, la dependencia del estimando
  «pasa en m/m» respecto de m, el presupuesto de E.5 y la línea de azar con dos relevantes (`cotas-y-cuentas.py`,
  `cotas-y-cuentas-salida.txt`).
- La coherencia interna de las tablas de §6.8 y §6.9 contra los crudos de `Examples/04` y `05`.

## 2. Hallazgos

### CAT-FO-01 · §6.9: la comparación pareada usa otra unidad que la fila que acompaña (S2, coherencia)

**Ubicación.** Guía §6.9, tabla de l. 1730–1734 («Comparación pareada»); §8.1.4, l. 2650 (definición de par discordante).

**Evidencia.** La fila dice «Respondibles que pasan en 3 de 3: 10/12 | 10/12 | 3 discordantes (2 y 1)». Si el par fuera ese
binario (pasa en 3/3 o no), con los dos márgenes en 10/12 los discordantes en cada sentido serían iguales (b = c): «2 y 1» es
imposible. Lo mismo en «Todas»: 37/48 por los dos lados (0,771) obliga a b = c por corrida, y la tabla dice «3 y 2». El código
(`Examples/05/.../Evaluacion/Oro.cs`, `Estadistica.Pareada`, y `ContextoFijoFrenteARagConModeloTests`, «pares =
consultas.Select(c => (aciertos contexto, aciertos rag))») empareja **por consulta sobre los aciertos en 3 semillas**:
discordante es «una estrategia acertó en más semillas que la otra». La guía no lo dice, y §8.1.4 define discordante como «uno
acierta y el otro no». El crudo además da «Todas, pasan en 3/3: 10/16 [0,39; 0,82] y 11/16 [0,44; 0,86]», que la tabla
omite. Detalle en `E-FO-01-pareada-ex05.txt`.

**Propuesta.** (a) Encabezado de la columna: «Comparación pareada (el par es la consulta; discordante = distinto número de
aciertos en las 3 semillas)». (b) Debajo de la tabla, agregar: «Por eso hay discordantes aunque las dos columnas den 10/12: la
fila cuenta las consultas que pasan en 3 de 3; el par compara cuántas semillas acertó cada estrategia en la misma consulta.
Todas las consultas, pasan en 3 de 3: contexto fijo 10/16 [0,39; 0,82], RAG 11/16 [0,44; 0,86].» (c) En §8.1.4 reemplazar
«y sólo mira los pares discordantes (uno acierta y el otro no)» por «y sólo mira los pares discordantes: el par es el pedido
(o la consulta), y es discordante cuando una variante acierta en más semillas que la otra; con una semilla, cuando una acierta
y la otra no».

### CAT-FO-02 · La regla de comparación está enunciada de tres maneras incompatibles (S2, coherencia)

**Ubicación.** §0.5 l. 225; §5 «Cifras» l. 906; §6.8 l. 1718; §6.9 l. 1726; §8.4.4 l. 2823 y 2825; §8.14 l. 3202; §9.7
l. 3443; §2.6.4 l. 308.

**Evidencia.** (1) §0.5, §6.8, §6.9 y §8.14 dicen «6 o más pares discordantes **en el mismo sentido**», lo que admite 7 a favor y
2 en contra; §8.4.4, E.5 y el código (`aMejor == 0 || bMejor == 0`) exigen **todos** en el mismo sentido (p = 2·0,5⁶ = 0,031).
Con 7 contra 1, la lectura de §0.5 da «difiere» y el código «no separado» (signo exacto p = 0,070). (2) §5 l. 906 («con N = 10
no se usa para afirmar que una variante supera a otra») y §8.4.4 l. 2825 («lo que no se puede es decir que una variante supera
a otra») contradicen la propia regla, que con 10 semillas permite «difiere» si hay ≥ 6 discordantes puros, y contradicen §9.7,
que declara «difiere» en D1 y D3 con N = 10 (9 y 10 discordantes). (3) En §9.7 y §2.6.4 el «par» entre dos modelos es la
semilla, que no empareja nada entre modelos distintos: la prueba del signo no es la que corresponde; la conclusión se sostiene
igual con la exacta de Fisher para dos proporciones, pero la guía la presenta como pareada. Detalle en `E-FO-02-regla-pareada.txt`
y `cotas-y-cuentas-salida.txt`.

**Propuesta.** (a) En §0.5, §6.8 l. 1718, §6.9 l. 1726 y §8.14 l. 3202 escribir siempre «6 o más pares discordantes, **todos**
en el mismo sentido». (b) En §5 l. 906 reemplazar «y con N = 10 no se usa para afirmar que una variante supera a otra» por «y
dos variantes se declaran distintas sólo por la regla pareada de §8.4.4, nunca comparando sus intervalos». (c) En §8.4.4
l. 2825 reemplazar la última oración por «Con N = 10 una tasa se puede **mostrar** con su intervalo; que una variante supera a
otra se afirma sólo con la regla pareada, no porque los intervalos no se toquen.» (d) En §9.7 agregar tras «todos en el mismo
sentido»: «(entre modelos la semilla no empareja: la cuenta equivale a comparar dos proporciones independientes, y con 10/10
frente a 1/10 o a 0/10 la exacta de Fisher también separa)».

### CAT-FO-03 · El estimando operativo de «la tarea» no está declarado y depende de m (S2, evidencia)

**Ubicación.** §0.5 l. 225; §3.7 l. 532; Anexo C («Tasa de este pedido / de la tarea»); §6.9 fila «media de las tasas por
consulta»; §8.4.4 l. 2822.

**Evidencia.** Las definiciones de §0.5, §3.7 y del glosario dicen «k/n sobre al menos 10 pedidos … intervalo sobre los
pedidos», pero no qué se cuenta por pedido. Sólo §8.4.4 y E.5 dicen «pedidos que pasan en m/m: j/K». Ese estimando es la
proporción de pedidos que el modelo resuelve **en todas** las semillas, que depende de m: un pedido con 0,9 de acierto por
semilla pasa 3/3 con probabilidad 0,73 y 5/5 con 0,59 (`cotas-y-cuentas-salida.txt`). Como §3.7 dice que es «la única que
puede fijar un umbral», un umbral sin m declarado no es comparable entre corridas. Además, §6.9 rotula «la tarea» también a
«la media de las tasas por consulta» (0,771), que es otro estimando (acierto medio por corrida) y sale sin intervalo ni la nota
«sin Wilson sobre K·m» que sí trae el crudo. Detalle en `E-FO-03-estimando-tarea.txt`.

**Propuesta.** (a) En §0.5, después de «intervalo calculado sobre los pedidos», agregar: «; se cuenta un pedido como acierto
cuando pasa en las m semillas, así que el valor depende de m y se informa junto con él». (b) En §3.7, en la definición de
«Tasa de la tarea», agregar «(j/K: pedidos que pasan en m de m; un umbral se fija para un m dado)». (c) Igual en el glosario.
(d) En §6.9, fila «Todas»: «media de las tasas por consulta (acierto medio por corrida; otro estimando, sin intervalo: las 48
corridas no son independientes)».

### CAT-FO-04 · Una tasa hace fallar una prueba, contra la regla de la guía (S2, coherencia)

**Ubicación.** `Examples/01-Chat-Basico/tests/.../ConModelo/ChatConModeloTests.cs` l. 18 y 68; `MaxOutputTokensConModeloTests.cs`
l. 69; `Examples/01-Chat-Basico/README.md` l. 150; guía Anexo A.4 l. 3629; reglas en §8.1.3, §9.5 («Las tasas no hacen fallar
una prueba») y E.5 regla 3.

**Evidencia.** `ChatConModeloTests` hace `Assert.That(k, Is.GreaterThanOrEqualTo(m - 2))` sobre «nombra 4 dígitos», una tasa
de este pedido: con k = 7 de 10 la prueba falla. `MaxOutputTokensConModeloTests` falla si por `/v1` no se observa ninguna
salida excedida (una existencia convertida en aserción). La guía dice en §8.1.3 «Tasa observada: … se informa y no hace
fallar» y «Una tasa no es un umbral de aceptación», y el Anexo A.4 muestra como «caso real» de cabecera un criterio «con
k ≥ 8». Detalle en `E-FO-04-tasa-como-compuerta.txt`.

**Propuesta.** En `ChatConModeloTests.cs`: borrar la l. 68 y cambiar la l. 18 a «la tasa se informa, sin umbral (§8.1.3)». En
`MaxOutputTokensConModeloTests.cs`: dejar como aserción sólo `nativaAcotada == m` (invariante de la vía nativa) y registrar
`v1Excedida` como «se observó en k de n» sin `Assert`. En el README de 01 (l. 150) y en el Anexo A.4 (l. 3629): reemplazar
«invariantes en 10/10 y «nombra 4 dígitos» con k ≥ 8» por «invariantes en cada corrida; «nombra 4 dígitos» se informa, sin
umbral». Si la presidencia prefiere conservar el umbral, la alternativa es declararlo en §8.1.3 como un cuarto tipo («umbral de
humo, elegido y no medido, que corta una corrida rota») y quitar de §9.5 y E.5 la frase absoluta.

### CAT-FO-05 · Misiones: la métrica publicada no ve el error que la guía nombra, y la cuenta manual no coincide (S2, evidencia)

**Ubicación.** §7.3.4, tabla l. 2017–2018 y párrafo l. 2022; Anexo B.1, ESC-01 pregunta 2 (l. 3652); §3.2 l. 464.

**Evidencia.** «Afirma un conteo con número 0/10 [0,00; 0,28]» por las dos vías usa el criterio previo `\b\d+\s+localidad`
(`evidencia-examples/06/00-criterio-previo.md`), que no captura «cero» ni «no hay localidades cargadas». El párrafo dice que,
por lectura manual, «entre 3 y 4 de cada 10» afirmaron cero sin consultar. En los crudos son **4 de 10** por la vía nativa
(s = 3, 4, 5, 9) y **5 de 10** por `/v1` (s = 3, 4, 5, 8, 10). El lector ve 0/10 con intervalo junto a la confabulación que
§3.2 llama riesgo dominante. Detalle en `E-FO-05-misiones-criterio.txt` y `misiones-afirma-cero.txt`.

**Propuesta.** En la tabla, renombrar la medida a «afirma un conteo en cifras (criterio previo: `\b\d+\s+localidad`)». En
l. 2022 reemplazar «Por lectura manual, entre 3 y 4 de cada 10 respuestas afirmaron «no hay localidades» o «cero» sin haber
consultado (existencia).» por «Ese criterio no ve «cero» ni «no hay localidades»: leídas a mano después de correr, afirmaron
cero sin consultar 4 de 10 respuestas por `/api/chat` y 5 de 10 por `/v1` (existencia, criterio posterior: no es una tasa).»

### CAT-FO-06 · §6.8: la lección 2 atribuye a la calibración valores de la evaluación (S3, evidencia)

**Ubicación.** §6.8, lección 2, l. 1719.

**Evidencia.** «La calibración no fue separable: «¿Si elimino una ciudad se pierden las encuestas?» trajo … 0,463, más que el
acierto del código postal (0,373).» Esas dos consultas son `e13` y `e01` del conjunto de **evaluación**
(`02-oro-con-y-sin-instruccion.txt`), no del de calibración (5 + 5), que es el que fija el umbral. Y con el umbral 0,4756, `e13`
(0,463) **se abstuvo bien**: el ejemplo muestra que ningún umbral separa la evaluación, no que la calibración falló. Detalle en
`E-FO-06-calibracion-vs-evaluacion.txt`.

**Propuesta.** Reemplazar la oración por: «La calibración no fue separable (la peor respondible quedó por debajo de la mejor no
respondible) y en la evaluación tampoco hay umbral que separe: «¿Si elimino una ciudad se pierden las encuestas?» trajo «Una de
las localidades cargadas en el ABM.» con 0,463, más que el acierto del código postal (0,373).»

### CAT-FO-07 · Dos cotas distintas para 0/10 sin decir cuál es cuál (S3, coherencia)

**Ubicación.** §8.4.4 l. 2820 y E.5 regla 3(b) l. 4049 («0,26 con n = 10»), frente a §8.1.4 l. 2650 y todas las tablas («0/10,
[0; 0,28]»).

**Evidencia.** 1 − 0,05^(1/n) = 0,259 es la cota **exacta unilateral** (Clopper-Pearson) al 95 %; el 0,28 es el límite
superior del Wilson **bilateral** al 95 %. Las dos son correctas, pero la guía las llama a las dos «cota superior al 95 %» y un
lector ve 0,26 y 0,28 para el mismo 0/10 (`cotas-y-cuentas-salida.txt`).

**Propuesta.** En §8.4.4 y en E.5 regla 3(b) escribir: «Con 0 en n, la cota exacta unilateral al 95 % (Clopper-Pearson) es
1 − 0,05^(1/n): 0,26 con n = 10; el Wilson bilateral que informan las tablas da 0,28 para el mismo 0/10.»

### CAT-FO-08 · Cuentas del Anexo E que no cierran: presupuesto de un turno y medianas de §7.13.2 (S3, reproducibilidad)

**Ubicación.** Anexo E.5, regla 5 (l. 4051); §7.13.2 (l. 2583) frente a E.4.

**Evidencia.** (1) Regla 5: 45 min / 27 s = 100 llamadas, no «unas 90»; y los dos ejemplos no suman eso: K = 10 × m = 5 = 50,
cuatro tasas de un pedido × 10 = 40. La mediana «de unos 27 s por llamada del 4b» no figura en E.4 (las medianas del 4b en 4
núcleos van de 4,68 a 26,37 s según la operación). (2) §7.13.2 dice «de 4,65 a 4,96 s de mediana por serie»; E.4, que se
declara fuente de «toda cifra de latencia», da medianas 4,68 y 4,75 s para esas series; 4,65 es el mínimo de una serie, y 4,96
no aparece. Detalle en `E-FO-07-08-cotas-y-presupuesto.txt`.

**Propuesta.** (1) Regla 5: «con una mediana de hasta unos 27 s por llamada del 4b en la estación de 4 núcleos (la propuesta de
escritura más lenta de E.4), un turno de 45 minutos da unas 100 llamadas: alcanza para una tasa de la tarea con K = 10 y m = 5
(50 llamadas) más cuatro tasas de un pedido con m = 10 (40), sin margen». (2) §7.13.2: «una llamada a herramienta con el modelo
cargado tardó 4,68 y 4,75 s de mediana en dos series de 10 (E.4), sin contar la carga».

## 3. Observaciones menores, no elevadas

- §6.1 y §6.8: la «línea de azar» k/12 supone un relevante por consulta; el oro de `Examples/04` tiene una consulta con dos
  (criterio previo), donde el azar de hit@3 es 0,455, no 0,25. Con 1 de 12 consultas, el promedio pasa de 0,25 a 0,27: no cambia
  ninguna lectura, pero la frase «con un relevante» debería decir «con un relevante por consulta (una tiene dos)».
- E.5 cita `05 · RecuperacionConModeloTests` en §6.9, que no la menciona; el crudo da hit@1 11/12 con instrucción y 12/12 sin,
  el sentido contrario al de `Examples/04`. Refuerza «no separado» si se cita.

## 4. Revisado y bien

1. **Wilson, sin excepción.** Las 93 apariciones de k/n con intervalo (17 intervalos distintos) coinciden con mi cálculo (z = 1,959964), y el código que los produce
   (`Oro.cs`, `RegistroRllm.Wilson`) es la fórmula correcta con recorte a [0; 1]. Nunca se calcula sobre K·m.
2. **hit@k, recall@k, MRR@k y abstención.** Las definiciones de §6.1 son correctas, las no respondibles quedan fuera de los
   promedios, el código (`MetricasDeRecuperacion`) las implementa igual y la tabla de §6.8 es internamente consistente
   (hit@1 = hit@3 = MRR@3 = 11/12 con un relevante en rango 1; abstenciones indebidas 4/12 coinciden con el crudo).
3. **«Falso aceptado»** tiene unidad (la propuesta), numerador y denominador (las que pasan `LocalidadRules`), se separa de la
   invariante violada y queda «no medido», sin umbral, en §3.7, §8.3.1 y el glosario.
