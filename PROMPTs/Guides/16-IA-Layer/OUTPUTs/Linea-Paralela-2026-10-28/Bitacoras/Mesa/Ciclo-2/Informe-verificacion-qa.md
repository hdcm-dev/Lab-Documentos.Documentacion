---
doc_id: BIT-16-C2-INF-verificacion-qa
doc_type: informe-de-especialista
title: Informe a ciegas — Verificación / QA (relectura integral, ciclo 2)
status: hecho
origin: agent
owner: rol Verificación / QA de la mesa (ciclo 2, REED-16 §10)
last_review: 2026-10-28
audience: [mesa-evaluadora, presidencia, relator, jurado]
traces: [REED-16 §9.1, §10, §13, BIT-16-C1-06 §10, BIT-16-C1-07, BIT-16-C2-00, Ciclo-2/trazabilidad.md, Ciclo-2/evidencia-examples/, Ciclo-2/evidencia-demo/, Sondeo-Evidencia/2026-10-28/cifras-2026-10-28.md]
---

# Informe de Verificación / QA — relectura integral (ciclo 2)

## 1. Mandato y alcance

¿Cada afirmación técnica tiene REF con versión y fecha o resultado medido y rotulado? ¿Las cifras coinciden con la evidencia cruda de `evidencia-examples/` y `evidencia-demo/` (muestra de al menos 20)? ¿Los snippets coinciden con el código? Re-correr build y `Cableado/` de tres ejemplos al azar y de la demo.

Leí la guía entera (4116 líneas, por partes), los README y el código que piden los snippets, y la evidencia cruda que se cita abajo. A ciegas: no leí ningún otro `Informe-*.md` de este ciclo. Fuera del mandato no opino.

## 2. Lo que corrí

| Qué | Cómo | Resultado | Evidencia |
|---|---|---|---|
| Elección de los tres ejemplos | `shuf` con semilla fija 20261028 sobre `Examples/` | `10-Workflow`, `06-Tool-Calling`, `02-Streaming` | `evidencia-verificacion-qa/01-correr.sh.txt` |
| Build + `Cableado/` de los tres y de la demo | copias en el área de trabajo del laboratorio, recurso `build`, `mcr.microsoft.com/dotnet/sdk:10.0` (SDK 10.0.403), volumen `<volumen-nuget>`, comandos del README de cada carpeta | los cuatro: `0 Warning(s)`, `0 Error(s)`; `10-Workflow` 27/27, `06-Tool-Calling` 23/23 (guía §7.3.2: 23), `02-Streaming` 9/9 (E.1: 9), demo 69/69 (§8.3.1 y §9.8: 69) | `01-builds-y-cableado-10-06-02-demo.txt` |
| Filtro de §8.4.2 sobre la demo | `dotnet test MovilidadUrbana.Asistente.slnx --filter TestCategory=Cableado` | «No test matches the given testcase filter» (0 pruebas, sin error) | `02-demo-filtro-TestCategory-Cableado.txt` |
| Snippets contra el código | script que toma cada bloque `csharp` con «Compila en … (l. a–b)» y compara línea a línea con el archivo; los 12 que la referencia precede al bloque o tiene dos tramos, con ruta y rango a mano | **66 de 66** coinciden con el tramo citado (54 automáticos, 12 manuales) | `03-snippets-automatico.txt`, `03-snippets-manual.txt`, `verificar-snippets*.py` |
| Referencias de línea sin snippet | 16 rangos citados en el texto (`FormaNoEsValidezTests` l. 112–127, `RecorridoD1aD6Tests` l. 273–302, `Oro.cs` l. 82–91, `ReglaDeCapas` l. 89–124, etc.) | los 16 caen en la prueba o el método que la guía nombra | salida en la sesión; rangos en el §5 |
| Paquetes | `PackageReference` de todos los `.csproj` | coinciden con D.2 (versiones y carpetas) | `05-paquetes-csproj.txt` |
| Fechas de tres REF sin versión | API de arXiv, 2026-10-28 | ver VERIFI-06 | `arxiv-*.xml`, `arxiv-fechas-2026-10-28.txt` |

No quedó `bin/`, `obj/` ni `*.db` en la carpeta de la guía (verificado con `find` al terminar).

## 3. Muestreo de cifras contra la evidencia cruda (31 cifras)

| # | Cifra en la guía | Dónde | Fuente cruda | Estado |
|---|---|---|---|---|
| 1 | «nombra 4 dígitos» 10/10; Markdown 7/10; pared mediana 2,9 s (2,4–10,1) | §5.4, §8.10.2 | `01-Chat-Basico/con-modelo/rllm/chat-basico-4b.txt` (mediana recalculada 2,9) | coincide |
| 2 | `MaxOutputTokens` 3: nativa 3 en 3/3, `length`; `/v1` 30, 35, 31, `stop` | §5.7 | `…/rllm/max-output-tokens-4b.txt` | coincide |
| 3 | 4096 → 2050 tokens en 3/3, respuestas «14», «30», «34» | §2.5 | `…/rllm/num-ctx-humo.txt` | coincide |
| 4 | 16384 y 8192 → 6843 «3 de 3» | §2.5, §5.4, §6.5, E.5 | ídem: **16384 tiene una sola corrida** (referencia) | **no coincide → VERIFI-01** |
| 5 | primer texto 24,9 s → mediana 0,51 s en nueve repeticiones | §6.4.3 | `02-Streaming/corrida-2/1-completa.jsonl` (mediana s2–s10 = 0,505) | coincide |
| 6 | corte ≤ 0,01 s, 10/10; fragmento final sin texto 10/10 | §5.5 | `corrida-3-final/2-cancelacion.jsonl`, `corrida-2/1-completa.jsonl` | coincide |
| 7 | forma 10/10; CP «3400» 8/10, siempre «3400»; 2 con «34» | §5.6, §2.5 | `03-…/03-conmodelo-corrida-2/conmodelo-salidas.jsonl` | coincide |
| 8 | 0 escrituras en 40 corridas | §5.6 | `…/conmodelo-resumen.txt` | coincide |
| 9 | hit@1 11/12 y 10/12; recall/MRR 0,917 y 0,833; abstención 4/10; indebidas 4 de 12; umbrales 0,4756 y 0,4407 | §6.8 | `04-…/02-oro-con-y-sin-instruccion.txt` | coincide |
| 10 | 128/128 vectores idénticos; un par discordante | §6.8 | ídem, l. 2 y 64 | coincide |
| 11 | 0,463 frente a 0,373; colectivo/ómnibus 0,6082, bicicleta 0,5962, avión/Moto 0,7010, Tren 0,6371 | §6.8 | `04-…/03-consola.txt`, `03-similitud-entre-medios.txt` | coincide |
| 12 | 10/12 y 10/12; 0 de 4 y 1 de 4; media 0,771 y 0,771; discordantes 3, 2 y 5 | §6.9 | `05-…/corrida-2/05-contexto-fijo-frente-a-rag.txt` (RESUMEN y PAREADA) | coincide |
| 13 | tokens 516 / 241; pared 4,2 / 4,6 s; 0 de 48 citas ausentes | §6.9, §6.3 | ídem (COSTO; recalculado) | coincide |
| 14 | cita literal copiada en 28 de 48 RAG y 4 de 48 contexto fijo | §6.9 | `05-…/corrida-1-ejemplo-de-cita-literal/…` (conteo de «[Politica.») | coincide |
| 15 | puntajes 0,301–0,539 frente a 0,429–0,788 | §6.9 | `05-…/corrida-2/05-recuperacion.txt` | coincide |
| 16 | Chaco 10/10 por vía; Misiones «fuera del catálogo» 9/10 (nativa) y 10/10 (`/v1`); 0 conteos | §7.3.4 | `06-…/con-modelo/tool-calling-*.txt` | coincide |
| 17 | 23 pruebas de `Cableado/` | §7.3.2 | `06-…/cableado/01-build-y-cableado.txt` y mi corrida | coincide |
| 18 | plazo cortó a los 205 ms | §7.5.2 | `07-…/cableado/02-test-cableado.txt` l. 7 | coincide |
| 19 | baja pendiente 10/10, otra entidad 0/10; 4 núcleos: primer pedido > 300 s | §7.5.4 | `07-…/con-modelo/estacion-*/…` | coincide |
| 20 | MCP: más núcleos 10/10 y 10/10; 4 núcleos 9/10 y 1 timeout de 300 s; revisión 2026-07-28 | §7.8.4, §7.8.2 | `08-…/con-modelo-estacion-*/agente-por-mcp.txt` | coincide |
| 21 | 362 cacheados de unos 441; cuatro spans en 10/10 | §6.4.4, §8.5.1 | `09-…/pipeline-con-modelo.txt` | coincide |
| 22 | 5114 con 8192, 2050 con 4096 y excepción en 3/3 | §6.5, §8.8 | `09-…/contexto-truncado.txt` | coincide |
| 23 | deserializó 10/10; catálogo 5/10 | §8.9.1 | `09-…/salida-estructurada-con-modelo.txt` | coincide |
| 24 | 37 pruebas de `Cableado/` | §8.4 | `09-…/01-sin-modelo-salida.txt` | coincide |
| 25 | alta: CP «34» 8/10, rechazo 9/10, «3489» 1/10; 3450 exacto 10/10; secuencial 10/10 | §7.6.2, §7.7 | `10-…/conmodelo-workflow-de-alta.txt`, `conmodelo-secuencial.txt` (8×«34», 1×«3489», 1×«34899») | coincide |
| 26 | 13 pruebas; 34 tipos en el núcleo; R4 con 12 hallazgos | §4.6.2 | `13-…/02-cableado.txt` (l. 18–29: los 12 rastros) | coincide |
| 27 | D1 «34» tal cual 10/10; D2 sin propuesta 10/10 y 1 habitante inventado; D3 5/10; D4 9/10; D6 10/10 | §9.5, §9.5.1 | `evidencia-demo/pruebas/conmodelo/D*.jsonl` (D2 s = 5: «34.633 habitantes») | coincide |
| 28 | D5 8/12 [0,39; 0,86], A07 0/3; abstención en 8 de 9 | §9.5.2 | `…/D5-20261028-192838.jsonl` | coincide |
| 29 | inyección: 0/10 baja, 0/10 herramienta inexistente, repitió 10/10; «Tengés»/«Tás» en 7 de 10 | §8.10.1, §5.4 | `…/CTRL14-nombre-*.jsonl` | coincide |
| 30 | herramientas: medianas 4,68 y 4,75 s; razonando 24,22 s y 152 tokens; «caminata» 10/10; «piedra» en 6 de 10 | §2.5, E.4 | `Sondeo-Evidencia/2026-10-28/salidas/04-tools.jsonl`, `05-tools-apie.jsonl` (recalculado) | coincide; **§7.13.2 las cita mal → VERIFI-03** |
| 31 | lectura del prompt «unos 19 tok/s (13–22)» | §2.5, E.3 | `Sondeo-Evidencia/2026-10-28/cifras-2026-10-28.md` | **no coincide con E.4 → VERIFI-02** |

29 de 31 coinciden con lo crudo; las dos que no, y una mal rotulada, son hallazgos.

## 4. Hallazgos

### VERIFI-01 · La ventana de 16384 se corrió una vez, no tres (S3, evidencia)

- **Ubicación:** guía §2.5 (l. 410), §5.4 (l. 1062), §6.5 tabla, fila 1 (l. 1506), Anexo E.5 fila `01 · NumCtxConModeloTests` (l. 4059).
- **Evidencia:** `evidencia-examples/01-Chat-Basico/con-modelo/rllm/num-ctx-humo.txt`: la cabecera dice «3 semillas por tamaño (s = 1..3) **+ 1 de referencia**» y hay una sola línea `num_ctx=16384 s=1 entrada=6843`; las tres semillas son de 8192 y de 4096. El README del ejemplo lo dice bien (l. 152: «1 pedido × 3 semillas por tamaño (s = 1..3) más 1 de referencia»). La guía dice «Con `num_ctx` 16384 y 8192 entraron 6843 tokens (3 de 3)» y la tabla de §6.5 pone «16384 y 8192 … este pedido, 3 semillas por tamaño».
- **Propuesta:** §5.4: «Con `num_ctx` 8192 entraron 6843 tokens (3 de 3), igual que en la corrida de referencia con 16384 (1 corrida).» §6.5, fila 1: columna `num_ctx` «8192 (y 16384, 1 corrida de referencia)»; estimando «este pedido, 3 semillas con 8192 y 4096». §2.5: «con 8192 llegaron los 6843 en 3 de 3, y con 16 384, en la corrida de referencia». E.5: «6843 tokens con 8192 (3/3) y con 16384 (1 de referencia)».

### VERIFI-02 · El rango «13–22 tok/s» no es el de la tabla del mismo anexo (S3, coherencia)

- **Ubicación:** §2.5 (l. 412), §6.4.3 (l. 1467, «unos 19 tokens por segundo sin caché»), Anexo E.3 fila «Lectura del prompt» (l. 4001), contra la tabla E.4 (l. 4014 y 4029).
- **Evidencia:** E.4 declara la regla («se calcula sólo en llamadas con más de 1 s de evaluación; las repeticiones servidas desde la caché del servidor no cuentan») y, con esa regla, muestra para el 4b **27,2** (chat corto en frío, 37 tokens) y **11,8** (prefijo alterado, **0 reusados**). Ninguna de las dos está en 13–22. El rango sale de una selección de cuatro lecturas largas (18,8; 17,6; 21,9; 13,2), según `Sondeo-Entorno.md` l. 325; la de 13,2 (O3) no figura en E.4. La fuente de E.4 es `Sondeo-Evidencia/2026-10-28/cifras-2026-10-28.md`.
- **Propuesta:** E.3: «unos 19 tok/s de mediana en las cuatro lecturas largas sin caché (1466–2943 tokens: 13,2–21,9); en la tabla E.4, de 11,8 (prefijo alterado, 0 reusados) a 27,2 (prompt de 37 tokens)». §2.5: «la lectura de prompts largos sin caché rondó 19 tokens por segundo (13–22 en cuatro mediciones; 11,8 con el modelo ya cargado y el prefijo alterado, Anexo E.4)». Y agregar a E.4 la fila de O3 (`qwen3.5:4b`, 1469 tokens, 13,2 tok/s), para que el rango tenga su fila.

### VERIFI-03 · §7.13.2 presenta un rango como «mediana por serie» (S3, evidencia)

- **Ubicación:** §7.13.2 (l. 2583).
- **Evidencia:** la guía dice «una llamada a herramienta con el modelo cargado tardó de 4,65 a 4,96 s de mediana por serie». Recalculado de `Sondeo-Evidencia/2026-10-28/salidas/04-tools.jsonl` y `05-tools-apie.jsonl` (4b): medianas **4,68** y **4,745**; sin la primera llamada (la de la carga), el **rango** de las dos series es 4,65–4,78 y 4,69–4,96. E.4 (l. 4018–4019) y §2.5 dan las medianas bien.
- **Propuesta:** «una llamada a herramienta con el modelo cargado tardó una mediana de 4,68 s y de 4,75 s en las dos series de 10 (de 4,65 a 4,96 s sin la primera, que carga el modelo; estación de 4 núcleos)».

### VERIFI-04 · El filtro de §8.4.2 da 0 pruebas en la demo, sin error (S3, reproducibilidad)

- **Ubicación:** §8.4.2 (l. 2797): «Por eso cada suite se corre con su filtro (`--filter TestCategory=Cableado` o `TestCategory=ConModelo`).» También la tabla de antipatrones de §8.14 se apoya en esa lectura.
- **Evidencia:** sólo 8 de las 13 carpetas usan esos filtros. `03-Salida-Estructurada` usa `Category!=ConModelo`; `05-RAG-En-Memoria` y la demo, `FullyQualifiedName~Cableado`; `13-Prueba-De-Arquitectura` corre sin filtro y con `Category=Regla` para las mutaciones (`evidencia-verificacion-qa/04-filtros-por-carpeta.txt`). Las pruebas de `Cableado/` de la demo no tienen categoría (0 `Category("Cableado")`). Corrido el 2026-10-28 sobre la demo: `--filter TestCategory=Cableado` → «No test matches the given testcase filter» y el comando termina sin error (`02-demo-filtro-TestCategory-Cableado.txt`). Quien siga la regla de §8.4.2 lee una corrida vacía como si hubiera pasado, que es justo el error que la sección quiere evitar. §9.8 y el README de la demo traen el filtro correcto.
- **Propuesta (texto):** «Por eso cada suite se corre con el filtro que trae el README de su carpeta: `TestCategory=Cableado` o `TestCategory=ConModelo` en la mayoría; `FullyQualifiedName~Cableado` en `Examples/05` y en la demo, y `Category!=ConModelo` en `Examples/03`. Con un filtro que no aplica, `dotnet test` dice «No test matches» y no falla.» **Alternativa (código, mejor):** agregar `[Category("Cableado")]` a las clases de `Cableado/` de `03`, `05`, `13` y de la demo, y unificar sus README en `TestCategory=Cableado`; entonces la frase de §8.4.2 queda verdadera tal cual.

### VERIFI-05 · «Tardó 167 s», pero la pared fue 168,20 s (S4, coherencia)

- **Ubicación:** §8.6 (l. 2939), §9.8 (l. 3460), E.4 fila «prompt largo» (l. 4030: «168,20 (unos 167 s)»).
- **Evidencia:** en `Sondeo-Entorno.md` l. 325, s5 son 2943 tokens leídos en **167,4 s**; la pared de la llamada, en `cifras-2026-10-28.md`, es **168,20 s**. «Unos 167 s» es la lectura del prompt, no lo que tardó la llamada, y la celda de E.4 se contradice.
- **Propuesta:** §8.6: «una sola llamada con 2943 tokens de prompt tardó 168 s, 167 de ellos en leer el prompt a unos 18 tokens por segundo». §9.8: «tardó 168 s». E.4: «168,20 (167,4 de lectura del prompt)».

### VERIFI-06 · Tres REF de arXiv sin versión ni fecha (S4, evidencia)

- **Ubicación:** Anexo D.1, REF-067 (l. 3836), REF-068 (l. 3837) y REF-090 (l. 3859): columna «Versión o fecha de publicación» = «—». Las demás de arXiv traen «v1 aaaa-mm-dd».
- **Evidencia:** API de arXiv consultada el 2026-10-28 (`evidencia-verificacion-qa/arxiv-fechas-2026-10-28.txt`): 2404.06654 publicado 2024-04-09, vigente v3 (2024-08-06); 2307.03172 publicado 2023-07-06, vigente v3 (2023-11-20); 2407.16833 publicado 2024-07-23, vigente v2 (2024-10-17).
- **Propuesta:** REF-067 «v1 2024-04-09 (v3 2024-08-06)»; REF-068 «v1 2023-07-06 (v3 2023-11-20)»; REF-090 «v1 2024-07-23 (v2 2024-10-17)». La fecha de consulta queda como está.

### VERIFI-07 · Una fila de E.5 remite a §6.9, que no tiene esa cifra (S4, coherencia)

- **Ubicación:** Anexo E.5, fila `05 · RecuperacionConModeloTests` (l. 4063): «hit@3 12/12 [0,76; 1] con y sin instrucción … En la guía: §6.9».
- **Evidencia:** la cifra está en `evidencia-examples/05-RAG-En-Memoria/corrida-2/05-recuperacion.txt` (hit@3 12/12 con y sin instrucción; hit@1 11/12 con, 12/12 sin; 1 discordante, «no separado»). En la guía, `12/12` sólo aparece en esa fila de E.5. §6.9 no la menciona, y §6.8 da para `Examples/04` otra cifra (hit@3 11/12), así que una persona que siga la remisión encuentra un número distinto.
- **Propuesta:** agregar en §6.9, antes de la tabla: «La recuperación de este ejemplo, medida sola (k = 3, la tarea, K = 12; estación con más núcleos), dio hit@3 12/12 [0,76; 1] con y sin instrucción, y hit@1 11/12 y 12/12, no separados: los fallos de la tabla no vienen de la búsqueda.» Si no, cambiar la columna «En la guía» de esa fila por «— (README de `Examples/05`)».

## 5. Revisado y bien

1. **Los 66 snippets de C# coinciden con su archivo y su tramo de líneas.** No hay ninguno sin referencia «Compila en». Además, los 16 rangos que el texto cita sin snippet caen en la prueba o el método que nombran (`03-snippets-*.txt`).
2. **Build y `Cableado/` se reproducen.** Tres ejemplos al azar y la demo, en un contenedor limpio con SDK 10.0.403, con 0 advertencias y los totales que dice la guía: 06 23/23, 02 9/9, demo 69/69 (10-Workflow 27/27; la guía no da ese total). Los paquetes de todos los `.csproj` son los de D.2.
3. **Las cifras contra el modelo son trazables al crudo y llevan rótulo.** 29 de las 31 del muestreo coinciden con la evidencia cruda, con estimando, N, Wilson y estación correctos, incluidos los casos finos: siempre «3400», «3489» y «34899» en el alta, 28/48 frente a 4/48, 8 de 9 abstenciones y los 12 rastros de R4. Las dos que no coinciden son VERIFI-01 y VERIFI-02.
