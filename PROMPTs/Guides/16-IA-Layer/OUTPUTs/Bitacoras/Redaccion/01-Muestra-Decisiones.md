---
doc_id: BIT-16-RED-01-MUESTRA
doc_type: decisiones-de-presidencia
title: Decisiones de la presidencia sobre la sección de muestra §5
status: cerrado
origin: agent (presidencia de la mesa de redacción)
last_review: 2026-10-27
traces: [BIT-16-RED-00-CARTA §16, secciones/05.md, BIT-16-04 v3 §C, BIT-16-06 §8]
---

# Decisiones sobre la sección de muestra §5

Tres lecturas de `secciones/05.md`: **L1** didáctica, **L2** editorial y **L3** técnica .NET. Las tres dieron «aprobado con observaciones» y ninguna editó archivos. La presidencia contrastó cada hallazgo con el plan v3 (§C), el código de `Examples/` y `Demos/`, los registros de `Evidencia/` y el registro de referencias, y decidió lo que sigue. Las reglas generales que salen de acá están en la carta, **§16 «Lecciones de la muestra»**.

## Índice

- [1. Evidencia que se comprobó antes de decidir](#1-evidencia-que-se-comprobó-antes-de-decidir)
- [2. Decisiones sobre la carta](#2-decisiones-sobre-la-carta)
- [3. Decisiones sobre la sección](#3-decisiones-sobre-la-sección)
- [4. Descartado o aplicado de otra forma, con motivo](#4-descartado-o-aplicado-de-otra-forma-con-motivo)
- [5. Otros archivos tocados](#5-otros-archivos-tocados)
- [6. Pendientes fuera del alcance de la presidencia](#6-pendientes-fuera-del-alcance-de-la-presidencia)
- [7. Estado final de §5](#7-estado-final-de-5)

## 1. Evidencia que se comprobó antes de decidir

| Afirmación en disputa | Qué se miró | Resultado |
|---|---|---|
| Por `/v1` «no se puede saber» si hubo recorte (L3) | `Evidencia/R-LLM/02-Cambio-De-Adaptador.modelo.jsonl`, `Examples/_Comun/…/AI/GuardaDeTruncado.cs` | Por `/v1` llega `prompt_eval_count` = 103, igual que por OllamaSharp. El `null` de `truncado_posible` lo pone `Evaluar`, que exige OllamaSharp y `numCtx`. **L3 tiene razón.** |
| En 02 «las reglas rechazan» la localidad inventada (L1) | mismo registro, campo `salida` | Es texto libre, sin `LocalidadRules`; el «4 dígitos» lo escribió el modelo y su CP de ejemplo tiene cinco. **L1 y L2 tienen razón**; la carta §10 y `06-Construccion.md` §8 decían lo contrario. |
| El compartido se rechaza «con `num_ctx` por defecto» (L3) | `ConfiguracionDelModelo.cs`, `DesdeEntorno` y `Validar` | El origen es `Default` sólo cuando `OLLAMA_NUM_CTX` no está definida. **L3 tiene razón.** |
| Recargar el modelo con otra ventana es «criterio de la guía» (L2) | `ConfiguracionDelModelo.cs`, README de 01, registro de REF-55, dossier N3b | Sólo lo afirman un comentario del código y un README; N3b lo trata como criterio propio. No hay REF ni registro. **Va como «no verificado».** |
| REF-192 agregado contra la carta (L2, L3) | Archivo crudo de `ChatClientBuilder.cs` en el commit 25f07afa | La línea 47 dice «the first factory added is the outermost». Fuente fijada a un commit y verificable. **Se convalida.** |
| Salidas de `--fake` sin fuente en R-LLM (L3) | `Evidencia/` | Están en `02-Cambio-De-Adaptador/reverificacion.log`, `03-Salida-Estructurada/fake-demostracion.log`, `Arnes/01-…fake.log`, `Arnes/04-…reverificacion.log` y `Cierre-Construccion/verificar-build.*.log`. **Se admiten los logs** como fuente. |
| Sondeo del entorno sin rótulo (L1, L2, L3) | `Bitacoras/Sondeo-Entorno.md` | Fechas 2026-10-25 y 2026-10-26; Ollama 0.32.0-rc0; sólo CPU; **sin digest**. |
| PD-3 contado sin rótulo (L2) | `Evidencia/R-LLM/Demo-MovilidadUrbana.Asistente.modelo.jsonl`, `pd3-01` | `qwen3.5:4b`, digest `2a654d98e6fb`, servidor compartido, 2026-10-27, `habitantes: null`. |
| Comando de la carta desactualizado (L2, L3) | `Examples/README.md` y los README de 01 a 04 | El comando es `tools/verificar.sh correr <carpeta> [--con-modelo]`. **L2 y L3 tienen razón.** |
| AC-7 y AC-8 no corren (L3) | `tools/compuerta-ac7.sh`, `compuerta-ac8.sh` | Exigen listas fuera del repositorio (R-PRIV). Es el diseño, no una falla. |
| Conteo de 3.391 (las tres lecturas) | regla de §11 llevada a un comando (carta §16.3) | Da 3.391 sobre la versión leída: el comando reproduce el conteo del redactor. |
| Comentarios que enseñan, cortados (L3) | `NormalizacionDeMovilidad.cs`, `FabricaDeClientes.cs`, `AsistenteDeAyuda.cs` | La línea «Nunca se descarta en silencio…» lleva un ID interno («hueco H4»). Se conserva la línea anterior y la regla se cuenta en la prosa. `Envolver` y `_historial` sí entran. |

## 2. Decisiones sobre la carta

| # | Hallazgo (lectura) | Decisión | Dónde |
|---|---|---|---|
| C1 | Bloques de la plantilla colgando de §N.k (L1, L2, L3) | **Aplicado**: título de nivel 3 sin número «Práctica de §N» (`sN-practica`) que agrupa los cuatro bloques de nivel 4. Se descartan los cuatro bloques en nivel 3 (ver §4). §15.1 y §15.2 quedan cerrados. | §6.1, §13, §15, §16.1 |
| C2 | Topes sólo por Parte (L1, L2, L3) | **Aplicado**: tabla de topes por sección, topes por bloque, orden de recorte y comando de conteo. Parte II: §4 ≤ 1.800 y §5 ≤ 3.200. | §11, §12.2, §16.3 |
| C3 | Ficha uniforme por ejemplo (L1) | **Aplicado**: título · carpeta · dificultad · ilustra · OA, comando, snippet, «Qué mirar», salida, «Probá…» opcional. Orden de los ejemplos: por numeración, declarado. | §16.4 |
| C4 | Forma de las respuestas a las preguntas guía (L1, L2, L3) | **Aplicado**: tres momentos, 60 a 130 palabras, la pregunta en su propio párrafo con línea en blanco, la evidencia del mismo artefacto y el cierre sobre el verbo del OA. | §7, §16.7 |
| C5 | Vocabulario de evidencia sin definir (L1) | **Aplicado**: lo define §0.4, se suma al glosario (ya hecho) y se enlaza en el primer uso. | §16.8; `00-Glosario.md` |
| C6 | Rótulos: variantes, repetición, sondeo, prosa (L1, L2, L3) | **Aplicado**: rótulo completo la primera vez por entorno y sección, rótulo corto después, fila del sondeo sin digest y sólo como conducta, rótulo también en la prosa y «humo de la demo». | §9.3, §16.6 |
| C7 | Salidas con tuteo o errores (L2, L3) | **Aplicado**: se copian textuales y no se corrigen; recorte con «[…]». | §16.6 |
| C8 | Comando de los ejemplos (L2, L3) | **Aplicado**: `tools/verificar.sh correr`. | §9.2 |
| C9 | Snippets: tope, sangría, comentarios con IDs, primer snippet (L1, L2, L3) | **Aplicado**: unas 25 líneas, sangría común quitada, la línea con ID interno se saltea entera, no se recorta lo que enseña, las piezas transversales van en su casa y la entrada remite al ejemplo más simple. | §9.2, §16.5 |
| C10 | Fila 02 de la tabla de cifras (L1, L3) | **Aplicado**: reescrita según el registro. Se avisa que `06-Construccion.md` §8 dice lo mismo (ver §6). | §10, §16.13 |
| C11 | Alias «salida tipada» en la carta (L2) | **Aplicado** en §2.3, en el diagrama de §3 y en OA-D2. «PD-3 extracción tipada» queda igual: no es el término del glosario, es el nombre del paso. | §2.3, §3, §5 |
| C12 | Términos en inglés y «función» (L2) | **Aplicado**. | §16.9 |
| C13 | Números de cuatro cifras, literales y fechas (L2) | **Aplicado**. | §11, §16.9 |
| C14 | Imperativos de voseo (L2) | **Aplicado**, con un control por grep. | §16.9 |
| C15 | Límite de «criterio de la guía» (L2) | **Aplicado**, con tope orientativo de ocho marcas por sección. | §11, §16.9 |
| C16 | Citas en inglés (L2, L3) | **Aplicado**: paráfrasis o traducción en la misma oración. | §16.9 |
| C17 | Alta de REF nuevos (L2, L3) | **Aplicado**: protocolo con constancia y convalidación de la presidencia. Se reemplaza la prohibición de §9.1, que la muestra ya había mostrado impracticable. | §9.1, §16.10 |
| C18 | Comentarios PENDIENTES en un repositorio público (L1, L2) | **Aplicado**: formato fijo, viven sólo en `secciones/`, se quitan al integrar y se controlan con `grep -c '<!--'` = 0. | §12.2, §16.11 |
| C19 | Línea de ubicación, anclas de OA y apertura (L1, L2, L3) | **Aplicado**: forma canónica, anclas `oa-…` en §0.1 y apertura de 90 palabras como máximo, sin enumerar subsecciones. El título de Parte lo escribe la primera sección de cada Parte. | §3, §13, §16.2 |
| C20 | «Definición.» en recuadros y en las subsecciones de decisión (L1, L2, L3) | **Aplicado**: el recuadro abre con «Qué se observó y con qué.»; el «qué no es», en una oración explícita. | §16.12 |
| C21 | «—» ambiguo y celdas no enseñadas (L1, L3) | **Aplicado**. | §16.12 |
| C22 | Remisiones hacia adelante (L1) | **Aplicado**: regla de progresión. | §16.7 |
| C23 | Compuertas con `grep` aliasado, AC-7 y AC-8 (L3) | **Aplicado**: `command grep -E`; AC-7 y AC-8 las corre la integración. | §12.2, §16.11 |
| C24 | Índice local (L3) | **Aplicado**: no lleva; alcanza §0.0. | §16.2 |

## 3. Decisiones sobre la sección

| # | Hallazgo (lectura) | Decisión |
|---|---|---|
| S1 | Pregunta 4 apoyada en 02 (L1, L2, L3) | **Aplicado**: se apoya en el guion de 03 con `--fake` (JSON válido con `"habitantes":30000`, descartado por la garantía). |
| S2 | Orden de responsabilidades en la pregunta 4 (L3) | **Aplicado**: el adaptador descarta, el caso de uso normaliza y valida, la pantalla pide. |
| S3 | A la pregunta 1 le falta el contexto de uso (L1) | **Aplicado**: CTX-LOCAL y CTX-NUBE, y el caso que cambia la respuesta (`GetService` / `RawRepresentationFactory`). |
| S4 | La pregunta 5 no cierra su OA-O2 (L1) | **Aplicado**: cierra con `OLLAMA_NUM_CTX` y la capa única. |
| S5 | «Sólo la nativa evita el recorte silencioso» (L3) | **Aplicado**: «sólo la nativa fija la ventana en cada pedido; por `/v1` hay que fijarla en el servidor [REF-55] y la aplicación no puede comprobarla». |
| S6 | «Por `/v1` no puede hacerlo» (L3) | **Aplicado** en §5.7, en la tabla de §5.6 y en la pregunta 2: llegan los tokens; la guarda responde «no verificable», con la ruta de `GuardaDeTruncado.cs`. |
| S7 | «`num_ctx` por defecto» en el rechazo del compartido (L3) | **Aplicado**: «sin `OLLAMA_NUM_CTX` definida». |
| S8 | Hecho de Ollama rotulado «criterio de la guía» (L2) | **Aplicado**: el criterio queda para la decisión y la recarga va como «no verificado». |
| S9 | «Prevé» (L2) | **Aplicado**: «preví». |
| S10 | Alias «salida tipada» (L2) | **Aplicado** en la apertura y en §5.3. |
| S11 | Rótulos fuera de forma, sondeo y PD-3 (L1, L2, L3) | **Aplicado** con la regla nueva (§16.6): el sondeo con su rótulo propio y sus dos fechas, 02 con rótulo corto, PD-3 con «humo de la demo». |
| S12 | «4096» (L2) | **Aplicado**: «4.096» en la prosa. `8192` sigue en código. |
| S13 | «Tramo» sin presentar y «función» (L2) | **Aplicado**: «tramo (*span*)» y «capacidad del proveedor». |
| S14 | Citas en inglés sin explicar (L2, L3) | **Aplicado**: paráfrasis junto a REF-48 y REF-24. |
| S15 | REF-35 como prueba sobre qwen3.5 (L2) | **Aplicado**: el respaldo es el mecanismo del código (`PredicadoDeSalto.cs`, `/api/show`) y REF-35 queda sólo como ejemplo de que el soporte se anuncia por modelo. |
| S16 | Falta el código del caso de uso de 03 (L3) | **Aplicado**: recorte de `AltaDesdeTextoService.cs` (`Decidir` y `ConfirmarAsync`). |
| S17 | Recortes que ocultan lo que enseñan (L3) | **Aplicado**: `Envolver` en lugar de `CrearHttp`; la declaración de `_historial` en 01; en 04, la línea «Cada medio propuesto entra…». La línea siguiente se saltea porque trae un ID interno (§16.5). |
| S18 | Sobreafirmación de la segunda pregunta de 01 (L3) | **Aplicado**: «la verificación de 01 comprueba que la segunda vuelta reenvía la conversación entera», según el README. |
| S19 | Llamada con herramientas y «circuito» sin definir (L3) | **Aplicado**: remisión a §8.2 y «una por conexión de Blazor». |
| S20 | El antipatrón `.Result` implica la excepción (L3) | **Aplicado**: queda «el camino sin IA no queda escrito en el código», como criterio de la guía. |
| S21 | Extensión de 3.391 palabras (L1, L2, L3) | **Aplicado**: quedó en 3.191, con un tope de 3.200. Recortes, en el orden de §16.3: la tabla de antipatrones pasó a dos viñetas y se sacó la que repetía un criterio; se sacaron las filas «Caché de prefijo» (su casa es §6.4), «Credencial» (pasó a «Qué mirar» de 02) y «Estado de la conversación»; los rótulos repetidos pasaron a la forma corta; se compactaron transiciones. |
| S22 | Ficha de ejemplo, «Qué mirar», ilustra y OA (L1) | **Aplicado** en los cuatro ejemplos, con comando y `--con-modelo`. |
| S23 | Primer snippet de infraestructura (L1) | **Aplicado de otra forma**: §5.1 remite a 01 como el uso más simple; los snippets transversales siguen en su casa (§16.5). |
| S24 | Bloques de la plantilla, «Definición.» del recuadro y «—» (L1, L2, L3) | **Aplicado**: «Práctica de §5», «Qué se observó y con qué.», la definición de «—» y una celda de CTX-PROD apoyada en §5.2. |
| S25 | Línea «Estás en» y apertura (L1, L2) | **Aplicado**: forma canónica con OA enlazados; la apertura ya no enumera las subsecciones. |
| S26 | Comentario PENDIENTES con vocabulario interno (L1, L2) | **Aplicado**: sin «dossier», «ficha» ni «presidencia»; con la procedencia de cada salida y el motivo de cada snippet por encima del tope. Se borra al integrar. |
| S27 | Vocabulario de evidencia (L1) | **Aplicado**: una oración al empezar Ejemplos que remite a §0.4. |

## 4. Descartado o aplicado de otra forma, con motivo

| Propuesta | Lectura | Decisión y motivo |
|---|---|---|
| Los cuatro bloques en nivel 3 sin número, como hermanos de las subsecciones | L2, L3 | **Descartado.** El plan §C fija «plantilla en nivel 4». El agrupador «Práctica de §N» resuelve la tabla de contenido sin contradecir el plan. Lo propuso L1 y la propia muestra lo dejó como alternativa. |
| §5 ≤ 3.000 y §4 ≈ 2.000 | L1, L2 | **Ajustado** a §5 ≤ 3.200 y §4 ≤ 1.800, dentro del tope de 5.000 de la Parte II. Con 3.000, §5 perdía la evidencia que pidió L3 (el caso de uso de 03 y la regla de 04), y el orden de recorte prohíbe sacar evidencia. §4 no tiene ejemplos propios: 1.800 alcanzan para seis subsecciones, la tabla de hitos y cinco preguntas, aunque con poco margen. Si no alcanzan, §4 declara cuánto toma de §5 (§16.3). |
| Rótulo corto sin digest en lugar del completo, una sola vez en §0.4 | L1 | **Ajustado**: completo una vez por entorno y por sección, para que cada sección se pueda leer sola; después, corto. |
| «Con el mismo rótulo» sólo dentro del mismo ejemplo y digest siempre obligatorio | L2 | **Ajustado**: el digest es obligatorio en el rótulo completo y el corto conserva modelo, servidor y fecha (lo que exige AC-9). «Con el mismo rótulo» queda dentro del mismo ejemplo. |
| Snippets de ≤ 20 líneas | L1 | **Ajustado** a unas 25 (L2, L3), con excepción declarada. Con 20, el bucle de streaming de 01 o el `SinPropuesta` de 03 quedaban afuera. |
| Un solo snippet por ejemplo | L3 | **Descartado** como regla fija. En 03, la propuesta, el extractor y el caso de uso son tres capas, y el principio rector pide mostrar en el código que deciden las reglas. Basta con el tope de líneas. |
| «Probá cambiar…» en cada ejemplo | L1 | **Opcional**, y sólo con opciones que documenta el README. En §5 no se usó por presupuesto: las opciones documentadas (`--adaptador`, `--extension`) no cambian la lección de la sección. |
| Reordenar los ejemplos según las subsecciones | L1 | **Descartado.** El orden por número es el de lectura del Anexo E y el de dificultad; se declara en una línea y cada subsección remite por ancla. |
| Agregar en §5 una definición de «circuito» de Blazor | L3 | **Ajustado**: «una por conexión de Blazor», sin definir el término, que no se usa más en §5. |
| Topes de L3 por bloque (Definición ≤ 80, respuesta ≤ 90, escenarios ≤ 3 filas) | L3 | **Ajustado** a los de §16.3 (Definición ≤ 120, respuesta de 60 a 130, ≤ 4 filas). Con ≤ 90 palabras no entran los tres momentos que piden L1 y L2. |
| Aceptar de 02 «el modelo agrega datos no pedidos» como apoyo de la pregunta 4 | L3 | **Descartado** por presupuesto. La pregunta 4 se sostiene con 03, y la conducta de 02 ya está contada en su ejemplo. |

## 5. Otros archivos tocados

- `00-Glosario.md`: cinco entradas nuevas (cliente guionado, prueba de cableado, prueba de humo, estímulo del mismo autor, IC95), sin alias, con «Se define en §0.4». Lo pide C5.
- `00-Referencias.md`: REF-192 queda marcada como convalidada por la presidencia el 2026-10-27, después de volver a comprobar la cita contra el archivo crudo.

## 6. Pendientes fuera del alcance de la presidencia

- `06-Construccion.md` §8, filas 02 (línea 30 y línea 223): dice que «las reglas del dominio la rechazan», igual que decía la carta. La presidencia no escribe en esa bitácora; rige la carta §10, ya corregida.
- §0 tiene que crear las anclas `oa-…` en la tabla de §0.1 y el párrafo de vocabulario de evidencia de §0.4. Hasta entonces, los enlaces `#oa-d1`, `#oa-d2` y `#oa-o2` de §5 no resuelven.
- AC-7 y AC-8 sobre §5 no se corrieron: necesitan listas fuera del repositorio. Las demás compuertas sobre §5, sin el comentario PENDIENTES, dieron 0: remisiones al plan, familias de ID, IPs y rutas absolutas de máquina, alias y voseo. El voseo da 0 fuera de la salida textual del modelo, que tutea y se cita igual. La comprobación de snippets dio 10 de 10 bloques textuales.
- `07-Redaccion.md` todavía no existe. Cuando se cree, tiene que registrar que las compuertas de anclas, inclusión, rutas y conteo se hacen a mano o con el comando de §16.3.
- Los README de 03, 04 y 08 siguen diciendo que la extensión no se corrió (carta §15.7, sin cambios).

## 7. Estado final de §5

- Archivo: `secciones/05.md`.
- Prosa: 3.191 palabras, con el comando de la carta §16.3. Tope: 3.200.
- 10 snippets, todos textuales con la sangría común quitada. Dos pasan las 25 líneas y su motivo está en PENDIENTES.
- Toda cifra está en la tabla de §10 de la carta. Toda salida tiene su procedencia en PENDIENTES.
- Veredicto de la presidencia: **aprobada como sección de muestra**. Las demás secciones se redactan con la carta y su §16.
