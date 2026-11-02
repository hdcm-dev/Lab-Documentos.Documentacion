---
doc_id: BIT-16-REC2-INV-estado-base
doc_type: inventario
title: Inventario «estado-base»: estado mecánico de la base restaurada (línea de <equipo-principal>)
status: entregado
origin: agent
owner: inventariador «estado-base», mesa de recuperación 2026-10-28
last_review: 2026-10-28
audience: [matriz de unidades, panel de especialistas, jurado, presidencia]
traces: [Bitacoras/06-Construccion.md §1, §2.1, §5, §8; Bitacoras/07-Redaccion.md §6, §8, §9 y «Pendientes finales»; Evidencia/Cierre-Construccion; Evidencia/Cierre-Redaccion]
---

# Inventario «estado-base»

Este inventario mide la base restaurada en <equipo-de-contingencia> con sus propias herramientas: `tools/verificar.sh`, `tools/verificar-markdown.py`, `tools/compuerta-ac7.sh`, `tools/compuerta-ac8.sh`, `tools/diff-dominio.sh`, `tools/recalcular-oraculos.sh`, `Demos/MovilidadUrbana.Asistente/tools/demo.sh` y `tools/diff-base.sh` de la demo.

**Método.**

- La base no se modificó. Se copió entera, sin `bin/` ni `obj/`, a `<trabajo>/estado-base/guia/`, fuera de los repositorios.
- En la copia se hizo una sola adaptación: los volúmenes de intermedios se renombraron a `<volumen-artefactos-eb>` y `<volumen-artefactos-eb-demo>`. Así no chocan con la compilación del inventariador de laboratorio, que corría al mismo tiempo. Los dos volúmenes se borraron al terminar. El volumen `<volumen-nuget>` se compartió, como fija la carta común.
- Las herramientas no tienen rutas de <equipo-principal>. Lo único que hubo que resolver fueron las listas de AC-7 y AC-8, que viven fuera del repo y hoy sólo están en la copia de rescate de <equipo-principal>. Se usaron desde ahí, en sólo lectura (ESTA-21).
- Build y pruebas corrieron con el turno `build` del gestor (`<gestor-de-turnos> build estado-base …`), con `TURNO_CMD` vacío dentro del turno y `RLLM_DIR` fuera del repo:
  - Examples: de 20:32:56 a 20:37:38 (-03).
  - Demo: de 20:37:55 a 20:38:44 (-03).
- No se llamó a ningún modelo. Las consolas corrieron con `--fake` y los tres endpoints apuntaban a un puerto cerrado.
- Después de las corridas, el árbol de la guía en <equipo-de-contingencia> sigue sin `bin/`, `obj/`, `registros/` ni `*.db`.

**Identidad de la base.** `diff -rq` entre la guía de <equipo-de-contingencia> y la copia de rescate de <equipo-principal> no da diferencias. Entre la bitácora de <equipo-de-contingencia> y la de rescate, la única diferencia es esta carpeta `Mesa/Recuperacion-2026-10-28/`. Ningún archivo de `Examples/`, `Demos/`, `tools/` ni `Compuertas/` cambió después del 2026-10-27 a las 19:45, con tres excepciones, todas del 2026-10-28 a las 00:34–00:39:

- los README de 03, 04 y 08;
- `tools/verificar-markdown.py`.

**Evidencia** (copiada a [`evidencia-estado-base/`](evidencia-estado-base/)):

- `verificar-build.estado-base.log`
- `demo-pruebas.estado-base.log`
- `ac3b-rllm.estado-base.log`
- `ac3b-sondas.estado-base.log`
- `compuertas-ac7-ac8-dominio.estado-base.log`
- `compuertas-ac8-evidencia-bitacora.estado-base.log`
- `ac10-diff-base.estado-base.log`
- `anclas-ref-rutas-guia.estado-base.log`
- `anclas-arbol.estado-base.log`

## 1. Resultado de las corridas (n/n por proyecto)

### 1.1 `tools/verificar.sh build` sobre `Examples/`

SDK 10.0.403. `restore`, `build -warnaserror` (22 compilaciones, 0 advertencias y 0 errores) y `test --filter "Category!=LLM"`:

| Proyecto de prueba | Pasan / total |
|---|---|
| 01 ChatYStreaming | 9/9 |
| 02 CambioDeAdaptador | 11/11 |
| 03 SalidaEstructurada | 20/20 |
| 04 Normalizacion-Contra-Catalogo | 124/124 |
| 05 ContextoCompletoConPrefijo | 14/14 |
| 06 EmbeddingsYBusquedaSemantica | 22/22 |
| 07 RagConCitas | 22/22 |
| 08 Primera-Herramienta-Solo-Lectura | 50/50 |
| 09 Caso-De-Uso-Como-Herramienta | 10/10 |
| 10 Workflow-Y-Contraejemplo | 9/9 |
| 11 Agente-Con-Aprobacion | 11/11 |
| 12 Uno-O-Varios-Agentes | 27/27 |
| 13 Servidor-Y-Cliente-MCP | 24/24 |
| 14 Anotaciones-SK-vs-MEAI | 13/13 |
| 15 PruebasYEvaluacion | 25/25 |
| 16 Inyeccion-Indirecta | 15/15 |
| 17 Observabilidad-Y-Pipeline | 14/14 |
| _Comun (Asistente.Comun.Pruebas) | 23/23 |
| **Total (18 proyectos)** | **443/443**, 0 fallidas, 0 saltadas |

Además:

- Las 18 consolas (01 a 17 y `_Comun/Humo`) corrieron con `--fake --verificar` y salieron sin falla, porque el script corre con `sh -e`. Los «falla» que aparecen en la salida son veredictos guionados del propio ejemplo, como el par p01 de 05 o los r04, r10 y r11 de 06. No son fallas del arnés.
- AC-6: «familias en una sola versión; previews sólo las de Compuertas/ac6.excepciones: Azure.AI.OpenAI 2.9.0-beta.1». rc 0.

Es la misma cifra que `verificar-build.redac.log` (443 de 443).

### 1.2 `Demos/MovilidadUrbana.Asistente/tools/demo.sh pruebas`

- `build -warnaserror`: 0 advertencias y 0 errores.
- Pruebas: **70/70**.
- AC-6 de la demo: «familias en una sola versión, sin previews». rc 0.

Pasan las pruebas que sostienen otras compuertas:

- AC-4: `PedidoDeAprobacion_MuestraArgumentosResueltos`, `Aprobacion_ArgumentosAlterados_SeRechaza`, `Escritura_ConResultadoNoConfiable_PideAprobacion` y `Escritura_NoAprobable_ConResultadoNoConfiable_Rechaza`.
- AC-5: `Domain_SinDependenciasDeIa`, `Application_SinInfrastructureNiSdk`, `Herramientas_SinRepositorios` y `Herramientas_SinParametrosDeDi`.
- AC-11: `Host_Humo_EstilosYEstados` y `Host_CookieSoloEnDocumentos`.

### 1.3 Compuertas de texto y de estructura

| Compuerta | Resultado hoy | Igual al cierre de <equipo-principal> |
|---|---|---|
| AC-3b `recalcular-oraculos.sh` | 50 registros de `Evidencia/R-LLM/`, uno por uno, todos coinciden; agregado «365 de 365», rc 0. `Sondas/`, con `tools/oraculos` y `Sondas/oraculos` juntados en una copia: DEP-03 1/1, DEP-09 1/1, DEP-13 2/2. `truncado_posible` en las llamadas: 469 `false`, 90 `null`, 0 `true` | sí |
| AC-5 `diff-dominio.sh` | «idénticos», rc 0 | sí |
| AC-7 (guía, Examples, Demos, tools, Compuertas) | 0 coincidencias; autoprueba 17/17; rc 0 | sí |
| AC-7 (toda la bitácora) | 0 coincidencias; 97 registros revisados; rc 0 | sí |
| AC-8 (guía y lo construido) | 0 fuera de excepciones (7 exceptuadas); autopruebas 0 negativos, 5/5 positivos, lista 11/11 | sí |
| AC-8 (Evidencia, con las excepciones de la guía) | 0 fuera de excepciones (2 exceptuadas) | sí |
| AC-8 (bitácora sin Evidencia ni esta carpeta, con `Bitacoras/Compuertas/rd-po-4.excepciones`) | 0 fuera de excepciones (58 exceptuadas). El script del cierre se borró; se usó `compuerta-ac8.sh` con `GUIA` y `CMP` sustituidos en una copia | sí: 58 + 2 de Evidencia = las 60 del cierre |
| AC-10 `diff-base.sh` contra `8fb4c3a` | 27 iguales, 17 distintos, 54 nuevos, 0 quitados; «todo cambio figura en la tabla de delta», rc 0 | sí |
| Anclas, REF y rutas (`verificar-markdown.py guia`) | 229 encabezados, 282 anclas, 1.565 enlaces internos, **0 anclas rotas**; REF 177 definidas, las 177 citadas; 104 rutas, 5 «inexistentes» (ESTA-06); rc 1 por esas 5 | sí (log `guia-anclas-ref-rutas.final.log`, idéntico) |
| Anclas de `Examples/`, `Demos/`, `tools/` y `Compuertas/` (.md) | 19 archivos, 0 marcas | sí |
| AC-9 bloques | sin herramienta en la base (ESTA-07). Recomprobación aproximada: 0 diferencias reales | — |
| Mermaid | no se volvió a renderizar: sin herramienta en la base (ESTA-08) | — |

**Lectura.** En el plano mecánico, la base está sana y es reproducible en <equipo-de-contingencia>: todo lo que corre sin modelo da hoy lo mismo que dio en <equipo-principal>. Las unidades de abajo son la deuda declarada que sigue abierta y los puntos donde el entorno nuevo rompe algo.

## 2. Deudas declaradas: estado hoy

| Deuda (fuente) | Estado hoy | Unidad |
|---|---|---|
| Pieza 08 rechazada por un S2 en el oráculo (06 §1, §5.1) | **Cerrada.** P1-08 la corrigió y se volvió a verificar. Hoy, 08 da 50/50 y sus registros recalculan (6/8 en la extensión, con las dos fallas leídas como falsos positivos del oráculo) | ESTA-09 |
| AC-6, OpenTelemetry en dos versiones (06 §2.2) | **Cerrada.** `OpenTelemetry.Api` está fijado en 1.20.1 y hoy rinde una versión por familia. El beta de SK queda con una excepción escrita. Residuos menores | ESTA-10 |
| AC-3b: sondas sin correr y extensiones (06 §2.2) | **Cerrada.** 365/365 y 4/4 hoy. Residuos de configuración | ESTA-11 |
| `estado` de la extensión en `ejemplo.json` de 03, 04 y 08 (06 §5) | **Cerrada.** Los tres dicen «ejecutado…» | ESTA-17 |
| README de 03, 04 y 08: «la extensión no se corrió» (07 §8.1) | **Cerrada** el 2026-10-28 a las 00:34. 07 §8 la sigue listando como abierta | ESTA-17 |
| Tres `PackageVersion` sin uso (07 §8.1) | abierta | ESTA-12 |
| README de 15 frente al ítem 12 de §15 (07 §8.1, H-05) | abierta | ESTA-13 |
| 13: las escrituras no se comparan con la descripción del cliente (07 §8.1) | abierta | ESTA-14 |
| Quinta regla de arquitectura de ADR-11 (07 §8.1) | abierta | ESTA-15 |
| `Examples/README.md`: corrida con modelo fuera del arnés (07 §8.1) | abierta | ESTA-16 |
| Fila 02 de 06 §8 (07 §8.2) | 06 ya tiene la corrección anotada, aunque 07 dice que no se escribe ahí | ESTA-17 |
| Anexo D (07 §8.3 y «Pendientes finales») | parcial | ESTA-19 |
| `Microsoft.Agents.AI.Abstractions` como transitivo (07 §8.4) | abierta: no se miró el registro de restauración | ESTA-12 |
| `tools/contar.sh` y los topes de extensión (07 §8.5) | abierta | ESTA-20 |
| Volúmenes de §E.6 (07 §8.6) | cambió con el entorno | ESTA-25 |
| `Redaccion/secciones/` sin resincronizar (07 §8.7) | abierta | ESTA-23 |
| Mermaid en GitHub (07 §8.8) | abierta | ESTA-08 |
| Decisiones del PO: demo, ESC-001 y estado (07 §9) | abiertas; ESC-001 cambió de premisa | ESTA-24 |
| 05 `--orden calentamiento`; medidor; `--no-build` (06 §5) | abiertas, menores | ESTA-26 |

## 3. Unidades

### ESTA-01 Build y pruebas sin modelo de Examples (S4)

- **Hoy:** 18 proyectos, 443/443, 0 advertencias, 18 consolas en verde y AC-6 cumple (§1.1).
- **Juicio:** la base compila y prueba en <equipo-de-contingencia> igual que en <equipo-principal>.
- **Acción:** mantener. Usar esta corrida como línea de partida del plan de integración. Después de cualquier fusión, volver a correr `verificar.sh build`.

### ESTA-02 Build y pruebas sin modelo de la demo (S4)

- **Hoy:** 70/70, sin previews. AC-4, AC-5 y AC-11 se sostienen en sus pruebas (§1.2).
- **Acción:** mantener. Repetir después de la integración.

### ESTA-03 AC-3b: registros recalculables (S4)

- **Hoy:** 365/365 en `R-LLM/` y 4/4 en `Sondas/`, sin truncado.
- **Juicio:** que se puedan recalcular demuestra la integridad del registro, no que las cifras valgan en el entorno vigente: todas se midieron contra servidores que ya no existen (ESTA-22).
- **Acción:** conservar la Evidencia como histórica. Las corridas nuevas en las estaciones vigentes van en registros aparte, con su rótulo.

### ESTA-04 AC-5 y AC-10 (S4)

- **Hoy:** el Domain de `_Comun` y el de la demo son idénticos. El delta contra `8fb4c3a` está completo (17 distintos y 54 nuevos, todos en la tabla).
- **Acción:** mantener. Si la integración trae algo de la demo de <equipo-de-contingencia>, volver a correr `diff-base.sh`.

### ESTA-05 AC-7 y AC-8 con las listas de <equipo-principal> (S4)

- **Hoy:** 0 coincidencias en la guía, en lo construido, en Evidencia y en la bitácora (§1.3).
- **Barrido ad hoc del R-PRIV ampliado** sobre la guía, Examples y Demos de la base, con 0 apariciones de:
  - los nombres de los tres equipos;
  - el usuario;
  - las rutas del directorio personal y del disco de trabajo;
  - el directorio de trabajo del laboratorio;
  - la clave de cabeceras por pedido;
  - `tailnet`;
  - `100.x` como dirección.

  Las únicas apariciones de `127.0.0.1` y `localhost` son loopback genérico: un puerto cerrado de prueba y el loopback de la demo.
- **Acción:** mantener. Ver ESTA-21 para las listas y ESTA-27 para el comentario del propio script.

### ESTA-06 Cinco «rutas inexistentes» en la guía (S4)

- **Hoy:** `verificar-markdown.py` sale con rc 1 por cinco rutas, todas falsos positivos del extractor:
  - `Examples/NN-` es un patrón.
  - `Examples/registros/` es el directorio que crea el arnés.
  - `tools/demo.sh` y `tools/diff-base.sh` son relativas a la carpeta de la demo (líneas 3965, 4482 y 4938).
  - `tools/server/README.md` es la ruta de llama.cpp dentro de REF-75.
- **Inconsistencia:** 07 §6 declara 95 rutas y 2 excepciones. El log final, igual que la corrida de hoy, da 104 rutas y 5 marcas.
- **Acción:** que el verificador acepte un archivo de excepciones (o que la guía escriba esas rutas completas, `Demos/MovilidadUrbana.Asistente/tools/…`). Corregir la cifra de 07 §6 con una nota fechada.

### ESTA-07 AC-9 bloques sin herramienta en la base (S3)

- **Hoy:** el comparador de AC-9 se borró en la limpieza (07 §7). Sólo queda su log (57 bloques, 0 diferencias). AC-9 cifras tampoco tiene herramienta.
- **Recomprobación aproximada de hoy:** script propio, fuera del repo, que toma un bloque precedido por su ruta y lo compara por tramos separados por «// …». Encontró 61 bloques candidatos y 57 coinciden. Los 4 restantes son falsos positivos del método: en tres, la ruta se cita en el párrafo anterior y no como rótulo del bloque (README de Examples dos veces y `PredicadoDeSalto.cs`); en el bloque de 17, el tramo inicial termina en una línea en blanco.
- **Juicio:** no hay divergencias reales entre bloque y archivo, pero la compuerta no se puede repetir con la herramienta de la base. Integrar código va a mover snippets.
- **Acción:** reponer el comparador de AC-9 en `tools/`, como se hizo con `verificar-markdown.py`, y correrlo después de integrar.

### ESTA-08 Mermaid sin re-render (S4)

- **Hoy:** 23 bloques, renderizados sin error en <equipo-principal> con mermaid-cli. Hoy no se renderizaron, porque la base no trae la herramienta. Sigue sin comprobarse el render de GitHub (07 §8.8).
- **Acción:** si la integración toca diagramas, volver a renderizarlos.

### ESTA-09 Pieza 08 (S4)

- **Hoy:** el S2 del oráculo «no-inventa» quedó corregido (P1-08), con el veredicto «aprobado con observaciones». Las pruebas dan 50/50. La extensión, 6/8, con xl04 y xn03 declarados como falsos positivos del oráculo. Quedan los cuatro límites del oráculo documentados.
- **Juicio:** la deuda «08 rechazada» que se le atribuía a la línea de <equipo-principal> es del estado de las 14:01. El saneamiento de las 16:06 la cerró.
- **Acción:** dar la deuda por cerrada. Si se re-mide en una estación vigente, mantener la lectura de las dos fallas del oráculo.

### ESTA-10 AC-6, OpenTelemetry (S4)

- **Hoy:** cerrada, con `OpenTelemetry.Api` 1.20.1 fijado por pinning de transitivos. En la corrida de hoy, cada familia resuelve una sola versión. `Azure.AI.OpenAI` 2.9.0-beta.1 queda como excepción escrita.
- **Residuos (06 §5):**
  - `ac6()` no vacía `$RLLM_DIR/paquetes`;
  - los `Microsoft.Extensions.*` del runtime resuelven en 2 o 3 versiones, fuera del invariante.
- **Acción:** cerrar la deuda. Vaciar `paquetes/` al empezar `ac6()`. El invariante de Microsoft.Extensions.* queda para decidir aparte.

### ESTA-11 AC-3b: residuos del arnés (S3)

- **Hoy, primer residuo:** `recalcular-oraculos.sh` no encuentra solo los oráculos de las sondas, que viven en `Evidencia/Sondas/oraculos/`. Hoy hubo que juntar los dos directorios en una copia.
- **Hoy, segundo residuo:** el arnés pasa `RLLM_UMBRAL_MS_POR_TOKEN` y `RLLM_CARACTERES_POR_TOKEN` por nombre, pero no fija ningún valor. DEP-03 los calibró en ≈ 1,7 y 2,33 contra el servidor que ya no existe.
- **Acción:**
  - Aceptar un segundo directorio de oráculos, por variable o por argumento.
  - Volver a calibrar DEP-03 en la estación vigente antes de fijar los umbrales.

### ESTA-12 `PackageVersion` sin uso (S4)

- **Hoy:** `Microsoft.Extensions.Hosting` 10.0.14, `OpenTelemetry.Extensions.Hosting` 1.20.1 y `OpenTelemetry.Exporter.OpenTelemetryProtocol` 1.20.1 siguen en `Examples/Directory.Packages.props`, y ningún `.csproj` los referencia. F.1 (línea 5035) los declara sin uso.
- **Pins legítimos:** otros cuatro `PackageVersion` sin `PackageReference` directo son pins de transitivos, con `CentralPackageTransitivePinningEnabled`: `Microsoft.Extensions.AI.Abstractions`, `Microsoft.Extensions.Compliance.Abstractions`, `OpenTelemetry.Api` y `Microsoft.Agents.AI.Abstractions`. Queda por confirmar el último con el registro de restauración (07 §8.4).
- **Acción:** retirar los tres sin uso, volver a correr el build y AC-6, y cambiar F.1. Cambia `paquetes_hash`: hay que anotarlo.

### ESTA-13 README de 15 frente al ítem 12 (S3)

- **Hoy:** `Examples/15-Pruebas-Y-Evaluacion/README.md:40` sigue indicando `dotnet test --filter …` en el host, sin contenedor. Es lo que H-05 corrigió en la guía.
- **Acción:** alinear el README con el ítem 12, que usa el arnés o el SDK en contenedor.

### ESTA-14 13: escrituras sin comparar con la descripción del cliente (S3)

- **Hoy:** `Garantias.DescripcionDelCliente` (`Examples/13-…/Garantias.cs:92`) compara sólo `PoliticaDeMontaje.DelEjemplo.Lecturas`. Las escrituras permitidas no se comparan con la descripción que ve el cliente.
- **Juicio:** la guía (§8.9, §11.5) lo trata como pendiente. Es un control de seguridad del ejemplo MCP.
- **Acción:** extender la garantía a las escrituras y sumar su prueba.

### ESTA-15 Falta la quinta regla de ADR-11 (S3)

- **Hoy:** la demo tiene cuatro pruebas de arquitectura por reflexión: `Domain_SinDependenciasDeIa`, `Application_SinInfrastructureNiSdk`, `Herramientas_SinRepositorios` y `Herramientas_SinParametrosDeDi`. La quinta regla que ADR-11 anuncia no está.
- **Agregado:** §13.12 (línea 3613) reconoce que ninguna prueba acota a `Chat.razor` la excepción de Presentación a Infrastructure/AI.
- **Acción:** agregar la prueba, o sacar de ADR-11 la promesa de la quinta regla.

### ESTA-16 `Examples/README.md` sin corrida con modelo fuera del arnés (S4)

- **Hoy:** el README documenta el `docker run` manual sólo con `--fake` (líneas 39–43). La guía E.5 ya explica cómo correrlo sin `--fake`, pasando las variables por nombre.
- **Acción:** llevar ese párrafo de E.5 al README.

### ESTA-17 Bitácora 07 §8 desactualizada (S4)

- **Hoy:**
  - Los README de 03, 04 y 08 ya dicen «se corrió contra el modelo el 2026-10-27» (línea 63 de 03, 85 de 04 y 72 de 08), y sus `ejemplo.json` dicen «ejecutado…». Aun así, 07 §8.1 los lista como pendientes.
  - 07 §8.2 dice que la corrección de la fila 02 «no se escribe en 06», pero 06 §8 ya la tiene anotada («Corrección 2026-10-28»).
- **Acción:** agregar a 07 una nota fechada que dé esos tres puntos por cerrados, sólo como agregado.

### ESTA-18 Estado de la guía y de los conteos (S4)

- **Hoy:** encabezado 0.10.1, «en revisión», `last_review` 2026-10-27. La guía tiene 5.128 líneas y 177 REF, definidas y citadas. Quedan 5 entradas «sin título registrado»:
  - REF-142, que no se consultó;
  - REF-187 a REF-189 y REF-200, cuya fuente no tiene título.
- **Acción:** mantener el estado hasta la integración y las decisiones del PO (ESTA-24). Subir la versión al integrar.

### ESTA-19 Anexo D (S4)

- **Hoy:** quedan pendientes:
  - REF-142, sin título;
  - los apellidos de las entradas «et al.» no repartidas (REF-17 a REF-22, REF-85 y REF-115);
  - las fechas que la fuente no da, como Ollama, Aspire, OpenAI y Anthropic.
- **Acción:** consultar REF-142 y los autores que falten. Lo que la fuente no trae queda como está, sin datos de memoria.

### ESTA-20 Sin `tools/contar.sh` y con los topes de extensión pasados (S3)

- **Hoy:** el script no existe. La última medición del jurado:

  | Medida | Palabras | Tope |
  |---|---|---|
  | Parte 0 | 1.860 | 1.400 |
  | Anexos | 12.277 | 7.430 |
  | Total | 49.991 | 44.330 |

  Con `wc -w`, la guía da 66.827 palabras.
- **Juicio:** fusionar aportes de <equipo-de-contingencia> la va a hacer crecer. Sin una regla de conteo única, la compresión no se puede controlar.
- **Acción:** escribir `tools/contar.sh` con la regla del plan §C antes de integrar contenido, y medir antes y después.

### ESTA-21 Las listas de AC-7 y AC-8 sólo están en la copia de rescate (S3)

- **Hoy:** `r-priv.lista`, `rd-po.lista` y sus `.positivos` están sólo en el directorio de trabajo copiado del equipo principal (en el rescate, fuera del repo). En <equipo-de-contingencia> no hay otra copia. Sin ellas, las dos compuertas fallan cerradas.
- **Cobertura:** la lista de R-PRIV tiene 17 términos, entre ellos los nombres de los tres equipos. No cubre el usuario, la clave de cabeceras por pedido, las rutas del directorio personal y del disco de trabajo ni el directorio de trabajo, que exige el R-PRIV ampliado de esta mesa. Hoy no aparecen en la base (ESTA-05), pero la compuerta no los vigila.
- **Acción:** mudar las listas a una ubicación de <equipo-de-contingencia> fuera del repo y ampliarlas con los términos del R-PRIV ampliado, con sus positivos. Después, volver a correr AC-7.

### ESTA-22 Cifras de la guía medidas en servidores que ya no existen (S2)

- **Hoy:** 38 bloques «Observado». De ellos:
  - 29 se rotulan «servidor compartido, 2026-10-2x»;
  - 17 menciones de «Ollama 0.32.0-rc0», la versión del servidor de la LAN;
  - 6 se rotulan «Ollama propio, 2026-10-2x», con Ollama 0.40.11.

  Las 17 consolas corrieron contra esos dos servidores. El de la LAN ya no existe y el «propio» ya no es recurso del gestor. Según el inventario «entorno», el `qwen3.5:4b` de la estación 1 tiene otro digest.
- **Juicio:** los rótulos de las cifras son correctos y fechados, pero no dicen que el servidor ya no existe. La regla del PO pide re-correr en una estación vigente o rotular. Ninguna cifra es falsa, pero un lector no las puede reproducir con el servidor que nombran.
- **Acción:** en la fase con modelo, re-correr las piezas con cifra citada en una estación vigente, empezando por las de tasa: 03, 04 y 08 (extensiones), 06, 07, 15 y 16. Lo que no se re-corra se rotula «medido en un servidor de laboratorio retirado, 2026-10-27; histórico». Cada cifra nueva lleva su registro propio.

### ESTA-23 `Redaccion/secciones/` y acta con anclas rotas (S4)

- **Hoy:** sobre toda la bitácora, `verificar-markdown.py arbol` da 1.294 marcas. Casi todas son anclas de la guía citadas desde `Redaccion/secciones/*.md`, que no se resincronizó, y desde `Redaccion/03-Relectura-Mesa.md` (87). Además hay 2 enlaces relativos de `guia-pre-compresion.md`. Ninguna está en la guía.
- **Acción:** dejar `secciones/` como histórico, con una línea que diga que la fuente es la guía. No vale la pena arreglar sus anclas.

### ESTA-24 Decisiones pendientes del PO (07 §9) (S3)

- **Hoy:** siguen abiertas:
  - publicar la demo;
  - hacer el commit (AC-10 y la guía);
  - pasar la guía a «publicada».
- **ESC-001 cambió de premisa.** Preguntaba si instalar `qwen3-embedding:0.6b` en el servidor compartido de la LAN, que ya no existe. Según la carta común, la estación 1 ya trae `qwen3-embedding:0.6b`. Rige EMB-B, el Ollama propio, que tampoco existe como recurso. En la práctica, la pregunta pasa a ser qué estación sirve los embeddings.
- **Acción:** reformular ESC-001 sobre las estaciones vigentes. No cambia el código: `OLLAMA_EMBED_ENDPOINT` se pasa explícito. Hay que volver a medir 06 y 07. El resto sigue con el PO, después de la integración.

### ESTA-25 El arnés atado a los recursos y digests del entorno viejo (S2)

- **Hoy:** `tools/verificar.sh` fija `OLLAMA_VERSION_PROPIO=0.40.11`, `DIGEST_CHAT_PROPIO=a8b0c5157701` y `DIGEST_EMBED_PROPIO=ac6da0dfba84`, y si no coinciden, aborta la fase del Ollama propio. Los manifiestos piden estos recursos:
  - `[recurso-modelo-propio]`: 02, 05 y 06 (fase 3a) y 15 (fase 3b);
  - `<recurso-compartido>`: once ejemplos y la demo.

  El gestor de <equipo-de-contingencia> tiene `<recurso-compartido>` (estación 1) y `<recurso-estación-2>` (estación 2), pero no `[recurso-modelo-propio]`.
- **Volúmenes:** de los de §E.6, <equipo-de-contingencia> tiene sólo `<volumen-nuget>` e `<[recurso-modelo-propio]>`. `<volumen-artefactos>` lo vuelve a crear el arnés.
- **Juicio:** sin un mapeo, `verificar.sh fase 3a|3b` y `demo.sh embeddings` no corren en <equipo-de-contingencia>. Los digests valen para la estación 1 sólo si coinciden: según el inventario «entorno», `qwen2.5:0.5b` y la imagen sí coinciden.
- **Acción:** antes de la fase con modelo:
  - decidir qué estación hace de «propio»;
  - pasar el recurso por variable (`TURNO_CMD` ya admite cualquier nombre) o cambiar los manifiestos con un registro;
  - comprobar los digests en esa estación.

  El endpoint va sólo por variable. Los volúmenes viejos de §E.6 no existen en <equipo-de-contingencia>: no hay nada que borrar acá.

### ESTA-26 Deuda menor del arnés y de 05 (S4)

- **Hoy:**
  - 05 conserva la opción `--orden calentamiento`, que no se adoptó, y su README rotula «de 230 a 439 ms» sin decir que es la corrida 1.
  - El medidor tiene cuatro defectos (06 §3.1).
  - La vía con modelo usa `dotnet run --no-build` y necesita un `build` previo, que E.5 documenta.
- **Acción:** dejarlo como está o arreglarlo junto con ESTA-25. No cambia ninguna cifra.

### ESTA-27 El script de AC-7 nombra rangos de IP en el repo público (S3)

- **Hoy:** `tools/compuerta-ac7.sh:6` dice en su comentario «IPs privadas (10/8, 172.16/12, 192.168/16) y el rango de red superpuesta 100.64/10». El patrón de la línea 35 codifica esos rangos, aunque la autoprueba arma sus direcciones en tiempo de ejecución, justamente para no escribirlas. AC-7 no se marca a sí mismo porque `\b` exige dirección completa.
- **Juicio:** el R-PRIV ampliado de esta mesa prohíbe IPs parciales y rangos `100.x` en el repo público. Son rangos de RFC y no revelan ningún equipo, pero el comentario choca con la letra de la regla.
- **Acción:** reescribir el comentario sin cifras («rangos privados de RFC 1918 y el compartido de RFC 6598») y armar el patrón en tiempo de ejecución, como la autoprueba. Volver a correr AC-7.

## 4. Lo que no se hizo en este inventario

- No se corrió nada contra un modelo.
- No se tocó <equipo-principal> ni `Linea-*-2026-10-28/`.
- No se escribió en la base, salvo esta carpeta.
- Mermaid y AC-9 cifras no se volvieron a correr, porque no tienen herramienta (ESTA-07, ESTA-08).
- No se comparó con el insumo de <equipo-de-contingencia>: eso lo hacen los inventarios de aportes.

**Compuertas sobre este archivo.** Sobre este inventario, AC-7 marca 22 líneas (contando esta nota) y AC-8 marca dos. Son los nombres de los equipos y el de la carpeta `Linea-*-2026-10-28/`, que la mesa necesita para trabajar. Los otros inventarios de esta carpeta tienen las mismas marcas. La bitácora es privada, y el R-PRIV ampliado rige para la guía, `Examples/` y `Demos/`. Si esta carpeta pasa a un lugar donde rija AC-7 sobre toda la bitácora, hay que reescribir esos nombres. Los logs de `evidencia-estado-base/` dan 0 en las dos compuertas.
