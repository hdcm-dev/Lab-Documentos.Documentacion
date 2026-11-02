# Voto del juez de impacto (ciclo 2)

Fecha: 2026-10-28. Función: ¿qué le pasa al lector si no se corrige? Se vota una opción por ítem de 01-Consolidado.md. Verificado en la guía: l.1511 («se perdió el principio»), l.2070 («no del tamaño del modelo»), l.2583 («4,65 a 4,96 s de mediana por serie»), l.4051 («unos 27 s», «unas 90 llamadas»). Sin veto.

Criterio: pesa más lo que hace que el lector **copie algo mal o crea algo falso**: una cifra mal atribuida, una prueba verde que no midió nada, un endpoint filtrado o una dependencia dibujada al revés. Pesa menos lo que sólo le cuesta tiempo de lectura. Ese costo existe, pero no es engaño.

| Ítem | Voto | Fundamento (impacto en el lector) |
|---|---|---|
| C2-01 | D | Con nombres distintos, el lector no reconoce el escenario ni lo puede buscar. El matiz sirve, pero pegado al nombre lo vuelve a fragmentar. |
| C2-02 | A | Sin un molde único, el lector no encuentra el criterio de cada pregunta, que es justamente lo que forma juicio. C y D discuten tipografía; A arregla lo que se lee. |
| C2-03 | A | Un criterio que no dice su ESC/CTX lo aplica a otro escenario. Cuesta una línea. |
| C2-04 | C | Hoy §0.4 promete un orden que §4, §6 y §7 no cumplen. Renumerar sólo §7 y ajustar el enunciado elimina la promesa falsa y no arriesga 75 anclas. |
| C2-05 | C | Con 11 cajas sin ubicar, el lector cree que la guía las cubre. La tabla reducida declara el alcance y no infla el texto. |
| C2-06 | A | Sin PG-1, PG-6 y PG-7, al lector le faltan las preguntas que forman criterio en la entrada y en las decisiones (lo exige el prompt). Agregarlas cuesta poco. |
| C2-07 | A | El lector de la guía no sabe que hay capturas. Basta el enlace. |
| C2-08 | A | Si no se corrige, el lector atribuye al 4b cifras que dio el modelo de humo y toma una corrida como «3 de 3». También cree que se midió qué tramo se pierde. Es engaño directo. |
| C2-09 | A | C borra la única atribución de modelo y mezcla estaciones, justo la comparación que §0.5 prohíbe. A comprime sin perder lo que el lector necesita para no comparar mal. |
| C2-10 | A | «Mediana por serie» sobre un rango y un 4,96 que no figura en E.4 hacen que el lector no pueda verificar. C obliga a ampliar E.4 sin ganar nada. |
| C2-11 | A | Con un presupuesto que sale de una sonda mixta y una cuenta mal hecha, el lector planifica mal su turno. |
| C2-12 | A | Si una cifra de la guía no coincide con E.4, el lector deja de confiar en el anexo. |
| C2-14 | C | Con URL rotas y sin versión de arXiv, el lector no llega a la fuente exacta. La uniformidad de forma no le cambia nada. |
| C2-15 | A | Hoy E.5 remite a una cifra que §6.9 no tiene, con el signo invertido. El lector que la siga queda contradicho. |
| C2-16 | A | Grave: el filtro corre 0 pruebas, sale 0 y el lector cree que está en verde. Basta con el filtro correcto de cada carpeta en el texto; C toca código en cuatro proyectos para lo mismo. |
| C2-17 | A | Si copia el docker run, el lector se queda con bin/ y obj/ de root que no puede borrar. El arreglo se midió (23/23, 0 archivos de root). |
| C2-18 | A | La guía afirma que con Warning no se filtra el endpoint, y es falso. Por eso un lector que confíe en ella publica host:puerto en logs o issues. C deja una frase falsa. |
| C2-19 | A | Si una caída de red se cuenta como violación, el lector concluye que el modelo falló. Con la regla basta; clasificarlo en código es opcional. |
| C2-20 | A | Con seis nombres para la misma variable, el lector exporta una y el ejemplo lee otra: la salida se pierde sin aviso. |
| C2-21 | A | Si la confirmación aparece bajo el pedido equivocado, el lector malentiende el workflow. Son dos cambios chicos. |
| C2-22 | A | §0.5 ya define las formas abreviadas, y GiB es la unidad real. La cifra sigue rotulada con su estación, así que abreviar no expone al lector a comparar estaciones. |
| C2-23 | A | Si el README dice 17 y la corrida da 18, el lector cree que falló algo. |
| C2-24 | A | Un término definido que después no se usa deja al lector sin definición de «Contexto», que se usa todo el tiempo. |
| C2-25 | A | El ejemplo canónico de ESC-01 lleva a ESC-04 en el árbol, así que la herramienta de decisión enseña lo contrario. |
| C2-26 | A | El lector se encuentra con «semilla», «Wilson» y «discordante» en §0.5 sin definición, y «semilla» no se define en ningún lugar. |
| C2-27 | A | Si sigue la ruta ACT-DEV, el lector llega a §7.3 sin los términos de §7.1. |
| C2-28 | C | Al lector lo daña el exceso de prosa, y eso se recorta ítem por ítem (C2-29, C2-30, C2-66, C2-67). Un tope global corre el riesgo de que se pierda evidencia. Hace falta medir bien. |
| C2-29 | A | Cinco repeticiones y dos tablas casi iguales hacen que el lector busque diferencias que no existen. Con una sede y la remisión alcanza. |
| C2-30 | A | Una pregunta que repite el cuerpo no forma criterio. Al conservar el criterio y remitir, se queda lo formador. |
| C2-31 | A | El lector cree que Relevance/Coherence miden corrección, y el laboratorio vio un 4 sobre una respuesta incorrecta. Es una lección que la guía debe dar, con el N declarado. |
| C2-32 | A | Una prueba verde que no midió nada enseña al lector a confiar en un juez que no corrió. |
| C2-33 | A | k ≥ m−2 hace fallar por azar, y el lector toma ese rojo por una regresión. La existencia sí es una aserción legítima y conviene nombrarla. C saca una prueba útil y D deja el código contradiciendo la regla. |
| C2-34 | A | Con 7 contra 1, una forma de la regla da «difiere» y otra no: el lector concluye distinto según dónde lea. |
| C2-35 | A | Si la fila y la comparación pareada usan otra unidad, el lector no entiende «2 y 1» sobre 10/12 contra 10/12. |
| C2-36 | A | Dos cotas para 0/10 sin decir cuál es cuál parecen un error, y el estimando depende de m. |
| C2-37 | C | Con la flecha invertida, el lector aprende la dependencia al revés. Hay que corregirla, no borrarla, porque §5 es donde se aplica la regla. El resto de EDICIO-12 es compresión sin pérdida. |
| C2-38 | A | Si la decisión se apoya en un «no separado» y en «cuesta poco» sin medir, el lector la generaliza. Los textos de ADV-01 la acotan. |
| C2-39 | A | Si el formulario no marca el dato inventado, el operador lo confirma. Para el lector, la invariante del clic no protege. Va con prueba. |
| C2-40 | A | El árbol manda a MAF para algo que la demo hace sin MAF, y el lector suma una dependencia innecesaria. |
| C2-41 | A | Si el lector copia el comando, despliega con EnableSensitiveData y puertos abiertos, y en Production le revienta sin saber por qué. Con la redacción medida de CAT-OP-04 alcanza. D toca código sin necesidad. |
| C2-42 | A | El lector cree que Ollama queda en loopback y expone el puerto. La frase es falsa. |
| C2-43 | A | El lector cree que el modelo elige el paso, cuando lo elige el GroupChatManager (XML del paquete). Diseñaría sobre un supuesto falso. |
| C2-44 | A | Con la doble negación, el lector entiende lo contrario de lo que dice el registro. |
| C2-46 | A | Si lee «0/10» donde el registro da 4 o 5, el lector cree que la mitigación es total. CAT-FO-05 da las dos cifras sin ambigüedad. |
| C2-47 | A | Si el lector copia el extractor, inyecta datos en el rol System. Hace falta el patrón correcto, con prueba. |
| C2-48 | A | Una cita que exagera la fuente hace creer al lector que hay mitigación completa. |
| C2-49 | A | El lector busca en 08 un límite que no existe. |
| C2-50 | A | Con un Scoped tratado como si fuera por pedido en Blazor Server, el lector filtra estado entre usuarios. Va con la referencia oficial. |
| C2-51 | A | El singleton que retiene el HttpClient deja el DNS viejo en producción. La corrección es de una línea y va con referencia. |
| C2-52 | A | La demo viola las reglas R3 y R6 que la guía enseña, así que el lector aprende que la regla es decorativa. Hay que corregirla en código. |
| C2-53 | A | Un motor que no ve genéricos de método le da al lector una falsa garantía; el caso rojo lo demuestra. |
| C2-54 | C | Con el diagrama de la demo incompleto, el lector no ubica PERSA ni el limitador. Con el mermaid y una oración se resuelve sin mover código. |
| C2-55 | A | Basta declararlo, porque el lector ya tiene la regla. Mover el archivo cuesta más que lo que aporta. |
| C2-56 | A | Si 10 y la demo orquestan en capas distintas y nadie dice dónde va el workflow, el lector elige al azar. |
| C2-57 | A | Con dos tamaños no se puede afirmar nada sobre el tamaño en general. |
| C2-58 | A | Sin la oración, el lector cree que el 4b se eligió midiendo. Las corridas extra no hacen falta para no engañar. |
| C2-59 | A | Si la cifra de la vía B no es reproducible, el lector no puede verificarla. La prueba con m = 10 la vuelve evidencia. |
| C2-60 | C | Una prueba que depende del orden de llegada falla al azar, y el lector pierde confianza en el limitador. TaskCompletionSource la vuelve determinista. |
| C2-61 | A | Si el lector copia el patrón y no sabe que es una excepción, pone el timeout donde no corresponde. |
| C2-62 | A | El lector dimensiona la cola sin tener en cuenta la latencia y suma timeouts. |
| C2-63 | A | Son detalles S4 de bajo daño. Con texto alcanza. |
| C2-45 | A | Es un lote de forma de bajo riesgo, y cada parte ahorra una duda. |
| C2-64 | A | Con campos desiguales en el Anexo F, el lector no puede comparar decisiones. |
| C2-65 | A | Una forma única ayuda al lector a encontrar dónde compila cada snippet. |
| C2-66 | A | El lector relee en cada sección lo que ya está en §0.4, §0.5 y D.2. |
| C2-67 | C | Las remisiones ahorran lectura. La regla 3 de E.5 es operativa y le sirve al lector parado en el anexo. |
| C2-68 | C | Impersonal en el cuerpo, y en las preguntas guía, que interpelan al lector, el voseo se lee natural. |
