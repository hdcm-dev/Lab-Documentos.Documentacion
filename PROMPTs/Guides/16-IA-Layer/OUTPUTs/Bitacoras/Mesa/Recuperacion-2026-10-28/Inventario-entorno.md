---
doc_id: BIT-16-REC2-INV-entorno
doc_type: inventario
title: Inventario «entorno» — dependencias de la base (línea de <equipo-principal>) con un entorno que ya no existe o cambió
status: entregado
origin: agent
owner: inventariador «entorno», mesa de recuperación 2026-10-28
last_review: 2026-10-28
audience: [matriz de unidades, panel de especialistas, jurado, presidencia]
traces: [Bitacoras/Sondeo-Entorno.md (base, §0–§8), Linea-*-2026-10-28/Bitacoras/Sondeo-Entorno.md §R y §R.6–§R.7, Linea-*-2026-10-28/Bitacoras/Mesa/Ciclo-1/Ronda-2/Consulta-<estación-2>-ollama.md, Bitacoras/Mesa/Ciclo-3/08-Cierre.md (ESC-001), Bitacoras/07-Redaccion.md §9, guía 0.10.1, Examples/, Demos/, tools/]
---

# Inventario «entorno»

Sólo lectura sobre la base y sobre el insumo; no se compiló ni se llamó a ningún modelo. Cada número sale de un `grep` o de una lectura hecha hoy sobre los archivos (rutas desde la raíz de la guía `G = /LAB/Lab-Documentos/Lab-Documentos/Guides/IA/Dot-Net-Integration-AI-Layer-Guide/` y de la bitácora `B = /LAB/Lab-Documentos/Lab-Documentos.Documentacion/PROMPTs/Guides/16-IA-Layer/OUTPUTs/Bitacoras/`). Ningún endpoint ni dirección se escribe acá (R-PRIV).

## 0. Qué cambió en el entorno (resumen con evidencia)

| Pieza | En la base (<equipo-principal>, 25–27-10) | Hoy (28-10) | Fuente |
|---|---|---|---|
| Servidor de chat | «servidor Ollama compartido de la LAN», 0.32.0-rc0, sólo CPU, `qwen3.5:4b@2a654d98e6fb`, cargado con `context_length` 65536; sin embeddings (501) | **no existe** | base `Sondeo-Entorno.md` §0–§5; insumo §R (nota de cabecera) |
| «Ollama propio» (recurso `[recurso-modelo-propio]`) | 0.40.11, `qwen2.5:0.5b@a8b0c5157701`, `qwen3-embedding:0.6b@ac6da0dfba84`, «en otra máquina», que compartía CPU con emuladores de otras sesiones | el recurso **no existe** en el gestor vigente (`<gestor-de-turnos> estado [recurso-modelo-propio]` → «recurso desconocido»; válidos: `… <recurso-compartido> … <recurso-estación-2> … build …`) | `Mesa/Ciclo-3/02-Informes/desarrollo.md` §0; corrida de hoy |
| Estación 1 («estación de laboratorio de 4 núcleos», recurso `<recurso-compartido>`) | — | 0.40.11, misma imagen por digest; `qwen3.5:4b@d8b0f5e9760c`, `qwen3.5:2b@0689d44085e0`, `qwen2.5:0.5b@a8b0c5157701`, `qwen3-embedding:0.6b@ac6da0dfba84`; contenedor 4 CPU / 5 GB; carga con `context_length` 4096; `OLLAMA_MAX_LOADED_MODELS=2` | insumo §R.0, §R.1, §R.6 |
| Estación 2 («estación de laboratorio con más núcleos», recurso `<recurso-estación-2>`) | — | 0.40.11, mismos digests + `qwen3.5:35b-a3b@72aac7c28be8`; 14 CPU / 34 GiB; `MAX_LOADED_MODELS=1`, `KEEP_ALIVE=10m`; nunca emuladores ni KVM | insumo Consulta-<estación-2> §0 |

Dos hechos que ordenan casi todas las unidades:

1. **El 4b de la base no es el 4b de hoy.** Digest `2a654d98e6fb` (13 menciones en la guía, todas las corridas «compartido» del R-LLM de la base) frente a `d8b0f5e9760c` en las dos estaciones. Toda observación del 4b de la base es historia de otro artefacto.
2. **El «Ollama propio» de la base coincide en versión y digests con las dos estaciones vigentes** (0.40.11, `a8b0c5157701`, `ac6da0dfba84`). La precondición del arnés (`tools/verificar.sh` l. 52–54) pasa en cualquiera de las dos. Que el Ollama propio de la base fuera físicamente la estación 1 es **probable, no verificado** (en el sondeo de <equipo-de-contingencia> esos dos modelos «ya estaban»).

Recuento de lo rotulado con el servidor viejo (grep de hoy): en la guía, 29 líneas «Observad…» con «compartido» (l. 163, 1012, 1014, 1072, 1201, 1269, 1542, 1546, 1596, 1842, 1866, 1984, 2013, 2068, 2155, 2216, 2311, 2379, 2420, 3167, 3237, 3286, 3383, 3530, 3746, 3918, 4369, 4958, 4966), 18 apariciones de `0.32.0`, 13 de `2a654d98e6fb` y 39 líneas más con «compartido» en sentido de arquitectura o de laboratorio; en `Examples/*/README.md`, 14 README con `0.32.0`, «compartido» o «propio»; en el README de la demo, 8. En la bitácora base: `<recurso-compartido>` 445 apariciones en 107 archivos, `[recurso-modelo-propio]` 312 en 67, `0.32.0-rc0` 234 en 63, `2a654d98e6fb` 184 en 55.

Lo que **no** aparece (comprobado): el directorio de trabajo del laboratorio (por nombre o por variable), el disco de trabajo, los nombres de los tres equipos y direcciones IP en la guía, `Examples/`, `Demos/` y `tools/` (las coincidencias numéricas son versiones de paquetes como `10.11.0`). `qwen2.5:7b` y `gemma4` no aparecen en el cuerpo de la guía.

## 1. Unidades

Severidad: S1 bloquea la re-corrida o contamina evidencia; S2 afirmación de la guía que hoy no se sostiene como estado; S3 texto o herramienta que hay que rotular o ajustar; S4 menor.

### ENTO-01 · S1 · El recurso `[recurso-modelo-propio]` no existe en el gestor vigente

- **Base:** `Examples/{02,05,06,15}/ejemplo.json` y la vía `embeddings` de `07/ejemplo.json` piden `[recurso-modelo-propio]`; `tools/verificar.sh` l. 6 fija el orden global `build → [recurso-modelo-propio] (3a) → <recurso-compartido> → [recurso-modelo-propio] (3b)` y l. 166, 184, 394, 427–429, 472; `Demos/…/tools/demo.sh` l. 163 (`turno [recurso-modelo-propio]`); `Examples/README.md` l. 70, 84, 95, 102; guía E.3 (fases 2 y 4). El adaptador de `TURNO_CMD` (`turno.sh`, «turno.sh <recurso> -- <comando>» → `<gestor-de-turnos>`) existió sólo en el directorio de trabajo de <equipo-principal> (hoy copia en el rescate), no en <equipo-de-contingencia>.
- **<equipo-de-contingencia> / hoy:** `<gestor-de-turnos> estado [recurso-modelo-propio]` → «recurso desconocido». Con `TURNO_CMD` definido, las fases 2 y 4 del arnés y `demo.sh embeddings` mueren antes de llamar.
- **Juicio:** el contrato del arnés es bueno (no conoce el gestor); lo roto es el nombre de recurso del laboratorio. Las dos estaciones pasan la precondición de versión y digests, así que el papel «Ollama propio» se puede cumplir hoy sin tocar código.
- **Acción:** re-correr con un adaptador de `TURNO_CMD` **fuera del repo** que traduzca `[recurso-modelo-propio]` → `<recurso-compartido>` (estación 1) o `<recurso-estación-2>` (estación 2), con `OLLAMA_PROPIO_URL_CMD` que lea el endpoint de la variable o de un archivo del directorio de trabajo, fuera del repo (`{dir-de-trabajo}/…`). Recuperar `turno.sh` del rescate a `{dir-de-trabajo}/`. En el repo, evaluar (matriz) si los nombres de recurso de los `ejemplo.json` pasan a papeles neutros («servidor-chat», «servidor-propio»), porque son etiquetas del laboratorio en un repo público (ver ENTO-08).

### ENTO-02 · S1 · Colisión de nombre `<recurso-compartido>` y rótulo forzado «compartido»

- **Base:** `<recurso-compartido>` = el servidor compartido de la LAN (todos los `ejemplo.json` de chat, `verificar.sh`, `demo.sh humo`, 445 apariciones en la bitácora). `tools/verificar.sh` l. 406 y l. 496/503 exportan en la fase de chat `OLLAMA_SERVIDOR=compartido RLLM_MAQUINA=compartido`; `demo.sh` l. 138 hace lo mismo por defecto.
- **<equipo-de-contingencia> / hoy:** `<recurso-compartido>` es la estación 1, un Ollama propio en contenedor con turno exclusivo (insumo §R, cabecera). El `registro.log` del gestor mezcla las dos acepciones (115 eventos `<recurso-compartido>`).
- **Juicio:** una re-corrida en la estación 1 por el arnés quedaría registrada como `servidor: compartido` y `maquina: compartido`, y la guía la citaría como «servidor compartido». Eso contamina la evidencia sin aviso. El rechazo «compartido sin `num_ctx` del arnés» (`ConfiguracionDelModelo.cs` l. 96–99) sigue siendo un buen control de diseño; lo que no sirve es el rótulo fijo del arnés.
- **Acción:** antes de cualquier re-corrida, que el arnés tome `OLLAMA_SERVIDOR` y `RLLM_MAQUINA` del entorno con el valor actual como default (cambio de una línea en l. 406 y l. 496/503, y en `demo.sh` l. 138), y que la presidencia fije el rótulo de las estaciones («propio», máquina «estación-1» / «estación-2», sin nombres de equipo). En la bitácora, nota fechada: «`<recurso-compartido>` hasta el 2026-10-27 = servidor compartido dado de baja; desde el 2026-10-28 = estación 1».

### ENTO-03 · S2 · Observaciones de la guía rotuladas con el servidor compartido (29 líneas)

- **Base:** las 29 líneas de §0 listadas arriba (01, 03, 04, 07, 08, 09, 11, 12, 13, 16, 17, sondas DEP-09/DEP-13 y los humos PD-1/PD-3/PD-6 de la demo), todas `qwen3.5:4b@2a654d98e6fb`, Ollama 0.32.0-rc0, 2026-10-27. Las tasas e IC95 que la guía da como medidas (p. ej. 08: 4 preguntas legítimas, IC95 [0,398; 1], l. 1546; 16: 0/6, IC95 [0; 0,459], l. 3167) salen de ahí.
- **<equipo-de-contingencia>:** no tiene equivalentes de estos ejemplos (su línea tiene 12 ejemplos y otra numeración); sí tiene, para el 4b vigente, las sondas de herramientas de §R.4 y la tabla §R.6.
- **Juicio:** el rótulo de la base es honesto (servidor, versión, fecha), pero describe un servidor y un digest que ya no existen. La regla común pide re-correr en un servidor vigente lo que la guía afirma como medido, o rotularlo. El ahorro grande: todos los prompts de estas corridas son cortos (máximo 805 tokens de prompt en el R-LLM «compartido» de la base, cálculo de hoy), así que entran en la ventana de 4096 de la estación 1 sin truncado.
- **Acción:** re-correr en la estación 1 (o en la 2, con su rótulo) la fase de chat completa (`verificar.sh --con-modelo`, fase 3, más extensiones y estabilidad) y los tres humos de la demo, después de ENTO-01/02/09/10. Lo que no se re-corra: agregar al rótulo «servidor dado de baja el 2026-10-28; historia, no reproducible con ese digest». No mezclar cifras de dos servidores sin columna «servidor».

### ENTO-04 · S2 · README de los ejemplos y de la demo con el servidor viejo

- **Base:** `Examples/01/README.md` l. 48; `03`, `04`, `07`, `08` (l. 61), `09` (l. 94), `11` (l. 98), `12` (l. 71), `13` (l. 101, «turno `<recurso-compartido>` de 111 s»), `16` (l. 97), `17` (l. 69); `15/entradas/salidas-07.v1.json` (salidas congeladas del 07 con `0.32.0` y `<recurso-compartido>`); `Demos/…/README.md` l. 80 («el servidor compartido no tiene modelo de embeddings»).
- **<equipo-de-contingencia>:** sus README describen otro conjunto de ejemplos; no aportan reemplazo directo.
- **Juicio:** mismo caso que ENTO-03, con un matiz: `salidas-07.v1.json` es una entrada congelada (SHA-256 en `15/ejemplo.json`). Cambiarla crea `v2` y obliga a re-correr 15. Conviene **no** tocarla: es un estímulo, y su origen (servidor viejo) se declara.
- **Acción:** re-rotular cada «Observado…» de los README con el resultado de la re-corrida de ENTO-03, o con el sufijo de historia. Para `salidas-07.v1.json`, dejarla como entrada congelada y agregar en el README de 15 una línea: «generadas el 2026-10-27 por 07 en un servidor dado de baja; son estímulo, no medición».

### ENTO-05 · S2 · Fundamento de «embeddings nunca en `OLLAMA_ENDPOINT`» (el 501)

- **Base:** guía §7.1 l. 1596 («En el servidor compartido, `/api/embed` y `/v1/embeddings` respondieron 501»); A.12 («Nunca el de `OLLAMA_ENDPOINT`»); `_Comun/…/ConfiguracionDelModelo.cs` l. 73 (comentario «el servidor compartido responde 501 a embeddings (Sondeo §5)»); `_Comun/…/PredicadoDeSalto.cs` l. 3; `Demos/…/GeneradorDeEmbeddingsPersistidos.cs`; `Demos/…/tests/…/ComposicionTests.cs`; Demo README l. 80.
- **<equipo-de-contingencia>:** §R.3: en la estación 1, `qwen3-embedding:0.6b` responde por `/api/embed` y `/v1/embeddings` con dimensión 1024 (0,13 s caliente); en la estación 2 también (0,86–0,95 s). No se probó pedir embeddings al 4b en 0.40.11.
- **Juicio:** hoy un mismo servidor sirve chat y embeddings, así que el 501 deja de ser la razón. La regla sigue valiendo como **criterio de la guía** por otras causas medibles: con `MAX_LOADED_MODELS=1` (estación 2) cada llamada de embeddings descarga el modelo de chat, y en la estación 1 compite por los 5 GB del contenedor. Ese fundamento nuevo no está medido.
- **Acción:** reescribir l. 1596 como historia («en el servidor compartido de la corrida, 0.32.0-rc0, respondió 501») y cambiar la razón de A.12 a «criterio de la guía: papeles separados; un servidor con un solo modelo cargado lo recarga». Actualizar los dos comentarios de código (sin cambiar la conducta). Medición opcional: la recarga al alternar chat y embeddings en la estación 2 con el `sondeo.py` (no corre en esta mesa).

### ENTO-06 · S2 · ESC-001 y EMB-A/B/C quedan sin objeto

- **Base:** `Mesa/Ciclo-3/08-Cierre.md` l. 83 (ESC-001 «¿instalás `qwen3-embedding:0.6b` en el servidor Ollama de la LAN…?», estado «sin respuesta»); `Mesa/Ciclo-1/08-Cierre.md` l. 87 y 126; `05-Cierre-Mesa-De-Estructuracion.md`; `README.md` l. 30 y 104; `07-Redaccion.md` §9.2 (pendiente para el PO). En la guía y el código: `EMB_PLAN` con `EMB-A` («en el servidor de la LAN»), `EMB-B` (default) y `EMB-C` (A.12; Demo README l. 80).
- **<equipo-de-contingencia>:** el modelo de embeddings ya está en las dos estaciones vigentes (§R.3; Consulta §0).
- **Juicio:** la pregunta al PO ya no tiene a qué referirse: el servidor que habría que tocar no existe. Lo vigente es EMB-B de hecho, en un servidor del laboratorio. El valor `EMB-A` del código es inofensivo (el código trata A y B igual), pero su definición en la guía nombra un servidor que ya no está.
- **Acción:** nota fechada en `Mesa/Ciclo-3/08-Cierre.md` y en `07-Redaccion.md` §9: «ESC-001 se cierra sin objeto el 2026-10-28: servidor dado de baja; `qwen3-embedding:0.6b` en los dos servidores vigentes; rige EMB-B». Sacar el punto 2 de «Lo que queda para el PO». En la guía, redefinir `EMB-A` como «embeddings en el mismo servidor del chat» y `EMB-B` como «en un servidor aparte», sin nombrar la LAN. Decidir en la matriz si `EMB-A` se elimina del código (cambia la validación de arranque y pide re-compilar).

### ENTO-07 · S2 · Digest y entorno en el Anexo F.4 y en §4.2

- **Base:** F.4 (l. 5076–5085): filas «Servidor Ollama compartido del laboratorio, 0.32.0-rc0», «Modelo de chat (compartido) `qwen3.5:4b`, `2a654d98e6fb`» y «Ollama propio del laboratorio 0.40.11»; §4.2 l. 651 («el modelo de chat usado en el laboratorio, `qwen3.5:4b` (digest `2a654d98e6fb`)»); `sdk_validado` del frontmatter (sin cambio de entorno, queda).
- **<equipo-de-contingencia>:** §R.1 con digests, cuantización, contexto nativo y `capabilities` del 4b vigente (`d8b0f5e9760c`, Q4_K_M, 3,32 GB, 262144 nativo); Consulta §0 para la estación 2.
- **Juicio:** F.4 es la tabla que la guía usa como fuente de cada rótulo; con dos servidores vigentes y uno dado de baja, necesita la columna «servidor» y una fila por estación.
- **Acción:** reescribir F.4 con tres filas de servidor (compartido, «dado de baja el 2026-10-28, historia»; estación de laboratorio de 4 núcleos; estación de laboratorio con más núcleos) y los digests vigentes, tomados de §R.1 y de la Consulta §0, una vez hecha la re-corrida (ENTO-03). Actualizar §4.2 l. 651 a «`2a654d98e6fb` en las corridas de 2026-10-27; `d8b0f5e9760c` en las vigentes».

### ENTO-08 · S2 · «En el laboratorio fue el servidor compartido»: texto de arquitectura con ejemplo vencido

- **Base:** guía l. 108 (OA-O4), 288 (CTX-LOCAL: «en el laboratorio, Qwen en un servidor Ollama compartido»), 989, 2833, 3334, 3376–3383 (§12.4), 3570–3583, 3631–3640 (ADR-03), 4196–4198 (pregunta de autoevaluación «Hoy usás el servidor compartido»), 4348, 4490, 4505, 4598 (glosario), 4877 (E.3 «en el laboratorio fue el servidor Ollama compartido»), 4890 («El README da como motivo no recargar un servidor que usan otros»).
- **<equipo-de-contingencia>:** sin equivalente; la línea de <equipo-de-contingencia> ya hablaba de «estación de laboratorio».
- **Juicio:** «local, servidor compartido o nube» es un eje de decisión válido y no depende del laboratorio: se conserva. Lo que vence son las frases que presentan el servidor compartido como el entorno actual del laboratorio. La pregunta de 4196 sigue sirviendo como caso hipotético del lector.
- **Acción:** reescribir como historia sólo las frases «en el laboratorio…» (l. 288, 3383, 4877, 4890) y el glosario (l. 4598: el «servidor compartido» deja de ser un servidor del laboratorio y queda como concepto). Sin re-corrida.

### ENTO-09 · S2 · `num_ctx`: 65536 en la base, 4096 por defecto hoy

- **Base:** 126 registros R-LLM «compartido» con `num_ctx` 65536 tomado de `/api/ps` por el arnés; README de 08, 09, 11, 12, 13 y 16 lo citan. Guía §5.7 (`num_ctx` recorta en silencio; medido en el Ollama propio con 8192).
- **<equipo-de-contingencia>:** §R.0: las estaciones cargan cada modelo con `context_length` 4096; §R.6 fila 2: alternar `num_ctx` recarga el 4b (10,5–16,1 s de `load_duration`, N = 5, estación 1).
- **Juicio:** el arnés exportaría 4096 en la fase de chat. Las entradas de la fase entran (máximo 805 tokens, ENTO-03), pero el valor registrado cambia y los README que dicen 65536 dejan de describir la corrida. Si la fase del Ollama propio (que fija 8192, `verificar.sh` l. 303) y la de chat caen en el mismo servidor, el 4b se recarga entre una y otra.
- **Acción:** antes de re-correr, que la presidencia fije una ventana (sugerido 8192 para las dos fases, ya medida en §R.6), cargando el modelo con esa ventana dentro del turno para que `/api/ps` la informe. Re-rotular los README con el valor nuevo.

### ENTO-10 · S3 · Precondición «otro modelo cargado» con un solo servidor

- **Base:** `verificar.sh` l. 264–283 (`num_ctx_compartido` aborta si `/api/ps` lista otro modelo, R-04); E.3 l. 4890 (esperar la descarga o descargar antes).
- **<equipo-de-contingencia>:** la estación 1 tiene `OLLAMA_MAX_LOADED_MODELS=2` y la 2, `=1` con `KEEP_ALIVE=10m` (Consulta §0).
- **Juicio:** en la estación 1, después de la fase 2 (0.5b y embeddings) el chat aborta sin llamar mientras esos modelos sigan cargados. No es un defecto (protege), pero hace fallar la secuencia `--con-modelo` si no se descarga.
- **Acción:** en el procedimiento de re-corrida, descargar con `keep_alive: 0` al terminar cada fase. Sin cambios en el repo; E.3 ya lo prevé.

### ENTO-11 · S2 · Latencias y cola del servidor compartido

- **Base:** §5.7 l. 1014 (91,7 s y 123,1 s con la misma pregunta), §12 l. 3334 (cola en 07, 16 y 17), §12.4 l. 3383 (un solo modelo residente), l. 3570; turnos de `06-Construccion.md` l. 99–113 (consumo de `<recurso-compartido>` y `[recurso-modelo-propio]` contra el tope).
- **<equipo-de-contingencia>:** §R.6, tabla única recalculable desde los `.jsonl` (`cifras.py`, 28 filas + 5 de la ronda 2, con columna «servidor»): herramientas del 4b en caliente 4,65–4,96 s (estación 1), 3,08–3,20 s (estación 2); lectura del prompt del 4b ≈ 19 tok/s (estación 1) y 107,5–110,3 tok/s (estación 2); juez 4 casos × 7 evaluadores en 950 s (estación 2).
- **Juicio:** las cifras de la base son de un servidor bajo carga ajena y no se repiten. Las de <equipo-de-contingencia> son de banco exclusivo y recalculables. Son mejores como estado, pero miden otra cosa (sondas HTTP, no los ejemplos .NET).
- **Acción:** las cifras de la base pasan a historia («servidor compartido, bajo carga ajena, dado de baja»). Donde la guía da un orden de magnitud de latencia, citar §R.6 con su servidor. Las cifras por ejemplo salen de la re-corrida de ENTO-03. La lección («la cola de un servidor ajeno domina») se conserva como criterio.

### ENTO-12 · S3 · Observaciones de §5.7 tomadas del sondeo viejo

- **Base:** §5.7 l. 1012 (razonamiento encendido gasta el presupuesto y devuelve texto vacío; 0.32.0-rc0, «no repetida ni recalculada»), l. 1596 (501), l. 3383.
- **<equipo-de-contingencia>:** §R.2 y §R.4: `think:false` y `reasoning_effort:"none"` funcionaron por HTTP directo en 0.40.11; con razonamiento encendido, 5/5 aciertos y 4–5 veces más tiempo (19–26 s). §R.5.7: la vía .NET con `ReasoningEffort.None` **no se re-verificó** en 0.40.11.
- **Juicio:** la conclusión de diseño (la capa de opciones apaga el razonamiento) se sostiene, y la variante negativa de 01 la reproduce sin servidor. Lo observado en el servidor viejo queda como historia. La observación nueva de <equipo-de-contingencia> («con presupuesto suficiente el razonamiento acierta igual, pero cuesta 4–5 veces más») completa la anterior.
- **Acción:** rotular l. 1012 como historia y sumar la fila de §R.4 con su servidor. La re-corrida de 01 en una estación vigente (ENTO-03) cubre la vía .NET.

### ENTO-13 · S3 · «Ollama propio» rotulado con 0.40.11: vale, pero con condiciones distintas

- **Base:** guía l. 1013, 1493, 1742, 2905, 2973 (02, 05, 06, 15 y sondas de `num_ctx`); README de 02, 05, 06 y 15; `verificar.sh` l. 52–54 y 285–301.
- **<equipo-de-contingencia>:** mismos versión y digests en las dos estaciones (§R.1; Consulta §0).
- **Juicio:** son las únicas cifras de la base que se pueden reproducir con el mismo artefacto. El rótulo «Ollama propio, 0.40.11» sigue siendo correcto; la máquina no se puede afirmar (ENTO-0 punto 2). 05 mide duraciones del servidor, que dependen de la máquina.
- **Acción:** conservar el rótulo. Para 05 (tiempos de prefijo), re-correr en la estación que se use e informar cocientes, como ya dice su README. 02, 06 y 15 son conductas y métricas: re-correr sólo si la presidencia quiere rótulo vigente.

### ENTO-14 · S3 · README de 05: «la máquina del Ollama propio comparte CPU con emuladores de otras sesiones»

- **Base:** `Examples/05-Contexto-Completo-Con-Prefijo/README.md` l. 69 y l. 91 (carga de un minuto tomada a mano en esa máquina).
- **<equipo-de-contingencia>:** la estación 2 no aloja emuladores ni KVM, por regla; la estación 1 sí aloja un emulador del laboratorio (recurso `<recurso-emulador>`).
- **Juicio:** describe una condición del laboratorio que cambió. Además es un detalle del laboratorio (otras sesiones) en un repo público, del tipo que el R-PRIV ampliado pide no escribir.
- **Acción:** reescribir neutral: «las duraciones absolutas cambian entre corridas por carga de la máquina; por eso se comparan cocientes». Sin nombrar emuladores ni sesiones.

### ENTO-15 · S3 · Modelos que sólo había en el servidor viejo

- **Base:** `qwen2.5:7b-instruct` en la base `Sondeo-Entorno.md` §1–§2 (162,2 s, timeout) y 33 apariciones en 14 archivos de la bitácora; en el repo, sólo `Examples/07-RAG-Con-Citas/GuionDelEjemplo.cs` l. 5 y su README l. 67 (el caso guionado `e5` es «la respuesta de N3 E5 (de `qwen2.5:7b`)»). `gemma4:e4b-it-qat` en `Mesa/Ciclo-3/02-Informes/desarrollo.md` (RV-11: juez de otra familia).
- **<equipo-de-contingencia>:** ninguno de los dos está en las estaciones vigentes; la estación 2 tiene `qwen3.5:35b-a3b` (21 GiB cargado, herramientas 10/10 y 10/10, unas 4 veces más lento que el 4b; Consulta §2).
- **Juicio:** `e5` es un estímulo guionado, no una medición: se conserva aunque el modelo no esté. RV-11 sigue en «(a) sesgo declarado», ahora con más razón: no hay juez de otra familia en ningún servidor vigente. El 35b-a3b es de la misma familia.
- **Acción:** en 07, agregar al comentario y al README «respuesta tomada de una corrida de N3 en un servidor dado de baja; guionada, no reproducible». Sin re-corrida. Nota en la bitácora sobre RV-11. Que el 7b no corra hoy no se puede afirmar: no se midió (P-37 / P2-10 del insumo).

### ENTO-16 · S2 · Bitácora base sin la nota del servidor dado de baja ni el sondeo vigente

- **Base:** `B/Sondeo-Entorno.md` (214 líneas, §0–§8: describe el servidor compartido como estado y recomienda sobre él); `B/README.md` l. 131 (convención R-PRIV: «El servidor de IA es "el servidor Ollama de la LAN del laboratorio"»); `B/06-Construccion.md` y `B/07-Redaccion.md`, que cuentan turnos de `<recurso-compartido>` y `[recurso-modelo-propio]`.
- **<equipo-de-contingencia>:** el insumo tiene la nota de reanudación y §R.0–§R.7 (E1 del 2026-10-28, con crudos en `Sondeo-Evidencia/2026-10-28/` y `cifras.py`), más la Consulta de la estación 2 con su evidencia.
- **Juicio:** es la pieza de <equipo-de-contingencia> que más vale recuperar: es la única medición del entorno vigente, y la base no la tiene. Sin ella, ninguna re-corrida tiene línea de comparación ni rótulo de servidor.
- **Acción:** como agregado fechado en `B/Sondeo-Entorno.md`, la nota «§0–§8 describen el servidor compartido, dado de baja el 2026-10-28; historia» y §R completo, copiado del insumo con su procedencia. Copiar `Sondeo-Evidencia/2026-10-28/` y `Mesa/Ciclo-1/Ronda-2/evidencia-<estación-2>-ollama/` (o referenciarlos en la ruta archivada). Antes de copiar, pasar la compuerta R-PRIV: el insumo dice `grep` 0 de direcciones en esa evidencia. En `B/README.md`, nota que actualice la convención R-PRIV con los dos nombres vigentes («estación de laboratorio de 4 núcleos», «estación de laboratorio con más núcleos») y la equivalencia `<recurso-compartido>` de ENTO-02.

### ENTO-17 · S3 · Gestor de recursos (fuera del repo) desalineado con el entorno vigente

- **Base:** —. Es tooling del workspace (`<gestor-de-turnos>/`), no de la guía.
- **Hoy:** `<gestor-de-turnos>` l. 47: el `OLLAMA_URL` por defecto de `salud <recurso-compartido>` apunta a la dirección del servidor dado de baja (no se transcribe). Sin `OLLAMA_URL` exportado, «salud» mide un servidor que no existe. No hay rama de salud para `<recurso-estación-2>` (l. 245–250 → «recurso desconocido»), la lista `TODOS` (l. 39) no lo incluye y `PROTOCOLO.md` no menciona `<recurso-estación-2>` ni la regla «nunca emuladores ni KVM» de la estación 2. `cupos.conf` sólo declara `<recurso-estación-2> 1` y `build 2`.
- **Juicio:** no afecta la guía, pero sí la re-corrida y su evidencia («salud» es la condición previa registrada de DEP-14).
- **Acción:** que la presidencia pida al gestor: (1) exportar `OLLAMA_URL` o cambiar el default por una variable sin valor; (2) agregar la rama de salud de `<recurso-estación-2>`; (3) sumar al protocolo la estación 2 con su regla. Esta mesa no toca el gestor.

### ENTO-18 · S4 · Tope y regla de cola del compartido (`TOPE_LAN_S`, medidor)

- **Base:** `verificar.sh` l. 37, 154–171, 410–419 (tope de `<recurso-compartido>` de 4 h por ciclo, §E.5); `Examples/README.md` l. 33, 72, 92.
- **Hoy:** el tope protegía un servidor que operaba otro. Las estaciones son del laboratorio, con turno exclusivo y TTL de 45 min.
- **Juicio:** el mecanismo es genérico y útil para un lector con un servidor ajeno. Su motivo, en cambio, era del laboratorio viejo.
- **Acción:** conservar el código. En `Examples/README.md`, decir que el tope es para servidores ajenos y que con un servidor propio se puede dejar en el default. Sin re-corrida.

### ENTO-19 · S3 · Registros y adaptadores dentro del árbol de la guía

- **Base:** `verificar.sh` l. 50 (`RLLM_DIR` por defecto `$EX/registros`); `demo.sh` l. 18 (`./registros` de la demo, ignorado por git); el adaptador `turno.sh` y los scripts `lan-*.sh` / `build-*.sh` vivían en el directorio de trabajo de <equipo-principal> (hoy en la copia de rescate, `{copia-de-rescate}/…`).
- **Hoy:** no hay `Examples/registros/`, ni `bin/`, `obj/` o `*.db` en la guía (comprobado). Ningún archivo del repo ni de la bitácora base nombra `{dir-de-trabajo}`.
- **Juicio:** sin dependencia de rutas viejas en el repo. El riesgo es la re-corrida: con el default, el R-LLM queda dentro del árbol de la guía.
- **Acción:** en el procedimiento, exportar siempre `RLLM_DIR={dir-de-trabajo}/<etiqueta>/registros` y correr sobre copias en `{dir-de-trabajo}/<etiqueta>/`. Recuperar `turno.sh` del rescate como adaptador (ENTO-01). No escribir esas rutas en la guía.

### ENTO-20 · S4 · Hallazgo nuevo del entorno vigente que la base no tiene: Ollama no hace cumplir el `enum`

- **Base:** la guía valida los argumentos en la aplicación (por diseño, §8), pero no registra un caso en que el servidor deje pasar un valor fuera del esquema.
- **<equipo-de-contingencia>:** §R.4: `qwen2.5:0.5b` devolvió 6 veces `"medio":"piedra"` (fuera del `enum`) con `finish_reason: tool_calls`, en 0.40.11 (estación 1), repetido en la estación 2 (0/10, Consulta §1).
- **Juicio:** es evidencia E1 vigente que refuerza un criterio de la guía, y sale del entorno nuevo. No es una dependencia vencida, pero se pierde si la base no la recupera.
- **Acción:** proponerla a la matriz como evidencia para §8.2 (rótulo: estación de laboratorio de 4 núcleos, 0.40.11, 2026-10-28). Lo que no se hizo: buscar documentación que lo afirme o lo niegue.

## 2. Orden sugerido para la presidencia

1. ENTO-16: recuperar el sondeo vigente. ENTO-01, 02, 09, 17 y 19: arnés y gestor listos para re-correr sin contaminar rótulos.
2. ENTO-03, 04, 07, 11, 12 y 13: re-corrida de las fases con modelo en una estación vigente (no en esta mesa) y re-rotulado.
3. ENTO-05, 06, 08, 14, 15, 18 y 20: texto. Estos no necesitan modelo y se pueden hacer en la integración.
