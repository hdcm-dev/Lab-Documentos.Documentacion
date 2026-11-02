---
doc_id: BIT-16-06
doc_type: cierre-de-construccion
title: Construcción de Examples/ y Demos/ — cierre de la fase
status: construcción cerrada y saneada (2026-10-27, 16:06 -03); lista para redactar, con deuda declarada (§5, §8)
origin: agent
owner: presidencia de la mesa (secretaría)
last_review: 2026-10-27
audience: [PO, presidencia, redactores, próxima corrida]
traces: [BIT-16-04 v3 §E, §F, §G, BIT-16-05]
---

# Bitácora 06 — Construcción

Cierre de la fase de construcción de la guía 16 sobre la **ESTRUCTURA APROBADA v3** ([`04-Plan-De-Integracion.md`](04-Plan-De-Integracion.md)). Acá se consolida lo que dejaron los constructores y verificadores de cada pieza, se corren las compuertas que se pueden correr sin la guía redactada, se mide el consumo de turnos y se hace el inventario de §E.6.

- Destinos: `/LAB/Lab-Documentos/Lab-Documentos/Guides/IA/Dot-Net-Integration-AI-Layer-Guide/Examples/` (01–17 y `_Comun`) y `…/Demos/MovilidadUrbana.Asistente/`.
- Evidencia de este cierre: [`Evidencia/Cierre-Construccion/`](Evidencia/Cierre-Construccion/). Contiene `verificar-build.cierre.log`, `demo-pruebas.cierre.log`, `compuertas.cierre.log`, `recalculo-oraculos.cierre.log`, `ac10-diff-base.cierre.log`, `medidor-gestor.cierre.tsv`, `turnos.cierre.jsonl` y `regla-10-salida-del-modelo.log` (§7).
- Evidencia del **saneamiento** (re-corrida tras el corte de sesión, 2026-10-27 16:01–16:06 -03), en la misma carpeta con sufijo `-saneo`: `verificar-build.saneo.log`, `demo-pruebas.saneo.log`, `compuertas.saneo.log` (código y Evidencia), `compuertas-bitacora.saneo.log` (bitácora, corrida después de esta edición), `ac10-diff-base.saneo.log`, `recalculo-oraculos.saneo.log`, `medidor.saneo.log` y `limpieza.saneo.log`. Además, de los despachos del saneamiento: `compuertas.ac7-p3.log`, `medidor-arnes.p5.log`, `arnes-vias-seco.p5.log`, `ac6-paquetes.cierre.log`, `verificar-build.ac6.cierre.log`, y las carpetas `Evidencia/P4-Corridas-Modelo/`, `Evidencia/Sondas/` y `Evidencia/08-Primera-Herramienta-Solo-Lectura/` (`*-correccion-ids*`, `*-reanudacion.log`).
- Caso base: `Lab-E2E.WebBlazor` en `8fb4c3a`, sólo lectura. Después de la corrida, `git log -1` sigue dando `8fb4c3a`.
- No se commiteó nada.

## 1. Estado por pieza

Los veredictos son los del verificador adversarial de cada pieza. «Registro» es el archivo de `Evidencia/R-LLM/`. Cada uno se recalculó en este cierre con `tools/recalcular-oraculos.sh` y coincide en todas sus entradas (§2, AC-3b). En el saneamiento se volvió a recalcular todo (`recalculo-oraculos.saneo.log`: «365 de 365» sobre `R-LLM/*.jsonl`, 4 de 4 en `Sondas/`). Las filas 03, 04 y 08 están actualizadas con las extensiones de TURNO-2 (P4) y la corrección del S2 (P1-08).

| Pieza | Estado | Verificador | Corrida contra el modelo | Registro con modelo | Desvíos del plan (motivo) |
|---|---|---|---|---|---|
| 01 Chat y streaming | ok | aprobado con observaciones (5 × S3) | TURNO-1, `<recurso-compartido>`, 126 s; 2/2 pasan; `num_ctx` 65.536 (`arnes-ps-tras-carga`) | `01-…modelo.jsonl` (2 llamadas) | la variante negativa «sin la capa» corre sólo con `--fake`, por presupuesto (2 llamadas); el «historial de 3 turnos» se leyó como 3 mensajes |
| 02 Cambio de adaptador | ok con desvíos | aprobado con observaciones (4 × S3) | TURNO-3 3a, `[recurso-modelo-propio]`, 22 s; 1/1 pasa por las dos vías | `02-…modelo.jsonl` (2) | por `/v1` no llegan `num_ctx` ni duraciones: `truncado_posible` = null, como fija §E.1; el modelo inventa localidades fuera del catálogo en su salida: **decidido** (§7 d), la regla 10 no alcanza a la salida del modelo como regla de dominio, sí por la compuerta AC-7; el README lo declara y se quitó «San Juan» de `localidades-permitidas.txt` |
| 03 Salida estructurada | ok con desvíos | aprobado con observaciones (3 × S3) | TURNO-1, 63 s; 2/2 pasan. Extensión (TURNO-2, P4, por la vía `extension` del arnés): 210 s, M = 8, **8/8 pasan**, IC95 [0,631; 1]; JSON válido 8/8; habitantes propuestos sin el dato 0/4 | `03-…jsonl` (2), `03-…modelo-ext.jsonl` (8) | un solo `.csproj` para consola y pruebas; la vía `--extension` se agregó en P5; el oráculo jq diverge del C# en 5 formas de salida de laboratorio (no aparecen en los registros) |
| 04 Normalización contra catálogo | ok con desvíos | aprobado con observaciones (2 × S4) | TURNO-1, corrida repetida tras el rechazo (64 s): d01 pasa, d02 falla (frecuencia null). Extensión (TURNO-2, P4): 152 s, M = 8, **7/8** válidas con normalización correcta, IC95 [0,473; 0,997] | `04-…modelo.jsonl` (2), `04-…modelo-ext.jsonl` (8) | plegado de tildes explícito y finito para que la paridad C#/jq sea alcanzable (H2-022); módulo común `normalizacion-comun.jq`; 103 casos de paridad |
| 05 Contexto completo con prefijo | ok con desvíos | aprobado con observaciones (5 × S3) | TURNO-3 3a, corrida 4, 187 s, 13 llamadas; 5 de 6 pares a favor | `05-…modelo.corrida-4.jsonl` (13) | con el orden alternado de §E.2 el primer par llega en frío y el 6/6 es inalcanzable. **Decidido** (§7 b): se mantiene el orden del plan; el resultado es 5 de 6, sin afirmar ≪; `--orden calentamiento` queda como exploración no adoptada; `estado_cache` «desconocido» (falta DEP-03); `carga_1min` null (el gestor no la expone) |
| 06 Embeddings y búsqueda semántica | ok con desvíos | aprobado con observaciones (3 × S3) | TURNO-3 3a, 42 s, 44 embeddings | `06-…modelo.jsonl` (44) | corrida fuera de `verificar.sh`; los embeddings salen sin `num_ctx` (`num_ctx_origen` null, que §E.1 no prevé): **declarado** (§7 c) en el README y como nota en la fila 06 de §E.2; el motivo para descartar la corrida previa estaba mal declarado |
| 07 RAG con citas | ok con desvíos | aprobado con observaciones (5 × S3) | TURNO-1, M = 16, 780 s (+310 s de la corrida interrumpida, que no cuenta); estabilidad 3/3 | `07-…modelo.jsonl` (16), `…estabilidad.jsonl` (3) | embeddings (3a) y estabilidad corridos a mano porque el arnés no lee esas claves; el desempate de `InMemoryVectorStore` no es determinista en `--fake` |
| 08 Primera herramienta de sólo lectura | ok con desvíos | **aprobado con observaciones** (S2 corregido en P1-08; 4 observaciones, ninguna bloqueante) | TURNO-1, 162 s; 2/2 pasan. Extensión (TURNO-2, P4, 15:08, con el oráculo ya corregido): 720 s, M = 8, 14 llamadas; herramienta invocada con argumentos válidos 4/4 legítimas; oráculo no-inventa **6/8** (fallan xl04 «afirma 2» y xn03 «afirma 8»); xn02 cita sólo los ids devueltos (4 y 5) y pasa con razón | `08-…modelo.jsonl` (3), `08-…modelo-ext.jsonl` (8 entradas) | **S2 corregido** (14:06–14:10): el oráculo (C# y jq) acepta sólo ids presentes en los resultados de la herramienta; prueba sintética `sintetico-id-inventado.jsonl` 8/8 coincide; 50/50 pruebas; código sin cambios desde entonces (re-verificado 15:52). **Límites declarados del oráculo**, sin cambiar la regla: (1) controla que el id exista, no a qué nombre corresponde («Goya tiene el id 4» pasa en xn02); (2) un id dicho de otra forma entra como conteo y pasa si coincide con el total de filas; (3) en sentido contrario, es demasiado estricto: «los ids 4 y 5» en plural, una suma de conteos (xl04, 1+1 = 2) y los dígitos de un identificador de sesión («ejemplo-08-b» en xn03) cuentan como cifras inventadas; (4) `long.Parse` sin tope (no realista). Las 2 fallas de la extensión son falsos positivos del oráculo, no invención del modelo. Los dos `fake-ext` de `R-LLM/Reemplazados/` dan 6/8 rc 1 con el oráculo nuevo, como se espera |
| 09 Caso de uso como herramienta | ok | aprobado con observaciones (2 × S3) | TURNO-1, 279 s; 2/2 pasan | `09-…modelo.jsonl` (4) | — |
| 10 Workflow y contraejemplo | ok con desvíos | aprobado con observaciones (3 × S3) | no aplica (sin modelo) | `10-…jsonl` (sólo renglones «entrada») | «workflow = función» vale para las 4 entradas congeladas; con abandono después de un rechazo, los datos difieren |
| 11 Agente con aprobación | ok con desvíos | aprobado con observaciones (4 × S3) | TURNO-1, 91 s; 1/1 pasa; borrado = mostrado | `11-…modelo.jsonl` (2) | presupuestada como L y medida como H (p = 500/591); corrida con guiones propios; la prueba `Category("LLM")` no corrió, por presupuesto |
| 12 Uno o varios agentes | ok con desvíos | aprobado con observaciones (3 × S3 + 1 inf.) | TURNO-2, 128 s; 4/4 pasan; 0 vueltas | `12-…modelo.jsonl` (4) | el corrector de «dos-agentes» nunca se llamó contra el modelo; el `turno_id` del registro no cruza con el del medidor (corrida a mano) |
| 13 Servidor y cliente MCP | ok | aprobado con observaciones (4 × S3) | TURNO-2, 111 s; 1/1 pasa | `13-…modelo.jsonl` (2) | corrió antes de su lugar en la cola de TURNO-2 (sin efecto: el tope alcanzó) |
| 14 Anotaciones SK frente a M.E.AI | ok | aprobado con observaciones (4 × S3) | no aplica (sin modelo) | `14-…jsonl` | — |
| 15 Pruebas y evaluación | ok con desvíos | aprobado con observaciones (3 × S3) | TURNO-3 3b, 534 s, 52 llamadas; 0/52 salidas interpretables | `15-…modelo.jsonl` (52) | salidas de 07 congeladas en `salidas-07.v1.json`; anotador = agente constructor, no una persona; regla de acuerdo fijada antes de juzgar; dos paquetes de más (VectorData), porque 15 enlaza el índice de 07 |
| 16 Inyección indirecta | ok con desvíos | aprobado con observaciones (3 × S3) | TURNO-2, 2.463 s (+2.419 s de la corrida interrumpida); precondición 12/12 | `16-…modelo.jsonl` (24) | el nombre malicioso mide 48 caracteres, no 47; la corrida interrumpida queda aparte; se corrió con `TOPE_LAN_S` corregido porque el medidor no veía las corridas a mano |
| 17 Observabilidad y pipeline | ok con desvíos | aprobado con observaciones (1 × S2 declarado + 2 × S3) | TURNO-2, 275 s; 1/1 pasa | `17-…modelo.jsonl` (2) | **D-1 (S2)**: corrió fuera de la regla de cola de §E.5. Con el consumo real (§3), lo que queda de TURNO-2 entra igual. **Decidido** (§7 a): se muestra como «ejecutado»; el README lo declara |
| Demo `MovilidadUrbana.Asistente` (PD-2, PD-3, PD-6) | ok con desvíos | aprobado con observaciones (4 × S3) | TURNO-1, humo 239 + 64 + 58 s (PD-6 repetido por un defecto de la prueba); 3/3 pasan; embeddings de PD-2 en 3a (12 s) | `Demo-MovilidadUrbana.Asistente.modelo.jsonl` (4) | los oráculos de humo copian y adaptan la regla de 07, 03 y 11, porque el registro tiene otra forma; la `GarantiaNumerica` de la demo es más laxa que la de 03 (declarado) |

**Observación transversal (S3, en 01, 05, 09, 11, 12, 13, 15, 16 y 17).** En modo modelo, los campos `razonamiento` y `num_ctx` del registro **se reconstruyen**: se vuelve a aplicar `OpcionesDelProveedor.Aplicar` sobre un clon. No se observan en lo que sale por la red. La garantía real es la prueba de cableado con el cliente espía debajo de la capa, que pasa en la fase build (§2, AC-2). La guía no puede presentar esos campos como medidos.

## 2. Compuertas (§F.10)

### 2.1 Estado vigente: re-corrida del saneamiento (2026-10-27, 16:01–16:10 -03)

Re-corridas después de los seis despachos del saneamiento (P1-08, P2-AC6, P3-AC7, P4, P5-ARNES, P6-DECISIONES) y del corte de sesión. La corrida anterior de este mismo despacho (15:13) quedó cortada en la fase AC-6 del build y se reemplaza entera. Sin modelo: no se gastó `<recurso-compartido>` ni `[recurso-modelo-propio]`. Salidas con sufijo `-saneo` en `Evidencia/Cierre-Construccion/`.

| # | Resultado | Comando y salida |
|---|---|---|
| AC-1 | **cumple** | `tools/verificar.sh build` con turno `build` (212 s, SDK 10.0.403, `RLLM_DIR` nuevo): 22 proyectos con `-warnaserror`, «0 Warning(s)» en los 22, rc 0. Demo: `tools/demo.sh pruebas` (turno `build`, 34 s), «0 Warning(s) · 0 Error(s)», rc 0. Ningún `<NoWarn` ni `#pragma warning disable` en código ni en `.props`/`.csproj` |
| AC-2 | **cumple** | Examples: 18 proyectos de pruebas, **443** pruebas, 0 fallidas (`Category!=LLM`); 18 consolas con `--fake --verificar`, rc 0. Demo: **70/70** |
| AC-3a | **cumple** con los registros de los constructores y de P4 | No se re-corrió `--con-modelo` (no se repiten corridas válidas). Las pruebas `Category("LLM")` de 11 y de la demo siguen sin correr, por presupuesto (declarado) |
| AC-3b | **cumple** | `recalcular-oraculos.sh` uno por uno sobre los 50 registros de `R-LLM/` y los 4 de `Reemplazados/`: todos rc 0 salvo los dos `fake-ext` reemplazados de 08 (6/8, rc 1, esperado: se generaron con el oráculo viejo). Agregado `R-LLM/*.jsonl`: «365 de 365», rc 0. `Sondas/` (oráculos de `Sondas/oraculos/` junto a `tools/oraculos/`): DEP-03 1/1, DEP-09 1/1, DEP-13 2/2. `truncado_posible = true`: 0 en los 19 registros con modelo de `R-LLM/` y en los 3 de `Sondas/`; `null` sólo en 02 (1, `/v1`, §E.1) y en DEP-03 (1, la llamada sin la opción). Las extensiones 03, 04 y 08 y las sondas DEP-03/09/13 **ya corrieron** (P4) |
| AC-4 | **cumple** | Las cuatro pruebas de aprobación pasan dentro de las 70 de la demo (`demo-pruebas.saneo.log`) |
| AC-5 | **cumple** | `tools/diff-dominio.sh`: «idénticos», rc 0. Con `/usr/bin/grep` en la demo: `Domain/` sin SDK, `Application/` sin `Infrastructure` ni SDK, SDK sólo en `Infrastructure/AI` y `Program.cs`, `HerramientasDelAsistente.cs` sin `I*Repository`: rc 1 en las cuatro. `Cableado/ArquitecturaTests.cs` en verde dentro de las 70 |
| AC-6 | **cumple** | Examples: «AC-6: familias en una sola versión; previews sólo las de Compuertas/ac6.excepciones: Azure.AI.OpenAI 2.9.0-beta.1». Demo: «familias en una sola versión, sin previews» |
| AC-7 | **cumple** | Guía (0 bytes), Examples, Demos, `tools/`, `Compuertas/`: 0 coincidencias, autoprueba 17/17. `Evidencia/`: 0 en 95 registros. Toda la bitácora, **después de esta edición**: ver `compuertas-bitacora.saneo.log` (los 5 falsos positivos del cierre se reescribieron en P3, `compuertas.ac7-p3.log`) |
| AC-8 | **cumple** | Guía + Examples + Demos + `tools/` + `Compuertas/`: «0 coincidencias fuera de excepciones (7 exceptuadas …)»; `Evidencia/`: 0 (2 exceptuadas). Bitácora contra `Bitacoras/Compuertas/rd-po-4.excepciones`, después de esta edición: `compuertas-bitacora.saneo.log` |
| AC-9 | **pendiente de redacción** | La guía tiene 0 bytes. Qué puede citar: §8 |
| AC-10 | **cumple** | `BASE_REPO=<clon del caso base> tools/diff-base.sh`: «27 iguales tras la cabecera, 17 distintos, 54 nuevos, 0 quitados» y «todo cambio figura en la tabla de delta», rc 0; el caso base sigue en `8fb4c3a` |
| AC-11 | **cumple** | `Host_Humo_EstilosYEstados` y `Host_CookieSoloEnDocumentos` en verde dentro de las 70 |

### 2.2 Corrida del cierre (13:55–14:01 -03, histórica)

Corridas el 2026-10-27, entre las 13:55 y las 14:01 (-03). Las salidas completas están en `Evidencia/Cierre-Construccion/`. Las filas AC-3b, AC-6 y AC-7 de esta tabla quedaron superadas por §2.1.

| # | Resultado | Cómo se corrió y qué salió |
|---|---|---|
| AC-1 | **cumple** | `tools/verificar.sh build` con turno `build` (233 s, SDK 10.0.403): 22 proyectos con `-warnaserror`, «0 Warning(s) · 0 Error(s)» en los 22. Demo: `tools/demo.sh pruebas`, 0/0. No hay `NoWarn` (sólo aparece en comentarios) ni `#pragma warning disable` |
| AC-2 | **cumple** | Examples: 18 proyectos de pruebas, 433 pruebas, 0 fallidas (`Category!=LLM`, `OLLAMA_ENDPOINT` a un puerto cerrado); 18 consolas con `--fake --verificar`, rc 0 (incluido `_Comun/Humo`). Demo: 70/70 |
| AC-3a | cumple con los registros de los constructores | En el cierre no se volvió a correr `--con-modelo`, para no gastar tope. Las consolas con `--verificar` se corrieron en los turnos de §1. Las pruebas `Category("LLM")` de 11 y de la demo no se corrieron, por presupuesto |
| AC-3b | **cumple parcialmente** | 47 registros de `Evidencia/R-LLM/`: todos coinciden al recalcularlos, rc 0. Los 4 de `Reemplazados/` dan 6/8 con el oráculo nuevo de 08, como se espera. Todos los registros con modelo de 01–09, 11–13, 15–17 y la demo tienen entradas congeladas (el SHA-256 coincide con `ejemplo.json` y con el archivo) y `truncado_posible` = 0. **Faltan**: las sondas **DEP-03** (TURNO-3), **DEP-09** y **DEP-13** (TURNO-1) no tienen ninguna corrida registrada. Las extensiones 03, 04 y 08 de TURNO-2 quedan «no ejecutado contra el modelo». El oráculo de 08 tiene un S2 abierto |
| AC-4 | **cumple** | Pasan, dentro de las 70 de la demo: `PedidoDeAprobacion_MuestraArgumentosResueltos`, `Aprobacion_ArgumentosAlterados_SeRechaza`, `Escritura_ConResultadoNoConfiable_PideAprobacion` y `Escritura_NoAprobable_ConResultadoNoConfiable_Rechaza`. Se ejercita con modelo en 11, PD-6 y 16: 0 bajas sin aprobación |
| AC-5 | **cumple** | `Cableado/ArquitecturaTests.cs` en verde. Con `/usr/bin/grep`: `Domain/` sin M.E.AI, OllamaSharp ni OpenAI; `Application/` sin `Infrastructure` ni SDK; el SDK sólo en `Infrastructure/AI` y `Program.cs`; herramientas sin `I*Repository` (rc 1 en las cuatro búsquedas). `tools/diff-dominio.sh`: los dos `Domain/` son idénticos |
| AC-6 | **cumple** (resuelto en P2-AC6, 2026-10-27 14:07–14:12 -03) · cumple en la demo | Antes: «familia OpenTelemetry en varias versiones: 1.18.0, 1.20.1» (10 y 12 resolvían `OpenTelemetry.Api` 1.18.0 como transitivo de MAF; 17, 1.20.1) y «preview: Azure.AI.OpenAI 2.9.0-beta.1» (transitivo de SK en 14). Decisión de la presidencia: (a) `OpenTelemetry.Api` 1.20.1 en `Directory.Packages.props`, fijado por el pinning de transitivos (DEP-12); (b) el beta **no se fuerza**: se declara en el Anexo F del plan (§E.1) como dependencia transitiva preliminar de SK y en `Compuertas/ac6.excepciones` como excepción escrita, que `ac6()` lee por id y versión exactos (una preview no listada falla; una excepción que ya no se resuelve también falla). `tools/verificar.sh build` con turno `build` (314 s): rc 0, 443 pruebas, 0 fallidas, 18 consolas `--fake --verificar` en rc 0, y «AC-6: familias en una sola versión; previews sólo las de Compuertas/ac6.excepciones: Azure.AI.OpenAI 2.9.0-beta.1». Ahora 10, 12 y 17 resuelven `OpenTelemetry.Api` 1.20.1. Autoprueba de la excepción: sin la línea, rc 1; con una excepción vencida, rc 1. Evidencia: `verificar-build.ac6.cierre.log` y `ac6-paquetes.cierre.log`. **`paquetes_hash` cambia** de `51bc7596…23b8` a `2e28142b…f617` para las corridas futuras; los 529 registros de `Evidencia/R-LLM/` se conservan con su hash viejo y no se re-corren |
| AC-7 | **cumple sobre lo construido** · 5 falsos positivos en la bitácora (resueltos en P3: reescritos, 0 sobre todo lo escrito, `compuertas.ac7-p3.log`) | Sobre Examples, Demos, `tools/`, `Compuertas/` y `Evidencia/*/`: 0 coincidencias; autoprueba 17/17; 85 registros sin nombres fuera del conjunto sintético. Sobre toda la bitácora hay 5 coincidencias del patrón de IP, revisadas a mano: 2 son el número de versión de ensamblado de M.E.AI (cuatro componentes, empieza con 10) y 3 son la dirección base del rango de red superpuesta, que el plan admite como rango. Ninguna es una dirección real. La compuerta no tiene archivo de excepciones: antes de un commit hay que reescribirlas como rango (`/10`) o como versión de tres componentes, o agregarle excepciones al script (deuda) |
| AC-8 | **cumple** | Guía: 0 coincidencias fuera de excepciones (9 exceptuadas; negativos 0; positivos 5/5; lista 11/11). Para lograrlo se corrigieron las líneas 9–10 de `Compuertas/rd-po-4.excepciones` de la guía, que citaban el término marcado en su propio motivo. Bitácora: 58 coincidencias, las 58 en `Bitacoras/Compuertas/rd-po-4.excepciones`; ninguna excepción quedó sin coincidencia |
| AC-9 | **pendiente de redacción** | `Dot-Net-Integration-AI-Layer-Guide.md` tiene 0 bytes. La regla de cifras queda en §8 |
| AC-10 | **cumple** | `tools/diff-base.sh` contra `8fb4c3a`: 27 iguales tras la cabecera, 17 distintos, 54 nuevos, 0 quitados; «todo cambio figura en la tabla de delta», rc 0. La exportación temporal se borró sola |
| AC-11 | **cumple** | `Host_Humo_EstilosYEstados` y `Host_CookieSoloEnDocumentos` en verde, dentro de las 70. Evidencia de `curl` del constructor en `Evidencia/Demo-MovilidadUrbana.Asistente/curl-host.txt` |

## 3. Turnos (medidor, §E.5)

### 3.1 Consumo final (medidor del arnés, saneamiento, 16:05 -03)

Desde P5, `tools/verificar.sh medidor` lee el registro del gestor (`TURNO_REGISTRO`) y suma de `turnos.jsonl` sólo las fases sin turno. Lectura final (`medidor.saneo.log`, `TURNO_DESDE` = inicio del 2026-10-27), después de todas las corridas del día:

| Recurso | Usado (gestor) | Tope | % | Restante |
|---|---|---|---|---|
| `<recurso-compartido>` | **9.153 s** (TURNO-1 2.399 · TURNO-2 5.396 · P4 1.358) | 14.400 s | 63,6 % | **5.247 s** |
| `[recurso-modelo-propio]` | **1.892 s** (3a 1.235 · 3b 550 · DEP-03 107) | 7.200 s (90 % = 6.480) | 26,3 % | 5.308 s |
| `build` | 9.645 s (sin tope; este despacho: 212 + 34 s) | — | — | — |

- El saneamiento sólo usó `<recurso-compartido>` en P4 (DEP-09 59 s, DEP-13 217 s, 03 ext. 210 s, 04 ext. 152 s, 08 ext. 720 s) y `[recurso-modelo-propio]` en DEP-03 (107 s). Ninguna corrida válida se repitió. El restante de 5.247 s reemplaza el «≈ 6.600 s» del contexto común del saneamiento, que era anterior a P4.
- Las fases con modelo de P4 corrieron **por el arnés** (vía `extension` de `verificar.sh`, con turno `<recurso-compartido>`, `sin_turno` false): su `turnos.jsonl` se conservó en `Evidencia/P4-Corridas-Modelo/turnos.p4-ext.jsonl`. Corrige la deuda de P5 que decía que las vías sin `--fake` «nunca corrieron contra un modelo por el arnés».
- **Defectos del medidor (P5, observaciones del verificador, sin corregir)**: falla abierto si `TURNO_DESDE` no se puede leer (informa el tope entero, rc 0); si `TURNO_REGISTRO` apunta a un archivo inexistente, vuelve en silencio a sólo `turnos.jsonl` y dice «TURNO_REGISTRO vacía»; sólo lee el `turnos.jsonl` de su `RLLM_DIR`; empareja concesiones por (recurso, dueño). Hoy no cambian ninguna cifra: todas las fases con modelo del día tienen `sin_turno` false y están en el gestor. La lectura de arriba se hizo con las dos variables bien definidas.

### 3.2 Medición del cierre (14:01 -03, histórica)

La fuente es el registro del gestor de recursos. Se sumaron los tramos concedido→liberado del 2026-10-27; el detalle está en `medidor-gestor.cierre.tsv`.

| Recurso | Usado | Tope | % | Restante |
|---|---|---|---|---|
| `<recurso-compartido>` | **7.795 s** (TURNO-1: 2.399 s · TURNO-2: 5.396 s) | 14.400 s (4 h) | 54,1 % | 6.605 s |
| `[recurso-modelo-propio]` | **1.785 s** (3a: 1.235 s · 3b + prueba LLM de 15: 550 s) | 7.200 s (2 h; 90 % = 6.480 s) | 24,8 % | 5.415 s |

- **TURNO-1**: 2.399 s reales contra 7.650 s pesimistas. Incluye la corrida interrumpida de 07 (310 s), los dos PD-6 repetidos (122 s) y la corrección de 04 (64 s). Si se descuentan las correcciones, como pide §E.5, quedan 2.335 s.
- **TURNO-2**: 16 usó 4.882 s, contra 4.800 s pesimistas, por la corrida perdida. 12 usó 128 s, 13 usó 111 s y 17 usó 275 s.
- **Lo que queda de la cola**: carga en frío (80) + 03 ext. (640) + 04 ext. (640) + 08 ext. (3.200) = 4.560 s, que **entra** en los 6.605 s restantes. Por eso, con el consumo real, el salto de 17 (D-1) no le quitó lugar a ninguna pieza. Para correrlas falta una vía `--extension` en `verificar.sh` y, en 08, corregir antes el S2. *(Saneamiento: hecho; las tres corrieron en P4 con 1.082 s, §3.1.)*
- **Desvío del medidor del repo**: `turnos.jsonl` del arnés suma 3.981 s de `<recurso-compartido>`, 3.814 s menos que el gestor, porque las corridas a mano de los constructores no escribieron su línea. `tope_restante` de `verificar.sh` subestima el consumo. Hasta que lea también el registro del gestor, el tope se toma de esta tabla. *(Saneamiento: resuelto en P5; el medidor lee el gestor, §3.1.)*
- **DEP-13** no se corrió *(saneamiento: corrió en P4, con desvío, §5 ítem 7)*: la recalibración de clases antes de construir no se hizo. Los p medidos (11: 500 y 591, clase H y no L; 05: unos 1.730) quedan como insumo para recalcular §E.5.

## 4. Inventario y limpieza (§E.6)

Se verificó el 2026-10-27 a las 14:01 (-03). No hay contenedores con `label=<etiqueta-del-arnés>`: `docker ps -a … -q` da vacío. Tampoco hay redes con esa etiqueta. No se tocó ningún recurso de otras sesiones: emuladores, `<teléfono-de-prueba>`, imágenes `ollama/ollama:*` previas, imágenes de runners.

| Recurso | Qué se hizo | Motivo |
|---|---|---|
| `bin/` y `obj/` en `Examples/_Comun` (3 proyectos, de 10:44 a 10:46) | **borrados** | intermedios en el árbol; nadie compilaba a esa hora (`build` en uso 0). El árbol de la guía queda sin `bin`, `obj`, `registros` ni `datos` |
| Volúmenes `<volumen-artefactos-12>`, `-13`, `-15` y `-16` | **borrados** | intermedios de piezas aprobadas, regenerables, sin contenedores que los usen |
| Copias privadas `build-12`, `build-13` y `build-16`, y la exportación `base-8fb4c3a` (en `{dir-de-trabajo}/`) | **borradas** | copias del código fuente y de la base; AC-10 vuelve a exportar a un temporal |
| `<volumen-nuget>` y `<volumen-artefactos>` | se conservan | los necesitan las extensiones de TURNO-2 y la redacción; se borran al cerrar el ciclo |
| `<volumen-artefactos-08>` y la copia `build-08` | se conservan | 08 está rechazado (S2) y va a volver a compilarse |
| `<volumen-artefactos-demo>` | se conserva | lo usa `tools/demo.sh`; la demo puede levantarse otra vez para la redacción o para mostrarla |
| `<ollama-n3>` y `<volumen-nuget-n3>` (dossier N3) | se conservan | §E.6 los borra al cerrar el ciclo, después de verificar que `Evidencia/` tiene todo lo que cita la guía, y la guía no existe todavía. Ninguna evidencia de la construcción depende de ellos |
| `RLLM_DIR` crudo (`{dir-de-trabajo}/rllm/`, 6 MB, con `embeddings/` y `turnos.jsonl`) | se conserva | lo leen las corridas pendientes; lo que pasó AC-7 ya está copiado en `Evidencia/R-LLM/`. Se borra al cerrar el ciclo |
| Configuración de docker vacía (`dockercfg`) | se conserva | la necesita el camino del lector (`ollama-embed`); 28 KB |
| Guiones `build-NN.sh` y `lan-NN.sh` de los constructores | se conservan | fuera del repo; se borran al cerrar el ciclo |
| Imagen `ollama/ollama:0.40.11` | no aplica | no está en la máquina de la corrida: el Ollama propio es del gestor |

**Limpieza del saneamiento (2026-10-27, 16:06 -03, `limpieza.saneo.log`).** Antes y después: 0 contenedores con `label=<etiqueta-del-arnés>`. No se tocó nada de otras sesiones.

| Recurso creado o liberado por el saneamiento | Qué se hizo | Motivo |
|---|---|---|
| `RLLM_DIR` de esta re-corrida (`saneo2-rllm`, `saneo2-rllm-demo`) y de P2-AC6 (`rllm/p2-ac6`, `rllm/v-p2-ac6`) | **borrados** | sólo tenían los registros `--fake` del build y su `turnos.jsonl`; las salidas quedaron en los `.log` de la Evidencia y los tramos, en el gestor |
| Carpeta de trabajo de P4 (`p4-sondas`: fuente de las sondas, guiones y registros crudos) | **borrada** | registros idénticos a los de `Evidencia/R-LLM/*.modelo-ext.jsonl` y `Evidencia/Sondas/` (comparados con `cmp`/`jq` antes de borrar); logs idénticos a `Evidencia/P4-Corridas-Modelo/`; su `turnos.jsonl` se copió a `Evidencia/P4-Corridas-Modelo/turnos.p4-ext.jsonl` |
| Carpeta de P5 (`p5-arnes`, corridas en seco) | **borrada** | la salida está en `arnes-vias-seco.p5.log` |
| Copia `build-08`, su guion y el volumen `<volumen-artefactos-08>` | **borrados** | se conservaban porque 08 estaba rechazado; ahora está aprobado y el build general lo compila desde `<volumen-artefactos>` |
| 20 entradas de `{dir-de-sesion}` posteriores al cierre de las 14:01 (verificaciones de P1-08, P2, P4 y P5) | **borradas** | intermedios de los verificadores; sus conclusiones están en la Evidencia |
| `Examples/registros/` vacío (creado a las 16:00, ignorado por git) | **borrado** (`rmdir`) | el árbol de la guía queda sin `bin`, `obj`, `registros` ni `datos` |
| `<volumen-nuget>`, `<volumen-artefactos>`, `<volumen-artefactos-demo>`, `<ollama-n3>`, `<volumen-nuget-n3>`, el `RLLM_DIR` crudo y `dockercfg` | se conservan | como arriba: los usa la redacción y se borran al cerrar el ciclo |

## 5. Deuda para la redacción (qué cifras se pueden citar, AC-9)

> **Saneamiento (2026-10-27, 16:06 -03).** La regla vigente de qué puede citar la guía está en **§8**, por ejemplo y por paso de la demo. Las listas de abajo son las del cierre de las 14:01 y quedan como registro; donde §8 las contradice, rige §8. Los pendientes de decisión están marcados con su resolución y su evidencia.

**Se pueden citar** (cierre, 14:01) con su registro, el rótulo de laboratorio y la marca «estímulo del mismo autor» donde corresponda:
- **06 (medición, EMB-B)**: hit@1 10/12, hit@3 12/12 y MRR 0,889 en las dos variantes. La línea base léxica da 7/12, 8/12 y 0,679; la de azar, 1/12, 3/12 y 0,259. Con la regla pareada de §10.4 se afirma la ventaja sobre el azar (hit@1 p = 0,012; hit@3 p = 0,004), y **no** se afirma ni sobre la léxica ni entre variantes. Al redactar hay que corregir la glosa del README («todas a favor» → «p < 0,05»).
- **07 (medición)**: afirmación correcta 7/7, cita válida 5/5, «No sé» 0/4, cita y contradice 1/12, cada una con su intervalo (`verificar.sh tasa`). La estabilidad (3 repeticiones, 1 texto distinto) es informativa y no entra en la tasa.
- **15**: sólo la conclusión «juez no calibrado»: 0/52 interpretables; acuerdo juez-anotador 0/10, IC95 [0; 0,308]. El anotador es un agente, no una persona.
- **16 (medición)**: pedidos de baja inducidos 0/6 por variante, IC95 [0; 0,459]; b = c = 0, sin diferencia. Se cita «sobre un solo texto de ataque, del mismo autor». «Origen» es garantía de código, sin corrida.
- **Conductas de demostración** (sin tasa): 01, 02, 03, 04, 09, 11, 12, 13, 17 y los humos PD-2, PD-3 y PD-6, como ejemplos de salida con su registro.
- **05**: las duraciones observadas del servidor y el 5 de 6 descriptivo del orden alternado (corrida 4), **sin** afirmar «con-prefijo ≪ sin-prefijo». El 6 de 6 de `--orden calentamiento` no se cita como resultado: la variante no se adoptó (§7 b). No se puede hablar de «caché caliente o fría» por `estado_cache`, que es «desconocido».
- **17**: como conducta de demostración ejecutada contra el modelo (§7 a), sin tiempos.

**No se pueden citar**:
- ~~Tasas de las extensiones de 03, 04 y 08: no se ejecutaron.~~ Corrieron en P4 (§1, §8).
- ~~Ninguna cifra de 08 que dependa del oráculo «no-inventa» hasta corregir el S2.~~ S2 corregido en P1-08; la cifra del oráculo se cita sólo con la lectura de sus dos fallas (§8).
- El camino del corrector de 12 contra el modelo: no se observó.
- Las clases de tiempo K, M, H y L, y las P-*, como medidas: DEP-03 y DEP-13 no corrieron. *(Saneamiento: corrieron en P4; lo que se puede citar de ellas está en §8.)* Tampoco las cifras de dossiers (Sondeo, N3b) que no se volvieron a ejecutar en la construcción: R-PO-2 y AC-9.
- `razonamiento` y `num_ctx` del registro como «observados» (observación transversal de §1).
- ~~El invariante de versiones del Anexo F hasta resolver AC-6.~~ Resuelto en P2-AC6 (§2, AC-6): se cita, con la excepción escrita del beta de SK.

**Pendientes de decisión (presidencia o mesa)**:
1. ~~Corregir el S2 de 08 y volver a verificar.~~ **Resuelto** (P1-08, 14:06–14:10; re-verificado 15:52): el oráculo acepta sólo ids presentes en los resultados; veredicto «aprobado con observaciones» (§1, fila 08). Evidencia: `Evidencia/08-…/recalculo-correccion-ids.log`, `sintetico-id-inventado.jsonl`, `pruebas-reanudacion.log` (50/50), `recalculo-reanudacion.log`.
2. ~~AC-6: pinning de `OpenTelemetry.Api` y tratamiento del beta de SK.~~ Decidido por la presidencia y aplicado en P2-AC6 (§2, AC-6).
3. ~~AC-7: excepciones, o reescritura de los 5 falsos positivos de la bitácora antes de un commit.~~ **Resuelto** (P3): reescritos como rango o como versión de tres componentes; la presidencia decidió no agregar excepciones al script. AC-7 sobre toda la bitácora: 0 coincidencias (`compuertas.ac7-p3.log`; re-corrido en `compuertas-bitacora.saneo.log`).
4. ~~Si 17 se muestra como ejecutado.~~ Decidido: sí (§7 a).
5. ~~Si 05 adopta `--orden calentamiento`.~~ Decidido: no (§7 b).
6. ~~Si la regla 10 alcanza a la salida del modelo (02).~~ Decidido (§7 d).
7. ~~DEP-03, DEP-09 y DEP-13 sin corrida.~~ **Resuelto con desvío** (P4, 14:41–14:48): las tres corrieron y recalculan (`Evidencia/Sondas/`, `Evidencia/P4-Corridas-Modelo/resumen.md`). Desvíos declarados: DEP-03 con 5.714 tokens (no ~4.700) y una tercera llamada para calibrar; DEP-13 midió clase M (p 645 y 646, su oráculo falla en las dos) y la clase K se calibra con las 16 llamadas de 03 ext. y 04 ext.; §E.5 no se recalcula porque no quedan corridas que presupuestar.
8. ~~Vías del arnés y medidor.~~ **Resuelto** (P5): vías `extension`, `embeddings` y `estabilidad` en `verificar.sh`, en seco (`arnes-vias-seco.p5.log`) y con modelo en P4; el medidor lee el gestor (`medidor-arnes.p5.log`, `medidor.saneo.log`). Defectos del medidor que quedan: §3.1.

**Deuda que sigue abierta después del saneamiento** (ninguna bloquea la redacción):
- Campos `estado` de la vía `extension` en `ejemplo.json` de 03, 04 y 08: todavía dicen «pendiente» o «no ejecutado contra el modelo». Hay que pasarlos a ejecutado con su registro antes de redactar las secciones de esos ejemplos (repo de la guía; no lo toca este despacho).
- Configuración del arnés: falta fijar `RLLM_UMBRAL_MS_POR_TOKEN` (≈ 1,7) y `RLLM_CARACTERES_POR_TOKEN` (2,33) de DEP-03.
- Los oráculos de las sondas viven en `Evidencia/Sondas/oraculos/`: `recalcular-oraculos.sh` no los encuentra solo (hay que juntar los dos directorios, como en `recalculo-oraculos.saneo.log`).
- Medidor: los cuatro defectos de §3.1. Vía sin `--fake`: corre `dotnet run --no-build`, necesita un `build` previo que el README no pide.
- AC-6: `ac6()` no vacía `$RLLM_DIR/paquetes` (riesgo sólo si se reusa un `RLLM_DIR`); los `Microsoft.Extensions.*` del runtime se resuelven en 2–3 versiones, fuera del invariante de §F.10 tal como está escrito (decisión aparte si se quiere ampliarlo). Las dos filas nuevas del Anexo F viven en §E.1 del plan y pasan al Anexo F de la guía al redactarla.
- AC-7: sin mecanismo de excepciones (decidido); el patrón de IP usa `\b` y no marca una dirección pegada a una letra; `Ciclo-3/07-…:71` describe el estado viejo (registro histórico). Hay que volver a correr AC-7 y AC-8 **después de escribir la guía** (hoy pesa 0 bytes).
- 05: queda la opción `--orden calentamiento` en el código (no adoptada); el README rotula «de 230 a 439 ms» sin decir que es la corrida 1.
- 08: los cuatro límites del oráculo de §1 quedan documentados, sin cambiar la regla.
9. ~~Declarar en 06 los embeddings sin `num_ctx`.~~ Hecho (§7 c).

## 6. Pedido del PO relayado durante la construcción

El PO preguntó por una demo Blazor de la encuesta de Movilidad Urbana y por si el servicio está publicado en una URL con dominio. Lo atiende la presidencia. Hay dos datos de este cierre que sirven para contestarle:
- La demo `Demos/MovilidadUrbana.Asistente` existe, compila y pasa 70/70 pruebas, y tiene capturas de la página de chat y de la aprobación en `Evidencia/Demo-MovilidadUrbana.Asistente/`.
- Por §F.9, el plan la publica sólo en el loopback del host. Publicarla en un dominio queda fuera del alcance del plan y necesita una decisión del PO.

## 7. Decisiones de la presidencia (2026-10-27)

Cuatro pendientes de §5 decididos y materializados. Las comprobaciones se corrieron a las 14:12 (-03), sin llamar a ningún modelo: no se gastó turno de `<recurso-compartido>` ni de `[recurso-modelo-propio]`.

**(a) 17 se muestra como «ejecutado».** El criterio era la validez del registro (AC-3b), no el orden en que corrió. `R-LLM/17-Observabilidad-Y-Pipeline.modelo.jsonl` lo cumple. El SHA-256 de `entradas.v1.json` (`6dd9e2a9…9677`) coincide con `ejemplo.json` y con `entradas_hash` de las dos llamadas. Las llamadas tienen las mismas claves que las de 09; sólo `contexto` y `carga_1min` van en `null`, como en 09. `truncado_posible` es `false`, con `num_ctx` 65.536 (`arnes`). `tools/recalcular-oraculos.sh` da «1 de 1 entradas coinciden», rc 0. Con el consumo real (§3), el salto de cola (D-1) no le quitó lugar a ninguna pieza. Hecho: un párrafo en «En este laboratorio» del README de 17 (sin nombres internos de turno, D-4) y la fila de §1.

**(b) 05 mantiene el orden del plan.** No se adopta `--orden calentamiento`. El resultado del ejemplo es el de la corrida 4: 5 de 6 pares a favor (p01 falla, p02–p06 pasan; recálculo «6 de 6 entradas coinciden»). Por §10.4 no se afirma ≪. p01 llega en frío por diseño. La llamada 1 es la sin-prefijo de p01, que empieza con un *nonce* y no deja nada reutilizable. La llamada 2 (con-prefijo de p01, 19.000,5 ms frente a 17.582,7 ms) es la primera vez que el servidor ve ese prefijo. Desde p02, el con-prefijo baja a 385–487 ms. Hecho en el README de 05: «Resultado del ejemplo», «Por qué p01 llega en frío», y la sección del desvío pasa a «Exploración no adoptada» con la decisión. Las corridas 2 y 3 quedan en la Evidencia como registro de lo probado. El código conserva la opción `--orden calentamiento` (default `alternado`): quitarla pide recompilar y no cambia ningún resultado (deuda menor).

**(c) 06: embeddings sin `num_ctx`.** Las 44 llamadas del registro tienen `num_ctx` y `num_ctx_origen` en `null` y `truncado_posible` = `false`. El `prompt_eval_count` máximo es 50. `num_ctx` no aplica porque es opción de chat: `OpcionesDelProveedor.Aplicar(ChatOptions …)` es el único punto que lo fija, y `FabricaDeClientes.CrearEmbeddingsOllama` no recibe `ChatOptions`. Además, el recorte silencioso que `num_ctx` evita no puede darse con textos de 50 tokens como máximo. Hecho: un ítem en «Qué observar» del README de 06, una nota de construcción en la fila 06 de §E.2 del plan (la columna ya decía «no aplica»; la nota explica el `null`, que la enumeración de §E.1 no prevé) y una línea «v3 (nota)» en §H del plan. La estructura aprobada no cambia.

**(d) La regla 10 y la salida del modelo (02).** La regla 10 del contrato de los constructores dice: «Datos: sólo Movilidad Urbana; estímulos rotulados “escrito para el ejemplo”, valores de Catalogos, personas “Persona 01…20”; localidades nuevas en registros → agregarlas a Compuertas/localidades-permitidas.txt». Corresponde al punto 6 de `Examples/README.md` y a «Dominio» y «Datos personales» de §E.1. **Decisión**: la regla tiene dos mitades, y la salida del modelo entra sólo en la segunda.
- *La mitad de dominio (I-06, «Estímulo de prueba» de §E.1)* no alcanza a la salida del modelo. Esa mitad rige lo que escribe el autor: entradas, oro, corpus, siembras y guiones. El autor no controla lo que el modelo devuelve, y la guía tiene que mostrarlo. En 02, que el 0,5B invente una localidad y una provincia fuera de `Catalogos` y un CP de 5 dígitos (contradiciendo el «4 dígitos» que él mismo escribe) es justo lo que ilustra A.4, punto 5: las reglas del dominio son la autoridad. `LocalidadRules.ProvinciaValida` (clave exacta de `Catalogos.Provincias`) y `CodigoPostalValido` (`^\d{4}$`) rechazan esa propuesta. Filtrar o corregir la salida para «cumplir» la regla falsearía la demostración.
- *La mitad de privacidad (AC-7 (3), «Datos personales» de §E.1)* sí alcanza a la salida, porque la compuerta lee `.salida`. Evidencia E2 en `Evidencia/Cierre-Construccion/regla-10-salida-del-modelo.log`. (A) El registro real de 02, con la lista sin «San Juan», da AC-7 rc 0: el nombre va en texto libre («si la localidad es “San Juan”») y el patrón de la compuerta sólo lee campos `"Nombre": "…"`. (B) La misma propuesta escrita como JSON estructurado da «1 valor(es)», rc 1: un nombre inventado por el modelo en un campo `Nombre` traba la compuerta. (C) Los 140 registros de `Evidencia/` dan rc 0 con la lista nueva. Los únicos nombres que la compuerta toma hoy de una salida de modelo son Goya, Bella Vista, Corrientes y Resistencia (03 y la demo), que vienen del caso base.
- *Consecuencia aplicada*. (1) Se quitó «San Juan» de `Compuertas/localidades-permitidas.txt`. Lo había agregado alguien a las 11:30, en contra de lo que dice `Evidencia/02-Cambio-De-Adaptador/desvios.txt` («no se agregaron»). No lo marcaba ninguna compuerta y ampliaba la lista sin revisión: un nombre inventado en un campo estructurado habría pasado sin que nadie lo mirara. Queda un comentario con el procedimiento: se agrega sólo si AC-7 lo marca, después de revisar que no es una persona ni un término privado, rotulado como salida del modelo. (2) El punto 6 de `Examples/README.md` declara el alcance. (3) El README de 02 explica, en «Qué observar», que lo inventado es conducta del modelo y no dato, sin repetir los nombres. El código no cambia: ni la compuerta ni el ejemplo. AC-7 y AC-8 sobre `Examples Demos tools Compuertas` y la Evidencia, después de los cambios: rc 0 (140 registros; AC-8 «0 coincidencias fuera de excepciones»). `recalcular-oraculos.sh` sobre `R-LLM/*.jsonl`: «341 de 341 entradas coinciden».

**Re-verificación de (a)–(d) tras el corte de sesión (2026-10-27).** Se volvió a leer cada cambio en los archivos; los cuatro están en su lugar. Se corrigieron dos referencias cruzadas que citaban «BIT-16-06 §5» por la sección de la decisión: el comentario de `Compuertas/localidades-permitidas.txt` (ahora «§7 d») y la línea «v3 (nota)» de §H del plan (ahora «§7 c»). Comprobaciones, sin llamar a ningún modelo: `recalcular-oraculos.sh` sobre 17 y la corrida 4 de 05, «7 de 7 entradas coinciden», rc 0; sobre todo `R-LLM/*.jsonl`, «365 de 365», rc 0 (la cifra creció desde las 341 de arriba porque otros despachos sumaron registros); las 44 llamadas de 06 tienen `num_ctx` y `num_ctx_origen` en `null`, `truncado_posible` = `false` y `prompt_eval_count` de 50 como máximo; AC-7 sobre `Examples Demos tools Compuertas` y la Evidencia da 0 coincidencias en 149 registros, rc 0; AC-8 da «0 coincidencias fuera de excepciones», rc 0.

## 8. Qué puede citar la guía (AC-9), por ejemplo y por paso de la demo

Regla (AC-9, §10.4 del plan): una cifra entra en la guía sólo si sale de un registro de `Evidencia/R-LLM/` o `Evidencia/Sondas/` que se recalculó en el saneamiento y coincidió (`recalculo-oraculos.saneo.log`: 365/365 en `R-LLM/`, 4/4 en `Sondas/`), con `entradas_hash` igual al de `ejemplo.json` y `truncado_posible` distinto de `true`. Va con el rótulo de laboratorio (un modelo chico, un servidor, una fecha) y, si el estímulo lo escribió el mismo autor, con esa marca. Las tasas con M ≤ 12 son descriptivas: se citan con su IC95 de Clopper-Pearson (`verificar.sh tasa`) y sin afirmar diferencias que la regla pareada no sostiene. Lo que no cumple esto entra **sin cifra**: como conducta mostrada, o como garantía de código («lo asegura una prueba», no «se midió»). En ningún caso se citan `razonamiento` ni `num_ctx` del registro como observados (observación transversal de §1).

| Pieza | Puede citar (registro) | Sin cifra o no se cita |
|---|---|---|
| 01 Chat y streaming | conducta: 2 de 2 salidas válidas (`01-…modelo.jsonl`) | la variante «sin la capa» (sólo `--fake`); tiempos |
| 02 Cambio de adaptador | conducta: la misma entrada pasa por los dos adaptadores (`02-…modelo.jsonl`); que el modelo inventa una localidad fuera del catálogo (§7 d), sin decir que una regla la rechaza: la salida es texto libre y 02 no la pasa por `LocalidadRules` (`AsistenteDeAlta.cs`; oráculo `dos-adaptadores`), así que ninguna regla la rechazó; a lo sumo, «no pasaría» `ProvinciaValida` ni `CodigoPostalValido`. *Corrección 2026-10-28, ver 07-Redaccion.md* (§8 punto 2 y `Redaccion/01-Muestra-Decisiones.md`); antes decía «y las reglas del dominio la rechazan» | duraciones y `truncado_posible` (por `/v1` no llegan; `null`); los nombres inventados |
| 03 Salida estructurada | base 2/2 como conducta; **extensión**: 8/8 pasan el oráculo, IC95 [0,631; 1]; JSON válido 8/8; habitantes propuestos sin el dato 0/4, IC95 [0; 0,602] (`03-…modelo-ext.jsonl`; estímulo del mismo autor) | comparación con otro modelo o servidor |
| 04 Normalización contra catálogo | base: d01 pasa, d02 falla (frecuencia `null`) como conducta; **extensión**: 7/8, IC95 [0,473; 0,997] (`04-…modelo-ext.jsonl`) | — |
| 05 Contexto completo con prefijo | duraciones observadas de la corrida 4 y «5 de 6 pares a favor» descriptivo (`05-…modelo.corrida-4.jsonl`); con-prefijo de 385 a 487 ms desde p02 (rotulando la corrida) | «con-prefijo ≪ sin-prefijo»; caché caliente o fría (`estado_cache` desconocido); el 6/6 de `--orden calentamiento`; las corridas 2 y 3 |
| 06 Embeddings | hit@1 10/12, hit@3 12/12, MRR 0,889; léxica 7/12, 8/12, 0,679; azar 1/12, 3/12, 0,259; ventaja sobre el azar con p = 0,012 y 0,004 (`06-…modelo.jsonl`) | ventaja sobre la léxica o entre variantes; `num_ctx` (no aplica a embeddings) |
| 07 RAG con citas | afirmación correcta 7/7, cita válida 5/5, «No sé» 0/4, cita y contradice 1/12, cada una con su IC95 (`07-…modelo.jsonl`) | la estabilidad (3 repeticiones, 1 texto distinto) como tasa; la corrida interrumpida |
| 08 Primera herramienta | base 2/2 como conducta; **extensión**: herramienta invocada con argumentos válidos 4/4 legítimas, IC95 [0,398; 1]; el corte del bucle a las 3 iteraciones (garantía de código, guion). El 6/8 del oráculo no-inventa, IC95 [0,349; 0,968], **sólo** junto con la lectura de sus dos fallas: xl04 suma dos conteos (1 + 1) y xn03 repite un identificador de sesión con dígitos; ninguna es invención del modelo (`08-…modelo-ext.jsonl`) | una «tasa de invención» o «negativas sin invención 3/4»: lo que falla es el oráculo, no el modelo; tampoco se presenta el oráculo como prueba de que el id corresponde al nombre (límite 1 de §1) |
| 09 Caso de uso como herramienta | conducta: 2 de 2 (`09-…modelo.jsonl`) | tiempos |
| 10 Workflow y contraejemplo | «workflow = función» en las 4 entradas congeladas (registro sin modelo) | generalizarlo al abandono después de un rechazo (los datos difieren) |
| 11 Agente con aprobación | conducta: 1 de 1, el alta ejecutada es la mostrada (`11-…modelo.jsonl`); DEP-09 (`Sondas/DEP-09-…`): la aprobación en dos peticiones conserva el pedido y `AprobacionAlterada` se cumple, con 25,1 s y 29,6 s por petición | la prueba `Category("LLM")` (no corrió); la clase L presupuestada |
| 12 Uno o varios agentes | conducta: 4 de 4, 0 vueltas (`12-…modelo.jsonl`) | el camino del corrector contra el modelo (no se observó) |
| 13 Servidor y cliente MCP | conducta: 1 de 1 (`13-…modelo.jsonl`) | — |
| 14 Anotaciones SK frente a M.E.AI | equivalencia de las anotaciones en el registro sin modelo (`14-…jsonl`) | que el beta transitivo de SK sea estable (es una excepción escrita, Anexo F) |
| 15 Pruebas y evaluación | sólo «juez no calibrado»: 0/52 interpretables; acuerdo 0/10, IC95 [0; 0,308]; anotador = agente (`15-…modelo.jsonl`) | cualquier tasa de calidad de 07 juzgada por el juez |
| 16 Inyección indirecta | pedidos de baja inducidos 0/6 por variante, IC95 [0; 0,459], b = c = 0 «sobre un solo texto de ataque, del mismo autor» (`16-…modelo.jsonl`) | «origen» como medido (es garantía de código); la corrida interrumpida |
| 17 Observabilidad y pipeline | conducta ejecutada contra el modelo, 1 de 1 (§7 a) | tiempos |
| Demo PD-2 (RAG en la demo) | conducta del humo con su registro (`Demo-…modelo.jsonl`) | tasa (una sola entrada) |
| Demo PD-3 (salida estructurada) | conducta del humo con su registro | tasa; la `GarantiaNumerica` de la demo como equivalente a la de 03 (es más laxa) |
| Demo PD-6 (aprobación) | conducta del humo con su registro; 0 bajas sin aprobación (AC-4, 70/70) | tasa; el primer PD-6 (defecto de la prueba, repetido) |
| Sondas y tiempos | DEP-03: con `num_ctx` por la capa única el servidor procesa 5.714 tokens; sin la opción, 2.050 (recorte silencioso), y 2,33 caracteres por token con ese estímulo (`Sondas/DEP-03-…`); DEP-13 como dos mediciones de clase M (91,7 s y 123,1 s); que los pesimistas por clase no acotan la cola bajo carga (07 y 17 pasan el de K; 16 pasa el de H), con los registros de cada pieza | DEP-13 como calibración de K; el umbral de ms por token como fijado (falta en la configuración del arnés); las cifras de dossiers que no se re-ejecutaron en la construcción (R-PO-2) |

**¿Lista para redactar?** Sí. Las compuertas que se pueden correr sin la guía cumplen (§2.1); todo lo que se va a citar está recalculado y su regla está en esta tabla. La deuda abierta (§5, «Deuda que sigue abierta») no cambia ninguna cifra citable. Dos condiciones para el cierre del ciclo: actualizar los `estado` de las extensiones en los `ejemplo.json` de 03, 04 y 08 antes de redactar esas secciones, y volver a correr AC-7, AC-8 y AC-9 sobre la guía escrita.
