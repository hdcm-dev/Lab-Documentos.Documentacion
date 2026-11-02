---
doc_id: BIT-16-C2-INF-edicion-bibliografica
doc_type: informe-de-mesa
title: Relectura integral de la guía 16 (ciclo 2) — Edición de material bibliográfico
status: emitido
origin: agent
owner: rol «Edición de material bibliográfico», mesa del ciclo 2
last_review: 2026-10-28
audience: [presidencia, redacción, mesa del ciclo 2]
traces: [REED-16 §9.1, §10, §13; Mesa/Ciclo-1/06-Plan-De-Redaccion.md §2 (P-07), §7, §10; Mesa/Ciclo-2/00-Compuertas-Redaccion.md; Mesa/Ciclo-2/plan-de-preguntas.md]
---

# Informe de Edición de material bibliográfico — relectura integral (ciclo 2)

## Índice

1. [Alcance y método](#1-alcance-y-método)
2. [El presupuesto: dónde están las 20 000 palabras de más](#2-el-presupuesto-dónde-están-las-20-000-palabras-de-más)
3. [Hallazgos](#3-hallazgos)
4. [Revisado y bien](#4-revisado-y-bien)
5. [Evidencia](#5-evidencia)

## 1. Alcance y método

Mandato: edición y compresión (jerarquía, índice y anclas, voz única, formato uniforme de snippets y tablas, aparato de referencias del Anexo D con versión y fecha, autocontención) y recortes concretos que no quiten evidencia. Lectura a ciegas: no se leyó ningún otro `Informe-*.md` del ciclo 2.

Se leyó la guía completa, de la línea 1 a la 4116, en el orden del lector; de `Examples/` y `Demos/`, la estructura de los trece README y su relación con la guía (lo que pide este mandato). Las mediciones son scripts reproducibles en `evidencia-edicion-bibliografica/` (palabras por sección con y sin código, anclas, catálogo REF, repeticiones, formatos). Las fechas de versión de arXiv se consultaron hoy en la API de export de arXiv (`03-arxiv-versiones.txt`).

## 2. El presupuesto: dónde están las 20 000 palabras de más

Medido con `01-palabras-por-seccion.txt` (prosa y código separados; bloques de código, incluidos los mermaid, aparte):

| Sección | Plan (P-07) | Prosa | Código | Desvío de la prosa |
|---|---|---|---|---|
| §0 | 1 200 | 2 022 (≈ 900 son el índice) | 0 | +68 % (+ 9 % sin el índice) |
| §1 | 1 000 | 854 | 250 | dentro |
| §2 | 1 500 | 2 285 | 119 | +52 % |
| §3 | 2 000 | 2 617 | 85 | +31 % |
| §4 | 3 000 | 3 122 | 448 | dentro |
| §5 | 4 500 | 4 616 | 742 | dentro |
| §6 | 6 000 | 6 229 | 782 | dentro |
| §7 | 6 000 | 8 569 | 1 318 | +43 % |
| §8 | 5 500 | 8 130 | 886 | +48 % |
| §9 | 3 500 | 4 317 | 356 | +23 % |
| Anexos A–F | 6 000 | 11 654 (D.1 sola: 3 294) | 449 | +94 % |

Lectura de edición: el exceso no es mayoritariamente redundancia. Tres cuartos están en §7, §8 y los anexos, y en los anexos son el aparato que el plan exige (137 referencias con versión y fecha, la copia del glosario, el registro de cifras y de R-LLM). Lo que sí es redundancia recortable sin perder evidencia suma, según los hallazgos de abajo, **unas 3 400 palabras** (≈ 6 % del total). Con esos recortes la guía queda en ≈ 57 000; llegar a ±20 % de 40 200 exigiría quitar evidencia, lo que P-07 prohíbe («recortar redundancia no autoriza recortar evidencia»). Recomendación a la presidencia (EDICIO-01): aplicar los recortes y rebaselinar el presupuesto de §7, §8 y anexos con dictamen, midiendo la prosa sin código ni índice.

## 3. Hallazgos

Severidad: S1 bloquea; S2 debe corregirse antes del cierre; S3 conviene corregir; S4 menor. Las estimaciones de palabras son de prosa.

### EDICIO-01 · El presupuesto se mide mal y el exceso real es estructural — S2 · compresión

- **Ubicación:** guía completa; plan §2 (P-07) y compuerta «Presupuesto» del plan §7.
- **Evidencia:** tabla de §2 de este informe (`01-palabras-por-seccion.txt`, `06-palabras-por-subseccion.txt`). `wc -w` cuenta código (6 236 palabras), mermaid y el índice de §0.1 (≈ 900). Sin ellos, §0, §1, §4, §5 y §6 están dentro del ±20 %; §7, §8 y anexos no, y su exceso es contenido exigido.
- **Propuesta:** (1) medir la compuerta con `evidencia-edicion-bibliografica/palabras.awk` (prosa sin código) y excluir §0.1; (2) aplicar EDICIO-02 a EDICIO-06 y EDICIO-13 (≈ 3 400 palabras); (3) dictamen de la presidencia que fije el presupuesto de §7 (≈ 8 000), §8 (≈ 7 500) y anexos (≈ 11 000) como nuevo valor orientativo, con este informe como fundamento.

### EDICIO-02 · El truncado silencioso (2050 tokens) se cuenta cinco veces — S2 · compresión

- **Ubicación:** §2.5 l. 410; §5.4 l. 1062–1064; §6.5 l. 1504–1532 (canónica: tabla y decorador); §8.8 l. 3015–3017; §6.11.16 l. 1809. «2050» aparece 16 veces (`05-repeticiones-lineas.txt`).
- **Evidencia:** §8.8 repite casi entera la tabla y el párrafo del decorador de §6.5 («5114 con 8192…, 2050 con 4096…», «el largo esperado viaja en `AdditionalProperties`…», «esperado 5114, recibido 2050») y además la diferencia 5114/5134 de §6.1 y la recarga 10,5–16,1 s de §5.4 y §6.4.3.
- **Propuesta (≈ 370 palabras):**
  - §5.4, reemplazar el párrafo «**La ventana se pide en cada pedido.** `ConModelo/NumCtxConModeloTests` … estación con más núcleos).» y la primera oración del siguiente por: «**La ventana se pide en cada pedido.** Con `num_ctx` 4096, Ollama recortó un prompt de 6843 tokens a 2050, con fin `stop` y sin error, también con el modelo de chat (tabla y detector en §6.5). Dos reglas de configuración:». Se conservan las dos viñetas.
  - §8.8, reemplazar los dos párrafos por: «El detector de §6.5 es un `DelegatingChatClient` que envuelve al cliente del proveedor; el largo esperado viaja en `AdditionalProperties` y se saca antes del cuerpo HTTP, y por streaming lee el `UsageContent` del último fragmento (`Examples/09-Pruebas-Con-Cliente-Falso/src/MovilidadUrbana.Ejemplos.PruebasConClienteFalso/Infrastructure/AI/DetectorDeContextoTruncado.cs`, l. 34–47). Las cifras contra el modelo están en la tabla de §6.5; el largo esperado se mide con el tokenizador del modelo (§6.1) y el `num_ctx` es el mismo en todos los clientes (§5.4). La pregunta «¿subo la ventana al máximo?» se responde en §6.11.16.»
  - §2.5, viñeta «La ventana declarada no es la configurada»: quitar «Invariante con `qwen2.5:0.5b`, prueba en `Examples/01-…/NumCtxConModeloTests.cs`.» y la última oración, y cerrar con «(detalle y prueba en §6.5)».

### EDICIO-03 · «La política no es el código» tiene dos tablas y tres párrafos — S2 · compresión

- **Ubicación:** tabla de §6.3 l. 1442–1451 y tabla de §9.3.3 l. 1272–1279 (tres de cuatro filas iguales); prosa en §3.8 l. 550, §4.9.5 l. 886 (final), §5.4 l. 1028. La frase «el modelo repite la política; la prueba muestra el código» aparece 5 veces.
- **Evidencia:** las dos tablas enuncian lo mismo (60 caracteres declarados y no aplicados; `\d` Unicode; «del catálogo» no comparado); la de §9.3.3 suma lo que da cada camino y es la más completa.
- **Propuesta (≈ 210 palabras):** canónica la tabla de §9.3.3.
  - §6.3: reemplazar la tabla y el párrafo siguiente por «**La política no es el código.** La ayuda repite lo que la política **declara**, no siempre lo que el código **verifica** (caso base, commit `59399ba`): el máximo de 60 caracteres del nombre está declarado y ninguna regla lo verifica, «4 dígitos» acepta dígitos Unicode y «del catálogo» no se compara contra el catálogo. **El modelo repite la política; la prueba muestra el código.** La tabla, con lo que da cada camino, está en §9.3.3.»
  - §4.9.5: reemplazar desde «Y la otra cara: `LocalidadPolicy` declara…» hasta «…la prueba muestra el código.» por «Y la otra cara: la política declara reglas que la API copiada no aplica (§9.3.3).»
  - §5.4: reemplazar desde «El mensaje de sistema repite la política, pero repetirla no la hace cumplir:» hasta «…la prueba muestra el código.» por «El mensaje de sistema repite la política, pero repetirla no la hace cumplir: los valores que dejan pasar las reglas están en §9.3.3 y en `Examples/03-Salida-Estructurada`, `Cableado/FormaNoEsValidezTests`, l. 112–127.»
  - §9.3.3 conserva la frase-estribillo como cierre.

### EDICIO-04 · Preguntas guía que repiten el cuerpo en lugar de formar criterio — S2 · compresión

- **Ubicación:** §6.11.10, §6.11.12, §6.11.14 (repiten §6.4.1–§6.4.3 casi palabra por palabra, con las mismas cifras 71,7/26,0 s y 10,5–16,1 s); §8.13.11 (= §8.12.3), §8.13.12 (= §8.5.1), §8.13.13 (= §8.9.2, con 1285 s otra vez); §9.9.5 (= §7.13.1 y §7.13.2).
- **Evidencia:** el prompt del PO pide respuestas «formadoras de criterio»; P-07, «cada snippet aparece una vez y las demás secciones remiten». `plan-de-preguntas.md` fija la pregunta y su sección, no el largo de la respuesta: comprimirla no viola P-09.
- **Propuesta (≈ 420 palabras):** respuesta = criterio + remisión, sin volver a dar cifras.
  - §6.11.10: «No necesariamente: con un corpus que entra, el paper de CAG compite con RAG [REF-066, Tabla 2]. Pero «entra» se mide contra la ventana efectiva y la configurada, no la declarada (§6.1, §6.5). **Criterio:** si el corpus cambia seguido, tiene permisos por persona o hay que citar el fragmento, RAG (§6.2).»
  - §6.11.12: «Nada: en los modelos soportados es automática desde 1024 tokens [REF-076][REF-077]. **Criterio:** ordenar el prompt para que el prefijo coincida y verificarlo con `UsageDetails.CachedInputTokenCount` [REF-084], que OllamaSharp no llena (§6.4.2, §6.4.4).»
  - §6.11.14: «La rompen `keep_alive`, otro `num_ctx` y otro prefijo en el único espacio de concurrencia [REF-079], y cuánto se reusa depende del modelo (§6.4.3). **Criterio:** un solo `num_ctx` por modelo, lo estable primero y el reuso verificado con el handler de §6.4.4.»
  - §8.13.11: «Como en §8.12.3: *user-secrets* sólo en desarrollo (no cifra), variables de entorno o un almacén de secretos en CI y producción, nunca en `appsettings.json` versionado ni en el cuerpo del pedido [REF-126].»
  - §8.13.12: «Sí: cada `Use` envuelve al siguiente; con caché por fuera de la invocación de herramientas, un acierto no ejecuta herramientas ni deja traza, y la doble instrumentación cuenta dos veces los tokens. **Criterio:** el orden de §8.5.1 y el limitador en la entrada (§8.6).»
  - §8.13.13: «Sí, como tendencia y nunca como compuerta: calibrado contra casos anotados a mano [REF-128], con k/n y Wilson, y sabiendo sus sesgos [REF-127] y que con un modelo local rinde peor [REF-118]. **Aplica** si hay conjunto de evaluación y el costo cabe (§8.9.2); la demo no trae juez.»
  - §9.9.5: dejar las dos primeras oraciones y la última; reemplazar el resto por «Cuándo hace falta un agente de MAF o un workflow, en §7.13.1 y §7.13.2.»

### EDICIO-05 · Rótulos de estación completos pese a la abreviatura de §0.5 — S3 · compresión

- **Ubicación:** §2.5 l. 407, 408, 409, 410, 412; §3.2 l. 464; §4.9.5 l. 886; §8.4.3 l. 2813; §8.6 l. 2939; §8.8 l. 3015; §8.9.1 l. 3051; §8.10.1 l. 3086; §8.10.2 l. 3090; §8.13.9 l. 3171; §9.7 l. 3435 (`04-rotulos-completos.txt`: 15 en la guía, además de las dos definiciones de §0.5).
- **Evidencia:** §0.5 dice «**«estación de 4 núcleos»** abrevia *medido en la estación de laboratorio (CPU de 4 núcleos sin GPU; …), 2026-10-28*», y el resto de la guía ya usa la abreviatura. Esas 15 son la misma frase de 18–20 palabras.
- **Propuesta (≈ 270 palabras):** reemplazar en esas 15 líneas «medido en la estación de laboratorio (CPU de 4 núcleos sin GPU; contenedor limitado a 4 CPU / 5 GB; Ollama 0.40.11), 2026-10-28» por «estación de 4 núcleos» y «medido en una estación de laboratorio con más núcleos (CPU sin GPU; contenedor limitado a 14 CPU / 34 GiB; Ollama 0.40.11), 2026-10-28» por «estación con más núcleos» (con o sin cursiva, como el entorno). En §2.5, además, una sola línea al pie de la lista: «Todas, con Ollama 0.40.11 el 2026-10-28.» Los README conservan el rótulo completo, porque son autónomos.

### EDICIO-06 · Andamiaje repetido al abrir cada sección (Cifras, Escenario y contexto, molde, paquetes) — S3 · compresión

- **Ubicación:** «**Cifras.**» en §5 l. 906, §6 l. 1326, §7 l. 1837, §8 l. 2624, §9 l. 3213; «alcanzado sólo por `OLLAMA_ENDPOINT` (por defecto `http://localhost:11434`)» 6 veces (l. 38, 486, 904, 1324, 1837, 2622, 3213); listas de paquetes en §7 l. 1837 y §9 l. 3215 (duplican D.2); la frase del molde en §2.1 l. 320, §4.1 l. 579, §5.1 l. 910, §6.1 l. 1332, §7.1 l. 1843, §8.1 l. 2628 («Molde de siempre…»), ya declarada en §0.4; «Ninguna fila ni columna queda vacía.» en §3.5 l. 520 (frase de compuerta).
- **Propuesta (≈ 380 palabras):**
  - Cada bloque «Cifras» queda en una línea: «**Cifras.** Según §0.5; modelo de chat `qwen3.5:4b@d8b0f5e9760c`, provisional (§9.7).» (en §6 se suma el de embeddings).
  - En los recuadros «Escenario y contexto» de §5, §6, §7, §8 y §9, borrar «: el servidor Ollama de prueba, alcanzado sólo por `OLLAMA_ENDPOINT` (por defecto `http://localhost:11434`)»; queda en la cabecera (l. 38) y en CTX-LOCAL (§3.3).
  - §7 l. 1837 y §9 l. 3215: reemplazar la lista de paquetes por «Paquetes: Anexo D.2 (verificados en nuget.org el 2026-10-28, iguales a los `.csproj`).»
  - Borrar las frases del molde de §4.1, §5.1, §6.1, §7.1 (segundo párrafo) y §8.1; en §2.1 conservar sólo «(copia en el Anexo C)».
  - Borrar «Ninguna fila ni columna queda vacía.»

### EDICIO-07 · El orden del molde de P-07 no se cumple en §4, §6 y §7 — S2 · edición (jerarquía)

- **Ubicación:** §4.8, §6.10, §7.11–§7.13 e índice l. 122–124.
- **Evidencia:** P-07: «el Profile se recorre una vez por sección (definición → aplicación por escenario → ejemplos → preguntas → criterios)»; §0.4 lo promete al lector. §5 (5.2) y §8 (8.2) lo cumplen; §4 (4.8) y §6 (6.10) ponen la aplicación después de los ejemplos; §7 pone criterios (7.11) antes de la aplicación (7.12) y de las preguntas (7.13). Referencias afectadas (`grep`): §7.11–§7.13, 6 en la guía; §4.2–§4.7, 19; §6.2–§6.9, 56; ninguna en `Examples/` ni `Demos/`.
- **Propuesta:** (a) obligatorio: en §7, renumerar 7.12 → **7.11 Aplicación por escenario**, 7.13 → **7.12 Preguntas guía** (7.13.n → 7.12.n), 7.11 → **7.13 Criterios de calidad y antipatrones**; actualizar índice, el ancla de l. 1835 (`#711-aplicación-por-escenario`), §0.3 («§7.13» → «§7.12»), Anexo B.1 (§7.13.1, §7.13.9 → §7.12.1, §7.12.9) y B.3 (§7.11 → §7.13). (b) Para §4 y §6, o bien mover el bloque a la posición 2 con renumeración por script (75 referencias), o bien —mínimo— cambiar §0.4 a «definiciones, ejemplos que compilan, aplicación por escenario, preguntas guía y criterios de calidad» y mover §5.2 y §8.2 al lugar equivalente. Lo que no puede quedar es el molde prometido en §0.4 y tres órdenes distintos.

### EDICIO-08 · Voz única: seis nombres para los escenarios y persona gramatical mezclada — S3 · coherencia

- **Ubicación:** nombres (`08-uniformidad.txt`): ESC-01 «consulta de datos» (§7 l. 1835, §7.12); ESC-02 «búsqueda por significado» (§6, §7.12); ESC-03 «extracción a estructura» (§5 l. 904, §6.10, §7.12); ESC-04 «acción con aprobación» (§6.10, §7 l. 1835, §7.12) y «acción con herramientas» (§4.8); ESC-05 «integración con terceros» (§7 l. 1835, §7.12) y «MCP» (§4.8, §8.2). Persona: 2.ª persona con voseo en §7.13 (l. 2580–2604: «necesitás», «podés», «Hacé», «querés», «exponés»), §9.8–§9.9 («bajá», «buscá», «revisá»), §2.6 («verificá»), §9.7 («no lo trates»); el resto, impersonal.
- **Evidencia:** §3.2 fija los nombres: «Asistente sobre datos propios», «Búsqueda semántica», «Extracción estructurada», «Agentes y herramientas», «Exposición por MCP». Un lector que busca «acción con aprobación» no lo encuentra en §3.
- **Propuesta:** reemplazar cada variante por el nombre de §3.2 (en §7 l. 1835: «ESC-04 (agentes y herramientas) … ESC-01 (asistente sobre datos propios) … ESC-05 (exposición por MCP)»). Persona: la guía es impersonal; en las preguntas guía se admite el voseo sólo en la pregunta, no en la respuesta: «Cuando podés escribir la función» → «Cuando se puede escribir la función»; «Hacé el inventario» → «Primero, el inventario»; «bajá … a `Warning`» → «se baja … a `Warning`»; «buscá dónde» → «hay que buscar dónde»; «revisá qué entra» → «se revisa qué entra»; «no lo trates como inocuo» → «no es inocuo para el español sin medirlo».

### EDICIO-09 · Preguntas guía en cuatro formatos — S3 · edición

- **Ubicación:** §4.9 usa encabezados `####`; las demás, párrafo en negrita. Sin etiqueta de escenario y contexto: §4.9 (5), §7.13 (12), §9.9 (6) = 23 preguntas; con etiqueta, en dos estilos: «*(ESC-04; todos los contextos)*» (§2.6, §5.9, §6.11) y «*ESC-01, ESC-03, ESC-04; cualquier contexto.*» (§3.9, §8.13). El criterio va como «**Criterio:**» (11), «*Criterio:*» (24), «**Criterio**:» (8), «**Aplica**/**Cuándo no**» (4) o sin marca (§6.11, §7.13).
- **Evidencia:** `08-uniformidad.txt`. `plan-de-preguntas.md` asigna a cada pregunta su ESC/CTX; la guía no lo muestra en 23.
- **Propuesta:** un formato: `**N.N.N ¿Pregunta?** *(ESC-xx; CTX-yy)*` en una línea, respuesta en el párrafo siguiente y cierre con `**Criterio:**` (las marcas «**Aplica**» y «**Cuándo no**» se mantienen cuando la respuesta las necesita). §4.9: pasar los `####` a negrita (las 5 anclas no se citan desde fuera del índice: verificar con `grep '#49'`) y quitar las entradas de 4.9.x del índice si las hubiera. Etiquetas para §4.9, §7.13 y §9.9 tomadas de `plan-de-preguntas.md` §1, columna «ESC/CTX».

### EDICIO-10 · Ubicación de snippets en formatos distintos — S3 · edición

- **Ubicación:** 59 «Compila en»: 15 en cursiva (`*Compila en …*`, §6 y §9), 44 en redonda; antes del bloque (§5, §7, A.1–A.3) o después (§4, §6, §8, §9); «l. a–b» con raya (74), con guion (35, §4.4, §4.6, §8) o «líneas a–b» (26, §7).
- **Evidencia:** `02-chequeos-salida.txt`. §0.5 promete una forma: «Compila en `Examples/NN/…`», con líneas.
- **Propuesta:** forma única, **antes** del bloque, en redonda y terminada en dos puntos: «Compila en `ruta`, l. a–b (`using` en l. c–d):». Raya (–) en los rangos; «l.» siempre (no «líneas»). Reemplazos mecánicos: `sed -E 's/l\. ([0-9]+)-([0-9]+)/l. \1–\2/g'`, `s/líneas ([0-9]+)–([0-9]+)/l. \1–\2/g`, y quitar los asteriscos de las 15 líneas `*Compila en …*`. Mover las ubicaciones que van después del bloque (§4.4, §4.6, §6, §8, §9) delante.

### EDICIO-11 · Anexo D: tres URLs rotas, versiones que faltan y columnas en cinco formas — S2 · edición (aparato de referencias)

- **Ubicación:** D.1 l. 3768–3906; citas en todo el cuerpo.
- **Evidencia (`02-chequeos-salida.txt`, `03-arxiv-versiones.txt`):**
  - Autoenlaces con espacio, que no se renderizan como enlace: REF-030 `<https://www.anthropic.com/research/building-effective-agents (la URL … redirige ahí)>`, REF-032 `<https://…/NIST.AI.100-1.pdf (DOI …)>`, REF-035 `<https://…/NIST.AI.600-1.pdf (DOI …)>`. REF-033 trae la URL sin `<>`.
  - Versión «—» o sólo año en artículos de arXiv. Consultado hoy en la API de arXiv: REF-067 v1 2024-04-09, v3 2024-08-06; REF-068 v1 2023-07-06, v3 2023-11-20; REF-090 v1 2024-07-23, v2 2024-10-17; REF-121 v1 2023-02-23, v2 2023-05-05; REF-122 v1 2024-03-20; REF-127 v1 2023-06-09, v4 2023-12-24.
  - Columna «Consulta» en cinco formas: «consulta» 79, «consultada» 39, «consultado» 17, «artículo consultado» 1, «usada» 1, con notas mezcladas.
  - Columna «Fuente» sin editor en REF-052…REF-065 («Use the IChatClient interface», «Ollama: OpenAI compatibility»), cuando el resto lleva «Microsoft Learn, «…»».
  - Citas en tres formas: `[REF-a][REF-b]` (14), `[REF-a] [REF-b]` (13), `[REF-a, REF-b]` (6).
- **Propuesta:**
  - REF-030: URL `<https://www.anthropic.com/research/building-effective-agents>` y la nota «(la URL de /engineering/ redirige ahí)» en «Versión o fecha». REF-032 y REF-035: URL sola entre `<>` y el DOI en «Versión o fecha». REF-033: `<https://www.microsoft.com/en-us/haxtoolkit/ai-guidelines/>` y el DOI en «Versión».
  - Versión: REF-067 «arXiv v1 2024-04-09; v3 2024-08-06», REF-068 «v1 2023-07-06; v3 2023-11-20», REF-090 «v1 2024-07-23; v2 2024-10-17», REF-121 «v1 2023-02-23; v2 2023-05-05», REF-122 «v1 2024-03-20», REF-127 «v1 2023-06-09; v4 2023-12-24 (NeurIPS 2023)».
  - Columna «Consulta»: sólo la fecha ISO (`2026-10-26`); «Wayback», «API de GitHub», «citas verificadas ese día», «no re-consultada» pasan a «Versión o fecha» o a una nota al pie de la tabla.
  - REF-052…REF-065: anteponer el editor: «Microsoft Learn, «Use the IChatClient interface»», «Ollama, «OpenAI compatibility»», «GitHub, dotnet/extensions, README de Microsoft.Extensions.AI.OpenAI», etc.
  - Citas: una sola forma, `[REF-a][REF-b]` (la de §5 y §6), con `sed -E 's/\] \[REF-/][REF-/g; s/\[REF-([0-9]{3}), REF-([0-9]{3})/[REF-\1][REF-\2/g'` y revisión a mano de las que llevan «§» o «Tabla».

### EDICIO-12 · Diagramas mermaid que repiten la prosa o otro diagrama — S3 · compresión

- **Ubicación (`07-mermaid.txt`, 15 diagramas):** §5.3 l. 944 (repite la oración que lo precede y lo ya dibujado en §4.5 y §5.8); §5.9.5 l. 1271 (el párrafo siguiente dice lo mismo, rama por rama); §8.4 l. 2733 (repite las definiciones de §8.1.2 y §8.1.3); §7.2 l. 1888 y §6.2 l. 1381 repiten ramas del árbol maestro de §1.2 (D3–D6), pero son el mapa propio de su sección.
- **Evidencia:** P-07 pide un solo lugar por pieza; §1.2 ya es el árbol maestro y §4.5 el único de capas.
- **Propuesta:** borrar el mermaid de §5.3 (queda la oración «El caso de uso llama a un puerto; el adaptador recibe `IChatClient`; sólo la composición elige el proveedor.» con «(diagrama en §4.5)»). En §5.9.5, conservar el mermaid y reemplazar el párrafo por «**Cuándo no** confiar en `<T>`: nunca a ciegas, porque la forma no es la validez (§5.6). En Blazor Interactive Server el streaming encaja con renderizar fragmento a fragmento (criterio propio: la documentación de MEAI no habla de Blazor).» (≈ 60 palabras). Borrar el mermaid de §8.4 o, si se conserva, quitar de §8.1.2 la segunda oración de «Qué es». §6.2 y §7.2 se conservan, con una oración que remita al árbol de §1.2.

### EDICIO-13 · Anexos y §8.12 repiten lo que ya dice el cuerpo — S3 · compresión

- **Ubicación:** D.2 «Fuera de todo camino» l. 3947 (= §5.7 l. 1198 y §8.11 l. 3098–3102); E.5 regla 3 l. 4049 (= tabla de §8.4.4, palabra por palabra en sus cinco casos); E.3 último párrafo l. 4005 (repite §0.5 y §2.5); REF-022 l. 3791 (≈ 170 palabras de versiones que ya están en D.2 y en el cuerpo); §8.12.2 viñetas 2–4 (= §5.3 y §9.8: `ContentRootPath`, `--no-launch-profile`, `Warning`), §9.8 (`Warning` y 167 s otra vez).
- **Propuesta (≈ 650 palabras):**
  - D.2: dejar el párrafo final con «Servidor de modelos» y «Verificación de la copia»; el resto, «Deprecados, retirados y sólo preview: §5.7 y §8.11.»
  - E.5 regla 3: «**Por tipo de afirmación:** existencia, invariante, tasa de este pedido, tasa de la tarea y comparación, con los mínimos y la forma de enunciarlos de la tabla de §8.4.4.»
  - E.3: borrar el último párrafo (la equivalencia de tasas entre estaciones ya está en §2.5 y el costo de lectura en la fila de la tabla).
  - REF-022: «nuget.org, API de registro y flatcontainer (versiones, fecha de publicación, deprecación y vulnerabilidades de los paquetes de D.2, y las fechas históricas citadas en §2.3 y §7.11)».
  - §8.12.2: dejar las viñetas 1 y 5; las otras tres, «Además: `--no-launch-profile` y la raíz de contenido en consolas (§9.8, §5.3).»
  - §9.8: la viñeta del registro en `Information` remite a §8.5.4.

### EDICIO-14 · Anexo F con campos desiguales y una cita que no coincide con D-06 — S3 · edición

- **Ubicación:** Anexo F l. 4083–4116; §8.7 l. 2972.
- **Evidencia:** el encabezado promete «situación, alternativas, criterio, decisión, consecuencias y la pieza»; «*Situación:*» está sólo en D-01 y D-11, y D-11 no tiene «*Criterio:*». §8.7 entrecomilla como texto de D-06 «con `ValidateScopes = false` y un pipeline Singleton, todas las conversaciones comparten…», pero D-06 dice «Singleton fuera de Development: todas las conversaciones comparten…».
- **Propuesta:** (1) agregar «*Situación:*» de una oración a D-02…D-10, tomada de su sección (p. ej. D-05: «*Situación:* SQLite no busca por vectores con EF Core y el corpus son 12 enunciados.»), y a D-11 «*Criterio:* el puerto no expone tipos de MEAI; el historial es dato de la persona; vencimiento acotado.» (2) En §8.7, citar el título de D-06 tal cual («Singleton fuera de Development: …») y agregar «y, como lo mide la prueba, con `ValidateScopes = false`», o quitar las comillas y parafrasear.

### EDICIO-15 · README de Examples/ y Demos/ sin forma común ni vuelta a la guía — S4 · edición (autocontención)

- **Ubicación:** los 13 README.
- **Evidencia:** títulos en tres formas («01 · Chat básico», «Ejemplo 04 — …», «05 — …»); secciones con nombres distintos («Comandos» / «Comandos (desde esta carpeta)», «Resultado medido» / «Resultado medido (R-LLM)», «Estructura» sólo en 01, 02, 07 y «Archivos» sólo en 04); ninguno enlaza a la guía (0 enlaces a `Dot-Net-Integration-AI-Layer-Guide.md`), aunque nombran secciones por texto; 05 y la demo no nombran ninguna sección por número.
- **Propuesta:** título «NN · Nombre» en todos (04: «04 · Embeddings y búsqueda del requisito por significado»; 05: «05 · RAG en memoria sobre los requisitos de Movilidad Urbana»); secciones fijas «Qué demuestra · Requisitos · Estructura · Comandos · Resultado esperado · Resultado medido»; en la viñeta «Sección de la guía», un enlace relativo: `[§7.3](../../Dot-Net-Integration-AI-Layer-Guide.md#73-primer-ejercicio-herramientas-finas-sobre-casos-de-uso)`. La demo, `[§9](../../Dot-Net-Integration-AI-Layer-Guide.md#9-movilidad-urbana-con-capa-de-ia-la-demo)`.

## 4. Revisado y bien

- **Índice y anclas.** Las 165 anclas internas resuelven contra los encabezados con el algoritmo de GitHub (0 rotas); el índice de §0.1 coincide con los `##`/`###` de la guía.
- **Catálogo de referencias cerrado.** Las 137 REF citadas en el cuerpo son exactamente las 137 de D.1: ninguna sin definir y ninguna sin uso; todas tienen fecha de consulta y casi todas versión o fecha de publicación (salvo las de EDICIO-11).
- **Un término, un sentido.** El Anexo C da una sola definición por término, con la sección que la enseña y la columna «Sentidos excluidos»; la tabla de diferencias de vías de §5.7 se declara única y las menciones de `/v1` remiten a ella. Es la práctica que EDICIO-02 a EDICIO-04 piden extender a las cifras repetidas.

## 5. Evidencia

En `evidencia-edicion-bibliografica/`:

| Archivo | Qué es |
|---|---|
| `palabras.awk`, `01-palabras-por-seccion.txt` | palabras por sección, prosa y código separados |
| `06-palabras-por-subseccion.txt` | lo mismo por subsección |
| `02-chequeos.py`, `02-chequeos-salida.txt` | anclas, catálogo REF, formatos de cita y de consulta, autoenlaces, repeticiones, formatos de «Compila en» |
| `03-arxiv-versiones.txt` | versiones y fechas de seis artículos, consultadas hoy en arXiv |
| `04-rotulos-completos.txt` | las líneas con el rótulo de estación completo |
| `05-repeticiones-lineas.txt` | líneas de las frases y cifras repetidas |
| `07-mermaid.txt` | los 15 diagramas con su sección |
| `08-uniformidad.txt` | nombres de escenario, persona gramatical y formato de las preguntas guía |

Comando para reproducir: `python3 -I evidencia-edicion-bibliografica/02-chequeos.py <guía>` y `awk -f evidencia-edicion-bibliografica/palabras.awk <guía>`.
