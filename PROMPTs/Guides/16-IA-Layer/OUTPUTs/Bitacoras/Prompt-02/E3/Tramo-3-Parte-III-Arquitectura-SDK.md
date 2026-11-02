# E3 · Tramo 3 · Parte III · Arquitectura y SDK (capítulos 5–6)

Etapa E3, tramo 3 de 6 (`../05-Plan-Integrado.md` §5 E3). Fecha: 2026-11-01. Registro de sólo agregado. Recuento y compuertas: `Registro-Por-Parte.md` §4.

## Índice

1. [Definiciones](#1-definiciones)
2. [Qué se hizo](#2-qué-se-hizo)
3. [Cambios de E1 y recortes en el tramo](#3-cambios-de-e1-y-recortes-en-el-tramo)
4. [Decisiones de edición](#4-decisiones-de-edición)
5. [Para el Anexo H (tramo de Anexos)](#5-para-el-anexo-h-tramo-de-anexos)
6. [Pendientes para los tramos siguientes](#6-pendientes-para-los-tramos-siguientes)
7. [Archivos tocados](#7-archivos-tocados)

## 1. Definiciones

- **Ficha de ejemplo:** fila de la tabla «Ejemplos» del capítulo con objetivo, comando, salida esperada, enlace al README y la línea ADR-01 sí/no (D-09 a, D-11 d, U-2.2).
- **Recorrido del código:** fragmentos de código con su «Qué mirar» que en la 0.11.0 vivían en «Práctica de §5»; ahora viven en la sección «El código, paso a paso» de cada README.

## 2. Qué se hizo

1. **Encabezados** según el índice congelado: «Capítulo 5 · La capa de IA en la arquitectura de la aplicación» (`c5`, alias `s4`) y «Capítulo 6 · Hablar con un modelo desde .NET» (`c6`, alias `s5`). Secciones 5.1–5.5 y 6.1–6.7 con `cN-k` y alias `sM-k`.
2. **Patrón D-09 a** en los dos capítulos: Aplicación por escenario (5.6, 6.8), Ejemplos (5.7, 6.9), Decisión (5.8, 6.10), Preguntas guía (5.9, 6.11), Criterios de calidad (5.10, 6.12), con anclas `cN-escenarios`, `cN-ejemplos`, `cN-decision`, `cN-preguntas`, `cN-calidad`. El rótulo «Práctica» desaparece; `s4-practica`, `s5-practica` y los demás alias quedan en el paso que les asigna `../E2/Anclas-Viejo-Nuevo.md`.
3. **§4.1 Vocabulario (C-2.3):** la tabla «qué no es» pasa al Anexo C como Tabla C.2 con el ancla `s4-1`, como pide `Anclas-Viejo-Nuevo.md`. En el capítulo queda 5.1 (`c5-1`), de tres líneas, que remite a las Tablas C.1 y C.2 sin redefinir nada; así se conserva la numeración 5.2–5.5 que ya citan el Prólogo y la Parte II. Las nueve remisiones del glosario a «§4.1» dicen «Tabla C.2».
4. **Prácticas de §5 al README (D-11 d):** los fragmentos de 01–04 con su «Qué mirar» pasan a una sección nueva «El código, paso a paso» de cada README; en 01 va también la salida vigente con el modelo (2026-10-29). En el libro queda la Tabla 6.3 con una ficha por ejemplo. La práctica de §4 no tenía ejemplo numerado: queda como ficha de la demo en 5.7.
5. **Excepción I-5 (D-02 a, U-2.2):** una línea en 5.8 (Decisión ADR-01) con la lista medida en `../E1/Cambios-Al-Libro.md` §3; en 6.7 una línea «ADR-01: 02, 03 y 04 sí; 01 no»; columna ADR-01 en la Tabla 6.3; la ficha de la demo dice «sí».
6. **Numeración visible:** las remisiones del tramo muestran el número nuevo (§N+1) y apuntan a `c5…`/`c6…` dentro del tramo y a los alias fuera. Tablas 5.1–5.4 y 6.1–6.3; Figuras 5.1 y 6.1.
7. **Citas a P-n** donde el texto ya enunciaba el principio: P-1 y P-8 (cap. 5), P-2, P-8 y P-9 (cap. 6).
8. **Marcas:** «no está medido» de la cancelación y la vía .NET con `ReasoningEffort.None` pasan a NO VERIFICADO; el cambio a la nube, a NO EJECUTADO.
9. **Fuera de la Parte III:** la Parte II remitía la pregunta «¿En qué se distingue…?» a `s4-4` (§5.4); ahora apunta a `c5-preguntas` (§5.9), donde vive.

## 3. Cambios de E1 y recortes en el tramo

| Id | Estado en el tramo 3 |
|---|---|
| CL-07 (D-28 a) | aplicado: la fila del servidor que atendía a otros clientes sale de la Tabla 5.2; «servidor compartido» sale del rótulo vigente de 01; 6.5 habla de «varias aplicaciones en el mismo servidor» como criterio general; `OLLAMA_SERVIDOR=compartido` queda como identificador del arnés |
| §4 de CL (`qwen2.5:0.5b`) | l. 641 queda (familia, Tabla 5.1); l. 661, 972, 1032 y 1166 (Historia) salen al Anexo H (§5); l. 1034 queda como remisión sin el nombre del modelo («otra corrida y otro estímulo») |
| C-2.2 Historia | 12 líneas con «Historia (hasta» en la 0.11.0 del tramo → 0 en la Parte III; texto íntegro en §5 |
| C-2.3 glosario | §4.1 trasladada (Tabla C.2) |
| D-11 d | aplicado (01–04) |
| D-02 a / U-2.2 | aplicado |
| CL-01, CL-02, CL-03 | hechos en tramos 1–2 |
| CL-04, CL-05 | nada en el libro |
| CL-06, CL-08 | fuera del tramo (caps. 7 y 9) |
| HE-11 en la Parte III | 0 «Historia (hasta», 0 «versión anterior», 0 «antes era» |

## 4. Decisiones de edición

- **«Latencias de minutos»** (6.7) era entera Historia. Queda una línea sin cifra que justifica la espera de diez minutos y remite al Anexo H; no se escribió ninguna medición nueva.
- **Par de tokenizadores en 6.4** (5.114 con 4b, 5.134 con 0.5b, Historia): sale; la regla «calibración por modelo» queda sostenida por la medición vigente (2,46 caracteres por token contra la calibración general de 4,0).
- **Filas I01–I04 del mapa de intervalos** (`tools/compuerta-intervalos.tsv`, archivo de la guía): sus figuras eran Historia (I02–I04) o la frase que las resumía junto con la Historia (I01); salen del libro y del mapa para que la compuerta no falle por fila sin figura. La figura vigente de 01 sigue mapeada por PV01-02. Las cuatro filas, para reponer cuando exista el Anexo H, en §5.
- **Anexo H** se nombra sin enlace en 6.7 (no existe todavía; mismo criterio que el tramo 1).

## 5. Para el Anexo H (tramo de Anexos)

Texto íntegro de la 0.11.0 que sale del cuerpo (número de línea relativo al tramo, desde `<a id="parte-3">`). Algunas líneas son párrafos enteros: sólo la parte «Historia…» va al anexo.

- **Línea 57 del tramo en la 0.11.0 (ver abajo):**

  > | servidor del laboratorio que atendía a otros clientes | historia (hasta el 2026-10-28), retirado | 0.32.0-rc0, sólo CPU | `2a654d98e6fb` | — | registros del 2026-10-25 al 2026-10-27 |

- **Línea 61 del tramo en la 0.11.0 (ver abajo):**

  > Historia (hasta el 2026-10-28). Servidor retirado. El chat corrió con el digest `2a654d98e6fb` del 4b y el segundo servidor sirvió `qwen2.5:0.5b` (digest `a8b0c5157701`).

- **Línea 112 del tramo en la 0.11.0 (ver abajo):**

  > **Lo que la prueba no ve.** La prueba lee lo compilado: firmas, atributos (con los `typeof` de sus argumentos) y el IL de los cuerpos. Tres casos rojos lo comprueban con mutaciones compiladas sólo en el ensamblado de pruebas (`Cableado/MutacionesTests.cs`): un tipo de Infrastructure/AI usado sólo dentro de un método no se ve leyendo la firma y sí leyendo el IL, uno nombrado sólo en un atributo da violación, y un tipo fuera de Infrastructure/AI que usa `Comun.AI` en un cuerpo hace fallar la sexta regla. Lo que no deja rastro en lo compilado queda afuera y se declara como agujero: un `global using` que nadie usa no se compila, y `nameof(…)` queda como una cadena. Ninguno crea una dependencia en tiempo de ejecución, pero muestra que alguien tiene a mano el tipo prohibido; eso se ve en la revisión, no en la prueba. Historia (hasta el 2026-10-28). El laboratorio probó los dos agujeros con una mutación cada uno y la regla quedó en verde; en la demo no se repitió. Una búsqueda de texto sobre los `using`, como un `grep`, no es prueba suficiente: no ve un `global using` en otro archivo ni un nombre calificado. Por eso la regla vive en la prueba por reflexión.

- **Línea 372 del tramo en la 0.11.0 (ver abajo):**

  > **Ventana y truncado.** La capa manda un solo `num_ctx`, el de la configuración; el mismo valor tiene que valer para todos los clientes de un modelo ([§5.5](#s5-5)). Si igual el servidor recorta, no avisa ([§5.7](#s5-7)): `GuardaDeTruncado` compara los tokens que informa el servidor con una estimación del largo del prompt y marca el registro, sin cortar la llamada. El largo truncado depende del tokenizador: un estímulo propio, con su propia composición, midió 5.114 tokens con `qwen3.5:4b` y 5.134 con `qwen2.5:0.5b` (Historia (hasta el 2026-10-28). Estación 2). Ese par no es el prompt de 5.397 de este párrafo ni el de 5.714 de [§5.7](#s5-7), que tienen otro estímulo y otra composición: la comparación de tokenizadores vale sólo dentro del par. Por eso la calibración de caracteres por token es por modelo (`RLLM_CARACTERES_POR_TOKEN_POR_MODELO`, [A.12](#anexo-a-12)), y `GuardaDeTruncado` estima con el modelo de la llamada: el de `ChatOptions.ModelId` o, si la llamada no lo fija, el del cliente (prueba `GuardaDeTruncado_EstimaConLaCalibracionDelModeloDeLaLlamada`, en `Examples/_Comun/MovilidadUrbana.Asistente.Comun.Pruebas/`). Truncado con `qwen3.5:4b`: con `num_ctx` 8192, el servidor contó 5.397 tokens del prompt y la guarda estimó 3.323, un 38 % menos, porque usó la calibración general de 4,0 caracteres por token y ese estímulo dio 2,46; sin la opción, el servidor cargó el modelo con 4.096 y procesó 2.050 tokens, recortado en silencio. Observado en el laboratorio: `qwen3.5:4b`, estación 2, Ollama 0.40.11, digest `d8b0f5e9760c`, 2026-10-29, una entrada en tres variantes (sonda de `num_ctx`).

- **Línea 431 del tramo en la 0.11.0 (ver abajo):**

  > - **Razonamiento encendido por defecto.** Con un presupuesto de salida chico, `qwen3.5:4b` lo gastó en razonamiento y devolvió texto vacío, terminado por largo; sin razonamiento, respondió. Historia (hasta el 2026-10-28). Servidor retirado. Observado en el sondeo del entorno: `qwen3.5:4b` (sin digest registrado), Ollama 0.32.0-rc0, sólo CPU, servidor compartido, 2026-10-25 y 2026-10-26; observación del sondeo previo a la construcción, no repetida ni recalculada. La capa de opciones lo apaga, y la variante negativa de 01 reproduce la falla sin servidor. En la estación 1, por HTTP directo y sin pasar por .NET, `think:false` y `reasoning_effort:"none"` apagaron el razonamiento; con el razonamiento encendido y presupuesto suficiente, `qwen3.5:4b` llamó bien a la herramienta en 5 de 5, con 19,1 a 25,9 s por llamada, contra 4,65 a 4,78 s apagado. Observado: sondeo del entorno por `/v1`, estación 1, Ollama 0.40.11, 2026-10-28; conducta, no tasa. La vía .NET con `ReasoningEffort.None` no se volvió a verificar en esa versión.

- **Línea 432 del tramo en la 0.11.0 (ver abajo):**

  > - **`num_ctx` recorta en silencio.** La documentación de Ollama da un contexto por defecto de 4.096 tokens [REF-55], o uno que depende de la memoria de video [REF-56]. La regla: sin la opción, el servidor usa la ventana con que cargó el modelo (4.096 en las estaciones) y el prompt llega cortado, sin error. Con `qwen3.5:4b`, sin la opción el servidor procesó 2.050 tokens de un prompt que con la capa contó 5.397 ([§5.4](#s5-4)). El largo que queda lo decide el motor y no es igual a `num_ctx`; observado: 2.050 tokens, mecanismo no explicado. Observado en el laboratorio, sonda de `num_ctx`: `qwen3.5:4b` (digest `d8b0f5e9760c`), Ollama 0.40.11, estación 2, 2026-10-29, una entrada en tres variantes. Historia (hasta el 2026-10-28). Servidor retirado. Con la capa, el servidor procesó 5.714 tokens de un prompt de esa sonda, con otro estímulo y otra composición que el de 5.397; sin la opción, 2.050. Con ese estímulo hubo 2,33 caracteres por token. Observado en el laboratorio, sonda de `num_ctx`: `qwen2.5:0.5b` (digest `a8b0c5157701`), Ollama 0.40.11, segundo servidor, 2026-10-27. Como el servidor no avisa, la guarda de truncado compara los tokens informados con una estimación y saca de toda tasa la corrida que no cierra. Por `/v1` llegan los tokens, pero la aplicación no fija la ventana y la guarda responde «no verificable» (`Examples/_Comun/MovilidadUrbana.Asistente.Comun/AI/GuardaDeTruncado.cs`).

- **Línea 433 del tramo en la 0.11.0 (ver abajo):**

  > - **Latencias de minutos.** Historia (hasta el 2026-10-28). Servidor retirado. Dos llamadas con la misma pregunta tardaron 91,7 s y 123,1 s. Observado en el laboratorio, sonda de tiempos: `qwen3.5:4b` (digest `2a654d98e6fb`), Ollama 0.32.0-rc0, sólo CPU, servidor compartido, 2026-10-27. La diferencia es compatible con carga ajena en el servidor compartido, pero no se midió. No se comparan; de ahí las esperas de [§5.5](#s5-5).

- **Línea 513 del tramo en la 0.11.0 (ver abajo):**

  > Historia (hasta el 2026-10-28). Servidor retirado. Observado en el laboratorio: `qwen3.5:4b` (digest `2a654d98e6fb`), Ollama 0.32.0-rc0, sólo CPU, servidor compartido, 2026-10-27; estímulo del mismo autor. Respuesta a «¿Qué datos tengo que cargar para dar de alta una localidad?»:

- **Línea 566 del tramo en la 0.11.0 (ver abajo):**

  > Historia (hasta el 2026-10-28). Servidor retirado. Observado: `qwen2.5:0.5b` (`a8b0c5157701`), Ollama 0.40.11, segundo servidor, 2026-10-27. Por los dos adaptadores volvió el mismo texto libre, que agrega por su cuenta un «por ejemplo» con una provincia que no está en `Catalogos` y un código postal que no tiene cuatro dígitos. El ejemplo no lo filtra, y esa propuesta no pasaría `LocalidadRules.ProvinciaValida` ni `CodigoPostalValido`: cambiar de adaptador no cambia lo que hace el modelo.

- **Línea 642 del tramo en la 0.11.0 (ver abajo):**

  > Historia (hasta el 2026-10-28). Servidor retirado. Observado: `qwen3.5:4b` (`2a654d98e6fb`), Ollama 0.32.0-rc0, sólo CPU, servidor compartido, 2026-10-27; estímulo del mismo autor. El modelo dejó `habitantes` en `null` y las reglas decidieron `faltan:habitantes`:

- **Línea 699 del tramo en la 0.11.0 (ver abajo):**

  > Historia (hasta el 2026-10-28). Servidor retirado. Observado con el rótulo de 03; estímulo del mismo autor. Para «Algunos días por semana voy caminando y otros en moto.», el modelo dejó la frecuencia en `null` y el paso quedó con error; la otra entrada pasó:

- **Línea 710 del tramo en la 0.11.0 (ver abajo):**

  > **En la demo.** PD-3 repite el patrón de 03 en el host. Historia (hasta el 2026-10-28). Servidor retirado. Observado: `qwen3.5:4b`, servidor compartido, 2026-10-27; humo de la demo: dejó `habitantes` en `null`. PD-4 repite el de 04 y se prueba por cableado ([§14.3](#s14-3)).

Filas retiradas de `tools/compuerta-intervalos.tsv` (reponer con el ancla de la línea que quede en el Anexo H):

```text
I01	Las dos preguntas nombraron cada campo pedido	2 de 2	-	2	2	medicion	01-Chat-Y-Streaming.modelo.jsonl	tipo=entrada	resultado=pasa
I02	las ocho decisiones pasaron el oráculo	-	IC95 [0,631; 1]	8	8	medicion	03-Salida-Estructurada.modelo-ext.jsonl	tipo=entrada	resultado=pasa
I03	en los cuatro pedidos sin el dato el modelo no propuso habitantes	0/4	IC95 [0; 0,602]	0	4	medicion	03-Salida-Estructurada.modelo-ext.jsonl	tipo=entrada;entrada_id~^x0[5-8]$	motivo!~faltan:.*habitantes
I04	7 de 8 expresiones terminaron con la clave esperada	7 de 8	IC95 [0,473; 0,997]	7	8	medicion	04-Normalizacion-Contra-Catalogo.modelo-ext.jsonl	tipo=entrada	resultado=pasa
```

## 6. Pendientes para los tramos siguientes

1. Anexos: 13.083 palabras contra 12.100 (suben 197 por la Tabla C.2). El tramo de Anexos fusiona las Tablas C.1 y C.2 con el glosario y arma el Anexo H con §5.
2. Los README de 01–04 conservan remisiones viejas fuera de su encabezado (p. ej. «§10.4»); el encabezado ya dice §6.x. Renumerarlas en el tramo de Anexos o en E10.
3. La Parte IV (§6 de la 0.11.0) remite a «[§3.0](#s3-0)» y «[§5.4](#s5-4)» con número viejo: lo cambia el tramo 4.
4. El control docs-guard «mermaid-arroba» sigue sin estar en `dg.py`; se aplicó a mano (0 arrobas, 0 `#64;` en los 2 diagramas).
5. `verificar.sh` completo y filtro U-7.1, al cierre de E3.

## 7. Archivos tocados

| Archivo (LD, carpeta de la guía) | sha256 antes | sha256 después |
|---|---|---|
| `Dot-Net-Integration-AI-Layer-Guide.md` | `e182b1458b936fa422ef6d34890d355c76f0ecc0705f9643140bcc7a70f155b9` | `40a43163d0f7cd31657061f41e7630bf26b36ef62c9cf89a50032c2d509a9607` |
| `tools/compuerta-intervalos.tsv` | `719edac60f753309562778b176222cef74d9f5ff31e8cda6c60df4c268991250` | `c0fec99da2c5640634717ea9d3117affa3c9db86a17ed1072628b4446ee070c7` |
| `Examples/01-Chat-Y-Streaming/README.md` | `d5b65e782b8d95d85f94f8efc0c9530976c5d4c9ffdd0845bd108231a67e2017` | `dff552d482766bbb1a64308c1936ea6c7ab71a6c2baa79a38f7011d31f0cdd20` |
| `Examples/02-Cambio-De-Adaptador/README.md` | `a1136b063fe4d44521450c04d7632dc2c49c384f3d2a25f3b33419ab4a2ae78b` | `a8d94468a9cf6bf5865a016de567fdaf5f5a9069ba967a31485edacf2a3f0c50` |
| `Examples/03-Salida-Estructurada/README.md` | `3ce06ffaca1981b96b74619829c42d0e303f5e8ae8dbfe362bc02563fa64b7f8` | `67a50bcc2f5ecc26035ffa52f1a184638f037a7e64d9f65153a97284cd2b4305` |
| `Examples/04-Normalizacion-Contra-Catalogo/README.md` | `816197ccda91d220abc6ca403c67b9383db00129a7ca1d1cdf353e7749c99e47` | `4f957be23971a2460636358d1a2b87012b596fd7b055b2a81ea0490d1427159a` |

Sin commit, push ni PR. No se tocaron archivos comunes ni carpetas de otras sesiones. Sin mensajes ajenos a mitad de turno.
