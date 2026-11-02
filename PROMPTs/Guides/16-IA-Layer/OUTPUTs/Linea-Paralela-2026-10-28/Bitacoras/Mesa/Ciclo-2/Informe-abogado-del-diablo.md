---
doc_id: BIT-16-C2-INF-abogado-del-diablo
doc_type: informe-de-mesa
title: Relectura integral (ciclo 2) — Abogado del diablo
fecha: 2026-10-28
rol: Abogado del diablo
mandato: atacar la recomendación dominante de la guía y los consensos del panel (contexto fijo, «el modelo propone y la persona confirma», qwen3.5:4b para la demo, MAF frente a SK, compresión que recorte evidencia); hasta 6 hallazgos
objeto: Dot-Net-Integration-AI-Layer-Guide.md (§1, §2.5, §5.4, §5.6, §5.8, §6.2–§6.11, §7.4–§7.6, §7.13, §9, Anexo E.4), Demos/MovilidadUrbana.Asistente (csproj, ChatDelAsistente.razor, historial), y los doce Informe-*.md del ciclo 2
a_ciegas: no (entra después, por mandato)
evidencia: evidencia-abogado-del-diablo/
---

# Informe del Abogado del diablo — relectura integral, ciclo 2

## 1. Alcance y método

Leí los doce informes del ciclo 2 y, de la guía, las secciones donde viven las recomendaciones que el panel dio por buenas. El ataque es siempre el mismo: ¿la recomendación se sostiene con lo que la guía misma midió, en el contexto que la guía dice que es el suyo (CTX-LOCAL × CTX-PROTO), o se apoya en una medición de otro contexto, en un «no se separó» leído como «alcanza», o en una invariante que no cubre la falla que importa? No corrí nada contra el modelo: los seis hallazgos se sostienen con la guía, la tabla E.4, el código de la demo y los informes (R-LLM no aplica).

Evidencia en `evidencia-abogado-del-diablo/` (extractos con número de línea de la guía o del código, rutas relativas a la carpeta de la guía):

- `01-maf-y-la-demo.txt`: paquetes de la demo (sin `Microsoft.Agents.*`), historial multiturno propio, líneas del árbol que mandan «sesión de varios turnos» a MAF.
- `02-confirmacion-sin-marca.txt`: el formulario de alta de la demo y las frases de la guía sobre la confirmación.
- `03-contexto-fijo-costo.txt`: dónde se decidió el contexto fijo y lo que cuesta un token en la estación de 4 núcleos.
- `04-modelo-demo.txt`: la base de la elección del 4b y lo que quedó sin medir.
- `05-garantia-de-sesion.txt`: §1.1 frente a §7.3.2, §8.3.2 y §9.6.
- `06-compresion-edicio-02.txt`: lo que la compresión de EDICIO-02 quitaría de §2.5 y §5.4.

## 2. Hallazgos

### ADV-01 · S2 · evidencia — «Con 12 enunciados alcanza el contexto fijo» se decidió en la estación donde el token no cuesta, y la guía afirma un costo local que contradice su propia tabla

- **Ubicación:** §6.9 (l. 1738, «Con 12 enunciados alcanza el contexto fijo, y RAG sobre este corpus es didáctico»); §6.11.15 (l. 1806, «en local reprocesarlos cuesta poco»); §9.5.2 (l. 3362, título «D5, con 12 enunciados alcanza el contexto fijo»); §6.2, tabla, fila 0 (l. 1376, «Reenviarlo cuesta demasiado en tokens o en espera»).
- **Evidencia (`03-contexto-fijo-costo.txt`):**
  - La comparación de §6.9 se corrió sólo en la estación con más núcleos y dio **no separado** en las tres filas. «No separado con este N» no es «equivalente» ni «alcanza»: es ausencia de evidencia en los dos sentidos. Además, en calidad absoluta, el contexto fijo pasó **0 de 4** no respondibles en 3 de 3 y la demo dio 8/12 [0,39; 0,86]: la cota inferior no sostiene un «alcanza» para nada que no sea un prototipo.
  - El argumento de costo es el que la guía usa para elegir el escalón 0 (fila 0 de §6.2: deja de convenir cuando «cuesta demasiado en espera»), y ese costo **sólo se midió donde no muerde**. La guía misma dice que en la de 4 núcleos «no se afirma ningún ahorro» (l. 1738) y, dos secciones después, afirma lo contrario: «en local reprocesarlos cuesta poco» (l. 1806). Con su propia cifra (§2.5 l. 412 y §6.4.3 l. 1467: unos 19 tok/s, «unos 50 s por cada 1000 tokens»), 516 tokens son del orden de 25 s de lectura por pregunta en la estación de 4 núcleos, y 241 (RAG) la mitad; y la caché de prefijo, con el 4b, fue **parcial** (71,7 → 26,0 s con un prompt de ayuda de unos 1540 tokens). Eso no es «poco», y no está medido con el corpus de la ayuda.
  - El umbral de la escalera («cuesta demasiado») no tiene número ni procedimiento; §6.11.15 lo admite («Ese umbral no se midió acá»), pero igual cierra la elección.
- **Por qué importa:** es la recomendación dominante de §6 y la que el lector de CTX-LOCAL va a copiar. El contexto fijo puede ser la elección correcta para 12 enunciados, pero por **simplicidad y frescura** (se leen del código por reflexión, no hay índice que se desactualice), no por calidad ni por costo demostrados.
- **Propuesta:**
  - §6.9, reemplazar «Con 12 enunciados alcanza el contexto fijo, y RAG sobre este corpus es didáctico.» por: «Con 12 enunciados, la guía elige el contexto fijo por simplicidad y porque se lee del código, no porque haya ganado: en calidad no se separó de RAG con este N, y ninguno de los dos se abstuvo bien (0 y 1 de 4 no respondibles). El costo se midió sólo en la estación con más núcleos; en la de 4 núcleos, a unos 50 s por cada 1000 tokens de prompt (§6.4.3), mandar 516 en lugar de 241 es una diferencia que el lector tiene que medir en su equipo antes de decidir.»
  - §6.11.15, reemplazar «y en local reprocesarlos cuesta poco» por «y en local se pagan en pared: en la estación de 4 núcleos la lectura rondó 50 s por cada 1000 tokens (§6.4.3), y el contexto fijo de la ayuda no se midió ahí».
  - §9.5.2, título: «**D5, contexto fijo con 12 enunciados.**» (sin «alcanza»), y agregar al final del párrafo: «Ese 8/12 es una tasa de prototipo, no un piso para CTX-PROD.»
  - §6.2, fila 0, «Deja de convenir cuando»: «Reenviarlo cuesta en pared más de lo que el caso tolera, medido en el equipo de destino (en la estación de 4 núcleos, unos 50 s por cada 1000 tokens sin caché, §6.4.3)».

### ADV-02 · S2 · coherencia/seguridad — «El modelo propone y la persona confirma» se presenta como invariante, pero lo invariante es el clic, no la detección: el formulario no marca el dato inventado con forma válida

- **Ubicación:** §9.5.1 (l. ~3352, «Lo que no depende de la composición es la invariante: nada se escribe sin el clic y el dato inventado queda a la vista»); §9.9.4 (l. 3480, «la confirmación no se apoya en una tasa: es una invariante»); §1.2 (l. 271, «toda rama que escribe termina en una confirmación»); demo `Agregado/Presentation/Componentes/Paginas/ChatDelAsistente.razor`, l. 36–58.
- **Evidencia (`02-confirmacion-sin-marca.txt`):**
  - La guía midió que el 4b inventa «3400» para «CP 34» en 8/10 (`Examples/03`, §5.6) y 10/10 por `/v1` (§9.5.1), y que «3400» **pasa las reglas** y «llega a la pantalla sin un error» (§5.6, l. 1144). El formulario de la demo muestra el valor en un `<input>` igual a cualquier otro: no hay marca de «este valor no está en tu texto» ni comparación con el pedido. «Queda a la vista» quiere decir «está en un campo editable», nada más.
  - Lo que la invariante garantiza es **0 escrituras sin el clic**. Que la persona note el 3400 antes de hacer clic es una **tasa humana** que la guía no midió ni nombra. Decir «la confirmación no se apoya en una tasa» confunde las dos cosas.
  - Hay un control **determinista, de código**, coherente con el principio rector («la aplicación valida»): comparar cada campo propuesto con el texto de la persona y marcar los que no aparecen literales (el «3400» no está en «CP 34»). No requiere modelo y se prueba en `Cableado/` con el mismo «modelo» falso que ya propone «3400».
  - La confirmación tampoco cubre lo que no llega a ella: en D2 el clasificador mandó el alta a la consulta en 10/10 y en 1/10 la respuesta afirmó habitantes que no están en los datos (§9.5.1, l. 3354); la guía lo deja en el aviso genérico (CTRL-12). El principio protege escrituras; la falla dominante medida en la demo está en el **ruteo** (D2 10/10, A07 3/3), y no hay criterio para él.
- **Propuesta:**
  - §9.5.1, reemplazar «y el dato inventado queda a la vista» por «y el dato inventado queda en el formulario, **sin marca**: que la persona lo detecte antes del clic es una tasa humana que esta guía no midió».
  - §9.9.4, reemplazar «así que la confirmación no se apoya en una tasa: es una invariante.» por «La invariante es que nada se escribe sin el clic; que el clic sea informado no lo es. Por eso conviene marcar, con código, los campos cuyo valor no aparece en el texto de la persona: el «3400» no está en «CP 34».»
  - Demo (preferido): en `PropuestasDeLocalidad` agregar una marca por campo «no figura en tu pedido» (comparación literal normalizada del CP y de los habitantes contra el texto), mostrarla junto al `<Error>` del campo y fijarla con una prueba de `Cableado/` que use el «modelo» que propone «3400». Si no se cambia el código: declararlo como deuda en §8.3.2, fila nueva «Marca de dato no presente en el pedido».
  - §9.5.1, al final del párrafo de D2: «Clasificar es la etapa que más falló en la demo (D2 10/10, A07 3/3) y no tiene control: antes de sumar estrategia, medir el clasificador como tarea propia (al menos 10 pedidos por intención, §8.4.4).»

### ADV-03 · S2 · evidencia — La compresión EDICIO-02 recorta evidencia y, en §2.5 y §5.4, atribuye al 4b lo que midió el modelo de humo en otra estación

- **Ubicación:** Informe-edicion-bibliografica, EDICIO-02 (viñetas «§5.4» y «§2.5»); guía §2.5 l. 403 y l. 410; §5.4 l. ~1062.
- **Evidencia (`06-compresion-edicio-02.txt`):**
  - §2.5 abre la lista con «el modelo es `qwen3.5:4b@d8b0f5e9760c`, provisional, **salvo donde se nombra otro**» (l. 403). En la viñeta de la ventana, la única mención del otro modelo es «Invariante con `qwen2.5:0.5b`, prueba en `Examples/01-…/NumCtxConModeloTests.cs`», justo la oración que EDICIO-02 manda quitar. Sin ella, el lector atribuye al 4b el 6843 → 2050 y el «14, 30, 34», que son del modelo de humo con `MaxOutputTokens` 3 (EXPERT-03 lo documenta con el registro). La compresión convierte una ambigüedad en un error.
  - En §5.4, el texto propuesto («Con `num_ctx` 4096, Ollama recortó un prompt de 6843 tokens a 2050, con fin `stop` y sin error, también con el modelo de chat») borra modelo, estación, estimando y N, y funde dos mediciones que §0.5 prohíbe comparar: 6843 → 2050 es del 0,5b en la estación de 4 núcleos; con el 4b el prompt era **5114** y la estación, la de más núcleos. «Recortar redundancia no autoriza recortar evidencia» (P-07): esta parte de EDICIO-02 la recorta.
  - EDICIO-01 reconoce que lo recortable sin perder evidencia son ≈ 3 400 palabras de ≈ 60 000; las 370 de EDICIO-02 no compensan introducir una atribución falsa en la sección de entrada de ACT-ARQ.
- **Propuesta:** presidencia aplica de EDICIO-02 **sólo la viñeta de §8.8** (que remite a la tabla de §6.5 sin reenunciar cifras). Para §2.5 rige la reescritura de EXPERT-03, que conserva los dos modelos con su estación. Para §5.4, si se comprime, el texto mínimo es: «**La ventana se pide en cada pedido.** Con `num_ctx` 4096, Ollama recortó sin error y con fin `stop`: 6843 → 2050 tokens con el modelo de humo (estación de 4 núcleos) y 5114 → 2050 con el 4b (estación con más núcleos); 3 de 3 semillas cada uno, este pedido. Tabla y detector en §6.5. Dos reglas de configuración:». Regla general para la aplicación de parches de compresión: ninguna oración que nombre modelo, estación, estimando o prueba se quita si es la única en su sección que lo hace.

### ADV-04 · S2 · coherencia — El árbol manda a MAF la «sesión de varios turnos», y la demo tiene sesión de varios turnos sin MAF; «recomendado para proyectos nuevos» viene de un blog del fabricante anterior al GA y frente a SK, no frente a MEAI

- **Ubicación:** §1.2, nodo D5 (l. 265, «¿Hace falta sesión de varios turnos, aprobación integrada o componerlo?» → «Agente de MAF»); §7.13.1 (l. 2580); §5.8, tabla, fila MAF («recomendado para proyectos nuevos [REF-061]»); Anexo D, REF-061 (l. 3830, blog 2025-10-07).
- **Evidencia (`01-maf-y-la-demo.txt`):**
  - La demo no referencia ningún paquete `Microsoft.Agents.*` (csproj: EF Core Sqlite, `Microsoft.Extensions.AI` 10.11.0, OllamaSharp 5.5.0, OpenTelemetry) y tiene **historial de varios turnos** propio (`IHistorialDeConversacion`, `HistorialEnMemoria`, D-11: últimos 6 turnos por `SessionId + ConversacionId`). Es decir, la pieza que la guía presenta como modelo de referencia cae en la rama «sí» del nodo D5 y no usa MAF; §9.9.5 lo justifica por otro motivo («ninguna herramienta escribe»). El árbol y la demo se contradicen en el criterio que más lectores van a seguir.
  - Lo que la guía midió de MAF empuja hacia «no por defecto»: MAF 1.26.0 ejecuta la llamada de una sesión deserializada alterada y obliga a una guarda propia (§7.5.3); cinco trampas de API en 1.26.0, dos de ellas en la propia página de documentación (§7.6.3); una estable por semana entre septiembre y octubre (§7.11, criterio 9); la encuesta como workflow dio lo mismo que un `for` (§7.6.1).
  - REF-061 es el README de SK y un blog de 2025-10-07, seis meses antes del GA de MAF (2026-04-02/03). Lo que dice es «SK → MAF» para quien elige entre los dos marcos de agentes; la tabla de §5.8 lo lee como recomendación general «para proyectos nuevos», que el lector entiende también frente a MEAI solo.
- **Propuesta:**
  - §1.2, nodo D5: «¿Hace falta aprobación integrada dentro del turno, middleware de agente o componerlo en un workflow?» (sin «sesión de varios turnos»), y agregar a las «Dos lecturas del árbol»: «El historial de varios turnos no exige MAF: la demo lo guarda con una lista de mensajes por sesión (D-11); `AgentSession` lo resuelve, no lo justifica.»
  - §7.13.1, reemplazar «cuando necesitás sesión de varios turnos, aprobación integrada…» por «cuando la sesión tiene que viajar con el agente (persistirse, reanudarse o compartirse en un workflow), aprobación integrada…»; y agregar: «La demo tiene varios turnos y no usa MAF.»
  - §5.8, fila MAF, «Cuándo se elige»: «cuando el problema pasa a ser orquestación (§7). Para quien elige marco de agentes, Microsoft recomienda MAF sobre SK en proyectos nuevos [REF-061]; frente a MEAI solo, no hay recomendación: se sube cuando aparece una necesidad de §7.13.1. Versión fijada: 1.x publica una estable por semana (§7.11).»

### ADV-05 · S3 · evidencia — `qwen3.5:4b` para la demo: la razón de la elección no se reproduce en la demo, el 2b nunca se midió en la composición de la demo, y la demo no se midió en el equipo que más se parece al del lector

- **Ubicación:** §9.7 (l. 3433, rótulo «se eligió frente a `qwen3.5:2b` porque normaliza al catálogo»; l. 3445, «D1 y D3 **no se reproducen**»); §9.5 (l. 3316, «en la de 4 núcleos, no medido»); §9.8 (l. 3455, 300 s de timeout por 167 s de un prompt de 2943 tokens).
- **Evidencia (`04-modelo-demo.txt`):**
  - La única ventaja del 4b que separa (D3, 0/10 frente a 10/10, 10 pares discordantes) se midió por `/v1` con extracción en una llamada; en la composición de la demo D3 dio 5/10 [0,24; 0,76] con el 4b. El 2b no se corrió en la composición de la demo: no hay comparación que sostenga el 4b **para la demo**. En D1, el criterio de §9.7 favorece al 2b (1/10 frente a 10/10).
  - La demo sólo se midió en la estación con más núcleos. En la de 4 núcleos (la que §0.5 y E.4 usan como referencia de CTX-LOCAL y la más parecida a una notebook), un turno de la demo son dos llamadas con salida estructurada; las propuestas de escritura del 4b ahí tardaron 13,9–26,4 s de mediana por llamada (E.4) y el timeout de 300 s salió de un prompt que tardó 167 s. La guía no dice cuánto tarda un turno de la demo en ese equipo.
  - §9.7 dice bien que el modelo es provisional y que la demo no se apoya en las tasas; lo que queda sin sostener es la frase de elección, que el lector lee como «probado que el 4b es mejor para esto».
- **Propuesta:**
  - §9.7, después del bloque citado, agregar: «En la composición de la demo, el 2b no se midió y la ventaja del 4b en D3 no se reprodujo (5/10): **para la demo, la elección no está sostenida por una medición**; el 4b queda por continuidad con §5–§8. La demo tampoco se midió en la estación de 4 núcleos: ahí cada turno son dos llamadas del orden de 14–26 s cada una (E.4, propuestas de escritura), y el timeout de 300 s es para ese equipo.»
  - Opcional, si la presidencia quiere cerrar la duda con dato (R-LLM-1…5): correr `ConModelo/` de la demo con `qwen3.5:2b@0689d44085e0` en la estación con más núcleos (D1, D3, D6, 10 semillas, criterio escrito antes) y un turno de D5 en la de 4 núcleos para la pared.

### ADV-06 · S4 · coherencia — §1.1 cuenta «datos de una sola sesión» entre las garantías, y el resto de la guía dice que eso aísla pero no autoriza

- **Ubicación:** §1.1 (l. 241, «Las garantías que la guía da (cero escrituras sin confirmación, datos de una sola sesión, ninguna herramienta fuera de la lista) son invariantes del código»); contraste con §7.3.2 (l. 2002), §8.3.2 (l. 2718), §9.6 (l. 3426).
- **Evidencia (`05-garantia-de-sesion.txt`):** §7.3.2, §8.3.2 y §9.6 dicen, con la misma fórmula, que el aislamiento por sesión «aísla datos, pero **no es control de acceso**»: `X-Sesion-Id` lo elige el cliente y otro cliente que lo adivine ve y borra. §1.1 es lo primero que lee ACT-ARQ y lo pone como garantía sin la salvedad; un lector de CTX-SENS se queda con la versión fuerte.
- **Propuesta:** §1.1, reemplazar «datos de una sola sesión» por «las herramientas leen sólo la sesión del ámbito (aísla datos; no es control de acceso, §8.3.2)».

## 3. Lo que ataqué y se sostiene

- **El principio rector como tal.** «El modelo propone; la aplicación ejecuta, autoriza y valida» resiste: cada falla medida (3400, «piedra», la sesión alterada de MAF, el truncado silencioso) se contuvo con código y no con instrucciones. ADV-02 no lo discute: pide que la aplicación también valide la **fidelidad** al texto, que es la parte del principio que falta en el alta.
- **No ofrecer la herramienta de baja en la demo.** Con herramienta de baja, el 4b y el 2b borraron sin confirmar en 10/10 cada uno (§9.5.3): la decisión de proponer y usar la operación normal está mejor sostenida que cualquier alternativa con aprobación integrada, y la guía enseña esa alternativa con su guarda en `Examples/07`.
- **La honestidad del «no separado».** §6.9 escribe el criterio antes, compara pareado y declara los límites (el ejemplo de cita copiado, la clave de habitantes injusta). Lo que ataco en ADV-01 es la frase de cierre, no el método.
- **El rótulo «provisional».** §9.7 ya advierte que las tasas no se trasladan; ADV-05 sólo pide que la frase de elección no diga más que eso.
- **La compresión en general.** EDICIO-03, -04, -05, -06 y -13 no quitan evidencia que no esté en otro lugar de la guía con su rótulo; el problema es puntual (ADV-03).
