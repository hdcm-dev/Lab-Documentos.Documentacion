---
doc_id: BIT-16-07-REDACCION
doc_type: bitacora
title: Redacción de la guía 16 — cómo se escribió, relectura de la mesa, compresión, compuertas y cierre
status: cerrada (2026-10-28), con pendientes declarados y dos decisiones para el PO
origin: agent (redacción, relectura integral y cierre de la redacción)
last_review: 2026-10-28
audience: [PO, próxima corrida de la mesa]
traces: [BIT-16-04 v3 §C, §D, §E.6, §F.10, BIT-16-06 §8, BIT-16-RED-00-CARTA, BIT-16-RED-01-MUESTRA, BIT-16-RED-03-RELECTURA, Mesa/I-06]
---

# Redacción de la guía 16

Objeto: `/LAB/Lab-Documentos/Lab-Documentos/Guides/IA/Dot-Net-Integration-AI-Layer-Guide/Dot-Net-Integration-AI-Layer-Guide.md`, versión 0.10.1. Al cierre tenía 5.126 líneas y 66.458 palabras (`wc -w`); tras los pendientes finales del 2026-10-28, 5.128 líneas, 66.827 palabras y 177 REF.
La estructura sigue el plan aprobado (`04-Plan-De-Integracion.md` v3, §C). Las cifras salen de `06-Construccion.md` §8.
Los logs del cierre están en [`Evidencia/Cierre-Redaccion/`](Evidencia/Cierre-Redaccion/).

## Índice

- [1. Resultado](#1-resultado)
- [2. Cómo se redactó: muestra, cuerpo y síntesis](#2-cómo-se-redactó-muestra-cuerpo-y-síntesis)
- [3. Relectura integral de la mesa](#3-relectura-integral-de-la-mesa)
- [4. Pasada de parches (0.10.0)](#4-pasada-de-parches-0100)
- [5. Compresión (0.10.1)](#5-compresión-0101)
- [6. Compuertas del cierre](#6-compuertas-del-cierre)
- [7. Limpieza (§E.6)](#7-limpieza-e6)
- [8. Pendientes reales](#8-pendientes-reales)
- [9. Lo que queda para el PO](#9-lo-que-queda-para-el-po)

## 1. Resultado

- La guía está completa: Partes 0 a VI, Cierre y Anexos A a G. Tiene 229 encabezados, 282 anclas explícitas, 23 diagramas mermaid, 57 bloques de código copiados de archivos reales, 175 referencias citadas y 53 preguntas guía.
- La relectura de la mesa la dio por **aprobada con una condición**: aplicar los parches S1 y los S2 de seguridad antes de publicar. Esos parches entraron en la versión 0.10.0, así que la condición está cumplida.
- Todas las compuertas AC-1 a AC-11 cumplen sobre la guía escrita y sobre lo construido (§6). AC-3a con modelo no se volvió a correr, porque la redacción no usa el modelo. Su estado es el de la construcción.
- En el cierre hubo un solo cambio en la guía, y fue mecánico: la fila `EMB_PLAN` de A.12 ahora explica qué hace cada valor según el código (§6, AC-9 y anclas). No entró ni salió ninguna cifra.
- Quedan pendientes de código y de fuentes (§8), que están fuera del alcance de la redacción, y dos decisiones del PO (§9).

## 2. Cómo se redactó: muestra, cuerpo y síntesis

1. **Carta** ([`Redaccion/00-Carta-De-Redaccion.md`](Redaccion/00-Carta-De-Redaccion.md)). Se extrajo del plan v3, del marco N0, de la reedición y de `06-Construccion.md` §8, y no agrega decisiones. Fija lo siguiente:
   - las reglas duras;
   - la plantilla de encabezados;
   - los objetivos de aprendizaje;
   - el criterio de «una casa por pieza»;
   - la tabla de cifras citables (§10);
   - el estilo y las anclas previstas.

   La acompañan [`00-Glosario.md`](Redaccion/00-Glosario.md), [`00-Referencias.md`](Redaccion/00-Referencias.md) (el registro REF) y [`00-Versiones.md`](Redaccion/00-Versiones.md).
2. **Muestra** (§5, `secciones/05.md`). Se redactó primero y pasó por tres lecturas: didáctica, editorial y técnica .NET. La presidencia contrastó cada hallazgo con el plan, el código y los registros ([`Redaccion/01-Muestra-Decisiones.md`](Redaccion/01-Muestra-Decisiones.md)):
   - Tomó 24 decisiones sobre la carta y 27 sobre la sección.
   - Descartó o ajustó 9 propuestas, cada una con su motivo.
   - Las reglas que salieron de la muestra pasaron a la carta §16 y rigen sobre las anteriores. Por ejemplo: el agrupador «Práctica de §N», los topes por sección y por bloque, la ficha de cada ejemplo, los snippets de unas 25 líneas y los rótulos de las salidas.
   - Estado final de §5: 3.191 palabras sobre un tope de 3.200, y 10 snippets textuales.
3. **Cuerpo**. Cada sección se redactó en su propio archivo de [`Redaccion/secciones/`](Redaccion/secciones/): 00 a 15, A, B, E y G. Los Anexos C, D y F salen del glosario, del registro REF y del registro de versiones. Lo que no tenía respaldo quedó como comentario PENDIENTES, sección por sección, y se consolidó en [`Redaccion/02-Pendientes-De-Redaccion.md`](Redaccion/02-Pendientes-De-Redaccion.md).
4. **Síntesis (ensamblado del 2026-10-27)**. Las secciones se ensamblaron en el archivo de la guía:
   - Se quitaron los comentarios PENDIENTES y la trazabilidad interna del Anexo C y del Anexo F.
   - Los títulos repetidos de la plantilla llevan «de §N».
   - El índice general es §0.0.
   - La verificación mecánica dio cero en todo: 175 de 175 REF y 93 rutas.
   - Los 23 mermaid se renderizaron sin error.
   - Se publicaron 66 entradas del Anexo D como «sin título registrado».
   - Extensión con la regla del plan: 50.106 palabras sobre un tope de 44.330. La Parte 0 y los Anexos pasaban el disparador del 15 %, y el ensamblado no los recortó: los dejó para la relectura.

   Desde el ensamblado, **la fuente es el archivo de la guía**. `secciones/` no se resincronizó.

## 3. Relectura integral de la mesa

Acta: [`Redaccion/03-Relectura-Mesa.md`](Redaccion/03-Relectura-Mesa.md).

**Perfiles.** Nueve informes: didáctica, edición, .NET, IA, arquitectura, desarrollo, seguridad, evaluación y cohesión. Ninguno editó archivos. Los consolidó un jurado de cinco criterios:

- evidencia;
- impacto;
- costo-beneficio;
- coherencia con el plan, AC-9, I-06 y la plantilla;
- riesgo.

Antes de votar, el jurado comprobó en el código o en los registros los S1 y todo hallazgo que cambiaba una afirmación de seguridad.

**Hallazgos por severidad.**

| | S1 | S2 | S3 | S4 | Total |
|---|---|---|---|---|---|
| Informados por los nueve perfiles | 4 | 32 | 53 | 30 | 119 |
| Filas consolidadas por el jurado | 3 | 25 | 48 | 17 | 93 + 5 compresiones = 98 |

**Aplicados y descartados.**

- De las 98 filas, 88 se aplicaron completas y 10 en parte, con la parte omitida y su motivo.
- Se descartaron además 17 propuestas parciales, cada una con su motivo (acta §5). El acta dice 16 en su §3. El recuento de la tabla de §5 da 17.
- Hubo votos con disidencia o abstención en 15 filas.
- Se recalificaron cuatro severidades:
  - H-02 bajó de S1 a S2.
  - H-07 bajó de S2 a S3.
  - H-28 bajó de S2 a S3.
  - H-05 quedó en S2.

**Auditoría de homogeneidad.** Los nueve veredictos fueron idénticos: «aprobado con observaciones». El jurado no aceptó esa unanimidad, porque tres perfiles informaban S1 y aun así aprobaban. Su veredicto fue **aprobada con una condición**: no se publica sin los parches de H-01, H-03 y H-04 (S1) y de H-08 a H-12 (S2 de seguridad).

El jurado sí dio por justificadas dos coincidencias:

- La de los barridos mecánicos: al menos tres perfiles corrieron por separado RD-PO, R-PRIV, REF, anclas y snippets, con resultados binarios y reproducibles.
- La de los hallazgos textuales repetidos: cinco perfiles marcaron el ítem 12 y cinco la remisión de §10.5 a §7.5. El jurado los comprobó.

Donde los perfiles discreparon en la severidad, el jurado fijó una sola.

## 4. Pasada de parches (0.10.0)

Todos los parches del acta §6 se aplicaron. Cada uno tiene su línea «Estado» en el acta.

Tres no se aplicaron tal cual porque chocaban con el código, con la evidencia o con otro parche:

- **P-13-7**: la prueba que ejerce `conEscrituras: false` es la segunda de la lista, no la primera.
- **P-05-7**: la tabla de §5.5 se quitó por H-48, así que la fila corregida vive en A.12.
- **P-03-5**: las filas venían en tres celdas y se repartieron en las cuatro columnas de la tabla.

Cuatro tenían una condición que se resolvió de otra forma:

- **P-10-6**: el arnés exige la versión y los digests del Ollama propio.
- **P-E-6**: el comando sale de `tools/verificar.sh`.
- **P-F-1**: `Microsoft.Agents.AI.Abstractions` queda como está.
- **P-D-4**: los literales no se llevaron al cuerpo.

Uno quedó en parte: **P-D-3 (e)**, porque faltan los apellidos de algunos autores.

Cifras nuevas o reubicadas, todas contra §8:

- 17.881,0 ms: la vuelta a frío de la corrida 4 de 05.
- 0/52 y 0/10 de 15: cambió la lectura, no la cifra.
- 4/4 con piso 0,398: la extensión de 08.
- El bloque de costo de 12: es una salida guionada, rotulada como tal.
- p = 0,070: un cálculo, rotulado como tal.

## 5. Compresión (0.10.1)

Pedido del PO: «hacer las correcciones pertinentes en edición y compresión ajustando su coherencia». La versión previa quedó en [`Redaccion/guia-pre-compresion.md`](Redaccion/guia-pre-compresion.md).

**Palabras antes y después**, medidas en el cierre sobre los dos archivos. «Prosa» es el texto fuera de los bloques de código.

| Medida | Antes (pre-compresión) | Después (0.10.1, en el cierre) | Diferencia |
|---|---|---|---|
| `wc -w` del archivo | 67.089 | 66.458 | −631 |
| Prosa | 58.928 | 58.296 | −632 |
| Código | 7.885 | 7.886 | +1 |
| Parte 0 (prosa) | 2.399 | 2.395 | −4 |
| Cierre y Anexos (prosa) | 19.178 | 18.951 | −227 |

La cifra «después» incluye las 26 palabras que sumó la fila `EMB_PLAN` en el cierre. El registro anterior de esta bitácora daba 66.338 palabras: es una medición previa a los últimos retoques de las 19:43. La de esta tabla es la vigente.

La regla de conteo del plan no se pudo volver a aplicar con un comando único, porque `tools/contar.sh` no existe (§8). El jurado la había aplicado en la relectura: Parte 0 1.860 sobre un tope de 1.400, Anexos 12.277 sobre 7.430 y total 49.991 sobre 44.330.

Por qué los topes se siguen pasando, según la regla del plan §C:

- En la Parte 0, la tabla de los objetivos de aprendizaje ocupa casi la mitad del tope.
- En los Anexos, el Anexo D crece con cada fuente y E.3 ahora deja correr al lector con su propio Ollama.
- Los parches de corrección y de seguridad hicieron crecer la guía más de lo que la compresión pudo recortar.

**Qué se comprimió.**

- Compresiones H-45 a H-49:
  - la cita de REF-117 vive sólo en §8.1;
  - las latencias, en §5.7;
  - `tool_choice`, en §5.6;
  - la regla pareada, en §10.4;
  - la agencia excesiva, en §11.3;
  - «70 pruebas», en §14.5;
  - el ejemplo 13 completo aparece una sola vez;
  - los descriptores de REF-164 y REF-192 a REF-201 son cortos.
- Casas únicas nuevas, con remisión desde los demás lugares:
  - el escalón de agencia, en §8.1;
  - la cadencia de MAF, en §9.8;
  - `CS0534` y `BindExecutor`, en §8.6;
  - lo que anuncia el servidor MCP, en §8.9;
  - Secret Manager, en §11.6;
  - el humo de PD-6, en §14.3;
  - los ejemplos con piezas bajo `Application/`, en E.1;
  - la regla pareada aplicada a 06;
  - la lectura del LLM juez;
  - AutoGen y `Microsoft.Graph`;
  - el «—» de las tablas, en §0.4.
- Prosa acortada sin quitar contenido, en unos veinte lugares.

**Coherencia.**

- §0.3 ya no promete explicar el circuito de Blazor Server.
- §9.3 se alineó con H-17: quién fija el camino.
- La pregunta guía de §5 remite a §5.3.
- Se unificaron «LLM juez» y «caché de prefijo».

**Lo que se conservó**: las 53 preguntas guía, los bloques de código y de salida, las anclas y el índice de §0.0.

## 6. Compuertas del cierre

Logs en [`Evidencia/Cierre-Redaccion/`](Evidencia/Cierre-Redaccion/). Los comandos son los del saneamiento ([`Evidencia/Cierre-Construccion/`](Evidencia/Cierre-Construccion/), `*.saneo.log`).

El build y las pruebas se corrieron el 2026-10-27, entre las 19:45 y las 19:53, con el turno `build` del gestor. Ningún archivo de `Examples/`, `Demos/`, `tools/` ni `Compuertas/` cambió después, porque la búsqueda de archivos modificados desde las 19:45 sale vacía. Por eso esos logs siguen valiendo y no se volvió a pedir el turno. La guía no se compila.

| Compuerta | Estado | Log | Detalle |
|---|---|---|---|
| AC-1 build `-warnaserror`, sin `NoWarn` | cumple | `verificar-build.redac.log` | SDK 10.0.403; 0 advertencias y 0 errores en `Examples/`; demo en `demo-pruebas.redac.log` |
| AC-2 `Cableado/` sin servidor de modelos | cumple | `verificar-build.redac.log`, `demo-pruebas.redac.log` | 18 proyectos de prueba de `Examples/`: 443 de 443. Demo: 70 de 70 |
| AC-3a con modelo | no re-corrida | — | La redacción no corre el modelo. Rige el estado de `06-Construccion.md` |
| AC-3b registros válidos y recalculables | cumple | `compuertas.redac.log` | `R-LLM/`: 365 de 365 entradas coinciden. `Sondas/`: 4 de 4. `truncado_posible` en `true`: 0 en todos los registros con modelo |
| AC-4 escrituras con aprobación | cumple | `demo-pruebas.redac.log` | Pasan `PedidoDeAprobacion_MuestraArgumentosResueltos`, `Aprobacion_ArgumentosAlterados_SeRechaza`, `Escritura_ConResultadoNoConfiable_PideAprobacion` y `Escritura_NoAprobable_ConResultadoNoConfiable_Rechaza` |
| AC-5 dependencias por capa | cumple | `compuertas.redac.log`, `demo-pruebas.redac.log` | `diff-dominio` da archivos idénticos. Las cuatro búsquedas dan rc 1, sin coincidencias. Pasan `Domain_SinDependenciasDeIa`, `Application_SinInfrastructureNiSdk` y `Herramientas_SinRepositorios` |
| AC-6 versiones por familia | cumple | `verificar-build.redac.log`, `demo-pruebas.redac.log` | `Examples/`: una versión por familia, con la única preview exceptuada (`Azure.AI.OpenAI` 2.9.0-beta.1). Demo: sin previews |
| AC-7 R-PRIV | cumple | `compuertas.redac.log` | Sobre la guía, `Examples`, `Demos`, `tools` y `Compuertas`, y sobre toda la bitácora con sus registros: 0 coincidencias. La autoprueba marca 17 de 17. Se corrió después del último archivo escrito |
| AC-8 RD-PO-4 | cumple | `compuertas.redac.log` | 0 coincidencias fuera de las excepciones en la guía y lo construido, en la Evidencia y en la bitácora. Las autopruebas dan 0 negativos, 5 de 5 positivos y la lista 11 de 11. Los valores de las listas no se escriben en el repo |
| AC-9 bloques de código | cumple | `ac9-bloques.redac.log` | 57 bloques con ruta, 0 diferencias con su archivo |
| AC-9 cifras | cumple | `ac9-cifras.redac.log` | Las cifras que no figuran literalmente en §8 o en la carta §10 están clasificadas: mediciones de §8 con otra forma (las de 05 comparadas con el registro, 14 de 14), valores de fuentes con su REF, umbrales y cálculos rotulados, datos de configuración y DOI del Anexo D. Los IC95 se recalcularon con `tools/verificar.sh tasa` |
| AC-10 delta frente a `8fb4c3a` | cumple | `compuertas.redac.log` | 17 archivos distintos y 54 nuevos, todos en la tabla de delta |
| AC-11 humo del host | cumple | `demo-pruebas.redac.log` | Pasan `Host_Humo_EstilosYEstados` y `Host_CookieSoloEnDocumentos` |
| Anclas, REF y rutas | cumple, con 2 excepciones explicadas | `guia-anclas-ref-mermaid.redac.log` | 0 anclas rotas; 175 REF definidas, todas citadas; 95 rutas verificadas. Excepciones: `Examples/registros/`, el directorio que crea el arnés, y los valores literales de `EMB_PLAN` |
| Mermaid | cumple | `mermaid-render.redac.log`, `guia-anclas-ref-mermaid.redac.log` | 23 de 23 renderizados sin error con mermaid-cli. Los 23 son idénticos, byte a byte, a los de la guía final. GitHub puede usar otra versión de mermaid: no se comprobó |

Correcciones mecánicas del cierre:

1. **A.12, fila `EMB_PLAN`.** La compuerta de ID internos marcaba los valores sin explicar. Se agregó que `EMB-A` y `EMB-B` usan el modelo de `OLLAMA_EMBED_ENDPOINT` y que el código los trata igual, según `06/Program.cs`, `07/Program.cs` y `DependencyInjection.cs` de la demo.
2. **Esta bitácora.** La versión anterior nombraba en una línea el dominio que I-06 excluye, y AC-8 la marcaba fuera de las excepciones. Se reescribió sin nombrarlo.

## 7. Limpieza (§E.6)

Log: [`Evidencia/Cierre-Redaccion/limpieza.redac.log`](Evidencia/Cierre-Redaccion/limpieza.redac.log).

- **Contenedores**: este host no tiene ninguno con la etiqueta `<etiqueta-del-arnés>` ni con «<prefijo-del-laboratorio>» en el nombre. Los contenedores del SDK y de mermaid corrieron con `--rm`. El Ollama propio es un recurso del gestor que corre en otra máquina. No se tocó.
- **Lo que creó la redacción fuera de los repositorios**: el `RLLM_DIR` crudo del build y de las pruebas del cierre, 199 archivos y 2,1 MB, todos de corridas con guion o con el generador estable, sin modelo. Su `turnos.jsonl` se conservó como `Evidencia/Cierre-Redaccion/turnos.redac.jsonl`. El resto se borró.
- **Scratchpad de la sesión**: se borraron todos los intermedios: borradores de secciones, copias previas de la guía, scripts de verificación y descargas de fuentes. Los scripts de compuertas se borraron después de la última corrida.
- **Volúmenes**: quedan `<volumen-artefactos>`, `<volumen-artefactos-demo>`, `<volumen-nuget>`, `<volumen-nuget-n3>` y `<ollama-n3>`. Ninguno lo creó la redacción: son del 25 y del 27 a la mañana. Borrar un volumen es irreversible, y §E.6 lo deja para el cierre del proyecto, después de verificar la evidencia. Queda pendiente (§8).
- **Árbol de la guía**: sin `bin/`, `obj/`, `registros/` ni `datos/`.

## 8. Pendientes reales

Están fuera del alcance de escritura de la redacción. Ninguno cambia una cifra citada.

1. **Código y README.**
   - Retirar de `Examples/Directory.Packages.props` los tres `PackageVersion` sin uso. F.1 ya los declara sin uso.
   - Alinear `Examples/15-Pruebas-Y-Evaluacion/README.md` con el comando del ítem 12 de §15.
   - En 13, que las escrituras permitidas usen también la descripción del cliente (§8.9, §11.5).
   - Agregar la quinta regla de arquitectura de ADR-11.
   - Documentar en `Examples/README.md` la corrida contra el modelo fuera del arnés.
   - Los README de 03, 04 y 08 todavía dicen que la extensión no se corrió, aunque sus `ejemplo.json` ya la registran como ejecutada (03, línea 63 del README).
2. **`06-Construccion.md` §8, fila 02.** Dice que «las reglas del dominio la rechazan». La muestra comprobó que ninguna regla la rechazó, y la guía sigue la carta corregida. Esta corrección no se escribe en 06, que es de otra fase.
3. **Anexo D.**
   - 66 entradas siguen «sin título registrado».
   - Faltan apellidos de autores (P-D-3 e).
   - Faltan la vN de arXiv o el año de REF-76 a REF-83 y de REF-158.
   - Falta convalidar REF-193 a REF-201.
   - Falta una fuente para el circuito de Blazor Server (H-28).
   - Ningún dato faltante se completó: hay que consultar cada fuente.
4. **`Microsoft.Agents.AI.Abstractions`.** Confirmar con el registro de restauración si llega sólo como transitivo de `Microsoft.Agents.AI` (F.1).
5. **`tools/contar.sh`.** No existe. Hace falta para que los conteos de extensión usen una sola regla.
6. **Volúmenes de §E.6.** Borrarlos al cierre del proyecto, con la verificación de §E.6.
7. **`Redaccion/secciones/`.** No se resincronizó. La fuente es el archivo de la guía.
8. **Mermaid en GitHub.** El render se comprobó con mermaid-cli, no con la versión que usa GitHub.

## 9. Lo que queda para el PO

1. **Publicar la demo.**
   - `Demos/MovilidadUrbana.Asistente` compila y pasa 70 de 70 pruebas.
   - El plan §F.9 la publica sólo en el loopback del host. Publicarla en un dominio queda fuera del plan y necesita una decisión del PO (`06-Construccion.md` §6).
   - Tampoco hay commit: el commit de base de AC-10 y el de la guía se hacen al publicar, con el ok del PO.
2. **ESC-001.** La pregunta es si se instala un modelo de embeddings (`qwen3-embedding:0.6b`) en el servidor Ollama compartido de la LAN, o si se sigue con un Ollama aparte. Sigue sin respuesta, pero no bloquea:
   - Rige EMB-B, el Ollama propio que provee el gestor, con el que corrieron 06, 07 y PD-2.
   - Si el PO elige instalarlo (EMB-A), el código no cambia: basta con apuntar `OLLAMA_EMBED_ENDPOINT`, de forma explícita, al servidor compartido. Por defecto nunca toma el valor de `OLLAMA_ENDPOINT` (guía §7.1). Las cifras de 06 y 07 valen para el modelo y el servidor con que se midieron, y habría que volver a medirlas.
3. **Cambiar el estado de la guía.** La guía sigue en «en revisión», versión 0.10.1. Pasarla a publicada depende de las dos decisiones anteriores y del commit.

## Pendientes finales (2026-10-28)

Se aplicaron al Anexo D de la guía los datos de la verificación del 2026-10-28, hecha en tres tercios sobre las entradas pendientes. Cada URL respondió HTTP 200 ese día. No se renumeró nada y ningún dato salió de memoria.

**Lo aplicado.**

- **Títulos.** 66 de las 71 entradas con «sin título registrado» (incluidas las de título incompleto) dejaron el `[sin título registrado: …]`. Llevan ahora el título de la página (el H1, o el `<title>` si no había H1 registrado), y lo que la fuente respalda queda entre paréntesis.
- **Fechas de Microsoft Learn.** Se completó `ms.date` y «act.» (`updated_at`). Cambiaron dos datos que ya figuraban:
  - REF-94: act. 2026-10-27, no 2026-07-21.
  - REF-57: suma ms.date 2025-11-21. La act. 2026-10-19 coincide.
- **arXiv.** REF-15, REF-67, REF-76 a REF-84, REF-156, REF-158, REF-165 y REF-166 llevan los autores completos de la fuente, la v1 y la última vN con su fecha, más el lugar de publicación cuando la página lo trae. El encabezado del anexo dice ahora que la fecha de un artículo es la de su v1 y la de su última vN.
- **Convalidadas.** REF-193 a REF-199 y REF-201 coinciden con la fuente: títulos, versiones, etiquetas y commits. Se actualizó la fecha de consulta, y REF-201 suma act. 2026-03-03.
- **Circuito de Blazor Server (H-28).** Se sumaron dos fuentes, con los dos números libres siguientes:
  - REF-202, «ASP.NET Core Blazor hosting models». Tiene la definición del circuito. Se cita en §0.3, en «qué es un circuito de Blazor Server».
  - REF-203, «ASP.NET Core Blazor server-side state management». Dice que el estado del usuario, incluidos los servicios con scope del circuito, vive en el circuito. Se cita en el contexto de ADR-12 (§13.13).

**Lo que sigue sin dato.** Lo que la fuente no trae quedó como estaba. En total, 81 entradas llevan ahora «consultado 2026-10-28».

1. **Sin fecha en la fuente.**
   - REF-03 (los capítulos de PAIR se cargan por JS).
   - REF-51 a REF-56, REF-102 y REF-103 (Ollama). En REF-51 a REF-56, el `dateModified` del JSON-LD es el mismo instante en todas las páginas: es la fecha de compilación del sitio y no se usó.
   - REF-70 (OpenAI), REF-72 (Anthropic), REF-145 (LangSmith Deployment) y REF-168 (OpenTelemetry).
   - REF-174 a REF-176 (Aspire). Sólo figura el banner del sitio, Aspire 13.6.0 del 2026-09-29, y se anotó como tal.
2. **REF-142** (LangGraph, overview). Ningún tercio la consultó: sigue sin título registrado.
3. **Sin título en la fuente.**
   - REF-187 a REF-189: las APIs de NuGet devuelven JSON.
   - REF-200: el primer `.nuspec` no tiene elemento `title`. Las versiones y las dependencias de `SQLitePCLRaw.bundle_e_sqlite3` (2.1.13 y 3.0.3) coinciden con lo citado.
4. **Autores personales.** Faltan apellidos en las entradas «et al.» que no entraron en este reparto, como REF-17 a REF-22 y REF-85, y en REF-115 (P-D-3 e).
   - Para Microsoft Learn sólo hay usuarios de GitHub, así que la entrada queda con la organización.
   - En REF-60 y REF-179 la fuente da sólo un nombre de pila o un usuario, que no se anotó.
5. **Reparto.** Los tres tercios no usaron el mismo criterio: salieron 91, 81 y 84 entradas pendientes. Las superposiciones (REF-92 y REF-93) dieron los mismos datos. El único hueco fue REF-142.

- El verificador de anclas, REF y rutas de la corrida final quedó en `tools/verificar-markdown.py` de la guía, para repetirla.

## Notas de la recuperación (2026-10-29, bloque B-02)

Notas fechadas, sólo agregado: no reescriben nada de lo anterior.

> **2026-10-29 — Recuperación (B-02, paso 2.8; ESTA-17). Tres deudas de §8 que ya estaban cerradas.** (1) y (2) §8.1, último punto: los README de 03, 04 y 08 **ya dicen** que la extensión se corrió contra el modelo el 2026-10-27 (03, línea 63; 04, línea 85; 08, línea 72), y sus `ejemplo.json` la registran como ejecutada; README y manifiesto ya coincidían al cerrar la redacción. (3) §8.2: la fila 02 de `06-Construccion.md` §8 **ya está corregida** (dice que la salida es texto libre y no afirma que una regla del dominio la rechace); la corrección sí estaba escrita en 06. Aparte, el punto de §8.1 «Documentar en `Examples/README.md` la corrida contra el modelo fuera del arnés» lo cerró B-01 de la recuperación (párrafo de E.5).

> **2026-10-29 — Recuperación (B-02, paso 2.8; ESTA-06). Cifra corregida de §6, fila «Anclas, REF y rutas».** Donde dice «95 rutas verificadas» y dos excepciones, el log final y la corrida del 2026-10-28 dan **104 rutas y 5 marcas**, las cinco falsos positivos del extractor (un patrón `Examples/NN-`, el directorio `Examples/registros/` que crea el arnés, dos rutas relativas a la carpeta de la demo y una ruta de llama.cpp dentro de una REF). Desde B-01, `tools/verificar-markdown.py` lee `tools/verificar-markdown.excepciones` y sobre la 0.10.1 da 104 rutas, 5 exceptuadas y 0 marcas.

> **2026-10-29 — Recuperación (B-02, paso 2.8; ESTA-23).** `Redaccion/secciones/` queda como **histórico**: la fuente es la guía (ver `Redaccion/secciones/LEEME.md`). Sus anclas rotas no se arreglan.

> **2026-10-29 — Recuperación (B-02, paso 2.9; REC-06.3, ENTO-15). RV-11 y el caso e5 de 07.** (1) **e5** de `Examples/07-RAG-Con-Citas` es un **estímulo guionado**: la respuesta de N3 E5, tomada de una corrida de `qwen2.5:7b` en el servidor compartido de la LAN, que se retiró el 2026-10-28. No es una medición y no se puede reproducir en las estaciones vigentes, que no tienen ese modelo; se conserva como caso del oráculo. Que el 7b no corra hoy no está medido. El rótulo en el código y en el README de 07 es tarea del bloque B-04. (2) **RV-11** quedó en B′ (juez `qwen2.5:0.5b` en el Ollama propio, misma familia declarada). Ese servidor ya no existe y **ninguna estación vigente tiene un juez de otra familia**: la estación 2 suma `qwen3.5:35b-a3b`, de la misma familia que el 4b. El sesgo sigue declarado y vale con más razón; la re-corrida (B-11, R-15) se lee con M-G del plan: el acuerdo con un juez de la misma familia no es validación.

> **2026-10-29 — Recuperación (B-02, paso 2.10; REC-05 opción A). ESC-001 se cierra «sin objeto», y sale de §9.** La pregunta de §9, punto 2, era si se instalaba `qwen3-embedding:0.6b` en el servidor compartido de la LAN. Ese servidor se retiró el 2026-10-28, y las dos estaciones vigentes ya tienen `qwen3-embedding:0.6b@ac6da0dfba84` (`Sondeo-Entorno.md` §R.3 y §R.7). No queda nada que decidir. EMB-A pasa a leerse «en el mismo servidor del chat» y EMB-B «en un servidor aparte», sin cambiar el código (`OLLAMA_EMBED_ENDPOINT` se pasa explícito); la guía se ajusta en sus bloques. Las cifras de 06, 07 y PD-2 se vuelven a medir en la re-corrida (REC-02). **A §9 le quedan para el PO:** publicar la demo, el commit (AC-10 y la guía) y el paso a «publicada», que se le presentan después de la relectura integral de la recuperación.

> **2026-10-29 — Recuperación (B-13, REC-01). Versión 0.10.1 → 0.11.0, «en revisión».** Encabezado de la guía: `version: 0.11.0`, `status: en revisión`, `last_review: 2026-10-29` (cierre de B-12), y la línea de versión bajo el título reescrita según el plan («Recupera como base la línea de construcción y redacción del 2026-10-27, integra los aportes de la línea paralela del 2026-10-28 y re-mide lo observado en los dos servidores de laboratorio vigentes»). Tamaño por `tools/contar.sh` (no a mano): 58.820 palabras de prosa (133 % del tope de 44.330), `wc -w` 73.299, 5.235 líneas. Resumen por REC (detalle en `Mesa/Recuperacion-2026-10-28/04-Aplicacion.md`, bloques B-00…B-13):
>
> - **REC-01**: este cambio de versión; queda «en revisión» hasta la relectura integral (B-14) y la decisión del PO (B-15, DEU-07).
> - **REC-02**: fase con modelo única (B-11) en las dos estaciones vigentes, con criterios previos fijados por sha256; las cifras entraron en B-12 (0 marcadores pendientes) y lo que no se midió dice «no medido» (cancelación, tope de salida, juez).
> - **REC-05 / REC-06 / REC-07 / REC-08**: papeles EMB-A/B/C, bitácora y sondeo vigentes, renombre atómico a `modelo-compartido`/`modelo-propio` sin defectos en los modos con modelo, carga con 8192.
> - **REC-09 … REC-35**: piezas de código y prosa de B-03…B-10 (lector `estado_cache`, endurecimiento de `LocalidadRules`, limitador de la demo con 10 de 10, caché con sesión y versión, ADR-03/06/09/11/12, Anexos A–G), según la votación del §0.3 del plan; REC-15 B y REC-21 C, como ganaron.
> - **Servidores retirados (M-J)**: toda mención del servidor compartido de la LAN, del «Ollama propio» anterior, del digest `2a654d98e6fb` y de la versión 0.32.0 lleva rótulo de historia, salvo la ficha de REF-73 (versión de la fuente).
