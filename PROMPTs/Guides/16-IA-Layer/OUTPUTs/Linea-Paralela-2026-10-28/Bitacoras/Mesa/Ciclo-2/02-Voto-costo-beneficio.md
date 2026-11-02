# 02 · Voto del juez de costo-beneficio (ciclo 2)

Fecha: 2026-10-28. Rol: juez de costo-beneficio. Función fija: ¿el beneficio justifica el costo? Objeto votado: `01-Consolidado.md` (67 ítems).

## Criterio con el que voto

1. **Una frase falsa se corrige siempre**: es barato y protege la evidencia. Esto vale para una cita que no coincide, una cifra mal atribuida, una doble negación o un diagrama con la flecha al revés.
2. **Texto antes que código.** El código se toca sólo cuando cumple las dos condiciones: el defecto engaña al lector que corre el ejemplo (un verde falso, un filtro que corre 0 pruebas, archivos que quedan con dueño root, el host filtrado) **y** el cambio se verifica con `Cableado/` sin pasar por el modelo. Un cambio que modifica el prompt o la composición de la demo invalida cifras medidas y obliga a repetir corridas R-LLM, así que en esos casos voto declarar la deuda.
3. **Presupuesto.** La guía tiene 60 629 palabras frente a 40 200 (compuertas, §3.11, punto 1). Lo verifiqué con `wc` el 2026-10-28 y da lo mismo. No agrego tablas ni párrafos que no corrijan algo falso o que no cubran un hueco de requisito. Voto las compresiones que no quitan evidencia, con la regla de C2-09 A.
4. **Mecánico frente a cosmético.** Cambiar el formato en muchos lugares (13 README, la forma de las citas, ubicaciones de snippets) se aprueba sólo si se hace con un script y no cambia lo que el lector hace.

Lo verifiqué en la guía:
- §8.10.1 tiene la doble negación («no propuso una baja en 0/10»).
- El mermaid de §5.3 dibuja `Application → Infrastructure/AI`.
- §6.1, §8.1.6 y REF-046 citan «no mitiga».
- E.2 (l.3991) afirma «escucha en loopback».

## Votos

| Ítem | Opción | Fundamento (costo frente a beneficio) |
|---|---|---|
| C2-01 | A | Es un reemplazo mecánico de unos 15 nombres y no agrega palabras. Saca la reducción engañosa de ESC-04 a «aprobación». |
| C2-02 | A | El rótulo y la marca **Criterio:** se ponen con un script. Cumple una regla del PO (preguntas que forman criterio). Al aplicarlo se conservan los `####` de §4.9 para no romper anclas, que es la parte barata de C. |
| C2-03 | A | Son cinco líneas y lo exigen RV-04 y §3.10. Evita leer como universal lo que vale sólo para CTX-LOCAL. |
| C2-04 | A | Con un script y verificación de enlaces el riesgo de anclas se controla, y el plan obliga a respetar el molde. Condición: aplicarlo al final y con 0 enlaces rotos después. Si el script no lo garantiza, se renumera sólo §7. |
| C2-05 | C | La tabla de 24 filas no compensa con el presupuesto excedido. La tabla reducida más «fuera del alcance» cumple REED-16 §7.1 a un costo mínimo. |
| C2-06 | C | §0.6 cubre PG-1 y PG-6. La pregunta del Anexo F obliga a sumar una REF nueva (Nygard) para poco beneficio. |
| C2-07 | A | Es un párrafo y un enlace. La imagen de C muestra una propuesta sin confirmar, y explicarla cuesta más que lo que aporta. |
| C2-08 | A | Hay una atribución falsa (cifras del modelo de humo presentadas como del 4b) y un «3 de 3» que no existió. Corregirlo cuesta pocas palabras y salva la evidencia. |
| C2-09 | A | La compresión vale mientras no borre la atribución. La regla general (no quitar la única oración que nombra el modelo, la estación, el estimando o la prueba) protege todas las compresiones que siguen. |
| C2-10 | A | Corrige una frase y alinea con E.4 como fuente única. C obliga a ampliar E.4 para nada. |
| C2-11 | A | Usa la fuente única (E.4) y la aritmética queda correcta. C conserva una cifra que no está en E.4. |
| C2-12 | A | Son dos textos y una fila de E.4. Deja trazable la cifra de la que dependen otras (C2-38). |
| C2-14 | C | Las URL rotas y las versiones son evidencia, y hay que corregirlas. Unificar la columna y la forma de las citas en todo el cuerpo es cosmético, con muchas ediciones y riesgo de errores. |
| C2-15 | C | Es S4. Saca la remisión falsa sin agregar texto. |
| C2-16 | C | Un filtro que corre 0 pruebas con salida 0 es una trampa silenciosa. `[Category("Cableado")]` cuesta compilar y correr sin modelo, deja verdadera la frase de §8.4.2 y ahorra la lista de filtros de A. |
| C2-17 | A | Afecta a todo lector en Linux. Ya se midió (23/23 y 0 archivos de root) y el cambio de los comandos es mecánico. |
| C2-18 | A | Es seguridad en un repo público y hoy la guía afirma algo falso sobre `Warning`. Redactar el helper es poco código y se verifica sin modelo. Con C la frase nueva quedaría falsa. |
| C2-19 | A | La regla en texto alcanza. Clasificarlo en código (C) agrega trabajo y no cambia la lectura. |
| C2-20 | C | Unificar en código obliga a recompilar los ConModelo y desalinea las rutas de la evidencia ya registrada. La lista en E.5 resuelve la reproducibilidad con una oración. |
| C2-21 | A | Mover una línea y completar el README es trivial, y la consola desordenada confunde a quien corre el ejemplo. |
| C2-22 | A | Ahorra palabras y corrige la unidad (GiB). §0.5 ya declara las formas abreviadas. |
| C2-23 | A | Es una cifra. |
| C2-24 | A | Una definición que el resto de la guía no usa es S2, y la aclaración es una oración. |
| C2-25 | A | El árbol es una herramienta que el lector usa, y si deriva mal su propio ejemplo canónico pierde credibilidad. Arreglarlo cuesta tocar un mermaid. |
| C2-26 | C | Las filas del glosario resuelven las definiciones que faltan sin sumar prosa en §0.5. |
| C2-27 | A | Es una línea. |
| C2-28 | A | Medir con el método correcto es la base de toda compresión, y un exceso del 50 % le cuesta tiempo real al lector. Va sujeto a la regla de C2-09 A. |
| C2-29 | A | Ahorra unas 210 palabras sin perder evidencia (se conservan el commit y la ruta). |
| C2-30 | A | Ahorra unas 420 palabras y deja la respuesta como criterio, que es lo que pide el PO. Las cifras siguen a una remisión de distancia. |
| C2-31 | C | Con N = 1 por celda no se sostiene una sección nueva de «lo que vio el laboratorio», que además obliga a verificar nombres en Quality 10.11.0. Rotular el costo como sonda aparte corrige lo falso a costo mínimo. |
| C2-32 | C | Un verde que no mide es falso y hay que cortarlo. Cambiar la aserción es barato. A obliga a hacer corridas contra el modelo con el juez configurado, un costo alto para una prueba demostrativa. |
| C2-33 | A | Borrar una línea elimina el fallo por azar. Sumar «Existencia» como cuarto tipo hace coherente el texto con el código que se queda, y es más barato que reescribir aserciones (C). |
| C2-34 | A | El «difiere» de §9.7 contradice «con N = 10 no se puede». Dejarlo cuesta credibilidad estadística, y la nota de Fisher es una oración. |
| C2-35 | A | La tabla muestra una contradicción aparente (10/12 frente a 10/12 con discordantes «2 y 1»). El encabezado y la nota cuestan poco. |
| C2-36 | A | Son frases cortas y evitan comparar estimandos que dependen de m entre secciones. Las dos cotas son una oración. |
| C2-37 | A | Borrar elimina el error y ahorra palabras, y §4.5 ya cumple el requisito de mermaid. |
| C2-38 | C | Corrige las frases falsas sin arrastrar la cifra de 50 s/1000 tokens, que depende de C2-12 y obligaría a recalcular. |
| C2-39 | C | La invariante de 0 escrituras sin clic se cumple. Cambiar el Razor con una prueba nueva es poco frente a lo que aporta, y declarar la marca como deuda en §8.3.2 deja la limitación a la vista. |
| C2-40 | A | Es sólo texto. Corrige el árbol, que manda a MAF un caso que la demo resuelve sin MAF, y saca una fuente anterior al GA. |
| C2-41 | A | Es texto y comandos, ya medido (CAT-OP-04). `-p 127.0.0.1:` no cuesta nada. D (AllowedHosts en código) no hace falta para un laboratorio declarado. |
| C2-42 | A | La frase actual es falsa, y corregirla cuesta dos oraciones. |
| C2-43 | A | El texto se corrige con la fuente del paquete. Afirmar mal una API es un costo alto para el lector. |
| C2-44 | A | La frase dice lo contrario de lo medido. |
| C2-45 | C | El lote sin EDICIO-15. Editar los 13 README cuesta y no cambia lo que el lector hace. El resto son correcciones de una línea. |
| C2-46 | A | Nombra el criterio previo y el posterior. A un costo igual al de C, deja la honestidad metodológica explícita. |
| C2-47 | C | Mover la lista al mensaje del usuario cambia el prompt de la composición y deja sin validez la medición de §8.10.1. Habría que repetir la corrida R-LLM. Declararlo deuda en CTRL-14 es honesto y barato. |
| C2-48 | A | Es una cita entre comillas que no coincide con la fuente. |
| C2-49 | A | Es una atribución falsa y el grep da 0. |
| C2-50 | A | El error conceptual (Scoped = pedido) se le contagia al lector. El párrafo y una REF con fecha cumplen la regla de evidencia verificable a un costo bajo. |
| C2-51 | C | En el laboratorio el endpoint no cambia. Nombrar el límite cuesta una oración. El código obliga a recompilar dos proyectos. |
| C2-52 | D | Mover las herramientas en la demo obliga a reverificar CTRL-06 y las capas, que es caro. Declarar la deuda en texto es honesto, y la línea en el README de 13 sobre `Catalogo()` cuesta casi nada. |
| C2-53 | C | Con una oración el límite queda a la vista. Cambiar el motor no cambia nada de lo que la demo verifica hoy. |
| C2-54 | C | Se corrige el diagrama sin mover código. |
| C2-55 | A | Es una oración. Mover el archivo toca tres rutas de snippets. |
| C2-56 | A | Es un párrafo que cubre un hueco real, porque dos artefactos orquestan en capas distintas. |
| C2-57 | A | Acotar a lo medido cuesta media oración. |
| C2-58 | A | Es una oración. Las corridas de C cuestan tiempo de modelo para una elección que ya se declara provisional. |
| C2-59 | C | Una prueba nueva con m = 10 cuesta tiempo de modelo para un S3. La oración pone 8/8 en su lugar (existencia). |
| C2-60 | A | Contar en lugar de exigir posiciones es poco código, se verifica sin modelo y saca la fragilidad. La compuerta con TaskCompletionSource (C) es más de lo necesario. |
| C2-61 | A | Declarar la excepción es una oración. Moverla rompe las pruebas. |
| C2-62 | A | Es un párrafo corto con una lección operativa real: el timeout corre por llamada y la cola suma espera. |
| C2-63 | B | Son S4 de estilo en ejemplos que funcionan. Hasta la variante en texto agrega un párrafo y una REF sin cambiar lo que hace el lector. |
| C2-64 | A | Completar los campos es barato y hace consultable el Anexo F. |
| C2-65 | C | El `sed` y los asteriscos son mecánicos. Mover ubicaciones es caro y no aporta. |
| C2-66 | A | Ahorra unas 380 palabras de información que ya está en §0.4, §0.5 y D.2. |
| C2-67 | C | Ahorra la mayor parte sin chocar con la edición de E.5, regla 3, que pide C2-36 A. |
| C2-68 | C | La voz impersonal en el cuerpo es un cambio acotado. El voseo en las preguntas guía es deliberado, y cambiarlo cuesta mucho y no gana nada. |

## Sin veto

No veto ningún ítem. Ningún voto de la mesa me parece un costo injustificable que no pueda corregirse en la aprobación.
