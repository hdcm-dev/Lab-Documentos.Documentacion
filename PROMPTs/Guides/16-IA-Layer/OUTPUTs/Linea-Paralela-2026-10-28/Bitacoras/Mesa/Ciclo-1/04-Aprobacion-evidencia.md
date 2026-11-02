---
doc_id: BIT-16-C1-04-EVID
doc_type: aprobacion-de-parches
title: Aprobación del ciclo 1, vuelta 1 — juez de evidencia (REED-16 §9.6, M§5.5)
status: entregado
origin: agent
owner: juez de evidencia de la mesa de aprobación del ciclo 1
last_review: 2026-10-28
audience: [presidencia, aplicación, cuerpo auditor]
traces: [REED-16 §9.1, §9.6, §9.7, §12, §13; M§5.5; Mesa/Ciclo-1/03-Parches.md; Mesa/Ciclo-1/02-Voto-*.md; Mesa/Ciclo-1/02-Revision-Homogeneidad.md; BIT-16-00 R-PRIV, R-LLM]
---

# Aprobación del ciclo 1, vuelta 1 — juez de evidencia

Decido sobre los 44 parches de `Mesa/Ciclo-1/03-Parches.md`. Por cada uno contesto dos preguntas: si lo que el parche afirma tiene respaldo (E1–E4) y si corrige en la capa donde nació el defecto (M§5.5). Las rutas de este archivo son relativas a `OUTPUTs/` o a la raíz del workspace (R-PRIV).

## 0. Reglas que apliqué

1. **APLICAR** quiere decir que el diseño queda aprobado tal como está en 03-Parches.
2. **APLICAR con ajuste vinculante** es APLICAR más una corrección mecánica: un número, una línea de código, un patrón o un rótulo. La corrección se verifica con su propio criterio y no cambia el diseño. La aplicación la incorpora textualmente y la registra en `05-Aplicacion.md`. Si no la puede incorporar tal cual, el parche pasa a MEJORAR_PLAN sin otra vuelta de aprobación.
3. **Parches condicionados** (P-05, P-17, P-23, P-35, y las partes condicionadas de P-13, P-22 y P-27). Los apruebo como diseño completo de dos ramas. La parte común se aplica ahora. La rama se aplica sólo cuando la segunda ronda que pide 02-Revision-Homogeneidad §3.1–§3.2 quede registrada con mayoría de 3 o más. Ninguno se escala. REED-16 §12 fila 6 exige dos rondas sin mayoría y todavía no hubo segunda ronda.
4. **ESCALAR: ninguno.** Revisé los siete disparadores de REED-16 §12 y ninguno se cumple. El más cercano es la excepción a «sólo agregado» de P-01. Esa regla es una convención de la bitácora (`Bitacoras/README.md` l. 75), no una restricción dura del PO. Además, P-01 trae una rama que cumple a la vez R-PRIV y «sólo agregado». No hay conflicto irreducible, así que el disparador 2 no aplica.

## 1. Verificaciones que corrí hoy

Mi conocimiento previo no cuenta como evidencia. Esto es lo que consulté o ejecuté el 2026-10-28, entre las 11:20 y las 11:40 (-03):

| # | Qué | Fuente o comando | Resultado | Parche |
|---|---|---|---|---|
| V1 | Imagen `ollama/ollama:0.40.11` | API de Docker Hub, `v2/repositories/ollama/ollama/tags/0.40.11` | digest `sha256:dea72d1e…e322d8`, publicado el 2026-10-24T17:09:46Z. **Coincide** | P-10 |
| V2 | NUnit | `api.nuget.org/v3-flatcontainer/nunit/index.json` | última 5.0.0 (GA). **Coincide** | P-17 |
| V3 | `Microsoft.Extensions.AI.Ollama` | registro de NuGet, última 9.7.0-preview.1.25356.2 | `deprecation` con reemplazo `OllamaSharp`. **Coincide** | P-32 |
| V4 | EF Core SqlServer 10.0.14 | `.nuspec` en flatcontainer | depende de `Microsoft.Data.SqlClient` 6.1.7. No verifiqué el eslabón hasta `Pkcs` 9.0.11: se apoya en el NU1902/NU1903 observado (IMPLEM K6, E1) | P-32 |
| V5 | GHSA-2fmv-rv2c-59x7 y GHSA-846f-f764-76mx | API de avisos de GitHub | moderado y alto, publicados el 2026-10-13. `System.Security.Cryptography.Pkcs` vulnerable en el rango 9.0.0–9.0.20, que incluye 9.0.11. **Coincide** | P-32 |
| V6 | Ollama por `/v1` y `num_ctx` | `docs/api/openai-compatibility.mdx` (rama main, consultado hoy) | «The OpenAI API does not have a way of setting the context size». **Coincide** | P-39 |
| V7 | Reglas del caso base | `git show 59399ba:src/MovilidadUrbana.ApiWeb/Domain/Rules/LocalidadRules.cs` en `/LAB/Lab-E2E.WebBlazor/` | nombre `Trim().Length >= 3` sin máximo; provincia `!IsNullOrWhiteSpace`; CP `^\d{4}$` después de `Trim()`; habitantes ≥ 1; misma localidad `OrdinalIgnoreCase` en el nombre y `Ordinal` en la provincia. **Coincide** con P-16 | P-16 |
| V8 | Validación anidada de opciones | `dotnet/runtime` release/10.0, `DataAnnotationValidateOptions.cs` l. 85 y l. 111 | `TryValidateObject` valida sólo el primer nivel. Baja a un objeto anidado sólo si la propiedad lleva `[ValidateObjectMembers]` | P-11 (**defecto**) |
| V9 | Muestreo de Qwen3.5-4B | `huggingface.co/Qwen/Qwen3.5-4B/raw/main/README.md` l. 835–838 | cuatro preajustes. El modo sin razonamiento tiene **dos**: tareas generales (T 0,7, top_p 0,8, top_k 20, presence_penalty 1,5) y tareas de razonamiento (T 1,0, top_p 0,95, top_k 20, presence_penalty 1,5) | P-33 (precisar) |
| V10 | Especificación MCP 2026-07-28 | `modelcontextprotocol.io/specification/2026-07-28` y `…/basic/security_best_practices` | existe; la sección «Local MCP Server Compromise» está. **Coincide** | P-26 |
| V11 | Wilson al 95 % | cálculo propio, z = 1,96 | 2/10 → [0,057; 0,510] (**coincide** con P-02). Con N = 96 y p = 0,5, ancho 0,196 ≤ 0,2 (**coincide**). Semiancho con 10–20 casos: p = 0,5 → ±0,26 a ±0,20; p = 0,8 → ±0,23 a ±0,17; p = 0,9 → ±0,19 a ±0,14 | P-02, P-38 (precisar) |
| V12 | Compuerta R-PRIV | los cuatro patrones de P-01 sobre `OUTPUTs/` (sólo conté, no imprimí coincidencias) | ruta del home: 30 líneas; host del rango de la tailnet: 1; RFC 1918: 0; `usuario@IP`: 1. **Coincide** con la prueba de diseño. Un caso sintético (dirección del rango seguida de un punto final, `…7.`) **no** lo detecta el patrón del parche y sí la variante corregida de §2 | P-01 (**defecto**) |
| V13 | Estado de git | `git status` en `Lab-Documentos.Documentacion` | `PROMPTs/Guides/16-IA-Layer/` sin rastrear, 0 archivos en el índice. Una redacción in situ hecha hoy no deja la fuga en el historial | P-01 |
| V14 | Marcas `[C:` de la fundación | `grep -n -o '\[C:'` en 00, 01 y 03 | 13 apariciones en 12 líneas. Dos son la explicación de la notación (00 l. 102, 01 l. 18). Quedan 11 marcas, como dice P-28, pero `grep -c` da 12 | P-28 (precisar) |
| V15 | Anclas de BIT-16-02 | encabezados de `02-Cohesion-Global.md` | §6 es la trazabilidad y §7 la estructura. **Coincide** | P-28 |
| V16 | Literales de N5 §4.2 | `grep` en N5 | l. 256 `QueueLimit = int.MaxValue` y l. 258 `"llama3.1"`. **Coincide** | P-03 |
| V17 | Preguntas guía | conteo aproximado por encabezado en los nueve registros | entre 77 y 84 según el patrón. «80» no está fijado mecánicamente | P-09 (precisar) |

## 2. Decisiones

| Parche | Decisión | ¿Capa correcta? | Fundamento de evidencia | Ajuste o mejora |
|---|---|---|---|---|
| P-01 | APLICAR con ajuste vinculante | sí: la fuga nació en `Reanudar.md` y en los registros con rutas absolutas, y la compuerta incompleta en REED-16 §9.1 | V12 reproduce la prueba de diseño. V13 confirma que nada está commiteado, así que la redacción in situ es la única corrección que no deja la fuga a la vista. Una nota agregada no borra una fuga | (1) En los patrones 2 y 3, el cierre `([^0-9.]\|$)` pasa a `([^0-9.]\|\.([^0-9]\|$)\|$)`, para atrapar la dirección seguida de punto final. El caso de prueba fuera del repo suma esa forma. (2) El script informa `patrones=` e `identificadores=` por separado. El cierre sobre `OUTPUTs/` lee `patrones=0`, porque el código de salida combinado falla por identificadores que hoy no bloquean. (3) La excepción a «sólo agregado» la sigue dictaminando la presidencia. Si la rechaza, rige la rama alternativa |
| P-02 | APLICAR | sí: la definición triple nació en N0b §3.1.3 y se propaga a BIT-16-04 | V11 confirma el Wilson de 2/10 y que N ≥ 96 da un ancho de 0,196 | — |
| P-03 | APLICAR | sí: la cola y el literal nacieron en N5 §4.2 (V16); el orden, en BIT-16-04 R-C07 | El rechazo 503 con `PermitLimit` 1 y `QueueLimit` 2 se sigue de la semántica del `ConcurrencyLimiter`, y la prueba del cuarto pedido lo verifica. M8 queda neutral hasta PC-02: no afirma más que lo medido | — |
| P-04 | APLICAR con ajuste vinculante | sí: el hueco está en N1–N5 | La plantilla no afirma nada. El riesgo es llenar celdas sin respaldo | Cada celda completada cita la sección y línea del registro que la respalda. Si no hay respaldo, dice «sin respaldo en el registro: pendiente», no «no aplica» |
| P-05 | APLICAR (parte común ahora; columna «en la demo» tras la segunda ronda de C1-48) | sí | El mapa D1–D7 → caso → ESC sale del recorrido de N6. La regla «sólo lo que una afirmación necesita como E1» es la que comparten las cinco posiciones | — |
| P-06 | APLICAR | sí | La tabla registra decisiones, no hechos. La condición de PR-22 queda atada a P-32 | — |
| P-07 | APLICAR con ajuste vinculante | sí: la estructura vigente vive en BIT-16-04 §8 (P-28 lo fija) | P-07 dice que las RV citan por título, pero RV-02 («§2 y §7»), RV-03 («§7» = operación), RV-04 («§3–§7») y RV-16 usan la numeración vieja. En la nueva, operación es §8 y los temas son §4–§8 | Al agregar la lista de §3 a BIT-16-04, cada referencia numérica de las RV se cambia por el título de la sección de P-07 |
| P-08 | APLICAR | sí | Son reglas verificables por `grep`. No afirman nada sobre el mundo | — |
| P-09 | APLICAR con ajuste vinculante | sí | V17: «80» no es un conteo mecánico | El número de filas es el que da un comando guardado junto al plan, que cuenta las preguntas guía de los nueve registros. El criterio es «filas = conteo», no «= 80» |
| P-10 | APLICAR | sí: el hueco de la receta nació en REED-16 §1.3 frente a §9.1 | V1 confirma la versión, el digest y la fecha | — |
| P-11 | APLICAR con ajuste vinculante | sí | V8: con el fragmento tal como está, `Concurrencia.Permisos = 0` pasa la validación al arrancar. M10 promete «validada al arrancar» y no lo cumple para el objeto anidado | (1) `public OpcionesDeConcurrencia Concurrencia` lleva `[ValidateObjectMembers]`. (2) La verificación suma una prueba: `AI:Concurrencia:Permisos = 0` tiene que fallar al arrancar con `OptionsValidationException`. (3) Se corrige la sangría rota de la línea `DimensionDeEmbeddings` dentro de la cita |
| P-12 | APLICAR | sí | La diferencia entre Development y Production sale de O4 y X1 [B] (E1). El cruce entre sesiones queda rotulado «no probado» (PC-11) | — |
| P-13 | APLICAR (ADR firme; contrato según la rama de P-35) | sí | El defecto del puerto string → string es E1 (`PuertosDeIA.cs` l. 15). El vencimiento de 30 min se declara elegido | — |
| P-14 | APLICAR | sí | Las condiciones citan fuentes (playbook de Microsoft, OWASP LLM05:2025) y la vía móvil queda «no ejecutada» | — |
| P-15 | APLICAR | sí: el error de diagrama nació en N1, N4 y N6, y se propaga a BIT-16-04 §6.2 | La compuerta verifica que el mermaid renderice. La regla de adaptadores de entrada queda atada a P-30 | — |
| P-16 | APLICAR | sí: el caso base no se toca (R-ESCR); se corrige donde se copió de más | V7 confirma cada enunciado | — |
| P-17 | APLICAR (rama tras la segunda ronda de C1-38) | sí | V2 confirma NUnit 5.0.0. `diff -r = 0` es verificable y la carpeta fuera del árbol copiado lo hace posible | — |
| P-18 | APLICAR | sí | La limitación del `ValueConverter` es E1 (SENIOR-05). `ToQueryString` lo verifica | — |
| P-19 | APLICAR | sí: N3b y N5 citaron una cifra de otro modelo | Las cifras 71,7 → 26,0 s salen de O5 y O3b. La causa va con «probablemente» | — |
| P-20 | APLICAR | sí | La fórmula es correcta: `n − (n − 4)/2 = n/2 + 2` con `n` par. Está medida con un modelo de humo y deja pendiente repetirla con el de chat (P-08) | — |
| P-21 | APLICAR | sí: las cifras mal derivadas nacieron en el laboratorio | 2050/100 ≈ 20,5; 1466/77,8 ≈ 18,8; 2943/167 ≈ 17,6 tok/s: «~18–20» es consistente. `cifras.py` vuelve reproducible la tabla | — |
| P-22 | APLICAR (definiciones y oro firmes; candidato en la demo tras C1-48) | sí: el nombre mal puesto nació en N3 | Las definiciones son las estándar. Con 12 enunciados y un relevante, el azar da k/12 | — |
| P-23 | APLICAR (rama tras la segunda ronda) | sí | No hay conclusión comparativa hasta correr el oro | — |
| P-24 | APLICAR | sí | La corrección del N de EA-6 es un hecho de `salida-real.txt` [R3] | — |
| P-25 | APLICAR | sí | Cierra el verde silencioso con `Inconclusive` verificable sin modelo | — |
| P-26 | APLICAR con ajuste vinculante | sí: los fragmentos inseguros nacieron en N4 | V10 confirma la especificación MCP. Un `IAprobador` «que no responde» puede colgar la prueba en lugar de devolver `null` | La prueba usa dos dobles: uno que devuelve `null` y otro que no responde y se corta por `CancellationToken` con un plazo. Los dos dan `false` y 0 ejecuciones |
| P-27 | APLICAR (M13 según la rama de P-05) | sí | El criterio de corte declara la cota de 40 líneas como elegida. M1 y M3 quedan como invariantes | — |
| P-28 | APLICAR con ajuste vinculante | sí | V14 y V15 | La verificación usa `grep -o '\[C:' \| wc -l` = 13 menos las dos explicaciones de la notación (00 l. 102, 01 l. 18) = 11, no `grep -c` |
| P-29 | APLICAR | sí: E01 compiló con un SDK 11 rc y eso nació en N1 | RV-18 impide afirmar «ejecutado» sin compilar con `sdk:10.0` | — |
| P-30 | **MEJORAR_PLAN** (vuelta 1) | sí | El test por reflexión no ve los cuerpos de método. Un `new ChatMessage(...)` local en un método de Application no aparece en tipos base, campos, propiedades, parámetros, retornos ni atributos. Como Application y la capa de IA conviven en un mismo ensamblado, `GetReferencedAssemblies` tampoco lo distingue. Es el mismo tipo de agujero por el que el parche descarta el `grep` | Opciones: (a) inspeccionar el IL de los métodos (Mono.Cecil o NetArchTest.Rules, con la versión consultada según P-32 el día de aplicar); (b) mantener la reflexión y declarar el agujero en la guía. En las dos, sumar un segundo caso rojo con el uso sólo dentro del cuerpo de un método, y decir qué pasa |
| P-31 | APLICAR | sí | Es aparato editorial verificable por `grep` | — |
| P-32 | APLICAR | sí: la compuerta incompleta nació en REED-16 §9.1 | V3, V4 y V5 | — |
| P-33 | APLICAR con ajuste vinculante | sí: N1 trató el muestreo como genérico | V9: la card tiene dos preajustes sin razonamiento. El Modelfile servido coincide con «sin razonamiento, tareas de razonamiento», que es igual a «con razonamiento, tareas generales» | Nombrar el preajuste exacto: «Instruct (non-thinking) para tareas generales: T 0,7, top_p 0,8, top_k 20, presence_penalty 1,5», con URL y fecha. Declarar que el Modelfile servido trae otro |
| P-34 | APLICAR | sí: la ambigüedad nació en REED-16 §6.2 | Es una regla de proceso | — |
| P-35 | APLICAR (parte común ahora; rama tras la segunda ronda con PC-13 cerrada) | sí | «Inventó el CP 10/10» y «3400 pasa `LocalidadRules`» son E1 (X2 D1, y V7 para la regla). La invariante M3 no depende de la rama | — |
| P-36 | APLICAR | sí | El rótulo provisional se sigue de AD-S1 (el 2b igual que el 4b con N = 10). El criterio D1–D6 se escribe antes de correr | — |
| P-37 | APLICAR con ajuste vinculante | sí | La relectura «no se midió» es la única que respalda el dato | El texto de la nota nombra un hostname del equipo de respaldo entre paréntesis. Se quita: dice sólo «el equipo de respaldo». Ese equipo alojaría un servidor de IA, y R-PRIV prohíbe nombrar su host |
| P-38 | APLICAR con ajuste vinculante | sí | V11: «±0,17 a ±0,22» vale para un acuerdo observado cerca de 0,8. Con p = 0,5 llega a ±0,26 | Escribir «con 10–20 casos y un acuerdo observado de 0,8, el semiancho va de unos ±0,23 a ±0,17; con 0,5, de ±0,26 a ±0,20» |
| P-39 | APLICAR | sí | V6 | — |
| P-40 | APLICAR | sí | La restricción de `AllowBackgroundResponses` está citada como E4 (CAT-OP-01) | — |
| P-41 | APLICAR | sí | Lo verifica P-30, incluida su mejora | — |
| P-42 | APLICAR | sí | 0 spans con nombres distintos está reproducido (R6 sobre X1 [A]) | — |
| P-43 | APLICAR | sí | CS0182 es el error de argumento de atributo no constante (K7, E1) | — |
| P-44 | APLICAR | sí | El campo `Comentario` no existe en el caso base. La respuesta queda conceptual hasta PC-14 | — |

## 3. Resumen

- **APLICAR:** 33. **APLICAR con ajuste vinculante:** 10 (P-01, P-04, P-07, P-09, P-11, P-26, P-28, P-33, P-37, P-38). **MEJORAR_PLAN:** 1 (P-30). **NO_APLICAR:** 0. **ESCALAR:** 0.
- **Capa:** los 44 corrigen en la capa de origen. Ninguno parchea la guía por un defecto de núcleo. La guía todavía no existe, y las RV la alcanzan como regla de redacción.
- **Condicionados:** P-05, P-17, P-23 y P-35, más las partes condicionadas de P-13, P-22 y P-27, esperan la segunda ronda en el orden de 03-Parches §4 punto 4. Si esa ronda empata, recién ahí se cumple el disparador 6 de REED-16 §12.
- **Para la aplicación:** P-01 va primero, con su ajuste y antes de cualquier commit. Las salidas de V12 y de la compuerta corregida se guardan en `Mesa/Ciclo-1/aplicacion/`, que todavía no existe.
