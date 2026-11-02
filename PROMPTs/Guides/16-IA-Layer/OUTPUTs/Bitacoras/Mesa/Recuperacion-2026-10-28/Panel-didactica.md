# Panel de recuperación: Didáctica

Fecha: 2026-10-28. Mesa de recuperación, en <equipo-de-contingencia>. Matriz: [`01-Matriz.md`](01-Matriz.md).

**Mandato.** Que el lector de la guía (§0.2, rutas de lectura) entienda una sola cosa por término (C5), que lo que la guía afirma como medido lo pueda reconocer y reproducir (§0.4), que los ejemplos no enseñen lo contrario de la prosa y que el orden de lectura aguante la recuperación. Me abstengo en lo que es R-PRIV, arnés, infraestructura, seguridad u operación sin efecto directo en la enseñanza.

Las líneas citadas son de la guía base 0.10.1 (`Dot-Net-Integration-AI-Layer-Guide.md`) y de los inventarios de esta carpeta.

## Posiciones

| Ítem | Opción | Fundamento |
|---|---|---|
| REC-01 | A | La recuperación cambia contenido que se enseña (tablas de §5.6, §8.5, §10.4). El lector necesita ver en el encabezado que la versión cambió. «En revisión» es lo honesto mientras las cifras del rótulo de §0.4 (l. 163) apunten a un servidor retirado. C mete versiones intermedias que nadie lee. B oculta el cambio. |
| REC-02 | A | El ejemplo canónico del rótulo en §0.4 (l. 163) y los tres puntos de §5.7 (l. 1012–1015) nombran el «servidor compartido» y el «Ollama propio», que ya no existen. Con B, el lector no puede reproducir nada de lo que la guía le muestra como observado. C deja una guía con dos regímenes de rótulo, que es más difícil de leer. El reparto entre estaciones (A frente a D) lo dejo a Entorno. |
| REC-03 | A | La guía crece y cambia en varias Partes a la vez. La coherencia de un término a lo largo de §3, §8 y el Anexo C sólo se ve leyendo entera (C5). B relee un texto cuyas cifras van a cambiar. C no detecta las contradicciones entre secciones tocadas y no tocadas. |
| REC-04 | A | Revisan otra guía con otra numeración. Tratarlos como hallazgos (B) obliga al jurado a traducir cada observación. Como insumo, mapeados con DECI-30, no se pierden. |
| REC-05 | abstención | Infraestructura y decisión del PO. Sólo pido que el texto de prerrequisitos de §0.3 (l. 139), que nombra el «Ollama propio», quede alineado con lo que se decida. |
| REC-06 | abstención | R-PRIV y arnés. |
| REC-07 | abstención | Arnés. |
| REC-08 | A | §5.7 (l. 1012) ya enseña que `num_ctx` recorta en silencio. La regla «mismo num_ctx en todos los clientes» es la consecuencia práctica de esa lección, y la recarga de 10,5 a 16,1 s (N=5) le da al lector un costo concreto. C mide sin enseñar. B mide una ventana que la guía dice que no conviene. |
| REC-09 | A | §5.2 (l. 879–884) enseña streaming, y el ejemplo 01 guarda el parcial cortado como si estuviera completo. Un ejemplo que hace lo contrario de lo que se enseña es lo peor para un lector que copia. C declara el antipatrón y deja el código que lo comete. |
| REC-10 | A | La tabla de §5.6 (l. 998–1003) es la referencia del lector cuando cambia de adaptador. «`/v1` no admite `tool_choice`» es impreciso, porque el cliente lo envía y es el servidor el que no lo honra. TopK y MaxOutputTokens son las sorpresas que el lector va a encontrar. C corrige una fila y deja afuera las dos que más confunden. |
| REC-11 | abstención | Seguridad. |
| REC-12 | abstención | Seguridad y arquitectura. Si se adopta A, pido que el matiz del diagrama de §5.4 no contradiga lo que §12.3 diga sobre la caché. |
| REC-13 | abstención | Operación. |
| REC-14 | abstención | Arquitectura. |
| REC-15 | B | Citar una tabla medida por `/v1` y con otra herramienta, que el propio inventario declara «no trasladable», en el texto de una decisión obliga al lector a cargar con dos rótulos de alcance al mismo tiempo. Si hace falta evidencia, que se re-mida con la demo de la base y con el rótulo de §0.4. Quitar la alternativa 7b inexistente es obligatorio en las dos opciones. |
| REC-16 | A | El CP 34 → 3400 es un contraejemplo concreto de que «pasa las reglas» no es «es verdad». Es el mejor material didáctico para §8.5. B mide sin enseñar. La prueba sin modelo deja la lección reproducible con `--fake`. |
| REC-17 | A | l. 1075 le promete al usuario «entre 3 y 60 caracteres», y el dominio no lo aplica. La guía no puede enseñar una regla falsa. A comprueba primero y, si falla, deja en la fila «Modificado a causa de la IA» la lección de que la IA destapa huecos del dominio heredado. B corrige el texto pero pierde esa lección. C esconde la regla en el adaptador, lejos de donde el lector la busca. |
| REC-18 | A | §0.4 (l. 169) dice que el cliente guionado «muestra conducta del código, nunca del modelo», y una salida `--fake` de 51/52 se puede leer como medición. Rotularla es obligatorio. El contraste Relevance aprueba / Equivalence y Completeness detectan (N=1), rotulado como observación, enseña por qué se elige un evaluador en §10.5–§10.6 mejor que cualquier párrafo abstracto. |
| REC-19 | A | La base enseña una sola regla (Clopper-Pearson y entrada distinta, l. 168 y 2829), y mezclar Wilson rompe C5. El estimando («describe este pedido, no la tarea») le dice al lector qué describe un número. Es la pieza que más le falta a §10.4. C deja afuera justo eso. D reescribe 365 cifras sin ganancia para el lector. |
| REC-20 | A | Una ADR enseña más cuando muestra la alternativa descartada y por qué. X2 y D6, rotulados, son la evidencia que motiva la aprobación impuesta por el código en §8.5 y §11.3. C desperdicia esa evidencia. D reabre una demo coherente. |
| REC-21 | C | Re-correr y sumar la fila del 4b y la frase del tokenizador alcanza para la lección («el recorte depende del modelo y del tokenizador»). Un segundo mecanismo (el detector que lanza) junto a `GuardaDeTruncado` le muestra al lector dos piezas para lo mismo sin un criterio de cuándo usar cada una. Si Arquitectura lo quiere, que vaya sólo en el ADR como alternativa. |
| REC-22 | abstención | Laboratorio. Sólo pido que §5.7 (l. 1015) y §6.3 digan lo mismo después de aplicar lo que se decida. |
| REC-23 | A | «Sin negaciones dobles» y «la garantía en una sola frase» son criterio de redacción para el lector. «Repitió el texto inyectado», rotulado, enseña que no ejecutar no es no contaminar la salida. C se queda con la frase pero sin el ejemplo que la justifica. |
| REC-24 | abstención | Seguridad. Noto que E.3 le da una instrucción al lector, así que la advertencia, si se suma, va en el mismo paso y no sólo en §12.6. |
| REC-25 | abstención | MCP y seguridad. |
| REC-26 | A | ADR-11 promete 5 reglas, y la demo tiene 4. Una promesa incumplida en el texto desorienta. Que AC-5 no se presente como suficiente y que se declaren los agujeros enseña el límite de una prueba de arquitectura. C cambia el sentido de la quinta regla respecto de lo que ADR-11 ya enseña. D deja la lección de las mutaciones afuera. |
| REC-27 | abstención | Seguridad y laboratorio. |
| REC-28 | A | «Citar no es fundamentar» y «el formato de cita se copia del ejemplo» son lecciones que el lector de §7.4 necesita. Una no respondible cercana en el oro de 07 las vuelve verificables. C deja sólo prosa, que se olvida. El perímetro de la demo no cambia. |
| REC-29 | A | El modelo dice «cero» sin consultar: es la lección de §7 y §8.2 que más se repite en la práctica. Con un oráculo en 08 o 09, el lector puede correrla. C la deja en prosa. |
| REC-30 | A | El Anexo C (l. 4566) da «flujo de trabajo» como equivalente, mientras la guía usa «workflow» a secas (42 apariciones, DECI-16). Un glosario que ofrece un término que el texto no usa confunde al lector que busca. «— (no se traduce)» con barrido lo cierra. Los casos rojos de SK le sirven al lector de §9.7, que viene de otro marco y no ve las fallas silenciosas. |
| REC-31 | abstención | Datos personales. |
| REC-32 | A | La escalera de §8.1 (l. 1919) y la definición de §8.7 (l. 2043, «el artefacto no fija el escalón») son coherentes de punta a punta. Con la definición del insumo, PD-1, PD-5 y PD-6 pasarían a ser agentes y C5 se rompería (DECI-17). La nota «hay fuentes que llaman agente a todo bucle de herramientas; acá ese bucle es el escalón 1» es justo lo que necesita el lector que viene de otra fuente. B lo deja sin ese puente. |
| REC-33 | abstención | R-PRIV de la bitácora. |
| REC-34 | A | Las coincidencias confirman la base. Reabrirlas no le aporta nada al lector. |
| REC-35 | abstención | Paquetes. |

## Pedidos transversales a la relectura (REC-03)

1. Que el rótulo modelo de §0.4 (l. 163), en su forma completa y corta, se reescriba con el servidor vigente antes que el resto. Es la plantilla que el lector imita.
2. Que el barrido de C5 cubra «agente», «workflow», «flujo de trabajo», «estimando» e «IC95» después de aplicar REC-19, REC-30 y REC-32.
3. Que cada cifra importada del insumo lleve el rótulo «una entrada, N semillas: describe este pedido, no la tarea» la primera vez en la sección, siguiendo el patrón completo/corto de §0.4.
