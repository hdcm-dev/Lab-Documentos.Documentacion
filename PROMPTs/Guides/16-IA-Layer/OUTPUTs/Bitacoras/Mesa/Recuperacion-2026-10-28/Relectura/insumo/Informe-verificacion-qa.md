---
doc_id: BIT-16-C1-INF-verificacion-qa
doc_type: informe-de-especialista
title: Informe del especialista Verificación / QA — ciclo 1
status: emitido
origin: agent
confidence: 0.85
owner: Verificación / QA (núcleo permanente, M§4.1.1; comisión N5)
last_review: 2026-10-28
audience: [relator, jurado, cuerpo-auditor, presidencia]
traces: [REED-16 §8, §9.1, §9.2, BIT-16-00 §2–§3, BIT-16-04 §1–§7, Mesa/Ciclo-1/00-Convocatoria §9]
---

# Informe de Verificación / QA — ciclo 1 (a ciegas)

**Fecha:** 2026-10-28, en <equipo-de-contingencia>. **Mandato** (00-Convocatoria §9, asiento 2): que toda afirmación técnica tenga fuente con versión y fecha o experimento; que los experimentos citados existan y corran como dicen; que las pruebas contra el modelo cumplan R-LLM; correr las compuertas mecánicas de REED-16 §9.1 que aplican a los registros, con los patrones R-PRIV extendidos a `/home/` y <rango-de-la-red-privada>. No juzgo didáctica, ni si una N alcanza para lo que se le atribuye (eso es de AH-02), ni la arquitectura.

**Objeto revisado:** `Bitacoras/00…04`, `Nucleos/*.md` (con sus notas del 2026-10-28), `Integracion-Evidencia/`, `Sondeo-Evidencia/2026-10-28/`, `Nucleos/*-Evidencia/` y, por la compuerta R-PRIV, `OUTPUTs/Reanudar.md` y `OUTPUTs/Crear-IA-Layer-Guide-Reedicion.md`. No leí otros informes del ciclo.

**Evidencia propia:** [`evidencia-verificacion-qa/`](evidencia-verificacion-qa/). Los valores que filtran se registran **redactados**; acá se da archivo y línea, nunca el valor. Las corridas fueron por turno (`<gestor-de-turnos> build` y `modelo-compartido`, etiqueta `verificacion-qa`), con intermedios en `$TRABAJO/verificacion-qa/` y sin bin/obj al terminar.

## Índice

- [1. Compuertas mecánicas corridas](#1-compuertas-mecánicas-corridas)
- [2. Experimentos re-corridos](#2-experimentos-re-corridos)
- [3. Hallazgos](#3-hallazgos)
- [4. Lo que revisé y está bien](#4-lo-que-revisé-y-está-bien)
- [5. Posición sobre los MI de mi mandato](#5-posición-sobre-los-mi-de-mi-mandato)
- [6. Solicitudes de convocatoria](#6-solicitudes-de-convocatoria)

## 1. Compuertas mecánicas corridas

| Id | Compuerta (REED-16 §9.1) | Alcance | Resultado | Archivo |
|---|---|---|---|---|
| G1 | `grep '\[C:'` (C2) | `00…04`, `Nucleos/*.md` | **13** marcas, todas en la fundación: 00 (4), 01 (7), 03 (1). Dos son definiciones de la convención (00 l. 102, 01 l. 18); quedan **11 sustantivas** sin nota de cierre. Núcleos y 04: 0 | `G1-grep-C.txt` |
| G2 | Enlaces y anclas (C4) | `Bitacoras/*.md`, `Nucleos/*.md`, `Integracion-Evidencia/*/README.md`, `Reanudar.md` | 188 enlaces relativos, **0 rotos** (archivo y ancla, con slug estilo GitHub) | `G2-enlaces.txt`, `G2-enlaces.py` |
| G3 | R-PRIV: RFC 1918, <rango-de-la-red-privada>, `:11434` con host, `usuario@`, `/home/`, serie y `adb` del <teléfono-de-prueba>, cadenas con forma de credencial | todo `OUTPUTs/` salvo `Mesa/Ciclo-1/` | **1 IP de <rango-de-la-red-privada> con usuario** (`Reanudar.md` l. 60); **20 rutas `/home/`** en 11 archivos; 0 credenciales (las coincidencias de `token` son `CancellationToken`); las de `10.11.0.0` son versiones de ensamblado. El endpoint del Ollama propio **no aparece** en ningún archivo | `G3-rpriv.txt` |
| G4 | Versiones de `PackageReference` = versiones citadas | `*.csproj` de la evidencia | Coinciden con X0 salvo `Microsoft.EntityFrameworkCore.Sqlite` 10.0.11 en un proyecto de N3 (anterior a 10.0.14; historia del 25-10) | (comando en §3, VERIFI-07) |

No aplican todavía: `dotnet build/test` de `Examples/` y `Demos/` (vacíos), mermaid que renderiza y `.gitignore` (DC-08), porque la guía no existe.

## 2. Experimentos re-corridos

| Id | Qué re-corrí | Contra | Resultado | Archivo |
|---|---|---|---|---|
| R1 | X0 (24 paquetes, flatcontainer), 2026-10-28T09:44 | X0 de 08:56 | **Sin diferencias** | `R1-X0-recorrida.tsv` |
| R2 | Deprecación y vulnerabilidades en `registration5-gz-semver2` de la versión citada de los 24 paquetes; PyPI y npm de LangGraph | X0, E-B6 | 0 deprecados, 0 vulnerabilidades; `Microsoft.Extensions.AI.Ollama` sigue deprecado (`["Other"]`); `langgraph` 1.2.18 (2026-10-26T20:04:29), `@langchain/langgraph` 1.5.3 (2026-10-26T19:41:49Z) | `R2-deprecaciones-y-langgraph.txt`, `R2-deprec.py` |
| R3 | Soporte de .NET (`https://dotnetcli.blob.core.windows.net/dotnet/release-metadata/releases-index.json`, 2026-10-28T09:45) | SUP-08 | 10.0: `lts`, `active`, SDK 10.0.403, EOL 2028-11-14; 11.0: `sts`, `go-live` (rc.3) | `R3-dotnet-soporte.txt` |
| R4 | `verificar-capas.sh` (EA-3) con `Copia/` regenerada y con una mutación | `verificar-capas-salida.txt` | Reproduce la salida; con la mutación da **falso negativo** (VERIFI-03) | `R4-mutacion-prueba-de-arquitectura.txt` |
| R5 | EA-5 (`dotnet run -- fake`), SDK 10.0.403 | `salida-fake.txt` | **Idéntica** salvo la línea de fecha | `R5-EA5-fake-recorrida.txt` |
| R6 | X1 (OTel `sourceName` y T1), sin modelo | `X1-sonda-otel-t1-salida.txt` | **Idéntica** en las ocho líneas `[A]`/`[B]` | `R6-X1-recorrida.txt` |
| R7 | `/api/version`, `/api/tags` y `/api/show` del Ollama propio en contenedor (<equipo-de-contingencia>), sin generación, 09:48 | 04 §0, Sondeo §R.1 | 0.40.11 y los **tres digests idénticos**; `qwen3.5:4b` con `tools`/`thinking` y contexto nativo 262144 | `R7-ollama-version-digests.txt` |
| R8 | N1b `E2-nuget-hitos.py` | `E2-nuget-hitos.txt` | Primeras versiones y primera estable **iguales** (MAF 1.0.0 = 2026-04-02T16:40) | `R8-N1b-E2-recorrida.txt` |
| R9 | Sonda propia de reflexión sobre MEAI 10.11.0 | N5 V6, 04 §6.3 M5, I-8 | `MaximumIterationsPerRequest`=40, `MaximumConsecutiveErrorsPerRequest`=3, `TerminateOnUnknownCalls`=false; existen `ChatOptions.Reasoning` y `ReasoningEffort.None` | `R9-sonda-defaults-meai/` |
| R10 | N4 [E02] `compilecheck` | N4 §3.0 | Compila; el workflow sin modelo da `checkpoint: True / output: ALOH / checkpoint: True` | `R10-N4-E02-recorrida.txt` |
| R11 | Paquetes de N5 §3.1 que X0 no cubre | N5 §3.1 | `Aspire.Hosting.Ollama` 404; Foundry.Local 2.2.1; Foundry.Local.WinML 1.2.4; Caching.Hybrid, Aspire.Hosting.OpenAI, Evaluation.Console y Reporting.Azure como dice N5 | `R11-N5-paquetes.txt` |

Además recalculé, desde las salidas crudas, las cifras de BIT-16-04 §1 y del Sondeo §R.4 (ver §4, ítem 1).

## 3. Hallazgos

Esquema M§8. La capa es dónde nació el defecto: pedido (incluye los documentos de control de la corrida), núcleo (incluye la fundación 00–03), integración, laboratorio, demo o guía.

### VERIFI-01 — Fuga R-PRIV en `Reanudar.md`: IP de la tailnet y usuario del host de respaldo

- **Ubicación:** `OUTPUTs/Reanudar.md` §5, línea 60 (viñeta «Respaldo»).
- **Afirmación:** el comando `rsync` escribe literalmente `<usuario>@<IP de <rango-de-la-red-privada>>` de <estación-2>, que MI-03 propone como host de un Ollama.
- **Evidencia (E1):** `G3-rpriv.txt`, patrón <rango-de-la-red-privada> y `usuario@` → `Reanudar.md:60` (valor redactado en la evidencia). Es la única IP no documental en todo `OUTPUTs/`. El mismo documento dice en su §5: «Repo público… nada sin redactar (rutas del home, IPs de la tailnet…)». BIT-16-00 R-PRIV: «ni IPs privadas… ni usuarios».
- **Severidad:** S1 (fuga R-PRIV, BIT-16-00 §3). **Confianza:** 0,95.
- **Impacto si no se corrige:** el primer commit de `OUTPUTs/` publica la dirección y el usuario de una máquina que la propia mesa propone como servidor de IA.
- **Propuesta de dirección:** sacar el valor del archivo (un agregado no borra una fuga: es la excepción justificada a «sólo agregado», y hay que dejarla registrada como nota fechada); referirse al host como «<estación-2>» y pasar destino y usuario por variable (p. ej. `RESPALDO_DESTINO`) o remitir a la memoria privada; volver a correr G3 con los patrones extendidos antes de cualquier commit.
- **Capa:** pedido (documento de control de la corrida).

### VERIFI-02 — Rutas del home del anfitrión en 11 archivos, una de ellas fija en un script de evidencia

- **Ubicación:** 20 líneas. `Reanudar.md` l. 6, 14, 36; `Sondeo-Entorno.md` l. 5, 195; `Crear-IA-Layer-Guide-Reedicion.md` l. 116; `00-Contrato-De-Entrada.md` l. 70; `N0b` l. 428, 464, 513; `N1` l. 433, 434, 514, 522; `N1b` l. 284, 351; `N3b` l. 378, 504, 554; `Integracion-Evidencia/A-arquitectura/exp-capas/verificar-capas.sh` l. 9.
- **Evidencia (E1):** `G3-rpriv.txt`, patrón `/home/` (extensión pedida por la convocatoria, §4.1 y §9). En `verificar-capas.sh` la ruta absoluta del caso base (`SRC=/home/…/MovilidadUrbana.ApiWeb`) hace que el script sólo corra en este anfitrión.
- **Severidad:** S3. No son credenciales, pero violan la regla de redacción para el repo público (`Reanudar.md` §5) y, en el script, la reproducibilidad. **Confianza:** 0,9.
- **Impacto si no se corrige:** si la redacción copia de la bitácora, la guía, `Examples/` o `Demos/` heredan rutas del anfitrión; el script de la prueba de arquitectura no corre en la máquina del lector.
- **Propuesta de dirección:** rutas desde la raíz del workspace (`/LAB/...`, la convención de la bitácora) o por variable (`CASO_BASE`); incorporar `/home/` y <rango-de-la-red-privada> al grep R-PRIV de REED-16 §9.1 como compuerta fija sobre guía, `Examples/` y `Demos/`; en los registros, nota fechada que lo señale (sólo agregado).
- **Capa:** núcleo (registros y fundación) e integración (script).

### VERIFI-03 — La prueba de arquitectura por `grep` da falsos negativos y nunca falla

- **Ubicación:** `04-Integracion.md` §1 (EA-2/EA-3), §3.1 RA-2 («la regla la hace cumplir una prueba de arquitectura»), §5 MI-04; `Integracion-Evidencia/A-arquitectura/exp-capas/verificar-capas.sh`.
- **Afirmación:** el script cuenta sólo líneas `^using (Microsoft.Extensions.AI|…)`. No detecta `global using` ni tipos con nombre calificado, y termina con código 0 aunque el conteo no sea 0. No hace cumplir la regla: la informa.
- **Evidencia (E1):** `R4-mutacion-prueba-de-arquitectura.txt`. Con `Copia/` regenerada desde `59399ba`, el script reproduce `0/0/0/2`. Después agregué a `Nuevo/Application` un `global using Microsoft.Extensions.AI;` y una propiedad `Microsoft.Extensions.AI.IChatClient?`, y el script volvió a informar **0 archivos**, con salida exitosa. Además, tal como está en la bitácora (sin `Copia/`) falla con «No existe el fichero o el directorio» (lo declara el README de A, así que eso no es defecto).
- **Severidad:** S2 (recomendación presentada como control sin el escenario en que falla; el lector se lleva una falsa garantía). **Confianza:** 0,9.
- **Impacto si no se corrige:** la guía enseña como «prueba de arquitectura» un chequeo que deja pasar la violación más común (un `global using` en el proyecto).
- **Propuesta de dirección:** que el ejemplo de MI-04 sea una prueba que **falla** (código ≠ 0 o test NUnit en rojo) y que inspeccione lo compilado (los tipos que referencian los tipos de `Domain`/`Application`, por reflexión sobre el ensamblado), no el texto. Que su evidencia incluya la mutación de arriba en rojo y la copia limpia en verde. Si se mantiene el `grep`, la guía tiene que declarar sus dos agujeros.
- **Capa:** integración (EA-3; se propaga a N1 y N6 por RA-2).

### VERIFI-04 — Marcas `[C:]` de la fundación sin cierre; SUP-08 (.NET 10 LTS) nunca se verificó

- **Ubicación:** `00-Contrato-De-Entrada.md` l. 138, 142 y 169 (SUP-04, SUP-08, §6); `01-Descomposicion-Conceptual.md` l. 104, 115, 117, 123, 136 y 149 (×2); `03-Marco-De-Referencia.md` l. 48.
- **Evidencia (E1):** `G1-grep-C.txt`: 11 marcas sustantivas, ninguna con nota fechada que diga dónde se resolvió. Por muestreo, la mayoría sí tiene resolución en un núcleo: SUP-04 y propietarios de NuGet en N4 [E06] y E-B6; semconv en N5 §3.2; OWASP en N5 §3.4; Qwen y herramientas en el Sondeo §R.4. La excepción es **SUP-08**: `grep -rnw LTS` sobre toda la bitácora devuelve sólo la propia marca de 00 l. 142; ningún núcleo verificó el soporte. Lo verifiqué yo (R3): .NET 10.0 es `lts`, `active`, con fin de soporte el 2028-11-14 (release-metadata oficial, consultado el 2026-10-28T09:45).
- **Severidad:** S3 (trazabilidad de C2). Pasa a S1 si la guía afirma «LTS» sin fuente. **Confianza:** 0,85.
- **Impacto si no se corrige:** la compuerta C2 se corre sobre la guía y da 0 porque la guía todavía no existe; las hipótesis de la fundación pueden entrar a la redacción sin que nadie compruebe que se resolvieron.
- **Propuesta de dirección:** una nota fechada en 00, 01 y 03 (sólo agregado) que mapee cada `[C:]` → núcleo y evidencia que lo resolvió, o «sigue abierta»; SUP-08 se cierra con R3 (URL y fecha). En el Anexo D, la fila de .NET con estado de soporte y fecha.
- **Capa:** núcleo (fundación).

### VERIFI-05 — R-LLM incompleto en el registro de las corridas X2, X3 y de la sonda B; scripts de C que no corren desde la bitácora

- **Ubicación:** `04-Integracion.md` §1 («Todas las corridas contra el modelo siguen R-LLM (modelo@digest, parámetros, N, criterio de éxito escrito antes, tasa)»); `Integracion-Evidencia/C-operacion-demo/` (X2, X3) y `B-abstracciones-agentes/sonda/salidas/`.
- **Afirmación:** (a) ninguna salida cruda de X2, X3 ni de la sonda B registra el **digest**: el `jsonl` trae sólo `modelo` (barrido en todas las salidas: 0 coincidencias de los tres digests o de `digest`; sólo los README de A y B y el Sondeo lo nombran); `C-operacion-demo/` no tiene README que fije modelo@digest y parámetros. (b) X3 **no tiene fecha** en la bitácora: `x3-fecha.txt` quedó en el intermedio `$TRABAJO/c-operacion-demo/ctx/salidas/` (09:11:26–09:15:25) y no se copió; el `jsonl` no trae hora. (c) `X2-correr.sh` y `X3-correr.sh` llaman a `escrituras.py`/`ventana.py` y escriben en `salidas/…`, pero los archivos guardados se llaman `X2-escrituras.py`, `X3-ventana.py` y `X2-escrituras-qwen3.5-4b.jsonl`; `X2-X3-correr-ollama.sh` apunta a `$TRABAJO/c-operacion-demo/tools/`, fuera de la bitácora.
- **Evidencia (E1):** barrido de digests sobre `Integracion-Evidencia/` y `Sondeo-Evidencia/` (este informe, §1); `ls` de `C-operacion-demo/` (sólo `X2-fecha.txt`); lectura de los tres scripts. Atenuante medido: R7 confirma a las 09:48 que los tres digests no cambiaron, así que la atribución vale **hoy**. Lo que sí cumple: el criterio de éxito de X2 está escrito en el código antes de correr (comentarios de `PEDIDOS` y `clasificar`), y los parámetros (T 0,7, `seed` 1..N, `max_tokens` 300, `reasoning_effort` none) están en el script.
- **Severidad:** S3. **Confianza:** 0,85.
- **Impacto si no se corrige:** si alguien hace `pull` de otra etiqueta con el mismo nombre, las tasas de X2 (que sostienen MI-14 y M3) dejan de ser atribuibles a un modelo; X3 no se puede reproducir sin renombrar archivos, y no tiene fecha propia.
- **Propuesta de dirección:** cada script contra el modelo escribe una primera línea con `fecha`, `/api/version` y `modelo@digest` (de `/api/tags`); un README en `C-operacion-demo/` como los de A y B; copiar `x3-fecha.txt`; scripts con los nombres que quedaron guardados. Es la misma plantilla que va a necesitar `tests/ConModelo/` y el Anexo E.
- **Capa:** integración.

### VERIFI-06 — E1 de los núcleos sin artefacto re-ejecutable, y P-14 no los cubre a todos

- **Ubicación:** N2 §4.0 [E3b]/[E4] (sin carpeta de evidencia; la nota del 2026-10-28 dice «El doble de 15 líneas se perdió»); N5 §3.6 (sonda sin código en la bitácora; dice SDK 10.0.400, cuando la misma etiqueta dio 10.0.403 en la verificación de N2); N1 `E01/E03/E04` («las fuentes… se perdieron», N1 nota de reanudación, fila 4; además `E01` compiló con `sdk:11.0.100-rc.1`, fuera de la imagen que fija REED-16 §9.1); N3b X1 («el programa se perdió»). `04-Integracion.md` §7 P-14 sólo nombra N2, N4 y N5.
- **Evidencia (E1/E2):** listado de `Nucleos/*-Evidencia/` (sólo existen N1b, N3, N4, N6) y citas de las notas de reanudación. Re-ejecuté por mi cuenta lo que se podía sin el código original: los defaults de N5 V6 se confirman (R9) y N4 [E02] reproduce (R10).
- **Severidad:** S3. **Confianza:** 0,8.
- **Impacto si no se corrige:** la guía puede citar como «ejecutado» un snippet de N1, N2, N3b o N5 cuyo programa ya no existe, sin que nadie lo haya vuelto a compilar.
- **Propuesta de dirección:** extender P-14 a N1 (4.1–4.7) y a N3b X1, con la regla de que **ningún snippet entra a la guía como ejecutado** si no compila en `Examples/` con `mcr.microsoft.com/dotnet/sdk:10.0` (o el SDK 10.0.403 registrado). Lo que yo re-ejecuté (R9 y R10) puede citarse como evidencia vigente.
- **Capa:** núcleo (se corrige al construir el laboratorio).

### VERIFI-07 — X0 no consulta deprecaciones, y la tensión 8 y el Anexo D se apoyan sólo en X0

- **Ubicación:** `04-Integracion.md` §2 tensión 8 y §8 Anexo D («re-consultada antes de publicar»); `Integracion-Evidencia/C-operacion-demo/X0-nuget-consultar.sh`.
- **Afirmación:** X0 sólo lee el flatcontainer (última estable y última preview). R-EVID exige verificar estado GA/preview **y deprecaciones**, y eso vive en el registro (`registration5-gz-semver2`), que X0 no toca. Además, la columna «preview» de X0 muestra la última preview en orden semver (p. ej. `9.5.0-preview…` para MEAI), no la más reciente en el tiempo, y se presta a malas lecturas en el Anexo D.
- **Evidencia (E1):** lectura del script; R2 corrió la consulta que falta: hoy no hay deprecaciones ni vulnerabilidades en las 24 versiones citadas, y `Microsoft.Extensions.AI.Ollama` figura deprecado. G4: un `.csproj` de N3 todavía referencia EF Core Sqlite 10.0.11.
- **Severidad:** S3 (la compuerta queda incompleta; el contenido hoy es correcto). **Confianza:** 0,85.
- **Impacto si no se corrige:** una deprecación publicada entre hoy y la publicación (un caso ya pasó, con `Microsoft.Extensions.AI.Ollama`) no la detecta la re-consulta prevista.
- **Propuesta de dirección:** que la re-consulta del Anexo D (P-13) use registro + flatcontainer (estado, `published`, `deprecation`, `vulnerabilities`), como `R2-deprec.py`; que la columna preview diga «última preview publicada» o se quite; y que los `PackageReference` de `Examples/` y `Demos/` se igualen a esa tabla (compuerta de §9.1).
- **Capa:** integración.

## 4. Lo que revisé y está bien

1. **Las cifras de BIT-16-04 §1 salen de las salidas crudas.** Las recalculé desde los `jsonl`. E-B1: `qwen3.5:4b` 5/5 por OllamaSharp y 5/5 por `/v1`; `qwen2.5:0.5b` 0/5 con «piedra» ×3. E-B2: 13/13 con forma válida, 11/13 válidas para el dominio (los dos fallos: `CodigoPostal` «Oh» y «{:04d}»). E-B3: 3/3 pedidos de aprobación, 0 ejecuciones. E-B5: 4/7, «en avión» → `moto` 0,641. Sondeo §R.4: 0.5b 0/10 en «a pie», con 6 «piedra». X2 D1: 7 «34000», 2 «3400», 1 «34089», y «3400» pasa `LocalidadRules` (4 dígitos, `Domain/Rules/LocalidadRules.cs` l. 16 en `59399ba`). E-B2b: las capturas HTTP muestran `think:false` y `format` (objeto o `"json"`) por OllamaSharp, y `reasoning_effort:"none"`, `response_format` y `tool_choice` por `/v1`.
2. **Los experimentos baratos reproducen.** X0 sin diferencias; LangGraph en PyPI y npm igual que E-B6; N1b E2; EA-5 en modo fake idéntico; X1 idéntico; N4 [E02]; defaults de MEAI 10.11.0; Ollama 0.40.11 con los tres digests de 04 §0 (§2, R1–R10).
3. **Compuertas de enlaces y de endpoint limpias.** 188 enlaces relativos con ancla, 0 rotos. El endpoint del Ollama propio no figura en ningún archivo de `OUTPUTs/`: los scripts lo leen de `OLLAMA_ENDPOINT` con default `localhost`, y el log de X3 enmascara IPs. Las únicas apariciones de `:11434` con host son `127.0.0.1` documental en N5.

## 5. Posición sobre los MI de mi mandato

Voto sólo lo que se decide por evidencia, reproducibilidad o R-LLM. El tamaño del juez y las métricas de recuperación (MI-07, MI-08, MI-16, MI-24) son de AH-02; la arquitectura (MI-01, MI-05, MI-06), del panel respectivo.

| MI | Posición | Fundamento |
|---|---|---|
| MI-02 | propuesta | La evidencia separa los modelos: el 0.5b da 0/5 (E-B1) y 0/10 (§R.4) en la herramienta con sinónimo; el 4b, 10/10 y 5/5. R7 confirma que los digests de 04 §0 siguen vigentes. Con la condición de VERIFI-05: modelo@digest en cada salida |
| MI-03 | propuesta | Lo que no corre en <equipo-de-contingencia> (≥ 7B, concurrencia, contexto grande) no está medido; o se mide con `sondeo.py` en <estación-2> o se declara «no medido». Condición: la dirección de <estación-2> sólo por variable (VERIFI-01) |
| MI-04 | otra | Sí como ejemplo en `Examples/` y en la demo, pero no el `grep` actual: una prueba que falla y que inspecciona lo compilado, con la mutación de R4 como caso rojo (VERIFI-03) |
| MI-12 | propuesta | X0 re-corrido sin diferencias (R1) y sin deprecaciones (R2). SqliteVec sólo existe como preview (1.0.3-preview) y depende de un `sqlite-vec` alpha (N3 F31): por defecto no cumple el criterio de estado verificable |
| MI-15 | propuesta | X1 reproduce (R6): lo que rompe la telemetría es que los nombres no coincidan (0 spans). Una constante única elimina ese modo de falla, y el nombre por defecto lleva el prefijo `Experimental.` |
| MI-17 | propuesta | Se verifica de forma barata y determinista: la dimensión de `qwen3-embedding:0.6b` es 1024 por HTTP (§R.3) y por .NET (EA-6, E-B4). Fallar rápido convierte un error silencioso en uno visible |
| MI-18 | propuesta | X3 muestra truncado silencioso con HTTP 200 y `done_reason: stop`, confirmado por el log del servidor (`limit=2050`, `limit=4098`). Sólo fijar `num_ctx` no detecta un prompt que lo supera. Condición: P-08 con el modelo de chat antes de citar la regla «contexto/2 + 2», hoy medida con N = 1 por caso y sólo con el 0.5b |
| MI-22 | propuesta | La delegación circular era real (C-3) y la asignación de 04 la corta. Condición: cada dueño usa la plantilla R-LLM de VERIFI-05 (fecha, versión, modelo@digest, parámetros, criterio escrito antes, N, tasa) |
| MI-16 | abstención | El tamaño y la calibración del juez son de AH-02. Desde mi mandato sólo constato que no se corrió (04 R-C09, P-03) |

## 6. Solicitudes de convocatoria

1. **AH-01 (seguridad y redacción para repo público):** en VERIFI-01 y VERIFI-02 sólo vi lo que encuentra el `grep`. Quedan fugas semánticas que no son mi mandato: el nombre del contenedor, los nombres de hosts (`<equipo-de-contingencia>`, `<equipo-principal>`, `<estación-2>` en 18 archivos) y la descripción del hardware del anfitrión. Pido que juzgue si son aceptables en el repo público.
2. **Senior .NET:** la captura HTTP de E-B2b (`01-b1-b2.jsonl`, `captura-http`) muestra una clave `<clave-de-cabeceras-por-pedido>` dentro del **cuerpo** JSON de `POST /api/chat` y `/api/embed` de OllamaSharp 5.5.0. Si es un artefacto de la sonda, no pasa nada; si OllamaSharp serializa ahí encabezados configurados por la aplicación, toca a M10 y a R-PRIV. Pido que se verifique.
3. **Arquitectura de software:** RA-2 depende de una prueba que hoy no hace cumplir la regla (VERIFI-03). Juzgar si la alternativa es separar `Domain`/`Application` en proyectos, para que lo haga cumplir el compilador, excede mi mandato.
